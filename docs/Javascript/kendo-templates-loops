When you have a [template](http://majorsilence.github.io/Dev/docs/Javascript/kendo-mvvm) you may want to use a for loop.

To do so the following should work.

```html
<div data-bind="source: data" data-template="tmp"></div>
<script id="tmp" type="text/x-kendo-template">
  <div>
    <input data-bind="value: quantity" />
    <span data-bind="text: price"></span>
    <span data-bind="text: total"></span>
     #for (var i=0,len=Accounts.length; i<len; i++){#
            <p>${ Accounts[i] }</p>
     # } #
  </div>
</script>
```
