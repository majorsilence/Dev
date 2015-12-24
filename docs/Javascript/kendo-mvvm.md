---
layout: base
title: Kendo MVVM
---

[Kendo core](https://github.com/telerik/kendo-ui-core) is an open source javascript framework.   This example is built on it.

Separate your model and view.  Quickly bind your data to html.  
These examples are taken directly from the linked telerik documentation.

Bind in html by using __data-bind="bindtype: valueProperty"__

List of all [binding types](http://docs.telerik.com/KENDO-UI/framework/mvvm/bindings/attr).

# Simple Binding

### Javascript
```javascript
<script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
<script src="http://kendo.cdn.telerik.com/2015.2.805/js/kendo.all.min.js"></script>

<script type="text/javascript">
var viewModel = kendo.observable({
    name: "John Doe",
    displayGreeting: function() {
        var name = this.get("name");
        alert("Hello, " + name + "!!!");
    }
});

kendo.bind($(document.body), viewModel);
</script>
```

### Html
```html
<div id="view">
    <input data-bind="value: name" />
    <button data-bind="click: displayGreeting">Display Greeting</button>
</div>
```

# Bind to Template

### Javascript
```javascript
<script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
<script src="http://kendo.cdn.telerik.com/2015.2.805/js/kendo.all.min.js"></script>

<script type="text/javascript">

var Product = kendo.data.Model.define({
  fields: {
    "quantity": {
      type: "number"
    },
    "price": {
      type: "number"
    }
  },
  total: function() { //define the calculated field
    return this.get("quantity") * this.get("price");
  }
});

var viewModel = kendo.observable({
  data: [
    new Product({ "quantity": 1, "price": 2 }),
    new Product({ "quantity": 5, "price": 1.99 }),
  ]
});
kendo.bind($(document.body), viewModel);

</script>
```

### Html
```html
<div data-bind="source: data" data-template="tmp"></div>
  <script id="tmp" type="text/x-kendo-template">
    <div>
      <input data-bind="value: quantity" />
      <span data-bind="text: price"></span>
      <span data-bind="text: total"></span>
    </div>
  </script>
```

### Send viewModel back to service for processing.

```javascript
var data = viewModel.toJSON();
$.ajax({
    url: "/your/service/path",
    method: "POST",
    data: {
        YourQueryStringName: JSON.stringify(data)
    },
    success: function (data, textStatus, jqXHR) {
        Alert("Data Saved");
    },
    error: function (xhr, textStatus, errorThrown) {
        alert(errorThrown);
    }
});
```

C# service code

```c#
var data = GetPostData();
var myJson = JsonSerializer.DeserializeFromString<YourType>(data["YourQueryStringName"]);

public static NameValueCollection GetPostData()
{
    if (HttpContext.Current.Request.HttpMethod != "POST")
    {
        return null;
    }
    using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
    {
        // This will equal to "charset = UTF-8 & param1 = val1 & param2 = val2 & param3 = val3 & param4 = val4"
        var value = reader.ReadToEnd();
        var query = HttpUtility.ParseQueryString(value, Encoding.UTF8);

        foreach (var item in query.AllKeys)
        {
            query[item] = HttpUtility.UrlDecode(query[item]);
        }
        return query;
    }
}
```


# Read More

Read more at [mvvm overview](http://docs.telerik.com/kendo-ui/framework/mvvm/overview).
