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



