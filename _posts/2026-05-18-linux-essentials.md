---
layout: post
title: Linux Essentials
date: 2026-05-18
last_modified: 2026-05-18
comments: true
enable_syntax_highlighting: true
---

This syllabus is divided into four distinct 30-minute modules and was created with gemini. It balances fundamental concepts, hands-on practice, and essential networking/security skills like SSH.

------------------------------
## 🐧 Linux Essentials: 2-Hour Crash Course## ⏱️ Course Overview

* Module 1 (0:00 - 0:30): Shell Navigation & The Help System
* Module 2 (0:30 - 1:00): File Manipulations & Text Processing
* Module 3 (1:00 - 1:30): Remote Access (SSH), File Transfer & Networking
* Module 4 (1:30 - 2:00): Permissions, Process Management & Troubleshooting

------------------------------
## 🛠️ Module 1: Shell Navigation & The Help System (30 Mins)

### Introduction to the CLI (5 mins)

* Linux relies on the Command Line Interface (CLI) for speed and server automation.
* The "Shell" (usually Bash or Zsh) translates your typed text into system actions.

### Basic Navigation (15 mins)

* pwd: Print Working Directory. Shows your exact current location.
* ls: List directory contents.
* ls -l: Long format (shows sizes, owners, and permissions).
   * ls -a: Shows hidden files (files starting with a dot, like .bashrc).
* cd: Change directory.
* cd /: Go to the root system directory.
   * cd ~ or just cd: Go to your user's home directory.
   * cd ..: Move up one level.
* Pro-Tip: Use the Tab key for autocomplete to prevent typos.

### Self-Help & Documentation (10 mins)

* man <command>: Opens the system manual (e.g., man ls). Press q to exit.
* <command> --help: Outputs a quick-reference summary flag list directly in the terminal.

------------------------------
## 📂 Module 2: File Manipulations & Text Processing (30 Mins)

### Creating and Moving Files (15 mins)

* mkdir <dir_name>: Create a new directory.
* touch <file_name>: Create an empty file or update an existing file's timestamp.
* cp <source> <destination>: Copy files.
* Use cp -r to copy folders recursively.
* mv <source> <destination>: Move or rename files and folders.
* rm <file>: Delete files.
* Use rm -rf <dir> to forcefully delete a directory and everything inside it (use with caution).

### Inspecting and Searching Text (15 mins)

* cat <file>: Dumps the entire file contents onto your screen.
* less <file>: Opens an interactive viewer for large files. Use arrow keys to scroll, q to quit.
* head -n 20 <file>: View the first 20 lines of a file.
* tail -n 20 <file>: View the last 20 lines of a file.
* tail -f <file>: Follow mode. Streams new additions to a file (like active log files) in real-time.
* grep "<search_term>" <file>: Searches for matching text patterns inside files.

------------------------------
## 🌐 Module 3: Remote Access (SSH), File Transfer & Networking (30 Mins)

### Introduction to SSH (10 mins)

* Secure Shell (SSH) encrypts the connection between your machine and a remote Linux server.
* Basic connection: ssh username@remote_host_ip
* Using a specific port: ssh -p 2222 username@remote_host_ip
* Key-Based Authentication: Utilizing ~/.ssh/id_rsa keys instead of passwords for automated, highly secure access.

### Copying Files Remotely (10 mins)

* scp: Secure Copy Protocol (best for simple, single file transfers over SSH).
* Local to Remote: scp localfile.txt username@remote_ip:/path/to/destination/
   * Remote to Local: scp username@remote_ip:/path/to/remotefile.txt /local/destination/
* rsync: Remote Sync. Faster and smarter than scp because it only copies differences between files and allows resuming interrupted transfers.
* Example: rsync -avz local_folder/ username@remote_ip:/remote_folder/

### Basic Networking Utilities (10 mins)

* ping <host>: Check if a remote server is reachable and active.
* curl <URL> or wget <URL>: Download files directly from the web via CLI.
* ip a: Display network interfaces and your current IP addresses.

------------------------------
## 🔒 Module 4: Permissions, System Control & Troubleshooting (30 Mins)

### Linux Permissions & Sudo (10 mins)

* Linux uses three user tiers: User (u), Group (g), and Others (o).
* Linux uses three access types: Read (r), Write (w), and Execute (x).
* chmod: Change file permissions.
* chmod +x script.sh: Makes a script executable.
* chown: Change file ownership (e.g., chown username:groupname file.txt).
* sudo: SuperUser Do. Runs a single command with root (administrator) privileges.

### Process Management (10 mins)

* ps aux: Lists every single running process on the system.
* top or htop: Interactive task managers showing live CPU and memory usage.
* kill <PID>: Gracefully stops a process using its Process ID number.
* kill -9 <PID>: Forcefully terminates a frozen process immediately.

### System Diagnostics (10 mins)

* df -h: Displays remaining disk space in human-readable formats (GB/MB).
* free -h: Displays total, used, and available RAM memory.
* history: Shows a list of all commands previously executed in this terminal session.


------------------------------
## 🏁 Hands-on Lab Challenge (To run during the final 15 mins)
Perform this exact sequence on your test environments to validate your understanding:

   1. Log into your remote training server using SSH.
   2. Create a folder named backup_test in your home directory.
   3. Generate a system status file: df -h > disk_space.txt.
   4. Use grep to find the word "root" inside disk_space.txt.
   5. Change the file permissions so it is read-only for everyone (chmod 444 disk_space.txt).
   6. Disconnect from SSH and try to use scp to pull that disk_space.txt file back to your local machine.


------------------------------
## 🚀 Hour 3: Users, Packages, Services, and Logs

### Module 5 (2:00 - 2:30): User and Group Administration

* whoami, id: Confirm current user and group membership.
* useradd / adduser: Create local users.
* passwd <username>: Set or reset user passwords.
* usermod -aG <group> <username>: Add a user to a group (example: sudo or wheel).
* groups <username>: Verify effective group membership.
* Common admin check:
   * Ubuntu: `groups <username>` should include `sudo`.
   * AlmaLinux: `groups <username>` should include `wheel`.

### Module 6 (2:30 - 3:00): Package and Service Management

* Package managers:
   * Ubuntu: apt
   * AlmaLinux: dnf
* Core package actions:
   * Search: `apt search <pkg>` or `dnf search <pkg>`
   * Install: `sudo apt install -y <pkg>` or `sudo dnf install -y <pkg>`
   * Remove: `sudo apt remove <pkg>` or `sudo dnf remove <pkg>`
* Service control with systemd:
   * `sudo systemctl status <service>`
   * `sudo systemctl start <service>`
   * `sudo systemctl stop <service>`
   * `sudo systemctl enable <service>`
* Essential examples:
   * Ubuntu SSH service: ssh
   * AlmaLinux SSH service: sshd

### Hour 3 Mini-Drill (5-10 mins)

1. Install htop.
2. Check SSH service status with systemctl.
3. Enable SSH service to start on boot.
4. Verify with `systemctl is-enabled <service>`.


------------------------------
## 🔧 Hour 4: Automation, Scheduling, and Recovery Basics

### Module 7 (3:00 - 3:30): Shell Scripting Fundamentals

* Why scripts: repeatability, consistency, and faster ops.
* Create your first script:
   * `nano health_check.sh` (or your preferred editor)
   * Add a shebang: `#!/usr/bin/env bash`
   * Add command checks: `date`, `uptime`, `df -h`, `free -h`
* Make executable and run:
   * `chmod +x health_check.sh`
   * `./health_check.sh`
* Save output for audits:
   * `./health_check.sh > health_report.txt`

### Module 8 (3:30 - 4:00): Scheduling and Troubleshooting Workflow

* Scheduled tasks with cron:
   * `crontab -e` to edit
   * Example every day at 06:00:
      * `0 6 * * * /home/<user>/health_check.sh >> /home/<user>/health.log 2>&1`
* Log investigation:
   * `journalctl -xe` for recent system issues.
   * `journalctl -u ssh --since "1 hour ago"` (Ubuntu)
   * `journalctl -u sshd --since "1 hour ago"` (AlmaLinux)
* Network/service triage checklist:
   * Verify IP (`ip a`)
   * Verify listener (`ss -tulpen | grep 22`)
   * Verify firewall policy (examples):
      * Ubuntu (UFW): `sudo ufw status verbose`
      * AlmaLinux (firewalld): `sudo firewall-cmd --list-all`
   * Verify service state in systemctl (examples):
      * Full status: `sudo systemctl status ssh` (Ubuntu) or `sudo systemctl status sshd` (AlmaLinux)
      * Quick state check: `systemctl is-active ssh` (Ubuntu) or `systemctl is-active sshd` (AlmaLinux)


------------------------------
## 🏁 Hands-on Lab Challenge 2 (End of Hour 4)
Complete this sequence to validate your Hour 3 and 4 skills:

1. Create a user named opsuser and add it to sudo (Ubuntu) or wheel (AlmaLinux).
2. Install htop and verify it launches.
3. Write a script named health_check.sh that outputs date, uptime, disk usage, and memory usage.
4. Make the script executable and run it, saving output to health_report.txt.
5. Create a cron job that runs the script every day at 06:00 and appends to health.log.
6. Confirm the cron entry exists with `crontab -l`.
7. Check recent SSH service logs using journalctl for your distro.
8. Document one troubleshooting finding from logs in a file named incident_notes.txt.



------------------------------
## 💿 Bonus: Installing Ubuntu Server 26.04 and AlmaLinux

Use this section if you want to build your own lab VMs (VirtualBox, VMware, Proxmox, Hyper-V, or cloud instances).

### Before You Start

* Minimum recommended per VM: 2 vCPU, 2-4 GB RAM, 20+ GB disk.
* Download official ISO images:
   * Ubuntu Server 26.04 LTS ISO from ubuntu.com.
   * AlmaLinux ISO from almalinux.org.
* Create bootable media:
   * On Linux/macOS: `dd` (advanced users only).
   * On Windows/macOS/Linux: tools like Rufus, balenaEtcher, or Ventoy.

### Install Ubuntu Server 26.04 LTS (Quick Path)

1. Boot from the Ubuntu Server 26.04 ISO.
2. Select language, keyboard layout, and network settings.
3. Set hostname (for example: ubuntu-lab).
4. Create your admin user and strong password.
5. For storage, choose guided partitioning unless you need a custom layout.
6. Enable OpenSSH Server during setup so remote access works immediately.
7. Complete install, reboot, and remove ISO media.
8. Verify after first login:
    * `cat /etc/os-release`
    * `ip a`
    * `sudo systemctl status ssh`

### Install AlmaLinux (Quick Path)

1. Boot from the AlmaLinux ISO.
2. In the installer, configure:
    * Keyboard and timezone.
    * Installation destination (auto-partitioning is fine for labs).
    * Network and hostname (for example: alma-lab).
3. In software selection, choose a minimal/server profile.
4. Set root password and create a regular admin user.
5. Start installation, then reboot when finished.
6. Verify after first login:
    * `cat /etc/os-release`
    * `ip a`
    * `sudo systemctl status sshd`

### First Updates (Both Distros)

* Ubuntu:
   * `sudo apt update && sudo apt upgrade -y`
* AlmaLinux:
   * `sudo dnf update -y`
* Optional but useful for this course:
   * `sudo apt install -y htop curl wget` (Ubuntu)
   * `sudo dnf install -y htop curl wget` (AlmaLinux)

## Bonus: SSH Keys on Windows (What They Are + How to Manage Them)

* SSH keys come in a pair:
   * Public key: safe to share. You publish this to servers, Git hosting, or tools.
   * Private key: secret. Never share this file, never email it, never paste it in chat.
* How auth works:
   * A server stores your public key in `~/.ssh/authorized_keys`.
   * Your Windows machine proves identity using the matching private key.

### Where Keys Live on Windows

* Default OpenSSH folder:
   * `C:\Users\<your_user>\.ssh\`
* Typical files:
   * `id_ed25519` (private key)
   * `id_ed25519.pub` (public key)
* Good habit: keep one key per purpose (for example: one for admin servers, one for Git).

### Generate a New Key Pair (PowerShell)

1. Open PowerShell.
2. Run:
   * `ssh-keygen -t ed25519 -C "your_email@example.com"`
3. When prompted:
   * Save path: press Enter for default, or set a custom filename.
   * Passphrase: set one (recommended).
4. Verify files:
   * `Get-ChildItem $HOME\.ssh`

### Start ssh-agent and Load Your Private Key

1. Ensure the agent service is running:
   * `Get-Service ssh-agent | Set-Service -StartupType Automatic`
   * `Start-Service ssh-agent`
2. Add your key:
   * `ssh-add $HOME\.ssh\id_ed25519`
3. Confirm key is loaded:
   * `ssh-add -l`

### Publish Your Public Key Safely

* View/copy only the `.pub` file:
   * `Get-Content $HOME\.ssh\id_ed25519.pub`
* Publish to a Linux server (Option 1, easiest):
   * `ssh-copy-id username@server_ip` (if available in your shell)
* Publish to a Linux server (Option 2, manual):
   * SSH into server and append key text into `~/.ssh/authorized_keys`.
   * Then fix permissions:
      * `chmod 700 ~/.ssh`
      * `chmod 600 ~/.ssh/authorized_keys`
* Publish to Git hosting (GitHub/GitLab/Azure DevOps):
   * Paste only the public key (`.pub`) into SSH Keys settings.

### Validate and Troubleshoot

* Test server login with key auth:
   * `ssh -i $HOME\.ssh\id_ed25519 username@server_ip`
* Debug connection issues:
   * `ssh -v username@server_ip`
* Common mistakes:
   * Wrong file shared (private key instead of `.pub`).
   * Bad file permissions on server `~/.ssh` or `authorized_keys`.
   * Using the wrong username/host or key filename.

### Alternative SSH Tools on Windows

If you do not want to use the built-in OpenSSH client, these are common alternatives.

#### 1. PuTTY + PuTTYgen + Pageant (Classic and Widely Used)

* What each tool does:
   * PuTTY: SSH terminal client.
   * PuTTYgen: key generator and key converter.
   * Pageant: SSH key agent for caching unlocked private keys.
* Typical setup flow:
   1. Install PuTTY from the official site.
   2. Open PuTTYgen and click Generate (move mouse until complete).
   3. Save:
      * Private key as `.ppk` (keep secret).
      * Public key text (copy to `authorized_keys` on server).
   4. In PuTTY, configure:
      * Session: hostname/IP and port 22.
      * Connection > Data: auto-login username (optional).
      * Connection > SSH > Auth > Credentials: select your `.ppk` file.
   5. Save the PuTTY session profile and connect.
* Optional (recommended):
   * Start Pageant and load your `.ppk` once, so PuTTY sessions can reuse it without repeated prompts.

#### 2. Convert Existing OpenSSH Keys for PuTTY

If you already created `id_ed25519` with `ssh-keygen`, convert it for PuTTY:

1. Open PuTTYgen.
2. Click Load and select your OpenSSH private key (`id_ed25519`).
3. Save private key as `.ppk`.
4. Use this `.ppk` in PuTTY Auth settings.

Note: your public key stays the same conceptually; keep publishing only the public key content.

#### 3. MobaXterm (All-in-One SSH + SFTP GUI)

* Why people use it:
   * Built-in terminal, tabs, and graphical SFTP browser.
* Basic workflow:
   1. Create a new SSH session (host, username, port).
   2. Under advanced SSH settings, select your private key file.
   3. Connect and use the left SFTP pane to transfer files.
* Key safety:
   * Use passphrase-protected keys and do not export private keys into shared folders.

#### 4. Bitvise SSH Client (Good GUI Controls)

* Why people use it:
   * Friendly GUI for terminal + SFTP + port forwarding.
* Basic workflow:
   1. Create a profile with host, port, and username.
   2. Import/select your private key in Client key manager.
   3. Connect and save the profile for repeat use.
* Best practice:
   * Keep separate profiles/keys for production vs lab servers.

#### Tool Choice Quick Guide

* Built-in OpenSSH (PowerShell/Windows Terminal): best for scripting and automation.
* PuTTY suite: best for traditional Windows SSH workflows and key conversion needs.
* MobaXterm: best for users who want terminal + easy file transfer in one window.
* Bitvise: best for users who prefer a full-featured SSH GUI with clear profiles.


