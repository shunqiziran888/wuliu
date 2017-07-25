/**
 * 分页默认数
 */
$.pageNum = 10;
//$.apiUrl = "http://testwl.mikiboss.com/";
  $.apiUrl = "http://192.168.0.201/";
$.adUrl = $.apiUrl + "/api.ashx";
$.IFramePath = "/Style/scripts/"; //IFRAME提交的根目录
$.CloseWX = true; //是否关闭微信

$(function () {
    $("a").addClass("external");
});