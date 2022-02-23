---
layout: post
created: 1643584317
title: Installing YugabyteDB in a Kubernetes cluster
redirect_from:
  - /news/2022/01/30/yugabytedb-kubernetes-install.html
---


Draft notes as of Jan 30, 2022.



This post is a short walkthrough of installing a YugabyteDB demo with local storage in a Kubernetes cluster.

If your Kubernetes cluster does not already have a storage class setup jump to the __Storage Setup - Prerequisites__ section and complete it before continuing with the following commands.

```bash
kubectl create namespace yb-demo
```



# Install Yugabytedb

Notice the overrides.

```bash
helm install yb-demo yugabytedb/yugabyte --set resource.master.requests.cpu=0.5,resource.master.requests.memory=0.5Gi,resource.tserver.requests.cpu=0.5,resource.tserver.requests.memory=0.5Gi,replicas.master=1,replicas.tserver=1,storage.tserver.size=1Gi --namespace yb-demo
```



## Yugabyte k8s info

NAMESPACE: yb-demo
STATUS: deployed
REVISION: 1
TEST SUITE: None
NOTES:
1. Get YugabyteDB Pods by running this command:
  kubectl --namespace yb-demo get pods

2. Get list of YugabyteDB services that are running:
  kubectl --namespace yb-demo get services

3. Get information about the load balancer services:
  kubectl get svc --namespace yb-demo

4. Connect to one of the tablet server:
  kubectl exec --namespace yb-demo -it yb-tserver-0 bash

5. Run YSQL shell from inside of a tablet server:
  kubectl exec --namespace yb-demo -it yb-tserver-0 -- /home/yugabyte/bin/ysqlsh -h yb-tserver-0.yb-tservers.yb-demo

6. Cleanup YugabyteDB Pods
  For helm 2:
  helm delete yb-demo --purge
  For helm 3:
  helm delete yb-demo -n yb-demo
  NOTE: You need to manually delete the persistent volume
  kubectl delete pvc --namespace yb-demo -l app=yb-master
  kubectl delete pvc --namespace yb-demo -l app=yb-tserver


# Storage Setup - Prerequisites

Local hostPath storage works well with YugabyteDB.


## Local storage


```yaml
apiVersion: storage.k8s.io/v1
kind: StorageClass
metadata:
 name: standard
provisioner: kubernetes.io/no-provisioner
volumeBindingMode: WaitForFirstConsumer
```

If this new storage class is the only one configured in the cluster, mark it as the default.

```bash
kubectl patch storageclass standard -p '{"metadata": {"annotations":{"storageclass.kubernetes.io/is-default-class":"true"}}}'
```


This storage class does not support auto-provisioning of persistent volumes. Each persistent volume must be created manually before the PVC can claim it.


Persistent Volumes

The storageClassName in the PV must match the storageClassName in the PVC.

pv-example.yaml

```yaml
apiVersion: v1
metadata:
  name: pv-test-vol1
  labels:
      type: local
Spec:
  storageClassName: standard
  capacity:
      storage: 10Gi
  accessModes:
      - ReadWriteOnce
  hostPath:
      path: "/opt/storage/test_pv"
```

```bash
mkdir -p "/opt/storage/test_pv"

kubectl create -f pv.yaml
```



## OpenEBS Replicated

OpenEBS local hostpath should also work well. Jiva replicated is best left for apps that don't handle replication such as sql server or PostgreSQL.

https://github.com/openebs/jiva-operator/blob/develop/docs/quickstart.md


```bash
kubectl apply -f https://openebs.github.io/charts/openebs-operator-lite.yaml
kubectl apply -f https://openebs.github.io/charts/jiva-operator.yaml
```


Jiva volume policy

```yaml
apiVersion: openebs.io/v1alpha1
kind: JivaVolumePolicy
metadata:
  name: example-jivavolumepolicy
  namespace: openebs
spec:
  replicaSC: openebs-hostpath
  target:
    replicationFactor: 1
    # disableMonitor: false
    # auxResources:
    # tolerations:
    # resources:
    # affinity:
    # nodeSelector:
    # priorityClassName:
  # replica:
    # tolerations:
    # resources:
    # affinity:
    # nodeSelector:
    # priorityClassName:
```


Storage Class

```yaml
apiVersion: storage.k8s.io/v1
kind: StorageClass
metadata:
 name: openebs-jiva-csi-sc
provisioner: jiva.csi.openebs.io
allowVolumeExpansion: true
parameters:
 cas-type: "jiva"
 policy: "example-jivavolumepolicy"
```


Persistent Volume Claim

```yaml
kind: PersistentVolumeClaim
apiVersion: v1
metadata:
 name: example-jiva-csi-pvc
spec:
 storageClassName: openebs-jiva-csi-sc
 accessModes:
   - ReadWriteOnce
 resources:
   requests:
     storage: 4Gi
```


# Reference

* [YugabyteDB Open Source Kubernetes Helm Chart](https://docs.yugabyte.com/latest/deploy/kubernetes/single-zone/oss/helm-chart/)
* [kubernetes storage](https://majorsilence.com/news/2022/02/05/kubernetes-storage.html) post.


