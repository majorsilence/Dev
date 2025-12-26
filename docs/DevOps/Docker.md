---
layout: base
title: Docker
date: 2017-10-17
last_modified: 2025-12-26
---

Create and publish new docker images. This example creates a new image that has the dotnet 10 sdk installed.

File "VERSION"
```txt
1.0.0
```

File "Dockerfile"
```dockerfile
FROM ubuntu:24.04

MAINTAINER Your name <your email address>
ADD VERSION .

RUN apt-get update \
	&& echo "start install" \
	&& apt install -y dotnet-sdk-10.0 \
	&& rm -rf /var/lib/apt/lists/* /tmp/*
```

# build image

```bash
# for a clean build first run the following commands
#docker rm $(docker ps -a -q)
#docker rmi $(docker images -aq)

docker buildx build --progress plain --no-cache --provenance=true --sbom=true -f Dockerfile -t your_docker_hub_account/imageName:latest --rm=true .
```

# publish container

```bash
version=`cat VERSION`
echo "version: $version"

docker tag your_docker_hub_account/imageName:latest your_docker_hub_account/imageName:$version

docker push your_docker_hub_account/imageName:latest
docker push your_docker_hub_account/imageName:$version
```


# Run the docker container
Run the built image in a few common ways.

```bash
# run an interactive shell in the image (remove container when exit)
docker run --rm -it your_docker_hub_account/imageName:latest /bin/bash

# run detached, map host port 8080 to container port 80 and name the container
docker run -d --name mycontainer -p 8080:80 your_docker_hub_account/imageName:latest

# run a specific version tag (read VERSION into shell variable first)
version=$(cat VERSION)
docker run --rm -it your_docker_hub_account/imageName:$version /bin/bash

# run with a host volume mounted at /app/data inside the container
docker run --rm -it -v "$(pwd)/data:/app/data" your_docker_hub_account/imageName:latest /bin/bash
```

