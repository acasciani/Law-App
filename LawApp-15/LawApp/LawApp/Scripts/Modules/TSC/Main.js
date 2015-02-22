Date.prototype.getDOY = function () {
    var onejan = new Date(this.getFullYear(), 0, 1);
    return Math.ceil((this - onejan) / 86400000) + 1;
}

Date.prototype.getDayFullName = function () {
    switch (this.getDay()) {
        case 0: return 'Sunday';
        case 1: return 'Monday';
        case 2: return 'Tuesday';
        case 3: return 'Wednesday';
        case 4: return 'Thursday';
        case 5: return 'Friday';
        case 6: return 'Saturday';
        default: 'Unknown';
    }
}

var daysClicked = [];
var holidays = [];

function pageLoad() {
    checkboxSettings();
    updateTotalDaysLabel();
    resizeWorkpane();
    resizeDrawer();
    individualOvernightCheckboxes();
    btnClearCalendar();
    getHolidaysFromServer();
    holidayCheckboxes();
    weekendOvernightCheckboxes();

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

	$('.input-group.date.sunday-only').datepicker({ daysOfWeekDisabled: [1, 2, 3, 4, 5, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.monday-only').datepicker({ daysOfWeekDisabled: [0, 2, 3, 4, 5, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.tuesday-only').datepicker({ daysOfWeekDisabled: [0, 1, 3, 4, 5, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.wednesday-only').datepicker({ daysOfWeekDisabled: [0, 1, 2, 4, 5, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.thursday-only').datepicker({ daysOfWeekDisabled: [0, 1, 2, 3, 5, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.friday-only').datepicker({ daysOfWeekDisabled: [0, 1, 2, 3, 4, 6], clearBtn: true, autoclose: true });
	$('.input-group.date.saturday-only').datepicker({ daysOfWeekDisabled: [0, 1, 2, 3, 4, 5], clearBtn: true, autoclose: true });

	$('.input-group.date').datepicker({ clearBtn: true, autoclose: true });
}



/*
 * Individual overnight checkbox logic
 */
function individualOvernightCheckboxes() {
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
                    if ($(this).prop('checked')) { $(dateSelection).focus(1, function () { }); }
                    else { element.attr('disabled', true); }
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
        HandleBiWeekly(DateString, Checkbox, DayOfWeek, Uncheck, CheckBiWeekly);

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



/*
 * Weekend overnight checkbox logic
 */
function weekendOvernightCheckboxes() {
    $('.checkbox-weekend :checkbox').change(function () {
        var dateSelection = '.WeekendDateStart';
        var element = $(dateSelection);
        var IsChecked = $(this).prop('checked');

        $(dateSelection).val('');

        element.attr('disabled', !IsChecked);
        if (IsChecked) { $(dateSelection).focus(1, function () { }); }
        else { Uncheck('Friday'); Uncheck('Saturday'); }
    });

    $('.WeekendDateStart').change(function () {
        var ClientID = $(this).attr('id');
        var DateString = $(this).val();
        var Checkbox = $('.checkbox-weekend :checkbox');
        
        if (Checkbox.prop('checked') && !isNaN(Date.parse(DateString))) {
            var friday = new Date(Date.parse(DateString));
            var saturday = new Date(friday);
            saturday.setDate(friday.getDate() + 1);
            var sunday = new Date(saturday);
            sunday.setDate(saturday.getDate() + 1);

            HandleBiWeekly(friday, Checkbox, 'Friday', Uncheck, Check);
            HandleBiWeekly(saturday, Checkbox, 'Saturday', Uncheck, Check);
        }
    });

    function Uncheck(Day) {
        _.forEach($('.CalendarDay.day-checked.' + Day + '.WeekendDate'), function (dayCheck) { $(dayCheck).removeClass('day-checked WeekendDate'); });
        updateSelectedLabel($('.CalendarDay.day-checked').length);
    }

    function Check(Day, dayOfYear) {
        _.forEach($('.CalendarDay.Day' + dayOfYear + '.' + Day + ':not(.day-checked)'), function (dayCheck) { $(dayCheck).addClass('day-checked WeekendDate'); });
        updateSelectedLabel($('.CalendarDay.day-checked').length);
    }
}



/*
 * Holidays toolbar logic
 */
function getHolidaysFromServer() {
    var inyear = (new Date()).getFullYear();
    $.ajax({
        url: '/api/Holidays?inyear=' + inyear
    }).done(function (data) {
        var sorted = _.sortBy(data, function (holiday) {
            return holiday.HolidayDate;
        });

        _.forEach(sorted, function (holiday) {
            var jsDate = new Date(Date.parse(holiday.HolidayDate));
            holidays.push({
                Name: holiday.Name,
                Description: holiday.Description ? holiday.Description : '',
                HolidayDate: jsDate,
                HolidayYear: jsDate.getFullYear(),
                HasDescription: holiday.Description != undefined && holiday.Description != null,
                CssClass: holiday.BackgroundClass ? holiday.BackgroundClass : 'holiday-color-default'
            });
        });

        addHolidayToKey(holidays); // use global holidays collection
        holidayCheckboxes(); // because ajax is async, we need to make sure that the dates are available if we do pageLoad holiday markings
    });

    function addHolidayToKey(holidays) {       
        $('#holiday-key-container .holiday-key').remove(); // remove any existing keys. probably just the template

        _.forEach(holidays, function (holiday) {
            var tempElement = document.createElement('div');
            tempElement.classList.add(holiday.CssClass);
            tempElement.classList.add('holiday-key');
            tempElement.innerText = holiday.Name;
            $('#holiday-key-container').append(tempElement);
        });
    }
}

function holidayCheckboxes() {
    $('.checkbox-holidays :checkbox').prop('checked', true); // the check box will be checked on pageload, if this is not desired remove this line
    applyDots(); // holidays will be marked on page load, if this isn't desired remove this line.

    $('.checkbox-holidays :checkbox').change(function () {
        var IsChecked = $(this).prop('checked') === true;

        if (IsChecked) {
            applyDots();
        } else {
            $('.CalendarDay.holiday').removeClass(function (index, css) {
                return (css.match(/(^|\s)holiday-color-\S+/g) || []).join(' ');
            });
            $('.CalendarDay').removeClass('holiday');
        }
    });

    function applyDots() {
        _.forEach(holidays, function (holiday) {
            var dayOfYear = holiday.HolidayDate.getDOY();
            $('.CalendarDay.Day' + dayOfYear).addClass('holiday ' + holiday.CssClass);
        });
    }
}



/*
 * Adds functionality for button group on calendar page.
 */
function btnClearCalendar() {
    // Add clear functionality
    $('#btnClearCalendar').click(function () {
        _.forEach($('.CalendarDay.day-checked'), function (dayCheck) {
            $(dayCheck).removeClass('day-checked');
            $(dayCheck).removeClass('IndividualSundayDate');
            $(dayCheck).removeClass('IndividualMondayDate');
            $(dayCheck).removeClass('IndividualTuesdayDate');
            $(dayCheck).removeClass('IndividualWednesdayDate');
            $(dayCheck).removeClass('IndividualThursdayDate');
            $(dayCheck).removeClass('IndividualFridayDate');
            $(dayCheck).removeClass('IndividualSaturdayDate');
        });

        resetReportingNumbers();
        resetToolbar();
        updateSelectedLabel($('.CalendarDay.day-checked').length);
    });

    function resetToolbar() {
        // Uncheck buttons in toolbar, but not all of them! for instance, we want things like holidays to be checked if it was checked before
        $('#criteria-individual-overnights input[type="checkbox"]').prop('checked', false);
        $('.IndividualDateStart').val('');
        $('.IndividualDateStart').attr('disabled', true);
    }

    function resetReportingNumbers() {
        daysClicked = [];
    }
}



/**
 * "Days clicked" function helpers
 */
function updateSelectedLabel(daysChecked) {
    var percentage = daysChecked / $('.CalendarDay').length;
    $('.tsc-calendar-days-selected-count').text(daysChecked); // whole number
    $('.tsc-calendar-days-selected-percentage').text((percentage * 100).toFixed(2)); // percentage
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



/**
 * Utilities
 */
function checkboxSettings() {
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
}

function HandleBiWeekly(DateString, Checkbox, Day, UncheckCB, CheckCB) {
    UncheckCB(Day);
    var IsChecked = Checkbox ? Checkbox.prop('checked') : false;
    if (!DateString || !IsChecked || isNaN(Date.parse(DateString))) return;
    var DateValue = new Date(Date.parse(DateString));

    // Check all the days greater than the selected one
    for (var i = DateValue.getDOY() ; i <= 366; i += 14) {
        CheckCB(Day, i);
    }

    // Check all the days less than the selected one
    for (var i = DateValue.getDOY() ; i >= 1; i -= 14) {
        CheckCB(Day, i);
    }
}