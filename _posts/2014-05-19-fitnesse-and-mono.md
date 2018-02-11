---
layout: post
title: Fitnesse and Mono
redirect_from:
  - /fitnesse_and_mono/
---

<p>Running fitnesse on ubuntu linux using mono is very simple. Follow the following instructions and you should have it running in 5 minutes.</p>
<p>See <a href="http://schuchert.wikispaces.com/Acceptance+Testing.UsingSlimDotNetInFitNesse#Rapid%20Intro%20to%20using%20Slim%20with%20.Net">http://schuchert.wikispaces.com/Acceptance+Testing.UsingSlimDotNetInFitN...</a> for more detailed instructions.</p>
<p>For a working example see <a href="https://github.com/majorsilence/FitnesseMono">https://github.com/majorsilence/FitnesseMono</a>.</p>
<ul><li><a href="https://github.com/jediwhale/fitsharp/downloads">fitsharp 2.2 for .net 4.0</a></li>
<li><a href="http://fitnesse.org/FitNesseDownload">fitnesse-standalone.jar 20140418</a></li>
<li>Java 1.7.0_55 IcedTea 2.4.7</li>
<li>Mono 3.2.8</li>
<li>MonoDevelop 4.0.12</li>
<li>Ubuntu 14.04</li>
</ul><p>Create a folder called fitnesse. Place the fitnesse-standalone.jar file in it. Inside the fitnesse folder create a folder called nslim. Unzip the contents of fitsharp into it.</p>
<p>Also in the fitnesse folder areate a runner.sh file and place the following in it. Make the script executable with chmod +x runner.sh.</p>

```bash
#!/usr/bin/env bash
/usr/bin/mono ./nslim/Runner.exe $@
```

<p>Also in the fitnesse folder create a start.sh file and place the following in it. Make the script executable with chmod +x start.sh.</p>

```bash
#!/usr/bin/env bash
java -jar fitnesse-standalone.jar -p 8075 -e 0
```

<p>I am assuming this is being committed to a git or subversion repo. The -e 0 tells it to not store history in zip files as it will be stored using git.</p>
<p>When the wiki is running you can open firefox or chrome and access it at localhost:8075. Create a new page and paste in the following.</p>

__Please not that due to some markdown problems line 3 below should not have a \ character anywhere.__

```text
!contents -R2 -g -p -f -h

!define TEST_SYSTEM {slim}
!define COMMAND_PATTERN \{\%m -r fitSharp.Slim.Service.Runner,./nslim/fitSharp.dll \%p\}
!define TEST_RUNNER {./runner.sh}
 
!path ../FitnesseTests/bin/Debug/FitnesseTests.dll

|import|
|slim_example|

!|Create Shows|5/6/2009 |
|Name |Episode |Channel|Start Time|Duration|Id? |
|House |Wilson Gets Mad |8 |19:00 |60 | House:8|
|Chuck |He Gets Kung Fu Power |9 |19:00 |60 | Chuck:9|
|Dr. Phil |Episode #405:Teens in Trouble|3 |16:00 |60 | Dr. Phil:3|
|Dr. Who |Yet another doctor |12 |20:00 |30 |$lastProgram=|

```

<p>After creating the above test page you may need to edit the page properties to make it a test. Load the page -&gt; Tools -&gt; Properties. Under page type make sure Test is checked and click Save Properties.</p>
<p>In a c# project file paste in.</p>

```cs
using System;

namespace slim_example
{
	public class CreateShows
	{
		public String ProgramDate { get; set; }
		public String Name { get; set; }
		public String Episode { get; set; }
		public int Channel { get; set; }
		public String StartTime { get; set; }
		public int Duration { get; set; }
		public String LastId { get; set; }

		public CreateShows(string programDate)
		{
			ProgramDate = programDate;
		}

		public void Execute()
		{
			Console.WriteLine("Hi");
			LastId = string.Format("{0}:{1}", Name, Channel);
		}

		public String Id()
		{
			return LastId;
		}
	}
}


```
