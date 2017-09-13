function ChangeIcons(iconNum) {
    console.log("_ScreenIcons::ChangeIcons(...) -> iconNum=" + iconNum);
    $("#tblScreenNav tr").each(function () {
        var currentIcon = $(this).attr('class').replace("screen-ajax", "");
        $(this).find('td[class^="screen-icon-"]').each(function () {
            $(this).removeClass("IconSelected");
            if (currentIcon == iconNum) {
                $(this).addClass("IconSelected");
            }
        })
    })
    //for (var b = 0; b <= $('#txtScreenNumber').val() ; b++) {
    //    if (b === 0) {
    //        if (b === iconNum) {
    //            $('.screen-icon' + b).removeClass('iconNormalTop');
    //            $('.screen-icon' + b).addClass('iconSelectedTop');
    //        }
    //        else {
    //            $('.screen-icon' + b).removeClass('iconSelectedTop');
    //            $('.screen-icon' + b).addClass('iconNormalTop');
    //        }
    //    }
    //    else {
    //        $('.screen-icon' + b).removeClass('iconSelectedTop');
    //        $('.screen-icon' + b).addClass('iconNormalTop');
    //        if (b === iconNum) {
    //            $('.screen-icon' + b).removeClass('iconNormalBottom');
    //            $('.screen-icon' + b).addClass('iconSelectedBottom');
    //        }
    //        else {
    //            $('.screen-icon' + b).removeClass('iconSelectedBottom');
    //            $('.screen-icon' + b).addClass('iconNormalBottom');
    //        }
    //    }
    //}
}

$(document).ready(function () {


    //hide the link text for gate list and show the icons on startup on the slide-in-handle splitter column
    if ($('#slide-in-handle').is(':visible')) {
        $('[class^="screen-text"]').hide();
        //$('[class^="screen-icon"]').css('height', '25px');
    }

    $("#splitter").kendoSplitter({
        orientation: "horizontal",
        panes: [
            { resizable: false, scrollable: false, collapsible: true, size: "200px" },
            { resizable: false, scrollable: false, collapsible: false, size: "100%" }
        ],
        expand: function (e) {
            //$(".Window-Container").closest(".k-window").width($(".splitter-main").width() - 240);
            //$(".Window-Container").closest(".k-window").css({ left: 246 });
            $("body").find(".k-window").width($(".splitter-main").width() - 240);
            $("body").find(".k-window").css({ left: 246 });
        },
        collapse: function (e) {
            //$(".Window-Container").closest(".k-window").width($(".splitter-main").width() + 160);
            //$(".Window-Container").closest(".k-window").css({ left: 46 });
            $("body").find(".k-window").width($(".splitter-main").width() + 160);
            $("body").find(".k-window").css({ left: 46 });
        },
        animation: false
        //contentLoad: onContentLoad,
        //resize: onResize
    });
    $("#splitter1").kendoSplitter({
        orientation: "horizontal",
        panes: [
            { resizable: true, scrollable: false, collapsible: true, size: "40px" },
            { resizable: false, scrollable: false, collapsible: true, size: "300px" },
            { resizable: false, scrollable: false, collapsible: false, size: "0px" }
        ],
        //expand: onExpand,
        expand: function (e) {
            setTimeout(function () {
                $(e.contentElement).find(".k-splitter").each(function () {
                    $(this).data("kendoSplitter").trigger("resize");
                });
            }, 300);
        },
        animation: false
        //collapse: onCollapse,
        //contentLoad: onContentLoad,
        //resize: onResize
    });

    var slide = kendo.fx($("#slide-in-share")).slideIn("right"),
                visible = true;


    $("#slide-in-handle").click(function (e) {
        if (visible) {
            $('[class^="screen-text"]').show();
            slide.duration(0).reverse();
            $("#slide-in-share").css("margin-left", "43px")
            $("#slide-in-share").width("240px");
            $("#slide-in-wrapper").width("240px");
            //$('[class^="screen-icon"]').css('height', '25px');
            $('[class^="screen-text"]').css({'height': '25px', 'width' : '200px', 'padding-left' : '10px', 'vertical-align' : 'middle' });

        } else {
            slide.duration(0).play();
            //$('[class^="screen-icon"]').css('height', '25px');
            $('[class^="screen-text"]').hide();
            $("#slide-in-share").css("margin-left", "0px")
            $("#slide-in-share").width("40px");
            $("#slide-in-wrapper").width("40px");

        }
        visible = !visible;
        e.preventDefault(); 
    });

    //browser check
    var is_chrome = navigator.userAgent.indexOf('Chrome') > -1;
    var is_explorer = navigator.userAgent.indexOf('MSIE') > -1;
    var is_firefox = navigator.userAgent.indexOf('Firefox') > -1;
    var is_safari = navigator.userAgent.indexOf("Safari") > -1;
    var is_Opera = navigator.userAgent.indexOf("Presto") > -1;
    if((is_chrome)&&(is_safari))
        is_safari = false;

    //added for functionality with Safari:
    if (is_safari) {
        $('div#Header.Header-FlexGroup').css('width', '62.5%'); // this needs to be fixed.
        $('.Header-ClientID').css('position', 'absolute');
        $('.Header-iOpsStats').css({
            'position': 'absolute',
            'width': '64%',
            'padding-top': '10px'
        })
        $('div#menuIcon').css('width', '72px');
        $('.Header-FlexItemGroup').css('width', '91%');

    }
    else {
        $('.Header-FlexGroup').css('width', '100%');
    }
})

