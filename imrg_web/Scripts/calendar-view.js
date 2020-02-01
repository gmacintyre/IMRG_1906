document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var month = new Date().getMonth();
    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid'],
        defaultDate: '2020-02-01',
        editable: false,
        eventLimit: false, // allow "more" link when too many events
        lazyFetching: true,
        events: {
            url: "/events/calendar"
            
            }
        });

        
    
    calendar.render();
});