---
layout: post
title: Kubernetes CKA Prep Notes
date: 2022-02-13
last_modified: 2022-02-20
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
    * Increase the replica set?  Or horizontal pod scaling?  Something else?
* Understand the primitives used to create robust, self-healing, application deployments
* Understand how resource limits can affect Pod scheduling
* Awareness of manifest management and common templating tools
    * operators?  helm? kustomize?

20% - Services & Networking
* Understand host networking configuration on the cluster nodes
* Understand connectivity between Pods
* Understand ClusterIP, NodePort, LoadBalancer service types and endpoints
* Know how to use Ingress controllers and Ingress resources
* Know how to configure and use CoreDNS
* Choose an appropriate container network interface plugin

10% - Storage
* Understand storage classes, persistent volumes
* Understand volume mode, access modes and reclaim policies for volumes
* Understand persistent volume claims primitive
* Know how to configure applications with persistent storage

30% - Troubleshooting
 Evaluate cluster and node logging
* Understand how to monitor applications
* Manage container stdout & stderr logs
* Troubleshoot application failure
* Troubleshoot cluster component failure
* Troubleshoot networking