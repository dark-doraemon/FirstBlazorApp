## Introduction
In this tutorial we will cover Razor Components in advanced manner and build the foundation for concepts of Custom Binding, Template Components, Generic Template Components & Cascading Parameters. Let’s understand each of them one by one with lots of examples.

## What will you learn in this section ?

>> 1. Chained Bind – Binding between Parent & Child components

Chained Bind is a custom two-way Data Binding between Parent and Child Razor Components. Here, a binding of a child razor component’s property is done with a property of the parent razor component. In Chain Bind, multiple levels of binding occur simultaneously.
Chained Bind là một custom two-way data binding giữa component cha và con. Ở đây, việc liên kết thuộc tính của component con được thực hiện với thuộc tính của component cha
1. Luồng value được truyền theo hệ thống cấp bật xuống, từ component cha -> component con
2. Thông báo thay đổi sẽ truyền theo hệ thông cấp bật lên, từ component con -> component cha

See example in code -> Pages/ChainedBind/Parent.razor and Child.razor

>> 2. Blazor Template Components – “Code Reusability”

Blazor Template Component is used to customize the user interface (UI) by the use of templates which supports reusable codes. You will love the way they work so stay tuned and feel their complete power.

In order to make a razor component as Template Component, we should define in them one or more properties of type RenderFragment or RenderFragment<TValue>. These properties should have [Parameter] attribute. See below code where we have defined 2 such properties.

Để định nghĩa một razor component như là Template Component, chúng ta nên định nghĩa trong chúng 1 hay nhiều thuộc tính kiểu `RenderFragment` hoặc `RenderFragment<TValue>` và những thuộc tính này phải có [Parameter] attribute đi kèm
VD: 
```
[Parameter]
public RenderFragment P1 { get; set; }

[Parameter]
public RenderFragment<TValue> P2 { get; set; }
```


