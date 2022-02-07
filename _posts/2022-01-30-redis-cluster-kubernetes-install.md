---
layout: post
created: 1644102582
title: Installing a redis cluster in Kubernetes
---

# Draft as of Feb 5, 2022.


The example below will use the OpenEBS jiva storage classes and operators as described in my [kubernetes storage](https://majorsilence.com/news/2022/02/05/kubernetes-storage.html) post.


```bash
helm repo add bitnami https://charts.bitnami.com/bitnami

kubectl create namespace redis-demo
helm install redis --set global.redis.password=HiThere,global.storageClass=openebs-jiva-csi-sc bitnami/redis-cluster --namespace redis-demo

kubectl -n redis-demo get pods
```


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


To get your password run:
    export REDIS_PASSWORD=$(kubectl get secret --namespace "redis-demo" redis-redis-cluster -o jsonpath="{.data.redis-password}" | base64 --decode)

You have deployed a Redis&trade; Cluster accessible only from within you Kubernetes Cluster.INFO: The Job to create the cluster will be created.To connect to your Redis&trade; cluster:

1. Run a Redis&trade; pod that you can use as a client:
kubectl run --namespace redis-demo redis-redis-cluster-client --rm --tty -i --restart='Never' \
 --env REDIS_PASSWORD=$REDIS_PASSWORD \
--image docker.io/bitnami/redis-cluster:6.2.6-debian-10-r95 -- bash

2. Connect using the Redis&trade; CLI:

redis-cli -c -h redis-redis-cluster -a $REDIS_PASSWORD

```


# Remove redis cluster

```bash
helm delete redis --namespace redis-demo
```


# Reference

* [bitnami redis-cluster](https://artifacthub.io/packages/helm/bitnami/redis-cluster)
* [Deploy and scale a redis cluster on kubernetes with bitnami and helm](https://engineering.bitnami.com/articles/deploy-and-scale-a-redis-cluster-on-kubernetes-with-bitnami-and-helm.html)

