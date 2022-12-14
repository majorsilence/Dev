---
layout: post
title: Kubernetes and KUBECONFIG
date: 2022-12-14
last_modified: 2022-12-14
---

> By default, kubectl looks for a file named config in the $HOME/.kube directory. You can specify other kubeconfig files by setting the KUBECONFIG environment variable or by setting the --kubeconfig flag.


To set an alternative kubectl config path set the KUBECONFIG environment variable or set the --kubeconfig flag.

## Example 1, KUBECONFIG

```bash
export KUBECONFIG=~/path/to/kubeconfig.yaml
kubectl get nodes
```

## Example 2, --kubeconfig 

```bash
kubectl get nodes --kubeconfig ~/path/to/kubeconfig.yaml
```

## Reference

* [Organizing Cluster Access Using kubeconfig Files](https://kubernetes.io/docs/concepts/configuration/organize-cluster-access-kubeconfig/)
