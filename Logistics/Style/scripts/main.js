/*
 * @Author: wudiankungg 
 * @Date: 2017-06-13 17:50:29 
 * @Last Modified by: wudiankungg
 * @Last Modified time: 2017-07-17 12:10:18
 */
/**
 * 初始化
 */
function InitSystem() {
    $.shareData = { title: "", link: window.location.href, imgUrl: "", desc: "", type: null, dataUrl: "" };
    $.loadScript($.IFramePath + "/tools/wx.js?" + Math.random(), function (e) {

        //检测是否登陆
        checklogin(function () {
            //初始化微信
            $.initWx();

            //微信加载完成后
            $.wxReady = function () {
                PageRun();
                if ($.WxInit!=null)
                    $.WxInit();
                $("#locationName").html("定位中..");
                //获取位置
                Relocation(function (res, latitude, longitude) {
                    debugger;
                    //设置最后的坐标
                    SetSession("lat", latitude);
                    SetSession("lng", longitude);
                    //InitData(); //初始化数据
                    //获取解析的地址
                    GetLatLngToAddress(GetSession("lat"), GetSession("lng"), function (obj) {

                        let address = obj.addressComponents;
                        $("#locationName").html(GetSession("setCityName") + '<i class="icon it it-unfold"></i>');

                    });

                }, function (res) {
                    Msg("拒绝定位!");
                }, function (res) {
                    Msg("定位错误!");
                });
            }
        });
    });
}
/**
 * 设置分享
 * @param {any} title
 * @param {any} link
 * @param {any} imgUrl
 * @param {any} desc
 */
function SetShare(title, link, imgUrl, desc) {
    if ($.shareData == null)
        return;
    $.shareData.title=title;
    $.shareData.link = (link);
    $.shareData.imgUrl = (imgUrl);
    $.shareData.desc = (desc);
}
//初始化分享
function InitShare() {
    debugger;
    if (StrIsNullOrEmpty($.shareData.link))
        InitShareUrl();
    var shareobj = new Object();
    shareobj.title = $.shareData.title;
    shareobj.link = encodeURI($.shareData.link);
    shareobj.imgUrl = encodeURI($.shareData.imgUrl);
    shareobj.desc = $.delHtmlTag($.shareData.desc);


    shareobj.success = function () { $.shareOkBackFun() }
    wx.onMenuShareTimeline(shareobj);
    wx.onMenuShareAppMessage(shareobj);
    wx.onMenuShareQQ(shareobj);
    wx.onMenuShareWeibo(shareobj);
    
}

$.shareOkBackFun = function () {
    //分享成功
}

//初始化分享URL
function InitShareUrl() {

    var shareUrl = $.filterUrl(window.location.href);
    $.shareData.link = shareUrl + "&type=2";
}

var login = false;

/**
 * 关闭系统
 * @param {function} callfun 
 */
function OutSystem(callfun) {
    GetHTML("OutSystem", {}, function (data) {
        if (CheckHTMLData(data, false)) {
            if (callfun != null)
                callfun();
        }
    });
}

/**
 * 页面JS库+微信登录完毕
 * @param {function} CallFun
 */
function PageInit(CallFun) {
    $.LoginOkFun = CallFun;
}

/**
 * 微信加载完毕执行
 * @param {any} CallFun
 */
function WXFinish(CallFun) {
    $.WxInit = CallFun;
}
/**
 * 移除路由
 */
function RemoveLuyou() {
    $("a").addClass("external");
}

/**
 * 检测是否已经登陆
 */
function checklogin(runpage) {

    let obj = new Object();

    let m = GET("UserSource");

    var code = GET("code");

    let acctype = GET("acctype");//访问类型(注册时使用)
    let region = GET("region"); //职位
    let logistics = GET("logistics"); //物流UID

    //来源是菜单
    if (!StrIsNullOrEmpty(m))
        obj.UserSource = m;

    if (!StrIsNullOrEmpty(code) && code != GetSession("code")) {

        obj.code = code;
        obj.aid = getAid();
        obj.acctype = acctype;
        obj.region = region;
        GetHTML("OAuth", obj, function (data, para, url) {
            debugger;
            let result = data.data;
            if (!CheckHTMLData(data, false)) {
                $.wxlogin(true);
            } else {
                login = true;
                SetLocalData("openid", result.Open_ID);
                SetSession("code", code);
                if ($.LoginOkFun != null) {
                    $.LoginOkFun();
                    $("a").addClass("external");
                }
                runpage();
            }
        });
    } else {

        //检测登录
        GetHTML("GetMyLoginData", obj, function (data, para, url) {
            debugger;
            var result = data.data;
            if (result.IsLogin == true) {
                login = true;
                SetSession("NickName", result.NickName);
                if ($.LoginOkFun != null) {
                    $.LoginOkFun();
                    $("a").addClass("external");
                }

                runpage();

                if ($('#page-home')[0]) {
                    $.href("index");
                }
                Log("已经登陆过了!");
            } else {
                Log("未登陆，重新登陆");

                $.wxlogin(false);
            }
        });
    }
}

/**
 * 获取AID
 */
function getAid() {
    return GetCheckSession("aid");
}
/**
 * 获取ADID
 */
function getAppid() {
    return GetCheckSession("appid");
}
/**
 * 获取OPENID
 */
function getOpenId() {
    var openid = GetLocalData("openid");
    if (StrIsNullOrEmpty(openid))
        return null;
    return openid;
}

/**
 * 获取经过检测的数据结构
 * @param {string} key 
 */
function GetCheckSession(key) {
    let v = "";
    if (StrIsNullOrEmpty(GetSession(key))) {
        v = GET(key);
        if (!StrIsNullOrEmpty(v))
            SetSession(key, v);
    } else {
        v = GetSession(key);
        if (!StrIsNullOrEmpty(GET(key))) {
            if (v != GET(key)) {
                v = GET(key);
                SetSession(key, v);
            }
        }
    }
    return v;
}

var i = 0;

$(function () {
    if (!$.CloseWX) {
            InitSystem();
    }
    else {
        if ($.LoginOkFun != null) {
            $.LoginOkFun();
        }
    }
});




