## Description
Blazor Event Handling is the process to respond to events like button click, select change, text change on text box, clipboard events, mouse events, etc. Then perfoming some work if the events happen. 

## What will you learn in this section
>> 1. Events in Blazor

How do events work in Blazor ?

. The Blazor JavaScript code receives the event that is triggered and forwards it to the server over the persistent HTTP connection (SignalR) <br>
. Then the handler method is invoked (on the server), and the state of the component is updated (on the server).<br>
. Next, the server sends back the changes on the page content to the JavaScript code, and this JavaScript code updates the content displayed on the browser. All this works instantly and without any page reload.<br>
Nghĩa là nếu có event gì xảy ra thì javascript sẽ gửi những event đó cho server thông qua SignalR, sao khi server xử lý xong nó sẽ trả về những thay đổi cho browser và JS sẽ xử lý những thay đổi này và update lại giao diện. Điều này xảy ra ngay lập tức và không cần load lại trang <br>

See example in code ->  Pages/Iexample.razor

>> 2. Preventing Default Events (preventDefault) 

Suppose a button is kept inside an HTML form tag. Then on clicking the button, the form gets submitted. This is called as the default behaviour of a button click event. Now suppose we add an onclick event to the button. Inside this event we do some work like increasing the counter by 1 every time the button is clicked. When you click, you will notice that on clicking the button, the form gets submitted but the button’s onclick event will not be executed. <br>
Nghĩa là mặc định nếu ta để 1 button trong trong thẻ form thì button này sẽ tự động được thêm event handler là form submit tức là send nội dụng của form (cái này là mặc đinh của html chứ không phải của framework nào cả). Vì vậy nếu ta thêm event handler vào button này thì nó sẽ không hoạt động mà nó chỉ kích hoạt event handler form submit. Vì vậy phần này sẽ hướng dẫn cách xử lý sự kiện mặc định này

See example in code -> Pages/DefaultEvent.razor

>> 3. Event propagation

Suppose I have a div tag that contains a button. Both the div and button have onclick events. So, when I click the button then both the onclick events get’s executed. That is, first the onclick event of the button is executed and then the onclick event of the div gets executed. This is an unexpected behaviour and happens due to propagation of events from child towards the parents. <br>
Nghĩa là ta có một button trong một thẻ div khi ta và cả 2 thẻ này đều có @onclick. Khi ta click vào button thì thì cả 2 sự kiện này đều được kích hoạt, đầu tiên là từ button sao đó tới thẻ div, nó có thể gây ra một số hành vi chúng ta không mong muốn. Phần này sẽ hướng dẫn cách giải quyết. 

See example in code ->  Pages/EventPropagation.razor

>> 4. Blazor Data Bindings

See example in code ->  Pages/DataBinding.razor

