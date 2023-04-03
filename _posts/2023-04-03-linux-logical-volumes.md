---
layout: post
date: 2023-04-03
last_modified: 2023-04-03
---

# Resize logical volume

```bash
# Check disks
lsblk /dev/sda
lsblk /dev/sdb
lsblk /dev/nvme0n1

# Increase the Physical Volume (pv) to max size
pvresize /dev/sda3

# Expand the Logical Volume (LV) to max size to match
lvresize -l +100%FREE /dev/mapper/ubuntu--vg-ubuntu--lv

# Expand the filesystem itself
resize2fs /dev/mapper/ubuntu--vg-ubuntu--lv
```

# Add a second disk to an lvm

```bash
# display physical volumes (pv)
pvs
pvdisplay

# display lvm volume groups (vg)
vgs
vgdisplay

# display lvm logical volume (lv)
lvs
lvdisplay

# find out info on all disks
fdisk -l | grep '^Disk /dev/'
lvmdiskscan

# create the physical volume (pv) and verify
# this is if the new disk is named /dev/sdb
pvcreate /dev/sdb
lvmdiskscan -l

# Add new pv named /dev/sdb to an existing lv

# add /dev/sdb to volume group
vgextend ubuntu-vg /dev/sdb

# extend mapped drive to full size
lvm lvextend -l +100%FREE /dev/mapper/ubuntu--vg-ubuntu--lv

# resize to 
resize2fs -p /dev/mapper/ubuntu--vg-ubuntu--lv

# verify
df -H
```


# Fdisk basics

```bash
# list partisions
fdisk -l

# open /dev/sdb for editing
# once fdisk is running 'm' is for help
fdisk /dev/sdb
```

# References

- [How can I make ubuntu--vg-ubuntu--lv consume the entire disk space available?](https://community.spiceworks.com/topic/2325763-how-can-i-make-ubuntu-vg-ubuntu-lv-consume-the-entire-disk-space-available)
- [Delete a linux partition](https://phoenixnap.com/kb/delete-partition-linux)
- [How to add an extra second hard drive on Linux LVM and increase the size of storage](https://www.cyberciti.biz/faq/howto-add-disk-to-lvm-volume-on-linux-to-increase-size-of-pool/)

