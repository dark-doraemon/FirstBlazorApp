## Introduction
Blazor App is created with components and these components are built in Razor Components File. Razor components files can be created in Visual Studio and have a .razor extension. Note that the term Blazor Component is same as Razor Component.<br>
Chú ý là Blazor App được tạo bởi Razor component, file có đuôi .razor chứ không phải .blazor

## What will you learn in this section ?
>> 1. What are Razor Components

In Razor Component we create our programming logic which can be of any type like a form which can be filled and submitted by the user, database operation, email sending code, maths logic or anything else. We make this logic using HTML markup and C# codes. The HTML codes forms the UI of the component and can communicate with C# codes. The C# codes are kept inside the @code{…} block.<br>
Trong Razor component chúng ta sử dụng HTML và c# code để tạo thành 1 component, HTML code dùng để tạo UI và có thể tương tác với c# code, c# dùng để xử lý logic và được lưu trong khối @code {...}


>> 2. Seperate razor component file

You should note that all razor component’s names should start with a capital letter. For example, Welcome.razor is valid, and welcome.razor is invalid.
When an app is compiled, the razor component file is converted into a partial class. The name of this generated class is the same as the name of the razor component file.

It is not necessary to keep all the C# codes in the @code block. You can also keep all the C# codes in a code-behind file. For example for a razor component Count.razor all the C# codes can be placed in a separate file called Count.razor.cs with a partial class.

Như đã biết trong razor component phần HTML dành cho UI và c# code cho xử lý logic <br>
Khi blazor compile razor component nó sẽ chuyển thành partial class (1 class cho ui và 1 class cho logic) và tên của class được tạo ra cũng tên với tên file của component (partial class nghĩ là 1 class có thể code ở nhiều file khác nhau) <br>
Do đó ta có thể sử dụng cơ chế này của blazor để tách ra thành 2 file riêng biệt với điều kiện file .razor.vs phải có partial (public partial class Count {})

See example in code -> Pages/Count/Count.razor and Count.razor.cs
