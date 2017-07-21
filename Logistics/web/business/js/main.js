$(function(){
    $('.check_tab_nav>div').click(function(index){
        // debugger;
        var index = $(this).index();
        $(this).children('span.iconfont').html('&#xe758;').parent().siblings('div').children('span.iconfont').html('&#xe637;');
        $('.check_main').eq(index).removeClass('dis_none').siblings('.check_main').addClass('dis_none');
    })
    $('.close_btn ').click(function(){
        debugger;
        var index = $(this).parents('.check_main').index();
        $(this).parents('.check_main').addClass('dis_none');
        $('.check_tab_nav div').eq(index).children('span.iconfont').html('&#xe637;');
    })
});