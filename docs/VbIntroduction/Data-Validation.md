---
layout: base
title: Data Validation
---

Validate all data.  Goes hand in hand with Error Handling.  

In some circumstances all data should be validated before doing any work on it.  One example is if you taking input from a user and are expecting an integer you should validate that it is an integer.  If there is no validation the program will throw an exception.  Of you may only want integers between lets say 1 and 100.  In this case 101 or -1 would be an error.  To stop these values from be used in the program you validate the data.

See: https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/DataValidation/Application.vb