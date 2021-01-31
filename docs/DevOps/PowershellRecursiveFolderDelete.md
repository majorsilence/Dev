---
layout: base
title: Powershell recursive folder delete 
---

Example of recurse delete all folders named "bin" and "obj" from current folder.

```powershell
function clean_bin_obj()
{
	# DELETE ALL "BIN" and "OBJ" FOLDERS
	get-childitem -Include bin -Recurse -force | Remove-Item -Force -Recurse
	get-childitem -Include obj -Recurse -force | Remove-Item -Force -Recurse
}
```
