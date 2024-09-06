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

Nghĩa là khi component con nhận tempate từ component cha, thì component con được định nghĩa như là một Template Component (nói là Template Component vậy thôi nhưng nó không khác gì component thường), nhưng chúng ta đã học cách truyền template bằng “ChildContent” Property ở bài 3 rồi, tại sao bây giờ lại có định nghĩa khác nữa ?

Thì trong Template Component, template mà component cha truyền cho component không phải là template tĩnh mà nó đã được áp dụng thêm kiểu dữ liệu, tức là template động

Như ta đã biết khi component cha truyền template cho component con thì component con sẽ lưu template đó trong một thuộc tính có kiểu là <br>
VD:
```
[Parameter]
public RenderFragment Header1 { get; set; }
```
Việc lưu như vậy thì nó chỉ lưu được HTML tĩnh, nó chỉ dùng để hiển thị, ta không truyền data vào nó được

Do đó chúng ta sử dụng <br>
VD:
```
[Parameter]
public RenderFragment<TValue> RowTemplate { get; set; }
```
Nghĩa là template lưu trong RowTemplate đã được áp đụng kiểu dữ liệu là TValue(TValue là dữ liệu ta muốn áp dụng vào template, int, string, Person,Dog,Cat,...)

Để truyền dữ liệu vào template ta chỉ càn sử dụng câu lệnh `<tr>@RowTemplate(dữ liệu muốn truyền vào)</tr>`, nếu TValue là kiểu int thì ta truyền kiểu int, Person thì truyền dữ liệu kiểu Person

Tóm lại 
```
[Parameter]
public RenderFragment Header1 { get; set; }
```
Sẽ lưu template tĩnh 

Trong khi đó
```
[Parameter]
public RenderFragment<TValue> Header1 { get; set; }
```
Sẽ lưu template động

Còn không hiểu nữa thì xem trong code thì sẽ hiểu những gì tui vừa nói


See example in code Pages/TemplateComponent/TemplateComponent.razor and TableTemplate.razor


>> 2. Cascading Values and Parameters

Blazor provides a convenient way for transferring data from parent to child components in hierarchy by the use of Cascading Values and Parameters. Suppose there are 3 Razor components – One.razor, Two.razor & Three.razor. One.razor is the parent of Two.razor. While Two.razor is the parent of Three.razor.

Nếu One component muốn truyền value cho Three component thì Two component phải tham gia truyền value, điều này không cần thiết vì nó lôi các component không liên quan vào

Do đó Blazor đã xây dựng sẵn một component tên là `CascadingValue`, component này có một thuộc tính là `Value`, nó sẽ nhận data cần truyền

Cách sử dụng là dùng `CascadingValue` bọc một component, thì các component con, cháu, chắt, ... của component đó sẽ đều nhận được value

See example in code -> Pages/CascadingValuesAndParameters/CascadingValuesAndParameters.razor

>> 3. Multiple Cascading Parameters

Nếu chúng ta muốn truyền nhiều giá trị khác nhau cho một component thì rất đơn giản, chỉ cần nest nhiếu `CascadingValue` component lại thôi và đặt tên cho nó
```
<CascadingValue Name="Cascade1" Value="@MyMessage">
      <CascadingValue Name="Cascade2" Value="@MyNumber">
          <ComponentYouWantToPassvalue/>
      </CascadingValue>
</CascadingValue>
```
Nếu muốn chon Value thì truyền tên vào thôi
```
[CascadingParameter(Name ="Cascade1")]
```
Cái này không cần giải thích gì nhiều chỉ cần xem code là hiểu 

See example in code -> Pages/CascadingValuesAndParameters/MultiCascading.razor

>> 4. Handling Errors in Blazor (Phần này không quan trọng lắm, chỉ là css lại các thông báo lỗi thôi, có thể bỏ qua khi nào thầy cần thì quay lại)

 Blazor Errors can be defined by 2 types, which are:

1. Connection Errors
2. Application Errors

### Connection Errors

Blazor dự trên kết nối HTTP liên tục giữa Browser và Server, nếu mất kết nối thì nó sẽ hiện lỗi như thế này `Attempting to reconnect to the server: 1 of 8`

chúng ta có thể custom lại thông báo đó -> xem code tại `Pages/Error/Error.razor` (cái này cũng không quan trọng lắm có thể bỏ qua)

### Application Errors

Khi chương trình bị throw Exception() thì Blazor sẽ kiếm phần tử có id là `blazor-error-ui` và set css của nó có thuộc tính `display: block`, khi đó cần phải reload (F5) lại thì chương trình mới tiếp tục chạy


See example in code -> Pages/Error/Error.razor and CustomErrorMessage.razor






