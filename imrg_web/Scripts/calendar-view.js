document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid'],
        defaultDate: '2019-08-12',
        editable: true,
        eventLimit: true, // allow "more" link when too many events
        events: function(start, end, callback) {
            $.ajax({
                type: "GET",    //WebMethods will not allow GET
                url: "events/calendar",
                //completely take out 'data:' line if you don't want to pass to webmethod - Important to also change webmethod to not accept any parameters 
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (doc) {
                    var events = [];   //javascript event object created here

                    var obj = doc;
                    $(obj).each(function () {
                        events.push({
                            title: $(this).attr('title'),  //your calevent object has identical parameters 'title', 'start', ect, so this will work
                            start: $(this).attr('start'), // will be parsed into DateTime object    
                            end: $(this).attr('end'),
                            id: $(this).attr('id')
                        });
                    });
                    if (callback) callback(events);
                }
            

    }
});
    calendar.render();
});