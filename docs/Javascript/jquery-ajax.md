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
