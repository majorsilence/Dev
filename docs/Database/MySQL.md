MySqlCommand, MySqlConnection, MySqlDataAdapter, MySqlTransaction, Parametrized Queries, DataTable, DataSet, Stored Procedure Calls

# Backup Database
```bash
 mysqldump -u root -pThePassword databasename > dumpfile.sql
```

# Restore from Database Dump
```bash
mysql -u root -pThePassword

mysql> create database databasename;

mysql -u root -pThePassword databasename < dumpfile.sql

```