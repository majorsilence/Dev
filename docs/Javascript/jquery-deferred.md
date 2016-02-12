---
layout: base
title: Jquery deferred object
---

Defer an action until later.

# Typescript example using JQuery.Deferred

```typescript
function SaveComment(msg) : JQueryDeferred<any> {
  var dfd = jQuery.Deferred();
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
          dfd.resolve();
      },
      error: function (xhr, textStatus, errorThrown) {
          dfd.reject();
      }
  });

  return dfd;
}
```

Calling the SaveComment function

```javascript
SaveComment("My comment")
  .done(function () {
      alert("The SaveComment function ajax call has finished");
  });
```
