/**
 * 动态加载JS
 */
$.loadScript = function loadScript(url, callback) {

    var script = document.createElement("script");
    script.type = "text/javascript";
    if (typeof (callback) != "undefined") {
        if (script.readyState) {
            script.onreadystatechange = function () {
                if (script.readyState == "loaded" || script.readyState == "complete") {
                    script.onreadystatechange = null;
                    callback();
                }
            };

        } else {
            script.onload = function (e) {
                callback();
            };
        }
    }
    script.src = url;
    document.body.appendChild(script);
}
/**
 * 去空格
 * @param {string} str 传入的内容
 */
function Trim(str) {
    return $.trim(str);
}

/**
 * 微信支付t
 * @param {number} amount 金额
 * @param {number} type 支付类型
 * @param {object} data 支付数据
 * @param {function(object)} successfun 支付成功回调
 * @param {function(object)} errfun 支付失败回调
 */
function UniformOrder(amount, type, data, successfun, errfun) {
    let _obj = {};
    _obj.amount = amount;
    _obj.data = JSON.stringify(data);
    _obj.type = type;

    GetHTML("CreateOrderPayment", _obj, function (data, para, url) {

        if (CheckHTMLData(data)) {
            data = data.data;
            let payobj = {
                attach: JSON.stringify({
                    payid: data.payid,
                    paytype: data.paytype
                })
            };
            GetHTML("UniformOrders", payobj, function (data, para, url) {

                if (CheckHTMLData(data)) {
                    var result = JSON.parse(data.data);
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
                                    successfun(res);
                                } else if (res.err_msg == "get_brand_wcpay_request:fail") {
                                    // alert(JSON.stringify(res));
                                    errfun(res);
                                }
                                else {
                                    errfun(res);
                                }
                                //err_msg将在用户支付成功后返回    ok，但并不保证它绝对可靠。 
                            }
                        );
                    }
                }
            });
        }
    });
}

/**
 * 验证函数是否存在
 * @param {string} funcName 
 */
function isExitsFunction(funcName) {
    try {
        if (typeof (eval(funcName)) == "function") {
            return true;
        }
    } catch (e) { }
    return false;
}

/**
 * 统一下单直接微信支付
 * @param {object} data 订单附加值
 * @param {number} amount 购买金额
 * @param {typeid} typeid 下单类型
 * @param {function(object)} callBack 返回值function(res)
 */
function WX_CreateOrder(data, amount, typeid, callBack) {
    $.wxCreateOrder(data, amount, typeid, function (res, obj) {
        var obj = new Object();
        obj.payid = res.payid;
        obj.paytype = res.paytype;
        $.wxPay(obj, callback);
    });
}
/**
 * 随机数
 * @param {number} Min 
 * @param {number} Max 
 */
function GetRandomNum(Min, Max) {
    let Range = Max - Min;
    let Rand = Math.random();
    return (Min + Math.round(Rand * Range));
}

/**
 * 弹出窗口
 * @param {string} title 标题
 * @param {string} content 内容
 * @param {function} callbackOk 点击成功 
 * @param {function} callbackCancel 点击取消 
 */
function ShowDalog(title, content, callbackOk, callbackCancel) {
    $.confirm(content, title, callbackOk, callbackCancel);
}

/**
 * 弹出提示框
 * @param {string} content 
 */
function MessageBox(content) {
    $.alert(content);
}

/**
 * 设置本地永久存储
 * @param {string} key 
 * @param {string} value 
 */
function SetLocalData(key, value) {
    localStorage.setItem(key, value);
}
/**
 * 获取一个本地永久存储
 * @param {string} key 
 */
function GetLocalData(key) {
    return localStorage.getItem(key);
}
/**
 * 清空本地存储
 */
function ClearLocalData() {
    localStorage.clear();
}
/**
 * 移除一个本地存储
 * @param {string} key 
 */
function RemoveLocalData(key) {
    localStorage.removeItem(key);
}

/**
 * 设置本地SESSION
 * @param {string} key 
 * @param {string} value 
 */
function SetSession(key, value) {
    sessionStorage.setItem(key, value);
}
/**
 * 获取SESSION的值
 * @param {string} key 
 */
function GetSession(key) {
    return sessionStorage.getItem(key);
}
/**
 * 删除某个session
 * @param {string} key 
 */
function RemoveSession(key) {
    sessionStorage.removeItem(key);
}
/**
 * 清空本地SESSION
 */
function ClearSession() {
    sessionStorage.clear();
}

/**
 * 初始化URL列表
 */
$.initLinkWithBaseUrl = function () {
    $("a").each(function (index, data) {
        var str = $(data).attr('href');
        if (!StrIsNullOrEmpty(str) && str.indexOf("#") != 0) {
            if (str.indexOf("$.back()") < 0 && str.indexOf("javascript") < 0 && str.indexOf("tel") < 0) {
                if (str.indexOf("?") < 0) {
                    $(data).attr('href', str + "?" + getBaseUrlPara());
                }
                else {
                    $(data).attr('href', str + "&" + getBaseUrlPara());
                }

            }
        }
    });
}

/**
 * 验证返回数据是否正确
 * @param {object} data 
 * @param {boolean} flag 是否显示错误提示 true显示,false不显示
 * @returns boolean
 */
function CheckHTMLData(data, flag = true) {
    if (data.state == 1) {
        if (data.data.status) {
            switch (data.data.status) {
                case -5: //未登录使用普通登陆
                    $.wxlogin(false);
                    break;
                case -10: //重新登陆
                    var nowUrl = indexUrl();
                    $.wxlogin(true);
                    break;
            }
        }
        return true;
    }
    else {
        if (flag)
            Msg(data.data);
        return false;
    }
}

//点击跳转
$.href = function (url) {
    if (url.indexOf("?") == -1) { url += window.location.search }
    url = delcode(url);
    window.location.href = url;
};

/**
 * 跳转链接
 * @param {string} url 要跳转的地址
 * @param {number} time 延迟多少毫秒后
 */
function Href(url, timeout = 0) {
    if (timeout > 0) {
        setTimeout(function () { $.href(url) }, timeout);
    }
    else {
        $.href(url);
    }
}
/**
 * 执行一个方法
 * @param {function} callBackFun 要调用的方法 
 * @param {number} timeout 延迟时间 
 */
function FunctionRun(callBackFun, timeout) {
    if (timeout > 0) {
        setTimeout(function () {
            callBackFun();
        }, timeout);
    }
    else {
        callBackFun();
    }
}

/**
 * 弹出悬浮窗口
 * @param {string} JqID Jquery的检索标识
 * @param {boolean} closeflag 模式true为关闭,false为打开
 */
function Popup(JqID = ".popup", closeflag = false) {
    if (!closeflag) {
        $.popup(JqID);
    }
    else {
        $.closeModal(JqID)
    }
}


/**
 * 经度纬度解析
 * @param {number} lat 纬度
 * @param {number} lng 经度
 * @param {function(object)} callback 回调方法 function(data)
 */
function GetLatLngToAddress(lat, lng, callback) {
    geocoder = new qq.maps.Geocoder({
        complete: function (result) {
            callback(result.detail);
        }
    });
    var coord = new qq.maps.LatLng(lat, lng);
    geocoder.getAddress(coord);
}

/**
 * 创建一个图片
 * @param {string} #id 要在什么位置创建有一个上传文件控件
 * @param {string} callbackName 回调名称(不填写则自动生成一个回调名称)
 * @param {number} maxNumber 最大上传数
 * @param {string} ImgsID 样式名称(不传则生成一个随机的图片ID)
 * @param {number} width 宽度
 * @param {height} height 高度
 * @param {string} action 上传命令
 * @param {string} uploadFilePath 要上传的文件路径
 */
function CreateUploadImage(id, ImgsID = "", maxNumber = 1, callbackName = "", width = 80, height = 80, uploadFilePath = "../upload/uploadFile.html", action = "WX_UploadFile") {
    if (StrIsNullOrEmpty(callbackName)) {
        callbackName = Guid();
    }
    if (StrIsNullOrEmpty(ImgsID))
        ImgsID = id.replace("#", "");
    let serverUrl = $.adUrl + "?action=" + action; //要上传的服务器路径
    let uploadUrl = uploadFilePath + "?serverUrl=" + encodeURI(serverUrl) + '&n=' + Math.random(); //要上传的回调html
    let ifRame = '<iframe  src="' + uploadUrl + '&callname=' + callbackName + '&v=1" width="100%" height="100%" frameborder="no" border="0″ marginwidth="0″ marginheight="0″ scrolling="no" ></iframe>';
    $(id).html(ifRame); //创建一个图片IFRAME
    //上传图片回调
    this[callbackName] = function (obj) {

        let guid = Guid();
        let oo = {};
        oo.imgID = id;
        oo.AddImgID = "div[ImgIds^=\\\"" + ImgsID + "\\\"]";
        oo.maxNumber = maxNumber;
        let json = JSON.stringify(oo);
        var imgStr = '<div id=' + guid + ' ImgIds=' + ImgsID + ' class="fl mr5 imgDiv"><span class="close it it-fault" onclick=$.removeImg(checkImg,\'' + json + '\',\'' + guid + '\')></span><img src="' + $.chickenImg(obj.data[0], '160') + '" width="73" /></div>';
        $(id).before(imgStr);
        if ($("div[ImgIds^='" + ImgsID + "']").length >= maxNumber) {
            $(id).hide();
        } else {
            $(id).show();
        }
    }
}
/**
 * 获取上传到图片链接
 * @param {string} ImgsID 传入CreateUploadImage的图片样式ID
 */
function GetImageListFromImgIds(ImgsID) {

    let imgsArr = [];
    let arr = $("[ImgIds^='" + ImgsID + "']");
    if (arr.length > 0)
        arr.forEach(function (v, i, arr) {
            if (v.getAttribute("src") != null)
                imgsArr.push(v.getAttribute("src"));
        });
    arr = $("[ImgIds^='" + ImgsID + "'] img");
    if (arr.length > 0)
        arr.forEach(function (v, i, arr) {
            if (v.getAttribute("src") != null)
                imgsArr.push(v.getAttribute("src"));
        });
    return imgsArr;
}

/**
 * 检测图像是否存在
 * @param {string} imgID 用来回复添加图像的ID
 * @param {string} AddImgID 用来检测图像数目的ID
 * @param {number} maxNumber 用来检测是否达到最大值的id
 */
function checkImg(imgID, AddImgID, maxNumber) {
    if ($(AddImgID).length >= maxNumber) {
        $(imgID).hide();
    } else {
        $(imgID).show();
    }
}

/**
 * 获取图片
 * @param {string} ImgIds 要检索的ImgIds的名称
 */
function GetImages(ImgIds) {

    let allStr = "";
    //div[ImgIds^=\\\""+ImgsID+"\\\"]
    if (ImgIds.indexOf("#"))
        ImgIds = ImgIds.replace("#", "");
    $("div[ImgIds^='" + ImgIds + "'] img").each(function () {
        var str = $(this).attr("src");
        str = str.replace($.apiUrl, "");
        allStr += str + ",";
    });
    if (!StrIsNullOrEmpty(allStr))
        allStr = allStr.substring(0, allStr.length - 1);
    return allStr;
}


/**
 * 验证字符串是否为空
 */
function StrIsNullOrEmpty(str) {
    if (str == null || str == "" | str == undefined)
        return true;
    return false;
}

/**
 * 验证电话号码
 */
function CheckPhone(phone) {
    var isPhone = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
    var isMob = /^(((13[0-9]{1})|(14[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1}))+\d{8})$/;

    if (isMob.test(phone) || isPhone.test(phone)) {
        return true;
    } else {
        return false;
    }
}

//获取url中的参数
$.GET = function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

/**
 * 获取URL传值
 * @param {string} name 
 * @returns {string}
 */
function GET(name) {
    return $.GET(name);
}

/**
 * 获取远程HTML
 * @param {string} action 要请求的命令
 * @param {object} obj 要请求的对象
 * @param {function (object, object, string)} fun 回调function(data, para, url)
 * @param {object} otherObj 附加属性给回调
 */
function GetHTML(action, obj, fun, otherobj) {
    obj.action = action;
    $.loadAdData($.adUrl, getBaseUrlData(obj), fun, otherobj);
}
/**
 * 创建支持滚动的分页请求
 * @param {string} Action 命令行
 * @param {string} JQ_ViewID 用于显示的ID(JQUERY形式的索引器名称)
 * @param {string} TemplateID 模板ID 只有ID 
 * @param {string} JQ_WhileClass 循环索引器 默认检索li
 * @param {object} Page 此为SUI框架中Page页面参数,pageInit事件返回的值
 * @param {function(object)} CallBackFun 数据回调 返回result
 * @param {string} JQ_BindID 绑定的滚动JQ对象
 * @param {object} OtherData 附加额外的属性
 * @param {boolean} OpenScroll 是否开启滚动 默认滚动
 */
// function CreateHTMLtoFY(Action, JQ_ViewID, TemplateID, JQ_WhileClass, Page, CallBackFun, JQ_BindID = '.infinite-scroll-bottom', OtherData = {}, OpenScroll = true) {
//     let obj = {};
//     obj.action = Action;
//     obj.template = TemplateID;
//     if (StrIsNullOrEmpty(JQ_WhileClass))
//         JQ_WhileClass = "li";
//     for (let key in OtherData) {
//         obj[key] = OtherData[key];
//     }
//     if (CheckTimeOut(obj))
//         return;
//     $(JQ_ViewID).html("");
//     $.loadMoreData(getBaseUrlData(obj), $(JQ_ViewID), true, Page, CallBackFun, JQ_WhileClass, JQ_BindID);
// }


/**
 * 创建一个唯一的GUID
 */
function Guid() {
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    function S4() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }
}


/**
 * 创建分页查询
 * @param {string} ItemListID 绑定的容器列表ID （Jquery语法）
 * @param {string} action 命令名称
 * @param {object} paramObj 命令参数
 * @param {number} page 当前页
 * @param {number} num 每页个数
 * @param {function(object)} succFun 成功回调 已经要RETURN一个完整的HTML
 * @param {function(object)} errFun 错误回调
 * @param {string} otherClassName 别名（Jquery语法名）
 */
function CreateHTMLtoFY(ItemListID, action, paramObj, page, num, succFun, errFun, otherClassName) {
    if (StrIsNullOrEmpty(otherClassName))
        otherClassName = ".infinite-scroll";
    let guid = Guid();
    $[guid] = {};
    // 加载flag
    $[guid].loading = false;
    paramObj.page = page;
    paramObj.num = num;
    /**
     * 
     * @param {number} lastIndex 索引
     * @param {function(number)} 成功回调
     */
    function addItems(lastIndex, guid, otherClassName, callFun) {
        // 生成新条目的HTML
        
        var html = '';
        paramObj.page = lastIndex;
        GetHTML(action, paramObj, function (data) {
            if (CheckHTMLData(data, false)) {
                if (callFun != null)
                    callFun(data.data.pagecount, guid, otherClassName);
                html = succFun(data);
                // 添加新条目
                $(ItemListID).append(html);
            }
            else {
                errFun(data);
            }
        });
    }
    //预先加载20条
    addItems(1, guid, otherClassName, AddItemsCallBack);

    // 上次加载的序号
    $[guid].lastIndex = paramObj.page;
    
    // 注册'infinite'事件处理函数
    $(document).on('infinite', otherClassName, function () {
        
        // 如果正在加载，则退出
        if ($[guid].loading) return;
        // 设置flag
        $[guid].loading = true;
        // 添加新条目
        addItems($[guid].lastIndex, guid, otherClassName, AddItemsCallBack);

        //容器发生改变,如果是js滚动，需要刷新滚动
        $.refreshScroller();

    });
}
/**
 * 添加数据
 * @param {number} allpage 最终页数 
 * @param {string} guid 
 */
function AddItemsCallBack(allpage, guid, otherClassName) {
    
    // 重置加载flag
    $[guid].loading = false;
    if ($[guid].lastIndex >= allpage) {
        // 加载完毕，则注销无限加载事件，以防不必要的加载
        $.detachInfiniteScroll($(otherClassName));
        // 删除加载提示符
        $('.infinite-scroll-preloader').remove();
        return;
    }
    else {
        $[guid].lastIndex++;
    }
}




/**
 * 检测超时时间，在超时时间内无法访问相同对象
 * @param {object} obj 
 * @param {number} time 
 * @returns {boolean} TRUE为在超时事件内访问了多次
 */
function CheckTimeOut(obj, time = 200) {
    if ($.checkFYTimeOut == null)
        $.checkFYTimeOut = [];
    let make_key = JSON.stringify(obj);
    let b = false;

    for (var i = $.checkFYTimeOut.length - 1; i >= 0; i--) {
        let v = $.checkFYTimeOut[i];
        if (v.outtime < new Date() * 1) {
            $.checkFYTimeOut.splice(i, 1);
        }
    }

    $.checkFYTimeOut.every(function (v, index, _arr) {
        if (v.action == make_key) {
            b = true;
            Log("已存在:") + v.action;
            return;
        }
    }
    );

    if (!b) {
        var ob = {};
        ob.outtime = (new Date() * 1) + time;
        ob.action = make_key;
        $.checkFYTimeOut.push(ob);
    }
    return b;
}


/**
 * 绑定模板，并显示数据
 * @param {string} tempid 绑定到的模板ID
 * @param {object} data 数据
 * @returns {string} 返回HTML
 */
function TempToHtml(tempid, data) {
    var html = template(tempid, data);
    return html;
}


//缩略图读取
$.chickenImg = function (data, chicken) {
    if (StrIsNullOrEmpty(data))
        return "";
    if (data.indexOf(",") > -1) {
        data = data.split(",")[0];
    }
    if (data.indexOf("/160") > -1) {
        data = data.replace("/160", "/" + chicken);
        return data;
    } else {
        if (data.indexOf("/") > -1) {
            var strArr = data.split('/');
            var fileurl = strArr[strArr.length - 1];
            var newurl = data.replace(fileurl, "");
            var filename = fileurl.split('.')[0];
            var ext = fileurl.split('.')[1];
            return newurl + chicken + '/' + filename + '.' + ext;
        }
    }
}


/**
 * 创建一个全新的URL
 * @param {string} url 
 */
function CreateNewUrl(url) {
    if (url.indexOf("?") == -1) {
        //创建一个地址
        return url + "?" + getBaseUrlPara();
    }
    else {
        return url + "&" + getBaseUrlPara();
    }
}

/**
 * 弹出提示
 */
function Msg(msg) {
    if ($.toast != null) {
        $.toast(msg);
    }
    else {
        alert(msg);
    }
}
/**
 * 显示日志
 */
function Log(msg) {
    console.log(msg);
}





/**
 * 验证身份证号
 */
function CheckIDCard(code) {
    var city = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
    var tip = "";
    var pass = true;

    if (!code || !/^\d{6}(18|19|20)?\d{2}(0[1-9]|1[12])(0[1-9]|[12]\d|3[01])\d{3}(\d|X)$/i.test(code)) {
        tip = "身份证号格式错误";
        pass = false;
    }

    else if (!city[code.substr(0, 2)]) {
        tip = "地址编码错误";
        pass = false;
    }
    else {
        //18位身份证需要验证最后一位校验位
        if (code.length == 18) {
            code = code.split('');
            //∑(ai×Wi)(mod 11)
            //加权因子
            var factor = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
            //校验位
            var parity = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];
            var sum = 0;
            var ai = 0;
            var wi = 0;
            for (var i = 0; i < 17; i++) {
                ai = code[i];
                wi = factor[i];
                sum += ai * wi;
            }
            var last = parity[sum % 11];
            if (parity[sum % 11] != code[17]) {
                tip = "校验位错误";
                pass = false;
            }
        }
    }
    // if(!pass) alert(tip);
    return pass;
}