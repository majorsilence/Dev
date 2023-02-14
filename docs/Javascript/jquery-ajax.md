---
layout: base
title: Jquery ajax
---

Call service

# Typescript example using jquery ajax

```typescript
function SaveComment(msg) {
  return $.ajax({
      url: "/some/url",
      data: {
          Message: msg
      },
      method: "POST",
      // dataType is the return data type
      dataType: "json"
  });
}
```

Calling the SaveComment function

```javascript
SaveComment("My comment")
  .done(function (data) {
      alert("The SaveComment function ajax call has finished");
  })
  .fail((xhr) => {
      alert("failed");
    });
```


# Example 2

```typescript
$.ajax({
      url: "/some/url",
      data: {
          Message: msg
      },
      method: "POST",
      dataType: "json"
  })
  .done(function (data) {
      alert("The SaveComment function ajax call has finished");
  })
  .fail((xhr) => {
      alert("failed");
    });
  
```

# Example 3 - POST Json

Using JSON.stringify to call mvc service with a model parameter.

The important part is to make sure you set

> contentType: "application/json; charset=utf-8"

```typescript

let someData = {
    Stuff1: this.viewModel.get("Stuff1"),
    Stuff2: this.viewModel.get("Stuff2"),
}

$.ajax({
      url: "/some/url",
      data: {
          Message: msg
      },
      method: "POST",
      contentType: "application/json; charset=utf-8",
  })
  .done(function (data) {
      alert("The SaveComment function ajax call has finished");
  })
  .fail((xhr) => {
      alert("failed");
    });
  
```

