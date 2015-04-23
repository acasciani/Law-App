var staged = {};


function saveCalendar() {
    $.removeCookie('StagedCalendar');
    staged = {};
    $.cookie.json = true;
    saveCaseInformation();
    saveWeekendOvernights();
    saveIndividualOvernights();
    saveHolidays();
    saveBreaks();
    saveUniqueDays();
}


function stage(group, key, value) {
    if (value === '' || value === undefined || value === null) return;
    if (!staged[group]) {
        staged[group] = {};
    }
    staged[group][key] = value;
    $.cookie('StagedCalendar', staged);
}

function stageObject(group, objectValue) {
    if (objectValue === '' || objectValue === undefined || objectValue === null) return;
    staged[group] = objectValue;
    $.cookie('StagedCalendar', staged);
}


function saveCaseInformation() {
    var Exhibit = $('#Exhibit').val();
    var CaseName = $('#CaseName').val();
    var CaseNumber = $('#CaseNumber').val();
    stage('CaseInformation', 'Exhibit', Exhibit);
    stage('CaseInformation', 'CaseName', CaseName);
    stage('CaseInformation', 'CaseNumber', CaseNumber);
}


function saveWeekendOvernights() {
    var IsSelected = $('#criteria-weekend-overnights .checkbox-weekend input[type=checkbox]:checked').length == 1;
    var StartDate = $('#criteria-weekend-overnights .WeekendDateStart').parent('.input-group.date').datepicker('getDate');
    stage('WeekendOvernights', 'IsSelected', IsSelected);
    if (!isNaN(StartDate)) stage('WeekendOvernights', 'StartDate', StartDate);
}


function saveIndividualOvernights() {
    var repeater = $('#criteria-individual-overnights .checkbox-list');

    _.forEach(repeater, function (chboxSet) {
        var obj = {};
        var day = $(chboxSet).data('day');
        var Start = $(chboxSet).parent().find('.input-group.date').datepicker('getDate');
        var EveryActive = $(chboxSet).find('input[type=checkbox][value=1]:checked').length == 1;
        var EveryOtherActive = $(chboxSet).find('input[type=checkbox][value=2]:checked').length == 1;
        obj.EveryActive = EveryActive;
        obj.EveryOtherActive = EveryOtherActive;
        obj.Start = !isNaN(Start) ? Start : null;
        stage('IndividualOvernights', day, obj);
    });
}


function saveHolidays() {
    var IsSelected = $('#criteria-holidays .checkbox-holidays input[type=checkbox]:checked').length == 1;
    stage('Holidays', 'IsSelected', IsSelected);
}


function saveBreaks() {
    saveIndividual('spring', 'Spring');
    saveIndividual('summer', 'Summer');
    saveIndividual('winter', 'Winter');

    function saveIndividual(breakName, breakKey) {
        var repeater = $('#criteria-breaks-' + breakName);
        var obj = {};
        var Start = repeater.find('.BreakStart').parent().datepicker('getDate');
        var End = repeater.find('.BreakEnd').parent().datepicker('getDate');
        var ShowActive = repeater.find('input[type=checkbox][value=1]:checked').length == 1;
        var ParentBFirstActive = repeater.find('input[type=checkbox][value=2]:checked').length == 1;
        var ParentBSecondActive = repeater.find('input[type=checkbox][value=3]:checked').length == 1;
        var ParentBFullActive = repeater.find('input[type=checkbox][value=4]:checked').length == 1;
        var ClearExistingActive = repeater.find('input[type=checkbox][value=5]:checked').length == 1;

        obj.ShowActive = ShowActive;
        obj.ParentBFirstActive = ParentBFirstActive;
        obj.ParentBSecondActive = ParentBSecondActive;
        obj.ParentBFullActive = ParentBFullActive;
        obj.ClearExistingActive = ClearExistingActive;
        obj.Start = !isNaN(Start) ? Start : null;
        obj.End = !isNaN(End) ? End : null;
        stage('Breaks', breakKey, obj);
    }
}


function saveUniqueDays() {
    // default css classes: CalendarDay [dayofweek] Day[day of year]
    // want to select all that are day-checked or holiday (more for future... just add them here)
    elements('.day-checked:not(.holiday), .holiday:not(.day-checked)');

    function elements(selector) {
        var allUniqueDays = []; // this allows us to pre-stage so we can overwrite duplicates

        _.forEach($(selector), function (day) {
            var obj = {};
            var element = $(day);
            var doy = element.data("doy");
            obj.Day = doy;
            obj.DayClass = element.attr('class');
            allUniqueDays.push(obj);
        });

        stageObject('UniqueDays', allUniqueDays);
    }
}