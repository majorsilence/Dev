---
layout: post
title: Monodevelop Build Instructions
created: 1402144014
redirect_from:
  - /monodevelop_build_ubuntu_14.04/
  - /news/2014/06/04/monodevelop-build-instructions.html
---

Requirements
Ubuntu 14.04 +, mono-devel installed

```bash
sudo apt-get mono-devel
```

# Build MonoDevelop

First make sure you have monodevelop build dependencies installed.  This is missing from the official instructions and will keep you from hunting down all required build packages.

```bash
sudo apt-get build-dep monodevelop
```

Next follow the instructions found at https://github.com/mono/monodevelop/tree/master but use config options like below to avoid overwritting the default monodevelop packages with ubuntu.


## Configure Options and Build

```bash
git submodule update --init --recursive

export EnableNuGetPackageRestore=true ;
./configure --prefix=/opt/majorsilence/monodevelop --profile=stable ; make
```

## Run MonoDevelop

```bash
make run
```

## Create binary package

See http://www.webupd8.org/2010/01/how-to-create-deb-package-ubuntu-debian.html
