Date.prototype.getDOY = function () {
    var onejan = new Date(this.getFullYear(), 0, 1);
    return Math.ceil((this - onejan) / 86400000) + 1;
}

var daysClicked = [];

function pageLoad() {
    updateTotalDaysLabel();
    resizeWorkpane();
    resizeDrawer();
    individualOvernightCheckboxes();


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

	$('.input-group.date').datepicker({
	});
}



/*
 * Individual overnight checkbox logic
 */
function individualOvernightCheckboxes() {
    // turn all CheckBoxLists labeled for 'radio' to be single-select
    $('[data-toggle=radio]').each(function () {
        var clientId = $(this).attr('id');
        $(this).find('input').each(function () {
            // set parent's id
            $(this).attr('data-parent', clientId);

            // add an onclick to each input
            $(this).click(function (e) {
                // ensure proper event
                if (!e) e = window.event;
                var sender = e.target || e.srcElement;
                if (sender.nodeName != 'INPUT') return;


                // toggle off siblings
                var id = $(this).attr('id');
                var parent = $(this).attr('data-parent');
                $('input[data-parent=' + parent + ']').not('#' + id).prop('checked', false);
            });
        });
    });

    $('.checkbox-list :checkbox').change(function () {
        var parent = $(this).parent().parent().parent().parent();
        var dateSelection = parent.data().startDate;

        // does it have the appropriate data?
        if (dateSelection) {
            var value = $(this).val();
            var element = $(dateSelection);

            switch (value) {
                case '1': // this is every week
                    $(dateSelection).val('');
                    element.attr('disabled', true);

                    break;

                case '2': // this is every other week
                    $(dateSelection).val('');
                    element.attr('disabled', false);
                    $(dateSelection).focus(1, function () { });
                    break;

                default: // reset everything, something weird happened

                    break;
            }
        }
    });

    $('.IndividualDateStart').change(function () {
        var ClientID = $(this).attr('id');
        var DateString = $(this).val();
        var Checkbox = $('[data-start-date=#' + ClientID + '].checkbox-list [value=2]:checkbox');
        var Parent = Checkbox.parent().parent().parent().parent();
        var DayOfWeek = Parent.data('day');
        HandleBiWeekly(DateString, Checkbox, DayOfWeek);

        updateSelectedLabel($('.CalendarDay.day-checked').length);
    });

    $('.checkbox-list [value=1]:checkbox').change(function () {
        var Parent = $(this).parent().parent().parent().parent();
        var DayOfWeek = Parent.data('day');
        var Checkbox = $(this);
        HandleWeekly(Checkbox, DayOfWeek);

        updateSelectedLabel($('.CalendarDay.day-checked').length);
    });

    $('.checkbox-list [value=2]:checkbox').change(function () {
        var Parent = $(this).parent().parent().parent().parent();
        var DayOfWeek = Parent.data('day');
        var Checkbox = $(this);
        if (!Checkbox.prop('checked')) Uncheck(DayOfWeek);

        updateSelectedLabel($('.CalendarDay.day-checked').length);
    });

    function HandleWeekly(Checkbox, Day) {
        Uncheck(Day);
        if (Checkbox.prop('checked')) CheckWeekly(Day);
    }

    function HandleBiWeekly(DateString, Checkbox, Day) {
        Uncheck(Day);
        var IsChecked = Checkbox ? Checkbox.prop('checked') : false;
        if (!DateString || !IsChecked) return;
        var DateValue = new Date(Date.parse(DateString));

        for (var i = DateValue.getDOY() ; i <= 366; i += 14) {
            CheckBiWeekly(Day, i);
        }
    }

    function Uncheck(day) {
        _.forEach($('.CalendarDay.' + day + '.day-checked.Individual' + day + 'Date'), function (dayCheck) { $(dayCheck).removeClass('day-checked Individual' + day + 'Date'); });
    }

    function CheckWeekly(day) {
        _.forEach($('.CalendarDay.' + day + ':not(.day-checked)'), function (dayCheck) { $(dayCheck).addClass('day-checked Individual' + day + 'Date'); });
    }

    function CheckBiWeekly(day, dayOfYear) {
        _.forEach($('.Day' + dayOfYear + '.CalendarDay.' + day + ':not(.day-checked)'), function (dayCheck) { $(dayCheck).addClass('day-checked Individual' + day + 'Date'); });
    }
}



/**
 * "Days clicked" function helpers
 */
function updateSelectedLabel(daysChecked) {
    $('.tsc-calendar-days-selected-count').text(daysChecked);
}

function updateTotalDaysLabel(daysChecked) {
    var count = daysChecked || $('.CalendarDay').length;
    $('.tsc-calendar-days-total-count').text(count);
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