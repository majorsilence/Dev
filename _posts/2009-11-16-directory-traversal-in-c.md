---
layout: post
title: Directory Traversal in C#
created: 1258337323
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBhbSByZWFkaW5nIHRocm91Z2ggYSBjaGFwdGVyIG9uIGJpbmFyeSB0cmVl
  cy4gIFRoZSBmaXJzdCBzaW1wbGUgZXhhbXBsZSB0aGV5IGdpdmUgaXMgdHJh
  dmVyc2luZyB0aHJvdWdoIGRpcmVjdG9yeSBzdHJ1Y3R1cmVzLiAgQXMgdGhl
  IGJvb2sgaXMgZm9yIGphdmEgdGhlIGF0dGFjaGVkIGZpbGUgaXMgdGhlIGV4
  YW1wbGUgdHJhbnNsYXRlZCB0byBjIy4gIA0KDQpPbmNlIEkgaGF2ZSBmaW5p
  c2hlZCB0aGUgY2hhcHRlciBJIHdpbGwgdXBsb2FkIHRoZSBiaW5hcnkgdHJl
  ZSBleGFtcGxlIHRyYW5zbGF0ZWQgdG8gYyMuDQoNCkhlcmUgaXMgYW4gZXhh
  bXBsZSBwb3N0b3JkZXIgcmVjdXJzaW9uIHRocm91Z2ggYSBkaXJlY3Rvcnkg
  dHJlZSAoYXR0YWNobWVudCBtYWluLmNzKS4gIFNlZSBhdHRhY2htZW50IE1h
  aW4uY3MgZm9yIGEgZGlmZmVyZW50IGV4YW1wbGUuDQo8cHJlPg0KdXNpbmcg
  U3lzdGVtLklPOw0KDQpjbGFzcyBSZWN1cnNlRGlyZWN0b3J5DQp7DQoJcHVi
  bGljIHN0YXRpYyB2b2lkIE1haW4oc3RyaW5nW10gYXJncykNCgl7DQoJCVJl
  Y3Vyc2VEaXJlY3RvcnkgciA9IG5ldyBSZWN1cnNlRGlyZWN0b3J5KCk7DQ==
redirect_from:
  - /node/299/
---
I am reading through a chapter on binary trees.  The first simple example they give is traversing through directory structures.  As the book is for java the attached file is the example translated to c#.  

Once I have finished the chapter I will upload the binary tree example translated to c#.

Here is an example postorder recursion through a directory tree (attachment main.cs).  See attachment Main.cs for a different example.

```c#
using System.IO;

class RecurseDirectory
{
	public static void Main(string[] args)
	{
		RecurseDirectory r = new RecurseDirectory();
		RecurseDirectory.PrintDirsRecursively(new System.IO.DirectoryInfo(@"\\Directory\Location"), 0);

		Console.Read();
	}
	
	
	public static void PrintDirsRecursively(System.IO.DirectoryInfo source, int depth) 
	{
		foreach (System.IO.DirectoryInfo dir in source.GetDirectories())
		{
			PrintTabs(depth);
			System.Console.WriteLine(source.FullName);
			PrintDirsRecursively(dir, depth+1);
		}
		foreach (System.IO.FileInfo file in source.GetFiles())
		{
			PrintTabs(depth);
			System.Console.WriteLine(file.FullName);
		}
	}


	private static void PrintTabs(int depth)
	{
		for (int j=0; j &lt; depth; j++)
		{
			System.Console.Write("\t");
		}
	}
}

```


Here is a simple recursive directory/file copy function.

```c#
using System.IO;

public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target) 
{
    foreach (DirectoryInfo dir in source.GetDirectories())
    {
        CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
    }
    foreach (FileInfo file in source.GetFiles())
    {
        file.CopyTo(Path.Combine(target.FullName, file.Name), true); //overwrite
    }
}
```
