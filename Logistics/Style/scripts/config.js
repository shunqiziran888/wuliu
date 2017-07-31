/**
 * 分页默认数
 */
$.pageNum = 10;
//$.apiUrl = "http://testwl.mikiboss.com/";
$.apiUrl = "http://192.168.0.201/";
$.adUrl = $.apiUrl + "/api.ashx";
$.IFramePath = "/Style/scripts/"; //IFRAME提交的根目录
$.CloseWX = false; //是否关闭微信

$(function () {
    $("a").addClass("external");
    $('.check_tab_nav>div').click(function (index) {
        // debugger;
        var index = $(this).index();
        $(this).children('span.iconfont')
            .html('&#xe758;')
            .parent()
            .siblings('div')
            .children('span.iconfont').html('&#xe637;');
        $('.check_main').eq(index)
            .removeClass('dis_none')
            .siblings('.check_main').addClass('dis_none');
    })


    $('.check_main_left form label').click(function () {
        $(this).addClass('active').siblings('label').removeClass('active');
    })

    $('.check_main_right form label').click(function () {
        $(this).addClass('active').siblings('label').removeClass('active');
    })

    $('.close_btn ').click(function () {
        debugger;
        var index = $(this).parents('.check_main').index();
        $(this).parents('.check_main').addClass('dis_none');
        $('.check_tab_nav div').eq(index - 1).children('span.iconfont').html('&#xe637;');
    })

    // 选车
    $('.bus_list li').click(function () {
        $(this).addClass('active').siblings('li').removeClass('active');
    })
    // 选车
});