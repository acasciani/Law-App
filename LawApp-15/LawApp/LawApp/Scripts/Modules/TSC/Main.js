function pageLoad() {
    updateTotalDaysLabel();
    resizeWorkpane();
    resizeDrawer();

	var daysClicked = [];

	$('td.CalendarDay').on('click', function () {
	    if(!$(this)) return; // The this selector should never be null, but if it is then just return
	    var htmlElement = $(this);
	    var dayId = $(this).attr('id');

	    // Add or remove the check mark
	    htmlElement.toggleClass('day-checked');

	    if (_.includes(daysClicked, dayId)) {
	        // This day was previously clicked, remove it.
	        _.remove(daysClicked, function (id) { return id === dayId; });
	    } else {
	        // This day was never clicked, add it.
	        daysClicked.push(dayId);
	    }

	    updateSelectedLabel(daysClicked.length);
	});

	$('.panel a.panel-title').on('click', function () {
	    setTimeout(function() {
	        resizeDrawer();
	    }, 300);
	});
}



/**
 * "Days clicked" function helpers
 */
function updateSelectedLabel(daysChecked) {
$('#tsc-calendar-days-selected-count').text(daysChecked);
}

function updateTotalDaysLabel(daysChecked) {
    var count = daysChecked || $('.CalendarDay').length;
    $('#tsc-calendar-days-total-count').text(count);
}



/**
 * Resize window functions
 */
$(window).resize(function () { resizeCalendarMonthColumns(); });
$(function () { resizeCalendarMonthColumns(); });

function resizeCalendarMonthColumns() {
    var maxCalendarMonthHeight = Math.max.apply(null, $(".column-calendar-month").map(function () {
        return $(this).height();
    }).get());

    $('.column-calendar-month').height(maxCalendarMonthHeight);
}