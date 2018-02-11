---
layout: post
title: UltraVNC Single Click Replacement
created: 1277211577
redirect_from:
  - /ultravnc_single_click_replacement/
---
<p>See <a href = "https://github.com/majorsilence/MajorSilenceConnect">https://github.com/majorsilence/MajorSilenceConnect</a></p>
<p>&nbsp;</p>
<p>MajorSilenceConnect is a basic replacement for ultravnc single click that uses the regular ultravnc server winvnc.exe. I find that this works much better on Windows Vista/7. Requires .NET 2.0. Currently this project only supports the port forwarding setup (does not support repeater mode) because that is all I need. It should be simple enough to add repeater support if it is ever needed. <img src="http://majorsilence.com/sites/default/files/SS-2010.06.22-10.45.43.png" /> How compile MajorSilenceConnect <a href="https://github.com/majorsilence/MajorSilenceConnect">Source code</a> You need Visual Studio C# 2008. In the resources/helpdesk.xml you will find:</p>
<pre>
&lt;helpdesk&gt;
    &lt;support&gt;Support 1&lt;/support&gt;
    &lt;address&gt;localhost:5500&lt;/address&gt;
  &lt;/helpdesk&gt;
</pre>
<p>&lt;support&gt; is what shows in the gui that the client will double click. &lt;address&gt; is the address/port that it will attempt to connect to. http://www.chunkvnc.com/ - for a solution with repeater mode and OSX support. http://uvnc.com/ - UltraVNC http://madebits.com/netz/ - .NET exe compressor</p>
