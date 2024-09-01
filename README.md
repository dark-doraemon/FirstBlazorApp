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



