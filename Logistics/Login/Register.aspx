<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Logistics.Login.Register" %>

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
      <h2>注册</h2>
    <a class="new-a-jd" id="trigger-overlay" href="javascript:void(0)"> <span>导航菜单</span> </a>
    </div>
  </header>
  <!--header 结束-->
  <div class="page">
    <div class="main">
      <form id="form1" runat="server" method="post" action="?">
        <div class="item item-username">
             <input name="UserName" class="txt-input txt-username" type="text" id="UserName" placeholder="用户名称">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-username">
            <input name="PositionID" class="txt-input txt-username" type="text" id="PositionID" placeholder="职位">
          <b class="input-close" style="display:none;"></b> </div>
          <div class="item item-username">
             <input name="Phone" class="txt-input txt-username" type="text" id="Phone" placeholder="手机号">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-password">
            <input name="Password" class="txt-input txt-password ciphertext" type="text" id="Password" size="15" placeholder="请输入密码" style="display: inline;">
          <input id="ptext" class="txt-input txt-password plaintext" type="text" placeholder="请输入密码" style="display: none;" name="ptext">
          <b class="tp-btn btn-off"></b> </div>
          <div class="item item-username">
            <%-- <input name="ZType" class="txt-input txt-username" type="text" id="ZType" placeholder="账号类型">--%>
              <select name="ZType" class="txt-input txt-username"  id="ZType">
                  <option>帐号类型</option>
                  <option value="1">物流总公司</option>
                  <option value="2">物流子公司</option>
                  <option value="3">客户端</option>
              </select>
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-captcha">
          <div class="input-info">
            <input id="validateCode" class="txt-input txt-captcha" type="text" placeholder="验证码" autocomplete="off" maxlength="6" size="11">
            <b id="validateCodeclose" class="input-close" onclick="validateCodeclose();" style="display: block;"></b> <span id="captcha-img"> <img id="code" src="/Style/img/code.jpg" style="width:63px;height:25px;" onclick="closeAndFlush();"> </span> </div>
        </div>
        <div class="ui-btn-wrap"> <a class="ui-btn-lg ui-btn-primary" href="#" onclick="loginwl()">用户注册</a> </div>
      </form>
    </div>
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
			if(this.id=="ptext_PwdTwo" || this.id=="password_PwdTwo"){
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
</script>
</body>
</html>
<script type="text/javascript">
    function loginwl()
    {
        document.getElementById("form1").submit();
    }
</script>
