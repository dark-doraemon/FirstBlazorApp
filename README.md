## Description
Blazor Event Handling is the process to respond to events like button click, select change, text change on text box, clipboard events, mouse events, etc. Then perfoming some work if the events happen. 

## What will you learn in this section
1. Events in Blazor
>> How do events work in Blazor

. The Blazor JavaScript code receives the event that is triggered and forwards it to the server over the persistent HTTP connection (SignalR) <br>
. Then the handler method is invoked (on the server), and the state of the component is updated (on the server).<br>
. Next, the server sends back the changes on the page content to the JavaScript code, and this JavaScript code updates the content displayed on the browser. All this works instantly and without any page reload.<br>
Nghĩa là nếu có event gì xảy ra thì javascript sẽ gửi những event đó cho server thông qua SignalR, sao khi server xử lý xong nó sẽ trả về những thay đổi cho browser và JS sẽ xử lý những thay đổi này và update lại giao diện. Điều này xảy ra ngay lập tức và không cần load lại trang <br>

See example in code ->  Pages/Iexample.razor
