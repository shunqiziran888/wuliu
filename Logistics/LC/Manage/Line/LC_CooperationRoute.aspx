<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_CooperationRoute.aspx.cs" Inherits="Logistics.LC.Manage.Line.LC_CooperationRoute" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="utf-8">
<title></title>
<meta content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" name="viewport" />
<link type="text/css" rel="stylesheet" href="/Style/css/basic.css" />
<script type="text/javascript" src="/Style/scripts/jquery-1.7.2.min.js"></script>
<!--加载样式-->
<script>
$(window).load(function() {
	$("#status").fadeOut();
	$("#preloader").delay(350).fadeOut("slow");
})
</script>
</head>

<body>
    <div class="w">
  <!--页面加载 开始-->
  <div id="preloader">
    <div id="status">
      <p class="center-text">加载中… </p>
    </div>
  </div>
  <!--页面加载 结束-->
  <!--header 开始-->
  <header>
    <div class="header">
      <h2>合作线路</h2>
    <a class="new-a-jd" id="trigger-overlay" href="javascript:void(0)"> <span>导航菜单</span> </a>
    </div>
  </header>
  <!--header 结束-->
  <div class="page">
    <div class="main">
      <form id="form1" runat="server" method="post" action="?">
          <div class="item item-username">
             <input name="Phone" class="txt-input txt-username" type="text" id="Phone" placeholder="手机号/帐号">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="ui-btn-wrap"> <a class="ui-btn-lg ui-btn-primary" href="#" onclick="loginwl()">确定</a> </div>
      </form>
    </div>
      <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>
    <script type="text/javascript" >
    $(function() {
		$(".input-close").hide();
		displayPwd();
		displayPwd_PwdTwo();
		remember();
		showActionError();
		autoHeight_login();
		dispValidateCode();
		displayClearBtn();
		setTimeout(displayClearBtn, 200 ); //延迟显示,应对浏览器记住密码
	});

	//是否显示清除按钮
	function displayClearBtn(){
		if(document.getElementById("username").value != ''){
			$("#username").siblings(".input-close").show();
		}
		if(document.getElementById("password").value != ''){
			$(".ciphertext").siblings(".input-close").show();
		}
		if(document.getElementById("password_PwdTwo").value != ''){
			$(".ciphertext_PwdTwo").siblings(".input-close").show();
		}
	}

	//清除input内容
    $('.input-close').click(function(e){
		$(e.target).parent().find(":input").val("");
		$(e.target).hide();
		$($(e.target).parent().find(":input")).each(function(i){
			if(this.id=="ptext" || this.id=="password"){
				$("#password").val('');
				$("#ptext").val('');
			}
			if(this.id=="ptext_PwdTwo" || this.id=="password_PwdTwo")
				$("#password_PwdTwo").val('');
				$("#ptext_PwdTwo").val('');
			}
         });
    });

	//设置password字段的值
	$('.txt-password').bind('input',function(){
		$('#password').val($(this).val());
	});
	$('.txt-password_PwdTwo').bind('input',function(){
		$('#password_PwdTwo').val($(this).val());
	});

	//显隐密码切换
	function displayPwd(){
    	$(".tp-btn").toggle(
          function(){
            $(this).addClass("btn-on");
			var textInput = $(this).siblings(".plaintext");
    		var pwdInput = $(this).siblings(".ciphertext");
			pwdInput.hide();
			textInput.val(pwdInput.val()).show().focusEnd();
          },
          function(){
		  	$(this).removeClass("btn-on");
		  	var textInput = $(this).siblings(".plaintext");
    		var pwdInput = $(this).siblings(".ciphertext");
            textInput.hide();
			pwdInput.val(textInput.val()).show().focusEnd();
          }
    	);
	}
	//显隐密码切换
	function displayPwd_PwdTwo(){
    	$(".tp-btn_PwdTwo").toggle(
          function(){
            $(this).addClass("btn-on_PwdTwo");
			var textInput = $(this).siblings(".plaintext_PwdTwo");
    		var pwdInput = $(this).siblings(".ciphertext_PwdTwo");
			pwdInput.hide();
			textInput.val(pwdInput.val()).show().focusEnd();
          },
          function(){
		  	$(this).removeClass("btn-on_PwdTwo");
		  	var textInput = $(this).siblings(".plaintext_PwdTwo");
    		var pwdInput = $(this).siblings(".ciphertext_PwdTwo");
            textInput.hide();
			pwdInput.val(textInput.val()).show().focusEnd();
          }
    	);
	}

	//监控用户输入
	$(":input").bind('input propertychange', function() {
		if($(this).val()!=""){
			$(this).siblings(".input-close").show();
		}else{
			$(this).siblings(".input-close").hide();
		}
	});


	function shows(id, elename) {
	    GetHtml("/Command/GetAddressNextList.aspx", { id: id }, function (data) {
	        let list = JSON.parse(data);
	        $("#" + elename).empty();
	        $("#" + elename).append("<option>请选择</option>");
	        for (let i = 0; i < list.length; i++) {
	            $("#" + elename).append("<option value='" + list[i].id + "'>" + list[i].Name + "</option>");
	        }
	    });
	}

	function loginwl() {
	    document.getElementById("form1").submit();
	  <%--  var UID = "<%=GetValue("UID")%>";
	document.getElementById("LCID").value = ""+UID+"";--%>
	}
</script>
</body>
</html>
