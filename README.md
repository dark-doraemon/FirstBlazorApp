## Introduction
Blazor App is created with components and these components are built in Razor Components File. Razor components files can be created in Visual Studio and have a .razor extension. Note that the term Blazor Component is same as Razor Component.<br>
Chú ý là Blazor App được tạo bởi Razor component, file có đuôi .razor chứ không phải .blazor

## What will you learn in this section ?
>> 1. What are Razor Components

In Razor Component we create our programming logic which can be of any type like a form which can be filled and submitted by the user, database operation, email sending code, maths logic or anything else. We make this logic using HTML markup and C# codes. The HTML codes forms the UI of the component and can communicate with C# codes. The C# codes are kept inside the @code{…} block.<br>
Trong Razor component chúng ta sử dụng HTML và c# code để tạo thành 1 component, HTML code dùng để tạo UI và có thể tương tác với c# code, c# dùng để xử lý logic và được lưu trong khối @code {...} <br>


>> 2. Seperate razor component file

You should note that all razor component’s names should start with a capital letter. For example, Welcome.razor is valid, and welcome.razor is invalid.
When an app is compiled, the razor component file is converted into a partial class. The name of this generated class is the same as the name of the razor component file.

It is not necessary to keep all the C# codes in the @code block. You can also keep all the C# codes in a code-behind file. For example for a razor component Count.razor all the C# codes can be placed in a separate file called Count.razor.cs with a partial class.

Như đã biết trong razor component phần HTML dành cho UI và c# code nằm trong @code {} cho xử lý logic <br>
Khi blazor compile razor component thì razor component sẽ chuyển thành partial class (1 class cho ui và 1 class cho logic) và tên của class được tạo ra cùng tên với tên file của component (partial class nghĩ là 1 class có thể code ở nhiều file khác nhau) <br>
Do đó ta có thể sử dụng cơ chế này của blazor để tách ra thành 2 file riêng biệt với điều kiện file .razor.cs phải có partial (vd: public partial class Count {})

See example in code -> Pages/Count/Count.razor and Count.razor.cs

>> 3. How Blazor renders Razor Components

Blazor keeps a track of the component on the server. When the component is initially rendered, the component’s render tree is formed by Blazor on the server. Now when this render tree is modified, due to events done by the user on the browser like button click, form submission, etc, then a new render tree is formed. Blazor then compares the new render tree against the previous one and applies any modifications to the browser’s Document Object Model (DOM).

In simple terms, Blazor sends the changes to the browser using SignalR and user sees these changes instantly. Remember only the changes are sent to the browser and not the whole render tree. This is a very light weight process and this makes Blazor extremely fast.

Cái này đọc để cho hiểu thôi, là Blazor sẽ theo dõi các component và tạo thành component’s render tree trên server và component’s render tree sẽ cũng được gửi tới browser. Khi component’s render tree ở browser bị thay đổi (như là click,...) thì nó sẽ gửi nhưng thay đổi cho server,server sẽ so sánh nhũng thay đổi, cuối cùng áp dụng lên những thay đổi lên DOM của browser <br>
Lý so server thay đổi thì browser thay đổi theo là blazor server sử dụng SignalR

>> 4. Parent-Child relationship – Calling Razor Components from another Razor Components

Two or more Razor Components can be combined together to form more complex features. A parent-child relationship between components is a perfect example of this scenario.

See example in code -> Pages/City.razor

>> 5. Calling Components from Razor Pages or MVC views

A Razor Component can be called from a Razor Page or an MVC View by using the Component Tag Helper. <br>
Component Tag Helper ->  `<component type="typeof(NameOfComponent)" render-mode="Server" />` <br>

Ở đây ta cần hiểu ra Razor pages là gì ?<br>
* Razor page có đuôi là .cshtml
* Razor page là một trang riêng hoàn toàn không liên quan gì tới các trang khác, và razor page là nơi đầu tiên gọi component, nó không phải là component
* Vì Razor page là một trang riêng biệt nên mỗi file phải có `<!DOCTYPE html>` riêng
* Vì mỗi trang có một `<!DOCTYPE html>` riêng nên khi sử dụng bootstrap ta phải khai báo lại link của bootstrap
* Khi di chuyển từ một razor page sang một razor page khác thì nó sẽ chuyển sang một trang hoàn toàn mới không liên gì tới trang trước nữa (để ý nút reload xoay)
> [!TIP]
> Trong file _Host.cshtml là một razor page (giống với file index.html trong các front-end framework khác) <br>
> Và _Host.cshtml gọi component App.razor bằng `<component type="typeof(App)" render-mode="ServerPrerendered" />` (giống với gọi App.jsx trong ReactJS) <br>

See example in code -> Pages/Hello.cshtml

>> 6. Component Parameters – Transferring values from Parent to Child component

In blazor, components not only are used for display but also interact with each other <br>
To do that, we need to pass data between them

See example in -> Pages/PasingData.razor

>> 7. Using Component Parameters to transfer values from Razor Pages or MVC Views

When you want to send values to Component Parameters through Razor pages or MVC views than you need to add “param-” before the attribute name. <br>
Nghĩa là ta có thể truyền value từ razor page cho component chứ không chỉ là từ component cha truyền data cho component con
 `<component type="typeof(CitySelection)" render-mode="Server" param-MyCity="@("Mumbai")" param-MyBackground="@("bg-warning")"/>` \

See example in -> Pages/Hello.cshtml

>> 8. Transfer bulk values with “CaptureUnmatchedValues” property

A single property can receive multiple values that have not been matched by other properties. Let us understand how to do it.<br>
Có nghĩa là 1 property có thể nhận được nhiều value cũng lúc, chứ không nhất thiết 1 property chỉ chứa 1 value <br>
Chúng ta làm bằng cách tạo ra một property có dạng giống vậy <br>
```
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object> InputAttributes { get; set; }
```
Dictionary là CTDL dạng key value nên ta có thể đặt từ key lấy ra value

See example in -> Pages/City2.razor and CitySelection2.razor 


>> 9. Blazor Route Parameters

A Route Parameter is provided in the URL by wrapping it inside braces. It is specified in the Razor Component @page directive. <br>
Example: `@page "/Tech/{Framework?}"` <br>
The “?” at the end of route parameter specify that the parameter accepts null value

`Here Framework is the Route Parameter`. You can get the value of the route parameter by specifying a property by the same name as the route parameter and having [Parameter] attribute over it. <br>
Tóm lại là để lấy route parameter thì ta tạo ra một thuộc tính cùng tên với route parameter và có [Parameter] attribute ở trên nó
```
[Parameter]
public string Framework { get; set; }
```


We can have more than 1 route parameters.
```
@page "/Tech/{Company}/{Framework?}"
```
Route Constraints
```
@page "/Tech/{Company}/{Framework:int}"
```
Framework chỉ nhận các giá trị kiểu int do đó ta phải update c# code Framework là kiểu int <br>

Some example of Route Constraints: <br>
| Constraint	   | Example         | Comments                                                                         |
| ------------- | ----------------|----------------------------------------------------------------------------------|
| bool          | {active:bool}   |active value should be either true or false.                                      |
| datetime      | {cur:datetime}  |cur value should be in date time format. Examples – 2021-10-31, 2022-11-20 4:32am |
| decimal       | {price:decimal} |Example – 100.33                                                                  |
| float         | {sum:float}     |Example – 61.984                                                                  |
| int           | {id:int}        |Example of id – 1000                                                              |
| long          | {average:long}  |Example of average – 98957875748697                                               |



> Catch-all route parameters

You can also catch all route parameters with just a single C# property. To do so apply * in front of route parameter. <br>
Ex – @page "/Catch/{*AllCatch}". So now any number of route parameters will be caught by the “AllCatch” route parameter.
```
@page "/Catch/{*AllCatch}"
 
<h1 class="bg-info text-white">@AllCatch</h1>
 
@code {
    [Parameter]
    public string AllCatch { get; set; }
}
```
See example in -> Pages/RouteParameter.razor

>> 10. “ChildContent” Property

We can pass a value to a razor component by `ChildContent property`. This property should be of `RenderFragment type` and `must be named ChildContent by convention`.
```
[Parameter]
public RenderFragment ChildContent { get; set; }
```

The value to the ChildContent property is provided inside the name tag of the razor component during its call.<br>
Nghĩa là khi ta sử dụng cú pháp opening and closing tag như vậy <br>
`<CustomComponent></CustomComponent>` <br>
Thì ta có thể truyền data cho component ở giữa opening and closing tag
```
<CustomComponent>
     <div>Content</div>
</CustomComponent>
```
Nó giống với children của ReactJS

See example in -> Pages/ChildContent.razor and TempComponent.razor

> Transferring multiple values through “ChildContent” Property

Multiple values can be transferred with the help of ChildContent property. All you have to do is to create `nodes containing values inside them. Add these nodes inside the name of the razor component (where it is called). <br>
Nghĩa là trong 1 component có thể có nhiều ChildContent property nhưng nếu nếu ta đặt data ở giữa opening and closing tag làm sao nó biết data đó của ChildContent property nào
Thì ta có 1 cách gọi là tạo node <br>
VD:
```
<TempComponent2>
    <Description><label>Commercial capital of India</label></Description>
    <Weather>Moderate and Humid</Weather>
    <Elevation>14 m</Elevation>
</TempComponent2>
```
Lưu ý Description, Weather, Elevation không phải là các component, ta có thể gọi chúng là các node, mỗi node tương ứng với một ChildContent property <br>
Trong TempComponent2
```
@code {
    [Parameter]
    public RenderFragment Description { get; set; }
 
    [Parameter]
    public RenderFragment Weather { get; set; }
 
    [Parameter]
    public RenderFragment Elevation { get; set; }
}
```
Do đó nó có thể biết được data thuộc về ChildContent property nào

See example in -> Pages/ChildComponent.razor - line 32 and TempComponent2.razor

>> 11. Transferring values from Child Razor Component to Parent Razor Component

Let us now see how to transfer values from Child Razor Component to Parent Razor Component in Blazor. <br>
To do this, we will create this feature by creating a custom event `in the child component` and parent component can register a handler method <br>
This custom event is defined by adding a property whose type is EventCallback<T>. 
