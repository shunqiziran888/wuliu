/**
 * 
 * @param {function(object,number,number)} _success 成功返回结果 function(res,latitude,longitude)
 * @param {function(object)} _cancel 取消定位
 * @param {object} _error 定位出错返回值
 */
function Relocation(_success, _cancel, _error) {
    let gps = GetSession("gps");
    if (!StrIsNullOrEmpty(gps)) {
        try {
            let _res = JSON.parse(gps);
            _success(_res, _res.latitude, _res.longitude);
            return;
        }
        catch (e) {
            Log("错误:" + e.err_msg);
        }
    }

    wx.getLocation({
        type: 'wgs84', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
        success: function (res) {
            var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
            var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
            var speed = res.speed; // 速度，以米/每秒计
            var accuracy = res.accuracy; // 位置精度

            SetSession("gps", JSON.stringify(res));
            _success(res, latitude, longitude);
        },
        cancel: function (res) {
            _cancel(res);
        },
        error: function (res) {
            _error(res);
        }
    });
}



//统一下单接口
$.wxCreateOrder = function (obj, _amount, _type, backFun) {

    var obj2 = {}
    obj2.amount = _amount;
    obj2.data = JSON.stringify(obj);
    obj2.type = _type;
    obj2.action = "WX_CreateOrderPayment";

    //支付调取
    $.loadAdData2($.adUrl, getBaseUrlData(obj2), function (data, para, url) {

        //跳转到支付界面
        var result = data.data;
        //var payid = result.payid;
        //var paytype = result.paytype;
        var purse = result.purse;

        $.popup('.popup-about');

        if (purse >= _amount) {
            $("input[name='paytype']").each(function () {
                if ($(this).val() == "1") {
                    $(this).attr("checked", "checked");
                }
            });
        } else {
            $("input[name='paytype']").each(function () {
                if ($(this).val() == "1") {
                    $(this).attr("disabled", "true");
                }
                if ($(this).val() == "2") {
                    $(this).attr("checked", "checked");
                }
            });
        }
        backFun(result, obj);

    });
}


//微信通用支付
$.wxPay = function (obj, backFun, pf) {
    //提交支付订单

    $.loadAdData($.adUrl, getBaseUrlData({ action: "WX_UniformOrders", attach: JSON.stringify(obj), platform: pf }), function (data, para, url) {

        var result = JSON.parse(data.data);
        //alert(JSON.stringify(data));
        if (typeof WeixinJSBridge == "undefined") {
            if (document.addEventListener) {
                document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
            } else if (document.attachEvent) {
                document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
                document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
            }
        } else {
            onBridgeReady();
        }

        function onBridgeReady() {
            WeixinJSBridge.invoke(
                'getBrandWCPayRequest', {
                    "appId": result.appId,
                    "timeStamp": result.timeStamp,
                    "nonceStr": result.nonceStr,
                    "package": result.package,
                    "signType": "MD5",
                    "paySign": result.paySign
                },
                function (res) {
                    if (res.err_msg == "get_brand_wcpay_request:ok") {
                        backFun(res);
                    } else if (res.err_msg == "get_brand_wcpay_request:fail") {
                        alert(JSON.stringify(res));
                    }
                    //err_msg将在用户支付成功后返回    ok，但并不保证它绝对可靠。 
                }
            );
        }
    });
}

//初始化微信
$.initWx = function () {
    $.loadAdData($.adUrl, getBaseUrlData({ action: "JSSignature", url: window.location.href }), function (data, para, url) {
        if (CheckHTMLData(data)) {
            var result = data.data;
            Log("JSSignature---初始化成功!");
            Log("微信对象wx===" + wx);

            wx.error(function (res) {
                Log("微信加载失败:" + res);
            });

            wx.ready(function () {
                Log("微信初始化成功!");
                $.wxReady();
            });

            wx.config({
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: getAppid(), // 必填，公众号的唯一标识
                timestamp: result.timestamp, // 必填，生成签名的时间戳
                nonceStr: result.noncestr, // 必填，生成签名的随机串
                signature: result.signature,// 必填，签名，见附录1
                jsApiList: [
                    'checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ', 'onMenuShareWeibo', 'hideMenuItems',
                    'showMenuItems', 'hideAllNonBaseMenuItem', 'showAllNonBaseMenuItem',
                    'onRecordEnd', 'uploadImage', 'downloadImage', 'getNetworkType', 'openLocation', 'getLocation', 'hideOptionMenu', 'showOptionMenu',
                    'closeWindow', 'chooseWXPay',
                ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
            });
        }
        else {
            Log("JSSignature---失败了:" + JSON.stringify(data));
            //Msg("JSSignature---失败了");
        }
    });
};

/**
 * 登陆微信
 * @param {boolean} rf 是否立即获取全部人员信息 
 */
$.wxlogin= function wxlogin(rf) {

    var nowUrl = window.location.origin + window.location.pathname + window.location.search;


    var appid = getAppid();
    var adid = getAid();

    var openid = getOpenId();

    nowUrl = delcode(nowUrl);
    nowUrl = encodeURIComponent(nowUrl);

    //基础验证口
    var baseUrl = 'https://open.weixin.qq.com/connect/oauth2/authorize?appid=' + appid + '&redirect_uri=' + nowUrl + '&response_type=code&scope=snsapi_base#wechat_redirect';
    //详细咨询验证口
    var infoUrl = 'https://open.weixin.qq.com/connect/oauth2/authorize?appid=' + appid + '&redirect_uri=' + nowUrl + '&response_type=code&scope=snsapi_userinfo#wechat_redirect';
    if (rf) {
        window.location.href = infoUrl;
        return;
    }
    //调用微信登录接口
    if (openid != null) {
        window.location.href = baseUrl;
    } else {
        window.location.href = infoUrl;
    }
}
