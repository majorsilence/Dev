---
layout: base
title: Crystal Reports
created: 1518649489
description: C# crystal report examples
tags: c# crystal reports
---

Examples to use crystal reports from c#.

Make sure you have the crystal reports runtime installed.  It
can be downloaded from [https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports%2C+Developer+for+Visual+Studio+Downloads](https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports%2C+Developer+for+Visual+Studio+Downloads).

All examples below require references for __CrystalDecisions.CrystalReports.Engine__ and __CrystalDecisions.Shared__ to be added to your project.

```xml
<Reference Include="CrystalDecisions.CrystalReports.Engine, Version=13.0.2000.0, 
Culture=neutral, PublicKeyToken=692fbea5521e1304, processorArchitecture=MSIL" />
<Reference Include="CrystalDecisions.Shared, Version=13.0.2000.0,
 Culture=neutral, PublicKeyToken=692fbea5521e1304, processorArchitecture=MSIL" />
```

# Set data using DataTables

Example initializing a report and passing in a DataTable.

```cs
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

// Pass a DataTable to a crystal report table
public static SetData(string crystalTemplateFilePath, 
    string pdfFilename, DataSet val)
{
    using (var rpt = new ReportDocument())
    {
        rpt.Load(crystalTemplateFilePath);
   
        rpt.Database.Tables["tableName"].SetDataSource(val);
    }
}

// Pass any generic IEnumerable data to a crystal report DataTable
public static SetData(string crystalTemplateFilePath, 
    IEnumerable<T> val)
{
    using (var rpt = new ReportDocument())
    {
        rpt.Load(crystalTemplateFilePath);
   
        var dt = ConvertGenericListToDatatable(val);
        rpt.Database.Tables[tableName].SetDataSource(val);
    }
}


// Found somewhere on the internet.  I know longer remember where.
public static DataTable ConvertGenericListToDatatable<T>(IEnumerable<T> dataLst)
{
    DataTable dt = new DataTable();

    foreach (var info in dataLst.FirstOrDefault().GetType().GetProperties())
    {
        dt.Columns.Add(info.Name, info.PropertyType);
    }

    foreach (var tp in dataLst)
    {
        DataRow row = dt.NewRow();
        foreach (var info in typeof(T).GetProperties())
        {
            if (info.Name == "Item") continue;
            row[info.Name] = info.GetValue(tp, null) == null ? DBNull.Value : info.GetValue(tp, null);
        }
        dt.Rows.Add(row);
    }
    dt.AcceptChanges();
    return dt;
}
```

# Set report parameters

Set report parameters from code.

```cs
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public static void SetParameterValueName(string crystalTemplateFilePath, object val)
{
    using (var rpt = new ReportDocument())
    {
        rpt.Load(crystalTemplateFilePath);

        string name = "ParameterName";
        if (rpt.ParameterFields[name] != null)
        {
            this.MyReportDoc.SetParameterValue(name, val);
        }
    }
}
```

# Move report objects

Example moving an object.

```cs
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public static MoveObject(string crystalTemplateFilePath)
{
    using (var rpt = new ReportDocument())
    {
        rpt.Load(crystalTemplateFilePath);
   
        rpt.ReportDefinition.ReportObjects["objectName"].Left = 15;
        rpt.ReportDefinition.ReportObjects["objectName"].Top = 15;
    }
}
```



# Export to pdf or other file type

Load a report and export it to pdf.  You can pass in data or set other properties before the export.

```cs
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public static ExportPdf(string crystalTemplateFilePath, 
    string pdfFilename)
{
    using (var rpt = new ReportDocument())
    {
        rpt.Load(crystalTemplateFilePath);
   
        var exp = ExportFormatType.PortableDocFormat;
        rpt.ExportToDisk(exp, pdfFilename);
    }
}
```

