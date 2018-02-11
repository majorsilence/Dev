---
layout: post
title: Ruby on Rails - Ubuntu 14.04
created: 1398462070
redirect_from:
  - /ruby_rails_ubuntu_14.04/
---
<p>Some basic instruction for easy setup of ruby on rails on a ubuntu 14.04 server.</p>
```bash
sudo apt-get install ruby ruby-dev nodejs
sudo gem install rails
sudo gem install rdoc-data; sudo rdoc-data --install
rails new path/to/your/new/application
cd path/to/your/new/application
rails server
```
<p>&nbsp;</p>
<p>Now browse to http://localhost:3000</p>
<p>More details on creating view/controllers/models see&nbsp;<a href="http://guides.rubyonrails.org/getting_started.html">http://guides.rubyonrails.org/getting_started.html</a>.</p>
