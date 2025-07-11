---
layout: base
title: fyi, majorsilence Reporting
last_modified: 2025-07-11
---

Majorsilence Reporting is an open-source .NET library for generating reports in PDF and other formats. It supports dynamic report creation using RDL (Report Definition Language) and can connect to various data sources, including SQL databases and json. The library is suitable for developers who need to automate report generation in their applications, offering flexibility and ease of integration.

See [Majorsilence Reporting Wiki](https://github.com/majorsilence/My-FyiReporting/wiki) for more example and documentation.


## Quick start

nuget package

```xml
<PackageReference Include="Majorsilence.Reporting.RdlCreator.SkiaSharp" />
<PackageReference Include="Majorsilence.Reporting.RdlCri.SkiaSharp" />
```

### c# example connected to an sql database
```cs
using Majorsilence.Reporting.RdlCreator;

var create = new Majorsilence.Reporting.RdlCreator.Create();

var report = await create.GenerateRdl(dataProvider,
    connectionString,
    "SELECT CategoryID, CategoryName, Description FROM Categories",
    pageHeaderText: "DataProviderTest TestMethod1");

string filepath = System.IO.Path.Combine(Environment.CurrentDirectory, "PLACEHOLDER.pdf");
var ofs = new Majorsilence.Reporting.Rdl.OneFileStreamGen(filepath, true);
await report.RunGetData(null);
await report.RunRender(ofs, Majorsilence.Reporting.Rdl.OutputPresentationType.PDF);
```

# c# example, create a pdf document

```cs
using Majorsilence.Reporting.RdlCreator;

var document = new Majorsilence.Reporting.RdlCreator.Document()
{
    Description = "Sample report",
    Author = "John Doe",
    PageHeight = "11in",
    PageWidth = "8.5in",
    //Width = "7.5in",
    TopMargin = ".25in",
    LeftMargin = ".25in",
    RightMargin = ".25in",
    BottomMargin = ".25in"
}
.WithPage((page) =>
{
    page.WithHeight("10in")
    .WithWidth("7.5in")
    .WithText(new Text
    {
        Name = "TheSimplePageText",
        Top = ".1in",
        Left = ".1in",
        Width = "6in",
        Height = ".25in",
        Value = new Value { Text = "Text Area 1" },
        Style = new Style { FontSize = "12pt", FontWeight = "Bold" }
    });
});

using var fileStream = new FileStream("PLACEHOLDER.pdf", FileMode.Create, FileAccess.Write);
await document.Create(fileStream);
```

