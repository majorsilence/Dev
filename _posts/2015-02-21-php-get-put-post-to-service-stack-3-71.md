---
layout: post
title: PHP Get, Put, Post to Service Stack 3.71
created: 1424548870
redirect_from:
  - /php_get_put_post_servicestack/
  - /news/2015/02/21/php-get-put-post-to-service-stack-3-71.html
---
This is an update on an <a href="http://www.majorsilence.com/servicestack_and_php">older post from 2012</a>.

Connecting to a servicestack (see servicestack.net) service from php is very easy.  If you go to https://github.com/majorsilence/WebServiceDotNetTesting there is a c# project that has one service called Hello.   This service will listen on http://localhost:9200.

In the php folder there is a script servicestack-php.php that will connect to the c# servicestack web service.

The main functions that can be used are get_data_curl, post_data_curl, put_data_curl.  These function can be used with both HTTP, HTTPS, and can connect to open services and services protected with basic authentication.

```php
function get_data_curl($base_url, $service_name, $query_string, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/' . $service_name . '/' . $query_string;
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 
		'Accept: application/json', "Expect: 100-continue"));
	
	// 0 do not include header in output, 1 include header in output
	curl_setopt($process, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($process, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	
	// Set so curl_exec returns the result instead of outputting it.
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

	
	// Get the response and close the channel.
	$response = curl_exec($ch);
	curl_close($ch);
	
	$json_obj = json_decode($response);
	return $json_obj;
}


function put_data_curl($base_url, $service_name, $post_data, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/json/syncreply/' . $service_name;
	
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 
		'Accept: application/json', "Expect: 100-continue"));
	
	// 0 do not include header in output, 1 include header in output
	curl_setopt($process, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($process, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	// Set the post variables
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "PUT");
	curl_setopt($ch, CURLOPT_POSTFIELDS, $post_data);
	
	// Set so curl_exec returns the result instead of outputting it.
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

	
	// Get the response and close the channel.
	$response = curl_exec($ch);
	curl_close($ch);
	
	$json_obj = json_decode($response);
	return $json_obj;
}

```


You can use the function like this.

```php
get_hello_info();
post_hello_info();
put_hello_info();

function get_hello_info()
{
	/*
	$username = "user";
	$password = "password";
	$cred = "{$username}:{$password}";
	*/
	// If you are connecting to a service that uses basic authentication 
	// you can use the code above to set the credentials.
	$cred = "";

	$json = get_data_curl("http://localhost:9200", "Hello", "Testthisservice", $cred);
	echo 'Get Result: ' . $json->{'Result'} . "<br />";
}


function post_hello_info()
{
	$json_str = json_encode(array('Name' =>  'Test this service'));
	
	
	/*
	$username = "user";
	$password = "password";
	$cred = "{$username}:{$password}";
	*/
	// If you are connecting to a service that uses basic authentication 
	// you can use the code above to set the credentials.
	$cred = "";

	$json = post_data_curl("http://localhost:9200", "Hello", $json_str, $cred);
	echo 'Post Result: ' . $json->{'Result'} . "<br />";
}


function put_hello_info()
{
	$json_str = json_encode(array('Name' =>  'Test this service'));
	
	
	/*
	$username = "user";
	$password = "password";
	$cred = "{$username}:{$password}";
	*/
	// If you are connecting to a service that uses basic authentication 
	// you can use the code above to set the credentials.
	$cred = "";

	$json = put_data_curl("http://localhost:9200", "Hello", $json_str, $cred);
	echo 'Put Result: ' . $json->{'Result'} . "<br />";
}
```
