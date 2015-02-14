var hideWidth = '-1600px'; //width that will be hidden
var hideWidthPx = 1600; //width that will be hidden
var prevMarginLeft;
var drawer = '#drawer';
var workpane = '#workpane';
var threshold = 941;

$(window).scroll(function () {
    var $sidebar = $(workpane + ' .collapsible'),
        $sidebar2 = $(drawer),
        $window = $(window),
        offset = $sidebar.offset(),
        topPadding = 0;

    $sidebar.stop().animate({
        marginTop: $window.scrollTop() + topPadding
    });

    if ($sidebar2.outerWidth() < $sidebar2.parent().outerWidth()) {
        $sidebar2.stop().animate({
            marginTop: $window.scrollTop() + topPadding
        });
    }
});

$(window).resize(function () {
    if (threshold >= $(drawer).parent().outerWidth()) {
        prevMarginLeft = $(drawer).offset().left;
        $(drawer).animate({ marginLeft: '0', marginTop: '0' }, { duration: 100 });
    } else {
        if (clickedPattern == 'hide') {
            $(drawer).animate({ marginLeft: hideWidth }, { duration: 100 });
        } else if (clickedPattern == 'show') {
            $(drawer).animate({ marginLeft: '0' }, { duration: 100 });
        }
    }
    resizeWorkpane();
    resizeDrawer();
});

function resizeDrawer() {
    $(workpane + ' .collapsible button').animate({ height: $(drawer + ' .panel-group').height() + 'px' }, { duration: 100 });
}

function resizeWorkpane() {
    $('.column-calendar-month').removeClass('col-sm-6 col-sm-4 col-md-6 col-md-4');

    if ($(workpane).outerWidth() >= 850) {
        $('.column-calendar-month').addClass('col-sm-4');
    } else {
        $('.column-calendar-month').addClass('col-sm-6');
    }
}

var clickedPattern = 'none';

function collapse(target, container, button) {
    var collapsibleEl = $(target); //collapsible element
    var collapsibleE2 = $(container); //collapsible element
    var containerWidth = collapsibleEl.parent().outerWidth();
    var drawerWidth = collapsibleEl.outerWidth();
    var curwidth = collapsibleEl.offset();

    if (drawerWidth == containerWidth) return;

    if (curwidth.left > 0) //compare margin-left value
    {
        clickedPattern = 'hide';
        //animate margin-left value to -490px
        // Close
        collapsibleEl.animate({ marginLeft: hideWidth }, {
            duration: 300,
            easing: 'swing',
            done: function () {
                $(collapsibleE2).addClass('col-md-12');
                $(collapsibleE2).removeClass('col-md-8', 600, function () {
                    button.html('&raquo;'); //change text of button
                    resizeWorkpane();
                });
            }
        });

    } else {
        clickedPattern = 'show';
        //animate margin-left value 0px
        $(collapsibleE2).removeClass('col-md-12');
        $(collapsibleE2).addClass('col-md-8', {
            duration: 300,
            easing: 'swing',
            complete: function () {
                collapsibleEl.animate({ marginLeft: "0" }, {
                    duration: 300,
                    easing: 'swing',
                    done: function () {
                        button.html('&laquo;'); //change text of button
                        resizeWorkpane();
                    }
                });
            }
        });
    }
}