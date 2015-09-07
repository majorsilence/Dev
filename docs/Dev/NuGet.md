---
layout: base
title: NuGet
---

# Using NuGet
Generally using nuget is very simple.  Using visual studio/xamarin studio/monodevelop right click your solution or project and select "Add Nuget Package".  Find your package and add it.  It is auto added.  Any time you now clone your project on a new computer the first time you build your project it will restore your nuget references.

# Create a NuGet Package
write me

# Add NuGet source

The following command will add a nuget source to your computer other than the default.  This is good for self hosted nuget servers.

```powershell
NuGet.exe sources add -Name "Your Source Name" -Source "http://your.source.url"
```



# Check if NuGet Source already Exists
The following powershell script will check if a nuget source already exists on your computer. 

```
nuget sources list | Select-String -Quiet "Your Source Name"
```