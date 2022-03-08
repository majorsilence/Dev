---
layout: post
title: Mac and linux dotnet dev
date: 2022-03-08
last_modified: 2022-03-08
---

# Mac specific

If you do not have brew install it before proceeding.  See [https://brew.sh](https://brew.sh).

```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
brew install node
```

## Install visual studio for mac 2022

At the time of this writing it is in preview

https://visualstudio.microsoft.com/vs/mac/preview/


## Install docker desktop for mac
See [https://docs.docker.com/desktop/mac](https://docs.docker.com/desktop/mac) for more info.

# Ubuntu linux specific

```bash
sudo apt install -y docker.io docker-compose

sudo groupadd docker
sudo usermod -aG docker $USER
sudo chown root:docker /var/run/docker.sock
sudo chown -R root:docker /var/run/docker
# this works but the group does not?  Why?
sudo chown $USER /var/run/docker.sock
newgrp docker
```

## Rider and dotnet

On linux use [rider](https://www.jetbrains.com/rider/) as the IDE.
```bash
# see https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-runtime-6.0 aspnetcore-runtime-6.0 dotnet-sdk-6.0

snap install rider --classic
```


# Nuget

## List nuget sources

```bash
dotnet nuget list source
```

# #Start fresh with just nuget.org

```bash
dotnet new nugetconfig
```

## Add private nuget source

Add any private nuget sources that you need.  This is optional.

```
dotnet nuget add source "https://[YourPrivateRegistry]/v3/index.json" -n [Feed Name] -u YourUserName -p YourPassword --store-password-in-clear-text
```

## Restore

dotnet restore [Your Solution Name].sln







