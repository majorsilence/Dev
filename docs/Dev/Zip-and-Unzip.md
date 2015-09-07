dotnetzip -  zip, unzip, self extracting zip, password protected aes encrypted zip

Use [dotnetzip](http://dotnetzip.codeplex.com/).  

Nuget package
```powershell
Install-Package DotNetZip 
```

# Unzip
``` C# 
using Ionic.Zip;

...

string zipToUnpack = "ZipToUnpack.zip";
string unpackDirectory = "TheExtractionFolder";
using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
{
    // Unzip all files
    foreach (ZipEntry e in zip1)
    {
      e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
    }
 }


```

# Zip

# Password Protected
Write me