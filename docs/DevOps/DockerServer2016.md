---
layout: base
title: Install docker on windows server 2016
---

Install docker

See https://docs.microsoft.com/en-us/virtualization/windowscontainers/quick-start/quick-start-windows-server

```powershell
Install-Module -Name DockerMsftProvider -Repository PSGallery -Force
Install-Package -Name docker -ProviderName DockerMsftProvider
Restart-Computer -Force
```

Run all computer updates

```powershell
sconfig
# pick option 6, update all
```


Test the install

```powershell
docker run microsoft/dotnet-samples:dotnetapp-nanoserver
```

To uninstall

```powershell
Uninstall-Package -Name docker -ProviderName DockerMsftProvider
Uninstall-Module -Name DockerMsftProvider
```

https://docs.microsoft.com/en-us/virtualization/windowscontainers/manage-docker/configure-docker-daemon
