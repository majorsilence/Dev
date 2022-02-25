---
layout: post
title: Optimizations
created: 1331941775
redirect_from:
  - /node/479/
  - /news/2012/03/16/optimizations.html
---
I recently spent some time optimizing some 8 year old .NET code.  The program would convert files, do some cleanup of data, and insert the data into a sql 2005 database.  The problem was that it could take anywhere from 10 to 20 hours.  It also would randomly crash and someone would need to babysit the process.

A lot of people would probably jump in at this point and start coding.  I first decided to take a look at how the process was running.  The program would load the data from a shared network drive as needed and then insert into a database that was also on another networked computer.

The first step was to copy all the data to the local computer before running the process.  Next was to insert into a database on the local machine.  This reduced the time of the process about 50%.  That was good.  Now we were down to 5 hours instead of 10.  Next another developer noticed that the databases were set to an initial size of 1 MB and to only grow at 1MB.  We changed that to an initial size of 200 MB and a growth size of I believe 10%.  The process was now down to 1 hour.  

The next step was to find out why it was randomly crashing.  This involved reviewing the code and reviewing the process with the data technician.  We discovered that most of the options in the conversion program have never been used in 8 years.  So I removed over 50% of the code and streamlined the user interface.  I added exception handling.  Instead of just crashing the program we would now log were the errors were occurring so we could investigate further.

With this done the conversion of data was for the most part down to a few button clicks as long as there were no errors to investigate.  With all the redundant code removed the process was down to 20 minutes.

A good example of useless code was every file that was converted was loaded into multiple hidden datagrids and then reset to nothing.

I still thought I could speed this up.  The next step I took was to clean and split the one multi thousand line class into multiple classes.    This may sound easy but it did take some work.  As it would turn out the original class used class level variables for almost every variable a function used.   There were only a few variables  declared in the functions that needed them.  So I had to sort out what functions used what variables and how they all related to each other.  When I was done I had three classes that used no class level variables.  All variables were declared in functions.  The few places that required more then one function access to a variable had the variable passed in as a function parameter.

Cleaning the code and splitting it into three classes of course did not bring any speed improvements, but it did make it much easier to understand.   If a function was passed the same parameter value it would always return the same result.  This made it very easy to make the data conversion part of the program multi threaded.  To be exact I used asynchronous delegates and had four conversions running at a time.  

The time to run the conversion was now 2 minutes.   At this point I decided it was not worth taking the optimization any further.
