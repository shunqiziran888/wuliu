function GetHtml(linkUrl, para, success, error) {
    $.ajax({
        //提交数据的类型 POST GET
        type: "POST",
        //提交的网址
        url: linkUrl,
        //提交的数据
        data: para,
        //返回数据的格式
        datatype: "text",//"xml", "html", "script", "json", "jsonp", "text".
        //成功返回之后调用的函数             
        success: success,
        //调用出错执行的函数
        error: error
    });
}

/**
* 判断字符串是否为空
*/
function StrIsNull(str)
{
    if (str=="" || str==null || str==undefined) {
        return true;
    }
    return false;
}
/**
* 链接跳转
* @param {any} url
*/
function Href(url) {
    window.location.href = url;
}

/**
 * 获取当前链接 不包含参数
 */
function GetNowHrefNoParam()
{
    return window.location.origin + window.location.pathname;
}

function GET(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}