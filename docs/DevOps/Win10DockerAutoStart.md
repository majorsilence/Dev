---
layout: base
title: Auto start docker on Windows 10
---

Auto start "Docker for Windows.exe" on windows 10.  So clients can connect without having logged into windows first.

Download NSSM from https://nssm.cc/

install nssm with chocolatey
```powershell
choco install nssm
```

Configure the above executables.  Add nssm folder to path.

### Uninstall a service

```powershell
nssm remove docker_for_windows_gui
```

### Install a service

```powershell
nssm install docker_for_windows_gui "C:\Program Files\Docker\Docker\Docker for Windows.exe"
net start docker_for_windows_gui 
```

Next open services.msc, find the service and add the login credentials, and restart service.
