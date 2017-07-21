
var notPC = true;
// try {
// 	var ua = navigator.userAgent.toLowerCase();//获取判断用的对
// 	if (ua.indexOf("windows") > -1) {
// 		if (ua.indexOf("phone") == -1) {
// 			alert("友情提示:PC端访问无法获得小福包.");
// 			notPC = false;
// 		}
// 	}
// } catch (e) { }
function chickenImg(date, chicken) {
	if (date.indexOf('http://') != -1 && chicken == undefined)
		return date;
	if (date == null) { return "" }
	if (date.indexOf(",") > -1) {
		date = date.split(",")[0];
	}
	if (date.indexOf("/160") > -1) {
		date = date.replace("/160", "/" + chicken);
		return date;
	} else {
		if (date.indexOf("/") > -1) {
			var strArr = date.split('/');
			var fileurl = strArr[strArr.length - 1];
			var newurl = date.replace(fileurl, "");
			var filename = fileurl.split('.')[0];
			var ext = fileurl.split('.')[1];
			if (ext == undefined) {
				return date;
			}
			return newurl + chicken + '/' + filename + '.' + ext;
		}
		//alert(strArr[strArr.length-1]);
	}
}

$(function () {
	$.log = function (msg) {
		console.log(msg);
	}
	String.prototype.replaceAll = function (s1, s2) {
		return this.replace(new RegExp(s1, "gm"), s2);
	}
	String.prototype.patch = function (re) {
		var reg = new RegExp(re, "g");
		var arr = this.match(reg);
		if (arr != null) {
			return arr.length;
		} else {
			return 0;
		}
	}

	String.prototype.trim = function () {
		return this.replace(/(^\s*)|(\s*$)/g, "");
	}

	if (typeof (template) != "undefined") {
		template.config('escape', false);
		/**
		 * 转换成小写
		 */
		template.helper('toLower', function (data) {
			return data.toLowerCase();
		})
		template.helper('dateFormat', function (date, format) {
			if (date == null) { return "未知" }
			if (date.indexOf(".") > 0) { date = date.split(".")[0] }
			//转换格式以兼容ios时间坑
			date = date.replaceAll("-", "/");
			date = new Date(date);
			var map = {
				"M": date.getMonth() + 1, //月份   
				"d": date.getDate(), //日   
				"h": date.getHours(), //小时   
				"m": date.getMinutes(), //分   
				"s": date.getSeconds(), //秒   
				"q": Math.floor((date.getMonth() + 3) / 3), //季度   
				"S": date.getMilliseconds() //毫秒   
			};

			format = format.replace(/([yMdhmsqS])+/g, function (all, t) {
				var v = map[t];

				if (v !== undefined) {
					if (all.length > 1) {
						v = '0' + v;
						v = v.substr(v.length - 2);
					}
					return v;
				}
				else if (t === 'y') {
					return (date.getFullYear() + '').substr(4 - all.length);
				}
				return all;
			});

			return format;
		});
		template.helper('imgLink', function (date, format) {

			return $.apiUrl + date;
			//return format;  
		});
		template.helper('withParaLink', function (link, format) {
			if (link.indexOf("?") > -1) {
				return link;
			} else {
				return link + "?" + getBaseUrlPara();
			}
		});
		template.helper('encodeURI', function (date, format) {

			return encodeURI(date);
		});
		template.helper('escape', function (date, format) {
			return escape(date);
		});

		template.helper('prizelevel', function (num) {
			switch (num) {
				case 1:
					return "一等奖";
				case 2:
					return "二等奖";
				case 3:
					return "三等奖";
				case 4:
					return "四等奖";
				case 5:
					return "五等奖";
			}
		});

		template.helper('chickenImg', chickenImg);
		template.helper('splitImg', function (date) {
			if (date == null) { return "" }
			if (date.indexOf(",") > -1) {
				var _date = date.split(",")[0];
				return _date;
			} else {
				return date;
			}
		});

		template.helper('delHtml', function (str) {
			var r = str.replace(/<[^>]+>/g, "");
			r = r.replace(/(^\s*)|(\s*$)/g, "");
			return r;
		});

	}




	//友好提示
	$.alertH = function (txt, callback) {
		var html = '<div class="alert-panel">';
		html += '<img src="../images/失败.png" style="width:64px"><br>';
		html += '<span class="f16">' + txt + '</span>';
		html += '</div>';
		$.alert(html, function () { callback() });
	}

	$.loadAdData2 = function (linkUrl, para, backFun) {
		var html = '<iframe style="display:none" id="postIframe" name="postIframe"></iframe><form style="display:none" id="postForm" target="postIframe" method="post"></from>';
		if ($("#postForm").length == 0) {
			$(".publishContent").append(html);
		}
		var url = $.apiUrl + "/" + $.IFramePath + "/";

		var input = "";
		for (var n in para) {
			input += '<textarea style="display:none" name="' + n + '">' + para[n] + '</textarea>';
		}
		$.backFun2 = backFun;
		$("#postForm").html(input);
		$("#postForm").attr("action", linkUrl + "?action=" + para.action + "&JumpUrl=" + url + "ok.html");
		$("#postForm").submit();
	};

	$.filterUrl = function (shareUrl) {
		var _s = shareUrl;

		var appid = getAppid();
		var aid = getAid();
		var urlid = getQueryString("urlid");
		var openid = getOpenId();

		if (_s.indexOf("?") > -1) {
			_s = _s.split("?")[0];
		}

		_s = _s + "?aid=" + aid + "&appid=" + appid + "&urlid=" + urlid + "&shareid=" + openid + "&t=" + getNowFormatDate()
		//alert(_s);
		return _s;
	}

	$.delHtmlTag = function (str) {
		return str.replace(/<[^>]+>/g, "");
	}
	/**
	 * 加载一个页面
	 */
	$.loadAdData = function (linkUrl, para, backFun, otherobj) {
		var type = "get";
		var _dataType = "jsonp";
		$.ajax({
			url: linkUrl,
			type: "GET",
			dataType: "jsonp",
			data: para,
			jsonp: 'jsonpcallback',
			contentType: "application/jsonp; charset=utf-8",
			success: function (backData) {

				var appid = getAppid();
				var aid = getAid();
				var enurl = encodeURIComponent($.adUrl);

				if (backData != null) {

					switch (backData.state) {
						case 1:
							backFun(backData, para, linkUrl, otherobj);
							break;
						case -5: //超时未登录
							$.wxlogin(false);
							return;
						case -10: //重新登陆
							var nowUrl = indexUrl();
							$.wxlogin(true);
							return;
						case -11:
							var errhtml = '<div class="card"><div class="tc nolist"><img src="../images/no.png"><br>审核中...</div></div>';
							$(".list-block").first().html(errhtml);
							$.toast("审核中...");
							break;
						default:
							// if (backData.data.indexOf("认证") > -1) {
							// 	$.alertH(backData.data, function () { $.href('../User/rzlist.html') });
							// }
							$(".readmask").hide();
							$("#redcard0").hide();
							if (backFun != null) {
								backFun(backData, para, linkUrl, otherobj);
							}
							else {
								Msg(backData.data);
							}

							break;
					}
				}

			},
			error: function (e) {
				//$.toast("error:"+JSON.stringify(e));
				$.hideIndicator();
			}
		});
	};

	//查看密码 固定.eye
	$(document).on("touchend", '.eye', function () {
		var obj = $(this).parent().find('input')
		var type = obj.attr("type");
		if (type == "password") {
			obj.attr("type", "text");
		}
		if (type == "text") {
			obj.attr("type", "password");
		}
	});

	//返回按钮
	$.back = function (msg, title) {

		var ref = document.referrer;
		if (ref.indexOf("index/index") > -1) {
			ref = delcode(ref);
			$.href(ref);
		} else {
			history.back(-1);
		}
		return;
	}


	//点击跳转
	$.home = function () {
		$.href("../index/index.html");
	}

	function setCookie(c_name, value, expiredays) {
		var exdate = new Date()
		exdate.setDate(exdate.getDate() + expiredays)
		document.cookie = c_name + "=" + escape(value) + ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
	}

	//back操作
	//$(document).off('click','.back');
	//$(document).on('click','.back', function (event) {
	//if (window.history.length == 1) {
	//$.router.loadPage(this.href);
	//event.preventDefault();
	//return false;
	//}
	//});

})

function indexUrl() {
	var nowUrl = window.location.origin + window.location.pathname;
	// nowUrl = delcode(nowUrl);
	// var aid = getAid();
	// var appid = getAppid();


	//if(nowUrl.indexOf("?")>0){nowUrl = nowUrl.split("?")[0];}
	//nowUrl=nowUrl+"?appid="+appid;
	return nowUrl;
}

function getQueryString(name) {
	var url = window.location.search;
	if (url.indexOf("undefined") > -1) {
		url = url.replace("undefined", "");
	}
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
	var r = url.substr(1).match(reg);
	if (r != null) return decodeURI(r[2]); return null;
}
function frameUploadImgBackFun(obj) {
	$.uploadImgOk(obj);
}
function frameUploadImgBackFun2(obj) {
	$.uploadImgOk2(obj);
}
function frameUploadImgBackErrFun(obj) {
	$.toast(obj.data);
}

// function GetSession(key) {
// 	var d = localStorage[key];
// 	if (d == null || d == undefined || d == '' || d == 'undefined') {
// 		return null;
// 	} else {
// 		return d;
// 	}
// }
// function SetSession(key, value) {
// 	localStorage[key] = value;
// }
function clearLocalData(key) {
	localStorage.removeItem(key);
}
function getLocalGPS() { }
function setLocalGPS() { }

function getBaseUrlPara() {
	var ob = getBaseUrlData({});
	let url = "";
	if (ob.aid != null)
		url += "aid=" + ob.aid;

	if (ob.appid != null) {
		if (url != "") {
			url += "&appid=" + ob.appid;
		}
		else {
			url += "appid=" + ob.appid;
		}
	}
	if (url != "") {
		url += "&n=" + Math.random();
	}
	return url;
}

/**
 * 启动页面
 * @param {string} jsName Jquery筛选的Page对象ID名称
 * @param {function(object,object,object)} fun 回调function (e,id,page) 
 */
function PageRun(jsName, fun) {
	$(document).on("pageInit", jsName, fun);
}


//获取当前格式化的时间
function getNowFormatDate() {
	var date = new Date();
	var seperator1 = "-";
	var seperator2 = ":";
	var month = date.getMonth() + 1;
	var strDate = date.getDate();
	if (month >= 1 && month <= 9) {
		month = "0" + month;
	}
	if (strDate >= 0 && strDate <= 9) {
		strDate = "0" + strDate;
	}
	var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
		+ " " + date.getHours() + seperator2 + date.getMinutes()
		+ seperator2 + date.getSeconds();
	return currentdate;
}
function getBaseUrlData(obj, action) {
	var ob = obj;
	if (ob == null) {
		ob = {};
	}
	ob.aid = getAid();
	ob.appid = getAppid();
	ob.openid = getOpenId();
	ob.n = Math.random();
	if (action != null)
		ob.action = action;
	return ob;
}

function delcode(url, code) {
	var nurl = url;
	if (nurl.indexOf("&code=") > -1) {
		nurl = nurl.replaceAll("&code=", "&oc=");
	}
	if (nurl.indexOf("%26code=") > -1) {
		nurl = nurl.replaceAll("%26code=", '%26oc=');
	}
	if (nurl.indexOf("&oc=") > -1) {
		nurl = nurl.replaceAll("&oc=" + getQueryString("oc"), "");
	}
	return nurl;
}

function wxlogin1() {
	//var appid = "wx9babadc78d0e426c";//
	var appid = "wx9ddddcbd8f031cc8";//
	var nowUrl = window.location.origin + window.location.pathname;
	nowUrl = delcode(nowUrl) + "&login1=true";

	nowUrl = encodeURIComponent(nowUrl);
	var baseUrl = 'https://open.weixin.qq.com/connect/oauth2/authorize?appid=' + appid + '&redirect_uri=' + nowUrl + '&response_type=code&scope=snsapi_base#wechat_redirect';
	window.location.href = baseUrl;
}

function wxlogin2() {
	//var appid = "wx61a46e829602a6a3";//
	var appid = "wx9ddddcbd8f031cc8";//
	var nowUrl = window.location.origin + window.location.pathname;
	if (nowUrl.indexOf("&login1=true") > -1) {
		nowUrl = nowUrl.replace("&login1=true", "");
	}
	nowUrl = delcode(nowUrl) + "&login2=true";
	nowUrl = encodeURIComponent(nowUrl);
	var baseUrl = 'https://open.weixin.qq.com/connect/oauth2/authorize?appid=' + appid + '&redirect_uri=' + nowUrl + '&response_type=code&scope=snsapi_base#wechat_redirect';
	window.location.href = baseUrl;
}


$.loadMoreData = function (morePara, contentPanel, scrollFlag, page, processData, JQ_WhileClass, JQ_BindID = '.infinite-scroll-bottom') {
	if (StrIsNullOrEmpty(JQ_WhileClass))
		JQ_WhileClass = "li";
	//分类信息
	var loadMoreing = false;
	var loadMorePara = getBaseUrlData({ action: "", page: 1, num: 10 });
	for (var str in morePara) {
		loadMorePara[str] = morePara[str];
	}
	Log("初始化分页:");
	//从服务器获取信息
	getDataFromSercer = function () {
		Log("初始化:getDataFromSercer");
		var nowNum = contentPanel.find(JQ_WhileClass).length;
		loadMorePara.page = parseInt(nowNum / $.pageNum);
		loadMorePara.page += 1;
		$('.infinite-scroll-preloader').show();
		$.loadAdData($.adUrl, loadMorePara, function (data, para, url) {
			var result = data.data;
			var arr = result.data;

			if (processData != null) {
				processData(result);
			}

			if (result.currentMonthIncome != undefined) {
				$("#moneyLabel").text(result.currentMonthIncome + "元");
			}

			if (result == "") { result = { data: "" }; }
			var html = template(morePara.template, result);

			//缓存预处理
			var div = document.createElement("DIV");
			$(div).html(html);
			contentPanel.find("img").removeClass("new_load_img");
			$(div).find("img").addClass("new_load_img");

			if ($.showImg) {
				$(".smartList .item-media").show();
			} else {
				$(div).find(".smartList img").each(function () {
					var src = $(this).attr("src");
					$(this).removeAttr("src");
					$(this).attr("_src", src);
				});
			}

			html = $(div).html();
			div = null;
			contentPanel.append(html);

			contentPanel.data("count", result.allcount);
			$('.infinite-scroll-preloader').hide();

			$(".y-sylist .item-media .new_load_img").jqthumb({ width: "80px", height: "60px", reinit: false });
			try { $.templateOk(contentPanel); } catch (e) { }

			result = null;
			html = null;
		});
	};

	if (scrollFlag == true) {

		Log("初始化滚动...");
		//滚动加载信息
		$(page).on('infinite', JQ_BindID, function () {
			if (loadMoreing) return;
			loadMoreing = true;
			// 模拟1s的加载过程
			setTimeout(function () {

				loadMoreing = false;
				lastIndex = contentPanel.find(JQ_WhileClass).length;
				if (lastIndex >= contentPanel.data("count")) {
					$.detachInfiniteScroll($('.infinite-scroll'));
					$('.infinite-scroll-preloader').remove();
					return;
				}
				Log("滚动执行:getDataFromSercer");
				getDataFromSercer();
				$.refreshScroller();
			}, 600);
		});
	}

	getDataFromSercer();

};