---
layout: post
title: microk8s ingress
date: 2023-09-06
last_modified: 2023-09-06
comments: true
---

# Install

Install microk8s and nginx ingress.

```bash
sudo snap install microk8s --classic
sudo microk8s status --wait
sudo microk8s enable ingress
```

Note that the nginx ingressClassName provided by microk8s is **public**.

# Configure

Increase proxy buffer size, enable header underscores, enable use-forwarded-headers.

```bash
microk8s kubectl -n ingress edit configmaps nginx-load-balancer-microk8s-conf
```

add the following

```yaml
data:
  use-forwarded-headers: "true"
  enable-underscores-in-headers: "true"
  proxy-buffer-size: "16k"
```

Rollout the changes

```bash
microk8s kubectl -n ingress rollout restart daemonset nginx-ingress-microk8s-controller
```
