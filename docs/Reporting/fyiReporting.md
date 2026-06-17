---
layout: base
title: fyi, majorsilence Reporting
last_modified: 2026-06-06
---

Majorsilence Reporting (formerly fyiReporting / My-FyiReporting) is an open-source .NET library for generating reports in PDF and other formats. It supports dynamic report creation using RDL (Report Definition Language) and can connect to various data sources, including SQL databases and JSON. The library is suitable for developers who need to automate report generation in their applications, offering flexibility and ease of integration.

See [Majorsilence Reporting Wiki](https://github.com/majorsilence/My-FyiReporting/wiki) for more examples and documentation.

---

## Version 4 (fyiReporting / Majorsilence Reporting v4 — Legacy)

Version 4 targets .NET Framework 4.x (net48) and uses a synchronous API. The project was formerly known as fyiReporting and My-FyiReporting. The v4 source is on the [v4 branch](https://github.com/majorsilence/My-FyiReporting/tree/v4).

### NuGet packages (v4)

```xml
<PackageReference Include="Majorsilence.Reporting.RdlEngine" />
<PackageReference Include="Majorsilence.Reporting.RdlCri" />

<!-- WinForms viewer -->
<PackageReference Include="Majorsilence.Reporting.RdlViewer" />

<!-- ASP.NET control (net48 only) -->
<PackageReference Include="Majorsilence.Reporting.RdlAsp" />
```

### c# example — load and export to PDF (v4 sync API)

```cs
var reportSource = System.IO.File.ReadAllText(sourcefile.AbsolutePath);
var rdlp = new RDLParser(reportSource);
var rpt = rdlp.Parse();
rpt.RunGetData(null);
var sg = new Majorsilence.Reporting.Rdl.OneFileStreamGen(savePath, true);
rpt.RunRender(sg, OutputPresentationType.PDF);
```

### c# example — WinForms viewer with DataTable (v4 sync API)

```cs
var dt = new System.Data.DataTable();
var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "report.rdl");
rdlViewer1.SourceFile = new Uri(filepath);
rdlViewer1.Report.DataSets["Data"].SetData(dt);
rdlViewer1.Rebuild();
```

---

## Version 5 (Majorsilence Reporting v5 — Modern)

Version 5 targets .NET 8.0 and newer. It introduces a fully async API, cross-platform support (Linux, macOS, Windows), and SkiaSharp as the rendering backend for server-side use. The root namespace was renamed from `fyiReporting` to `Majorsilence.Reporting`.

See the [v5 migration guide](https://github.com/majorsilence/My-FyiReporting/wiki/Majorsilence-Reporting-v5:-Migration,-Breaking-Changes-&-Packaging) for upgrading from v4.

**The core engine supports Linux and macOS for server-side report generation. The WinForms-based designer and viewer are Windows-only.**

### NuGet packages (v5)

Linux/macOS — SkiaSharp backend (recommended for cross-platform/containerized hosts):

```xml
<PackageReference Include="Majorsilence.Reporting.RdlCreator.SkiaSharp" />
<PackageReference Include="Majorsilence.Reporting.RdlEngine.SkiaSharp" />
<PackageReference Include="Majorsilence.Reporting.RdlCri.SkiaSharp" />
```

Windows:

```xml
<PackageReference Include="Majorsilence.Reporting.RdlCreator" />
<PackageReference Include="Majorsilence.Reporting.RdlEngine" />
<PackageReference Include="Majorsilence.Reporting.RdlCri" />

<!-- WinForms viewer -->
<PackageReference Include="Majorsilence.Reporting.RdlViewer" />

<!-- WPF viewer -->
<PackageReference Include="Majorsilence.Reporting.LibRdlWpfViewer" />

<!-- WinForms designer control -->
<PackageReference Include="Majorsilence.Reporting.ReportDesigner" />
```

On Linux, install the required fonts:

```bash
sudo apt install ttf-mscorefonts-installer
```

### c# example — connected to an SQL database (v5 async)

```cs
using Majorsilence.Reporting.RdlCreator;

// One time per app instance
RdlEngineConfig.RdlEngineConfigInit();

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

### c# example — load an existing RDL file and export to PDF (v5 async)

```cs
using Majorsilence.Reporting.Rdl;

// One time per app instance
RdlEngineConfig.RdlEngineConfigInit();

var rdlp = new RDLParser(await System.IO.File.ReadAllTextAsync("path/to/report.rdl"));
var rpt = await rdlp.Parse();

string filepath = System.IO.Path.Combine(Environment.CurrentDirectory, "PLACEHOLDER.pdf");
var ofs = new Majorsilence.Reporting.Rdl.OneFileStreamGen(filepath, true);
await rpt.RunGetData(null);
await rpt.RunRender(ofs, Majorsilence.Reporting.Rdl.OutputPresentationType.PDF);
```

### c# example — create a PDF document programmatically (v5)

```cs
using Majorsilence.Reporting.RdlCreator;

var document = new Majorsilence.Reporting.RdlCreator.Document()
{
    Description = "Sample report",
    Author = "John Doe",
    PageHeight = "11in",
    PageWidth = "8.5in",
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

### c# example — WinForms viewer with DataTable (v5 async)

```cs
var dt = new System.Data.DataTable();
var rdlViewer1 = new Majorsilence.Reporting.RdlViewer.RdlViewer();
string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "report.rdl");
await rdlViewer1.SetSourceFile(new Uri(filepath));
await (await rdlViewer1.Report()).DataSets["Data"].SetData(dt);
await rdlViewer1.Rebuild();
```
