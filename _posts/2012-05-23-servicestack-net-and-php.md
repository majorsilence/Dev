---
layout: post
title: Servicestack.net and PHP
created: 1337814031
redirect_from:
  - /servicestack_and_php/
  - /news/2012/05/23/servicestack-net-and-php.html
---
Update (Feb 21, 2015) New <a href="http://www.majorsilence.com/php_get_put_post_servicestack">blog post covering Get, Put, Post to service stack</a>.

Connecting to a servicestack (see servicestack.net) service from php is very easy.  If you go to https://github.com/majorsilence/WebServiceDotNetTesting there is a c# project that has one service called Hello.   This service will listen on http://localhost:9200.

In the php folder there is a script servicestack-php.php that will connect to the c# servicestack web service.

The main function that can be used is get_data_curl.  This function can be used with both HTTP, HTTPS, and can connect to open services and services protected with basic authentication.

```php

/**
* Generic curl function to POST to a servicestack.net service.  This function
* will work with both HTTP and HTTPS but does not validate an HTTPS connection.
*
* @param string $base_url the base url of the service.  It must not end with a / character.
* @param string $service_name the name of the service.  This is case sensitive.
* @param json $post_data the data to post.  Should already be encoded json using the json_encode function.
* @param string $credentials the username and password to login to the webservice. A string in Format "Username:Password"
* @ return json
*/
function get_data_curl($base_url, $service_name, $post_data, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/json/syncreply/' . $service_name;
	$contentLength = strlen($post_data);
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 
		'Accept: application/json', "Expect: 100-continue"));
    // 0 do not include header in output, 1 include header in output
	curl_setopt($ch, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($ch, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	// Set the post variables
	curl_setopt($ch, CURLOPT_POST, 1);
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


You can use the get_data_curl function like this:
```php

	/*
	$username = "user";
	$password = "password";
	$cred = "{$username}:{$password}";
	*/
	// If you are connecting to a service that uses basic authentication 
	// you can use the code above to set the credentials.
	$cred = "";

	$json = get_data_curl("http://localhost:9200", "Hello", $json_str, $cred);
	echo 'Result: ' . $json->{'Result'} . "<br />";

```
