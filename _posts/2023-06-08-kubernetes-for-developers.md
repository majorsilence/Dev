---
layout: post
title: Kubernetes (k8s) for developers 
date: 2023-06-08
last_modified: 2023-06-08
comments: true
---

# Create oci images/containers

Use podman or docker.

examplescript.sh

```bash
#!/bin/bash
while true
do
	echo "Press [CTRL+C] to stop.."
	sleep 1
done
```

Make the script executable.

```bash
chmod +x ./examplescript.sh
```

Dockerfile.  The filename must be "Dockerfile" or when calling docker build -f must be used to pass in the filename.
```Dockerfile
FROM ubuntu:22.04
ADD examplescript.sh /
RUN apt update && apt install bash -y
CMD [ "./examplescript.sh" ]
```

build the image
```bash
sudo docker build -t exampleapp .
```

Verify the image was built.

```bash
sudo docker build -t exampleapp .
sudo docker images
sudo docker run localhost/exampleapp
```

# create pods and deployments

## create a pod yaml

Create the yaml for a pod running a nginx container.

```bash
kubectl run nginx --image=nginx --dry-run=client -o yaml > example-pod.yaml
```

## create a deployment yaml

Create the yaml for a deployment with a pod running an nginx container.
```bash
kubectl create deployment --image=nginx nginx --dry-run=client -o yaml > example-deployment.yaml
```

## create a nodeport service yaml

Use a nodeport service to expose an applications via port.
Note: --tcp=<port>:<targetPort>

```bash
kubectl create service nodeport ns-service --tcp=80:80 --dry-run=client -o yaml > example-nodeport-service.yaml
```


