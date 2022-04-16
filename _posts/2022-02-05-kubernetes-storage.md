---
layout: post
created: 1644187448
title: Kubernetes storageclass and persistent volumes
redirect_from:
  - /news/2022/02/05/kubernetes-storage.html
---



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


### Persistent Volumes

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



## OpenEBS

> Jiva is preferred if your application is small, requires storage level replication but does not need snapshots or clones. Mayastor is preferred if your application needs low latency and near disk throughput, requires storage level replication and your nodes have high CPU, RAM and NVMe capabilities. [OpenEBS Data Engines](https://docs.openebs.io/docs/next/casengines.html).


Jiva is simple to setup and run.  cStor and Mayastor are options I need to investigate more.


###  Replicated - Jiva

With OpenEBS both local hostpath and replicated are options.  Jiva replicated is best left for apps that don't handle replication such as sql server or PostgreSQL.

https://github.com/openebs/jiva-operator/blob/develop/docs/quickstart.md


### Install Jiva Operators

```bash
kubectl apply -f https://openebs.github.io/charts/openebs-operator-lite.yaml
kubectl apply -f https://openebs.github.io/charts/jiva-operator.yaml
```

#### Jiva volume policy

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


#### Storage Class

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


#### Persistent Volume Claim

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

### Local PVs

See [https://openebs.io/docs/concepts/localpv](https://openebs.io/docs/concepts/localpv).


## References

* [Provisioning openebs jiva volumes via csi](https://openebs.io/blog/provisioning-openebs-jiva-volumes-via-csi)
* [Taint and tolerations](https://kubernetes.io/docs/concepts/scheduling-eviction/taint-and-toleration/)

