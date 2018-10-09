---
layout: base
title: Windows server create local admin
---

In an administrative command prompt

```cmd
net user [TheUser] [ThePassword] /add
net localgroup Administrators [TheUser] /add
```