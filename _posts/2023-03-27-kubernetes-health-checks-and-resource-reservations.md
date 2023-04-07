---
layout: post
title: Kubernetes Health Checks and Resource Reservations
date: 2023-03-27
last_modified: 2023-03-29
---

Set kubectl path

```bash
# Set the path to kubectl
# Example path if using microk8s "/snap/bin/microk8s kubectl"
k="/usr/bin/kubectl"
```

## Set Rolling Update Strategy maxUnavailable - Patch

Set the rolling update strategy to have a maxUnavailable to avoid outages.

```bash
echo "https://kubernetes.io/docs/concepts/workloads/controllers/deployment/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"strategy\":{\"rollingUpdate\":{\"maxSurge\": 0, \"maxUnavailable\": \"25%\"}, \"type\": \"RollingUpdate\"}}}"
```

## Health Checks - Patch

Health checks are important to managing a cluster.   They are used to determine if pods are online and healthy or offline and needs disposal and new pods spun up.

### startup probe

Has the pod started?

```bash
echo "https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
STARTUPPROBE="/healthz"
PORT="443"
SCHEME="HTTPS"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"startupProbe\":{\"httpGet\": {\"path\":\"$STARTUPPROBE\", \"port\": $PORT, \"scheme\": \"$SCHEME\"}, \"failureThreshold\": 30, \"periodSeconds\": 10}}]}}}}"
```

### livenessProbe

Is the pod alive.

```bash
echo "https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
LIVEPROBE="/healthz/live"
PORT="443"
SCHEME="HTTPS"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"livenessProbe\":{\"httpGet\": {\"path\":\"$LIVEPROBE\", \"port\": $PORT, \"scheme\": \"$SCHEME\"}, \"initialDelaySeconds\": 30, \"failureThreshold\": 3, \"timeoutSeconds\": 5}}]}}}}"
```

### readinessProbe

Is the pod alive and ready to serve traffic.

```bash
echo "https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
READYPROBE="/healthz/ready"
PORT="443"
SCHEME="HTTPS"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"readinessProbe\":{\"httpGet\": {\"path\":\"$READYPROBE\", \"port\": $PORT, \"scheme\": \"$SCHEME\"}, \"initialDelaySeconds\": 30, \"failureThreshold\": 30, \"timeoutSeconds\": 15}}]}}}}"
```

## Change Image Name/Version - Patch

Upgrade or downgrade images.

```bash
echo "https://kubernetes.io/docs/reference/kubectl/cheatsheet/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
IMAGE_NAME="PLACEHOLDER"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"image\":\"$IMAGE_NAME\"}]}}}}"
```

## Reserve Memory and RAM Resources - Patch

Request a set reservation of memory and cpu.  This helps kubernetes properly schedule pods across clusters.

```bash
echo "https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
RAM="128Mi"
CPU="500m"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"resources\":{\"requests\": {\"memory\":\"$RAM\", \"cpu\": \"$CPU\"}}}]}}}}"
```

## Limit Memory and RAM Resources - Patch

Set a limit on memory and cpu.

```bash
echo "https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/"
NAMESPACE="PLACEHOLDER"
DEPLOYMENT_NAME="PLACEHOLDER"
RAM="2048Mi"
CPU="2500m"

$k -n $NAMESPACE patch deployment $DEPLOYMENT_NAME -p "{\"spec\":{\"template\":{\"spec\":{\"containers\":[{\"name\":\"$DEPLOYMENT_NAME\",\"resources\":{\"limits\": {\"memory\":\"$RAM\", \"cpu\": \"$CPU\"}}}]}}}}"
```

## References

- [k8s management scripts](https://github.com/TownSuite/k8s-management/tree/main)
- [Resource Management for Pods and Containers](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)
- [kubectl Cheat Sheet](https://kubernetes.io/docs/reference/kubectl/cheatsheet/)
- [Deployments](https://kubernetes.io/docs/concepts/workloads/controllers/deployment/)
