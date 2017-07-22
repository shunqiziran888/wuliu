/**
 * 分页默认数
 */
$.pageNum = 10;
$.apiUrl = "http://nwl.mikiboss.com/";
//  $.apiUrl = "http://localhost:23445/";
$.adUrl = $.apiUrl + "/api.ashx";
$.IFramePath = "/Style/scripts/"; //IFRAME提交的根目录
$.CloseWX = false; //是否关闭微信

$(function () {
    $("a").addClass("external");
});