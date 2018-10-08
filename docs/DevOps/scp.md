---
layout: base
title: SCP upload and download
---

upload example
```bash
scp "your/local/file/path/localfile.zip" user@server:/remote/path
```

download example
```bash
scp user@server:/path/to/remotefile.zip /Local/Target/Destination
```

Download files that need sudo privledges
1. first ssh in
1. copy to home folder using sudo
1. sudo chown user filename
1. download using scp
1. delete copy in home folder with ssh

