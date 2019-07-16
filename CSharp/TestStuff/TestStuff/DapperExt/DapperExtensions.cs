using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dapper;

namespace MajorSilence.DapperExt
{
    public static class DapperExtensions
    {

        /// <summary>
        /// Extension method for use with SQLConnection to auto generate an upsert from a poco.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="setParam">the set portion</param>
        /// <param name="whereParam">the where clause</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        // [DebuggerStepThrough]
        public static int UpSert<T>(this SqlConnection connection, object setParam, object whereParam,
           IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var sql = UpSertSqlGeneration<T>(setParam, whereParam);
            var param = Merge(setParam, whereParam);

            return connection.Execute(sql.ToString(), param, transaction, commandTimeout: commandTimeout);
        }

        public static string UpSertSqlGeneration<T>(object setParam, object whereParam)
        {
            var type = typeof(T);
            var setNames = new List<string>();
            var whereNames = new List<string>();
            ParameterNameList(setParam, setNames);
            ParameterNameList(whereParam, whereNames);


            var tableName = GetTableName(type);

            var sql = new StringBuilder();

            sql.AppendLine("MERGE INTO ");
            sql.AppendLine(tableName);
            sql.AppendLine("AS tgt ");
            sql.AppendLine("USING");
            sql.Append("(SELECT ");
            bool setComma = false;
            var sbJoin = new StringBuilder();
            sbJoin.Append("ON ");
            foreach (var name in whereNames)
            {
                if (setComma)
                {
                    sql.Append(", ");
                    sbJoin.Append(" AND ");
                }

                // SELECT
                sql.Append("@");
                sql.Append(name);
                sql.Append("_1 ");
                sql.Append(name);
                // END SELECT

                // JOIN
                sbJoin.Append("tgt.");
                sbJoin.Append(name);
                sbJoin.Append("=src.");
                sbJoin.Append(name);
                // END JOIN

                setComma = true;
            }
            sql.AppendLine(") AS src ");
            sql.AppendLine(sbJoin.ToString());


            sql.AppendLine("WHEN MATCHED THEN");

            sql.Append("UPDATE ");
            sql.Append("SET ");

            bool setComma2 = false;
            foreach (var name in setNames)
            {
                if (setComma2)
                {
                    sql.Append(", ");
                }

                // SELECT
                sql.Append("[" + name + "]");
                sql.Append("=@");
                sql.Append(name);
                sql.Append("_2");
                setComma2 = true;
            }
            sql.AppendLine();
            sql.AppendLine("WHEN NOT MATCHED THEN ");
            sql.AppendLine("INSERT (");

            bool setComma3 = false;
            var sbInsertValues = new StringBuilder();
            sbInsertValues.AppendLine(") VALUES (");
            foreach (var name in setNames)
            {
                if (setComma3)
                {
                    sql.Append(", ");
                    sbInsertValues.Append(", ");
                }

                // SELECT
                sql.Append("[" + name + "]");

                sbInsertValues.Append("@");
                sbInsertValues.Append(name);
                sbInsertValues.Append("_2");

                setComma3 = true;
            }
            sql.AppendLine(sbInsertValues.ToString());
            sql.Append(");");
            return sql.ToString();
        }

        public static object Merge(object item1, object item2)
        {
            if (item1 == null || item2 == null)
                return item1 ?? item2 ?? new System.Dynamic.ExpandoObject();

            dynamic expando = new System.Dynamic.ExpandoObject();
            var result = expando as IDictionary<string, object>;
            foreach (System.Reflection.PropertyInfo fi in item1.GetType().GetProperties())
            {
                result[fi.Name + "_2"] = fi.GetValue(item1, null);
            }
            foreach (System.Reflection.PropertyInfo fi in item2.GetType().GetProperties())
            {
                result[fi.Name + "_1"] = fi.GetValue(item2, null);
            }
            return result;
        }

        private static void ParameterNameList(object setParam, List<string> setNames)
        {
            if (setParam.GetType() == typeof(DynamicParameters))
            {
                var p = (DynamicParameters)setParam;
                foreach (var item in p.ParameterNames)
                {
                    setNames.Add(item);
                }
            }
            else
            {
                var props = setParam.GetType().GetProperties();
                if (!props.Any())
                {
                    throw new DataException("UpSert<T> must have set and where param");
                }

                foreach (var prop in props)
                {
                    setNames.Add(prop.Name);
                }
            }
        }

        [DebuggerStepThrough]
        private static string GetTableName(Type type)
        {
            string name;

            //NOTE: handle both dapper.contrib as well as the table attribute in EntityFramework 
            var tableAttr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic;
            if (tableAttr != null)
                name = tableAttr.Name;
            else
            {
                name = type.Name + "s";
                if (type.IsInterface && name.StartsWith("I"))
                    name = name.Substring(1);
            }

            return name;
        }
    }

    [Dapper.Contrib.Extensions.Table("GroupInfo")]
    class GroupInfo
    {
        [Dapper.Contrib.Extensions.ExplicitKey()]
        public int Id { get; set; }
        [Dapper.Contrib.Extensions.ExplicitKey()]
        public int Id2 { get; set; }
        public string App { get; set; }
        public bool DB { get; set; }
    }
}
