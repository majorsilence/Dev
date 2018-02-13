---
layout: post
title: Crystal Reports, Ikvm, mono, and Ubuntu
created: 1415844950
redirect_from:
  - /crystal_reports_ikvm_mono_and_ubuntu/
---
How to generate pdf using c# (mono) on ubuntu linux 14.04.

See https://github.com/majorsilence/IkvmCrystalReports for a git repo with scripts that complete all the below steps.

This is incomplete and ends up with a runtime error.


* Download crystal reports runtime libraries for java at http://www.businessobjects.com/campaigns/forms/downloads/crystal/eclipse/datasave.asp or http://scn.sap.com/docs/DOC-29757
* Download [IKVM](http://www.ikvm.net/uses.html)
* Example of the crystal reports api to produce a pdf http://www.javathinking.com/2011/09/using-crystal-reports-java-api-to.html
* See http://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports+Java++SDK+Samples for examples of pushing data to crystal reports from java.  See the Database section.
* If connecting to microsoft sql server you will also need [com.microsoft.sqlserver.jdbc.SQLServerDriver](http://msdn.microsoft.com/en-us/sqlserver/aa937724.aspx)
* May also need to use apache derby http://db.apache.org/derby/releases/release-10.11.1.1.cgi


Run a script similar to the following to convert crystal reports java jars to .net.

```bash
    "C:\Path\to\ikvm-7.2.4630.5\bin\ikvmc.exe" \
    -target:library commons-collections-3.1.jar commons-configuration-1.2.jar \
    derby.jar derbyclient.jar CrystalCommon2.jar commons-lang-2.1.jar commons-logging.jar \
    com.azalea.ufl.barcode.1.0.jar cvom.jar DatabaseConnectors.jar icu4j.jar jai_imageio.jar \
    JDBInterface.jar jrcerom.jar keycodeDecoder.jar log4j.jar logging.jar pfjgraphics.jar \
    QueryBuilder.jar XMLConnector.jar xpp3.jar CrystalReportsRuntime.jar -out:crystal.dll
```

Create a .net project.  Reference IKVM.Runtime.dll, IKVM.OpenJDK.Core.dll, IKVM.OpenJDK.Jdbc.dll, IKVM.OpenJDK.XML.API.dll, IKVM.OpenJDK.XML.Bind.dll, IKVM.OpenJDK.Crypto.dll, IKVM.OpenJDK.XML.Parse.dll, IKVM.OpenJDK.XML.Transform.dll, IKVM.OpenJDK.XML.XPath.dll and crystal.dll.

Next write a function similar to the one below to generate a pdf report and export to a byte array.

```c#

    private static byte[] GetReportSimpleAsBytes()
    {
        // see the java_crj12_web_resultset_datasource.jsp exmpale

        java.sql.Connection cn;
        java.sql.PreparedStatement statement;
        java.sql.ResultSet resultset;
        java.io.ByteArrayInputStream inputStream;
        java.io.ByteArrayOutputStream outputStream = new java.io.ByteArrayOutputStream(); 
        byte[] byteArray;
        int bytesRead;


        var rpt = new com.crystaldecisions.sdk.occa.report.application.ReportClientDocument();
        rpt.setReportAppServer(
            com.crystaldecisions.sdk.occa.report.application.ReportClientDocument.inprocConnectionString);
        rpt.open("thereport.rpt",
            com.crystaldecisions.sdk.occa.report.application.OpenReportOptions._openAsReadOnly);
        var reportSource = rpt.getReportSource();
       
        inputStream = (java.io.ByteArrayInputStream)rpt.getPrintOutputController().export(
            com.crystaldecisions.sdk.occa.report.exportoptions.ReportExportFormat.PDF);


        byteArray = new byte[ 1024];
        while((bytesRead = inputStream.read(byteArray)) != -1) {
            outputStream.write(byteArray, 0, bytesRead);	

        }

        rpt.close();

        return outputStream.toByteArray();
    }


    public byte[] GetReportAsBytes()
    {
        // see the java_crj12_web_resultset_datasource.jsp exmpale

        java.sql.Connection cn;
        java.sql.PreparedStatement statement;
        java.sql.ResultSet resultset;
        java.io.ByteArrayInputStream inputStream;
        byte[] byteArray;
        int bytesRead;


        var rpt = new com.crystaldecisions.sdk.occa.report.application.ReportClientDocument();
        rpt.setReportAppServer(
            com.crystaldecisions.sdk.occa.report.application.ReportClientDocument.inprocConnectionString);
        rpt.open("thereport.rpt",
            com.crystaldecisions.sdk.occa.report.application.OpenReportOptions._openAsReadOnly);

        java.lang.Class.forName("com.microsoft.jdbc.sqlserver.SQLServerDriver");
        // See http://msdn.microsoft.com/en-us/sqlserver/aa937724.aspx
        //java.sql.DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
        cn = java.sql.DriverManager.getConnection(
            "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        statement = cn.prepareStatement("EXEC sp_name ?, ? ");
        statement.setString(1, "parameter 1");
        statement.setString(2, "parameter 2");
        resultset = statement.executeQuery();

        rpt.getDatabaseController().setDataSource(resultset, "TableName", "TableName");
        inputStream = (java.io.ByteArrayInputStream)rpt.getPrintOutputController()
            .export(com.crystaldecisions.sdk.occa.report.exportoptions.ReportExportFormat.PDF);


        rpt.close();

        return (byte[])inputStream;
    }

```

Next get a runtime error.  Now what?
