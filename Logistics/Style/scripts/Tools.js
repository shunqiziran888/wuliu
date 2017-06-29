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