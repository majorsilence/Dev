---
layout: base
title: Create strong passwords
---

Run the following bash command to get a strong password.

Replace the string with a long random sentence.  Use the output as the password.

```bash
echo "The Sentence" | sha256sum
```