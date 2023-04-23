---
layout: post
date: 2022-01-30
last_modified: 2022-02-16
title: Installing a redis cluster in Kubernetes
comments: true
redirect_from:
  - /news/2022/01/30/redis-cluster-kubernetes-install.html
---

## Prep work

The example below will use the OpenEBS hostpath storage classes and operators.  Installing openebs is described in my [kubernetes storage](https://majorsilence.com/posts/2022/02/05/kubernetes-storage.html) post.



Determine the storageclass name.

```bash
 kubectl get storageclasses.storage.k8s.io
 ```

As I'm currently testing openebs in microk8s I will use the storage class named __openebs-hostpath__ in the below examples.  As a redis cluster handles its own data 


If there are any affinity rules that are wanted set the labels now.  This example is going to set a label on a node and set the affinity to look for that as a soft (preferredDuringSchedulingIgnoredDuringExecution) target.

```bash
kubectl label nodes [NodeName] workertype=database
```

## Install


```bash
helm repo add bitnami https://charts.bitnami.com/bitnami

kubectl create namespace redis-demo

helm install redis --set "global.redis.password=HiThere,global.storageClass=openebs-hostpath,redis.nodeAffinityPreset.type=soft,redis.nodeAffinityPreset.key=workertype,redis.nodeAffinityPreset.values[0]=database" bitnami/redis-cluster --namespace redis-demo

kubectl -n redis-demo get pods
```

If external access is desired it should be set at deployment by setting __cluster.externalAccess.enabled__ to true as part of the above --set command.

```
cluster.externalAccess.enabled=true
```

See the [redis-cluster](https://artifacthub.io/packages/helm/bitnami/redis-cluster) chart docs for externalAccess options.


### Output

With those commands run there should be some output that looks like the following.

```
NAME: redis
LAST DEPLOYED: Sat Feb  5 23:08:17 2022
NAMESPACE: redis-demo
STATUS: deployed
REVISION: 1
TEST SUITE: None
NOTES:
CHART NAME: redis-cluster
CHART VERSION: 7.2.1
APP VERSION: 6.2.6** Please be patient while the chart is being deployed **
```

To get your password run:

```bash
export REDIS_PASSWORD=$(kubectl get secret --namespace "redis-demo" redis-redis-cluster -o jsonpath="{.data.redis-password}" | base64 --decode)
```

You have deployed a Redis&trade; Cluster accessible only from within you Kubernetes Cluster.INFO: The Job to create the cluster will be created. To connect to your Redis&trade; cluster:

1. Run a Redis&trade; pod that you can use as a client:

```bash
kubectl run --namespace redis-demo redis-redis-cluster-client --rm --tty -i --restart='Never' --env REDIS_PASSWORD=$REDIS_PASSWORD --image docker.io/bitnami/redis-cluster:6.2.6-debian-10-r95 -- bash
```

2. Connect using the Redis&trade; CLI:

```bash
redis-cli -c -h redis-redis-cluster -a $REDIS_PASSWORD
```


## Remove redis cluster

```bash
helm delete redis --namespace redis-demo
kubectl delete namespace redis-demo
```


## Reference

* [bitnami redis-cluster](https://artifacthub.io/packages/helm/bitnami/redis-cluster)
* [Deploy and scale a redis cluster on kubernetes with bitnami and helm](https://engineering.bitnami.com/articles/deploy-and-scale-a-redis-cluster-on-kubernetes-with-bitnami-and-helm.html)

