---
layout: post
title: Register a Windows Service
date: 2025-07-11
last_modified: 2025-07-11
comments: true
enable_syntax_highlighting: true
---

Use [nssm](https://nssm.cc/) or powershell to register a windows service application.

## Registering a Windows Service with PowerShell and SC.exe

Example using powershell and sc to register a new windows service.

```powershell
$serviceName = "PLACEHOLDER"
$exePath = "C:\Path\To\[PLACEHOLDER].exe"
$displayName = "PLACEHOLDER"
$description = "A service for PLACEHOLDER"

New-Service -Name $serviceName -BinaryPathName $exePath -DisplayName $displayName -Description $description -StartupType Automatic

# Set the service to restart on failure
sc.exe failure $serviceName reset= 0 actions= restart/60000/restart/60000/restart/60000

# Verify service configuration
Get-Service -Name $serviceName
sc.exe qc $serviceName
sc.exe qfailure $serviceName
```

## Example C# Console Application for Windows Service

Below is a minimal C# console application that can be registered as a Windows Service. Make sure to add a reference to `System.ServiceProcess`.

```csharp
using System;
using System.ServiceProcess;
using System.Threading;

public class SampleService : ServiceBase
{
    private Thread workerThread;

    public SampleService()
    {
        this.ServiceName = "SampleService";
    }

    protected override void OnStart(string[] args)
    {
        workerThread = new Thread(DoWork);
        workerThread.Start();
    }

    protected override void OnStop()
    {
        workerThread?.Abort();
    }

    private void DoWork()
    {
        while (true)
        {
            // Service logic here
            Thread.Sleep(10000);
        }
    }

    public static void Main()
    {
        ServiceBase.Run(new SampleService());
    }
}
```

> **Note:** To debug or run as a console app, you can add a conditional block in `Main` to run as a console when not installed as a service.