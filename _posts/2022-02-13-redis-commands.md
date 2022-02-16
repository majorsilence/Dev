---
layout: post
title: Redis commands
date: 2022-02-16
last_modified: 2022-02-16
---


Requires a redis install to work with.

See my [redis cluster kubernetes install](/news/2022/01/30/redis-cluster-kubernetes-install.html) post.


# Connect to a cluster

```bash
redis-cli -c -h redis-redis-cluster -a $REDIS_PASSWORD
```

# Commands

A few userful commands

## Interactive

```bash
INFO
CLUSTER INFO
dbsize
ping
incr helloworld
GET hello world
set hello "world"
append hello ". Hi"
GET hello
keys "*"
```

## cli

```bash
redis-cli --scan | head -10
redis-cli --bigkeys
redis-cli --scan --pattern '[YourSearch]:*' | wc -l
```




# References

* [ekvedaras redis-gui](https://github.com/ekvedaras/redis-gui)
* [rediscli](https://redis.io/topics/rediscli)

