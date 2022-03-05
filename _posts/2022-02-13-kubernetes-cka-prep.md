---
layout: post
title: Kubernetes CKA Prep Notes
date: 2022-02-13
last_modified: 2022-02-20
redirect_from:
  - /news/2022/02/13/kubernetes-cka-prep.html
---


This page will be a living document to help me prepare for the CKA (Certified Kubernetes Administrator) exam.   

The [CKA curriculum](https://github.com/cncf/curriculum) can be found on github.  As of 2022-02-13 it is targetting kubernetes 1.22.  It looks intense.

* [Curriculum](https://github.com/cncf/curriculum)
* [CKA_Curriculum_v1.22.pdf](https://raw.githubusercontent.com/cncf/curriculum/master/CKA_Curriculum_v1.22.pdf)
* [Linux foundations Handbook](https://docs.linuxfoundation.org/tc-docs/certification/lf-candidate-handbook)






# CKA Curriculum

https://raw.githubusercontent.com/cncf/curriculum/master/CKA_Curriculum_v1.22.pdf

25% - Cluster Architecture, Installation & Configuration
* Manage role based access control (RBAC)
    * [https://kubernetes.io/docs/reference/access-authn-authz/rbac/](https://kubernetes.io/docs/reference/access-authn-authz/rbac/)
* Use Kubeadm to install a basic cluster
    * [https://kubernetes.io/docs/setup/production-environment/tools/kubeadm/install-kubeadm/](https://kubernetes.io/docs/setup/production-environment/tools/kubeadm/install-kubeadm/)
    * [switch docker to systemd cgroup driver](https://kubernetes.io/docs/setup/production-environment/container-runtimes/)
        * Seriously ???
        * /etc/docker/daemon.json 

```json
{
  "exec-opts": ["native.cgroupdriver=systemd"]
}
```

* Manage a highly-available Kubernetes cluster
    * [https://kubernetes.io/docs/setup/production-environment/tools/kubeadm/high-availability/](https://kubernetes.io/docs/setup/production-environment/tools/kubeadm/high-availability/)
* Provision underlying infrastructure to deploy a Kubernetes cluster
    * Does this mean installing docker or cri-o?
    * [https://kubernetes.io/docs/setup/production-environment/container-runtimes/](https://kubernetes.io/docs/setup/production-environment/container-runtimes/)  ??????
* Perform a version upgrade on a Kubernetes cluster using Kubeadm
    * [https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/kubeadm-upgrade/](https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/kubeadm-upgrade/)
* Implement etcd backup and restore
    * [https://kubernetes.io/docs/tasks/administer-cluster/configure-upgrade-etcd/#backing-up-an-etcd-cluster](https://kubernetes.io/docs/tasks/administer-cluster/configure-upgrade-etcd/#backing-up-an-etcd-cluster)

15% - Workloads & Scheduling
* Understand deployments and how to perform rolling update and rollbacks
    * [https://kubernetes.io/docs/concepts/workloads/controllers/deployment/](https://kubernetes.io/docs/concepts/workloads/controllers/deployment/)
* Use ConfigMaps and Secrets to configure applications
    * [https://kubernetes.io/docs/concepts/configuration/configmap/](https://kubernetes.io/docs/concepts/configuration/configmap/)
    * [https://kubernetes.io/docs/concepts/configuration/secret/](https://kubernetes.io/docs/concepts/configuration/secret/)
* Know how to scale applications
    * Increase the replica set?  Or horizontal pod audoscaler?  Something else?
    * [https://kubernetes.io/docs/tasks/run-application/horizontal-pod-autoscale-walkthrough/](https://kubernetes.io/docs/tasks/run-application/horizontal-pod-autoscale-walkthrough/)
    * [https://kubernetes.io/docs/concepts/workloads/controllers/deployment/](https://kubernetes.io/docs/concepts/workloads/controllers/deployment/) - set the replicas, increase for more deployments
* Understand the primitives used to create robust, self-healing, application deployments
* Understand how resource limits can affect Pod scheduling
    * [https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)
* Awareness of manifest management and common templating tools
    * operators?  helm? kustomize?

20% - Services & Networking
* Understand host networking configuration on the cluster nodes
    * [https://kubernetes.io/docs/concepts/cluster-administration/networking/](https://kubernetes.io/docs/concepts/cluster-administration/networking/)
* Understand connectivity between Pods
* Understand ClusterIP, NodePort, LoadBalancer service types and endpoints
* Know how to use Ingress controllers and Ingress resources
    * [https://kubernetes.io/docs/concepts/services-networking/ingress/](https://kubernetes.io/docs/concepts/services-networking/ingress/)
    * [https://kubernetes.io/docs/concepts/services-networking/ingress-controllers/](https://kubernetes.io/docs/concepts/services-networking/ingress-controllers/)
* Know how to configure and use CoreDNS
    * [https://kubernetes.io/docs/tasks/administer-cluster/dns-custom-nameservers/](https://kubernetes.io/docs/tasks/administer-cluster/dns-custom-nameservers/ca)
* Choose an appropriate container network interface plugin
    * [https://kubernetes.io/docs/concepts/cluster-administration/networking/#calico](https://kubernetes.io/docs/concepts/cluster-administration/networking/#calico)
    * [https://kubernetes.io/docs/concepts/cluster-administration/networking/#flannel](https://kubernetes.io/docs/concepts/cluster-administration/networking/#flannel)
    * [https://kubernetes.io/docs/tasks/administer-cluster/network-policy-provider/calico-network-policy/](https://kubernetes.io/docs/tasks/administer-cluster/network-policy-provider/calico-network-policy/)

10% - Storage
* Understand storage classes, persistent volumes
    * [https://kubernetes.io/docs/concepts/storage/storage-classes/](https://kubernetes.io/docs/concepts/storage/storage-classes/)
    * [https://kubernetes.io/docs/concepts/storage/persistent-volumes/](https://kubernetes.io/docs/concepts/storage/persistent-volumes/)
* Understand volume mode, access modes and reclaim policies for volumes
    * [https://kubernetes.io/docs/concepts/storage/persistent-volumes/#volume-mode](https://kubernetes.io/docs/concepts/storage/persistent-volumes/#volume-mode)
    * [https://kubernetes.io/docs/concepts/storage/persistent-volumes/#access-modes](https://kubernetes.io/docs/concepts/storage/persistent-volumes/#access-modes)
    * [https://kubernetes.io/docs/concepts/storage/persistent-volumes/#reclaim-policy](https://kubernetes.io/docs/concepts/storage/persistent-volumes/#reclaim-policy)
* Understand persistent volume claims primitive
    * [https://kubernetes.io/docs/concepts/storage/volumes/#persistentvolumeclaim](https://kubernetes.io/docs/concepts/storage/volumes/#persistentvolumeclaim)
* Know how to configure applications with persistent storage
    * [https://kubernetes.io/docs/concepts/storage/storage-classes/#local](https://kubernetes.io/docs/concepts/storage/storage-classes/#local) - manual
    * [https://kubernetes.io/docs/concepts/storage/storage-classes/#gce-pd](https://kubernetes.io/docs/concepts/storage/storage-classes/#gce-pd) - google cloud

30% - Troubleshooting
* Evaluate cluster and node logging
    * [https://kubernetes.io/docs/tasks/debug-application-cluster/debug-cluster/#looking-at-logs](https://kubernetes.io/docs/tasks/debug-application-cluster/debug-cluster/#looking-at-logs)
* Understand how to monitor applications
    * [https://kubernetes.io/docs/tasks/debug-application-cluster/debug-application-introspection/](https://kubernetes.io/docs/tasks/debug-application-cluster/debug-application-introspection/)
* Manage container stdout & stderr logs
* Troubleshoot application failure
    * [https://kubernetes.io/docs/tasks/debug-application-cluster/debug-application/](https://kubernetes.io/docs/tasks/debug-application-cluster/debug-application/)
* Troubleshoot cluster component failure
    * [https://kubernetes.io/docs/tasks/debug-application-cluster/debug-cluster/#a-general-overview-of-cluster-failure-modes](https://kubernetes.io/docs/tasks/debug-application-cluster/debug-cluster/#a-general-overview-of-cluster-failure-modes)
* Troubleshoot networking
    * [https://kubernetes.io/docs/tasks/administer-cluster/dns-debugging-resolution/](https://kubernetes.io/docs/tasks/administer-cluster/dns-debugging-resolution/)