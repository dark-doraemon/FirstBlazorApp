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

Nghĩa là khi component cha muốn truyền 1 template (1 đoạn mã HTML) cho component con, thì component con được định nghĩa như là một Template Component (nói là Template Component vậy thôi nhưng nó không khác gì component thường), nhưng không phải chúng ta đã học cách truyền template bằng “ChildContent” Property ở bài 3 rồi sao ?

Thì trong Template Component, template mà component cha truyền cho component không phải là template chỉ có HTML tĩnh mà nó đã được áp dụng thêm kiểu dữ liệu 

Như ta đã biết khi component cha truyền template cho component con thì component con sẽ lưu template đó trong một thuộc tính có kiểu là <br>
VD:
```
[Parameter]
public RenderFragment Header1 { get; set; }
```
Ta thấy rằng việc lưu như vậy thì nó chỉ lưu được HTML tĩnh, nó chỉ dùng để hiển thị, ta không truyền data vào nó được

Do đó chúng ta sử dụng <br>
VD:
```
[Parameter]
public RenderFragment<TValue> RowTemplate { get; set; }
```
Nghĩa là template lưu trong RowTemplate đã được áp đụng kiểu dữ liệu là TValue(TValue là dữ liệu ta muốn áp dụng vào template, int, string, Person,Dog,Cat,...)

Để truyền dữ liệu vào template ta chỉ càn sử dụng câu lệnh `<tr>@RowTemplate(dữ liệu muốn truyền vào)</tr>`, nếu TValue là kiểu int thì ta truyền kiểu int, Person thì truyền dữ liệu kiểu Person




In order to make a razor component as Template Component, we should define in them one or more properties of type RenderFragment or RenderFragment<TValue>. These properties should have [Parameter] attribute. See below code where we have defined 2 such properties.

Để định nghĩa một razor component như là Template Component, chúng ta nên định nghĩa trong chúng 1 hay nhiều thuộc tính kiểu `RenderFragment` hoặc `RenderFragment<TValue>` và những thuộc tính này phải có [Parameter] attribute đi kèm
VD: 
```
[Parameter]
public RenderFragment P1 { get; set; }

[Parameter]
public RenderFragment<TValue> P2 { get; set; }
```

See example in code Pages/TemplateComponent/TemplateComponent.razor and TableTemplate.razor



