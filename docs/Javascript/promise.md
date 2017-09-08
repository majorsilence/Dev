---
layout: base
title: ES6 Promise object
---

Simple es6 [promise](https://developers.google.com/web/fundamentals/getting-started/primers/promises).

No support in IE11.  Use jquery deferred instead of you want to support older browsers.

# Typescript example using JQuery.Deferred

```typescript
function SaveComment(msg) : JQueryDeferred<any> {
    var promise = new Promise(function(resolve, reject) {
        $.ajax({
            url: "/some/url",
            data: {
                Message: msg
            },
            method: "POST",
            dataType: "json",
            success: function (result) {
                // With data
                // dfd.resolve(result);
                
                // Without data
                resolve("Stuff worked!");
            },
            error: function (xhr, textStatus, errorThrown) {
                reject(Error("It broke"));
            }
        });
    });
    return promise;
}
```

Calling the SaveComment function

```javascript
SaveComment("My comment")
    .then(function(result) {
        console.log(result); // "Stuff worked!"
    }, function(err) {
        console.log(err); // Error: "It broke"
    });
```
