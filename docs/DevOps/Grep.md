---
layout: base
title: Grep
---

Find content in files.  Case insensitive and print line number along with file name.

```bash
grep "Search Term" filename -in
```

Find all instances of userid in all .sql files in the current folder.

```bash
grep "userid" *.sql -in
```


Recursive search.

```powershell
grep "userid" *.sql -in -r
```



# Powershell equivalent

Current directory search.

```powershell
Select-String -pattern "SearchTerm"
```


Recursive search.

```powershell
dir -Recurse | Select-String -pattern "SearchTerm"
```
