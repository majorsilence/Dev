---
layout: base
title: fetch api
---

Call service

# Fetch post example

Call a service using post with fetch api.

### Helper functions

```typescript

function status_helper(response) {
    if (response.status >= 200 && response.status < 300) {
        return Promise.resolve(response);
    }
    else {
        return Promise.reject(new Error(response.statusText));
    }
}

function json_helper(response) {
    return response.json();
}

 function serialize(obj, prefix) {
    if (prefix === void 0) { prefix = null; }
    var str = [], p;
    for (p in obj) {
        if (obj.hasOwnProperty(p)) {
            var k = prefix ? prefix + "[" + p + "]" : p, v = obj[p];
            str.push((v !== null && typeof v === "object") ?
                serialize(v, k) :
                encodeURIComponent(k) + "=" + encodeURIComponent(v));
        }
    }
    return str.join("&");
}
```

### call fetch

```typescript
function SaveComment(msg) {
    var data = serialize({
        test_param: "test value",
        another_param: "another value"
    });

    return fetch(site + "/some/url", {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: data
    });
}

```

### Calling the SaveComment function

```javascript
SaveComment("My comment")
    .then(status_helper)
    .then(json_helper)
    .then(function(data) {
        console.log(data);
    })
    .catch(function(error) {
        console.log(error);
    });
```
