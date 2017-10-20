---
layout: base
title: Docker
---

Create and publish new docker images. This example creates a new image that has mono and powershell installed.

File "Version"
```txt
1.0.0
```

File "Dockerfile"
```dockerfile
FROM ubuntu:16.04

MAINTAINER Your name <your email address>
ADD VERSION .


RUN rm /bin/sh && ln -s /bin/bash /bin/sh

# Mono
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
	&& echo "deb http://download.mono-project.com/repo/ubuntu xenial main" > /etc/apt/sources.list.d/mono-official.list \
	&& apt-get update \
	&& echo "start install" \
	&& apt-get install -y apt-transport-https apt-utils libunwind8 libicu55 libcurl3 \
	&& apt-get install -y curl binutils ca-certificates-mono fsharp mono-complete msbuild nuget \
	&& rm -rf /var/lib/apt/lists/* /tmp/*

RUN curl -L -o powershell_6.0.0-beta.8-1.ubuntu.16.04_amd64.deb https://github.com/PowerShell/PowerShell/releases/download/v6.0.0-beta.8/powershell_6.0.0-beta.8-1.ubuntu.16.04_amd64.deb \
    && dpkg -i powershell_6.0.0-beta.8-1.ubuntu.16.04_amd64.deb \
&& rm -rf powershell_6.0.0-beta.8-1.ubuntu.16.04_amd64.deb
```

# build image

```bash
# for a clean build first run the following commands
#docker rm $(docker ps -a -q)
#docker rmi $(docker images -aq)

docker build --no-cache -f Dockerfile -t DockerHubAccount/imageName:latest --rm=true .
```

# publish container

```bash
version=`cat VERSION`
echo "version: $version"

docker tag DockerHubAccount/imageName:latest DockerHubAccount/imageName:$version

docker push DockerHubAccount/imageName:latest
docker push DockerHubAccount/imageName:$version
```


# Run the docker container