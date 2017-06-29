<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Logistics.Login.Login" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>登录</title>
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
      <p class="center-text">加载中…</p>
    </div>
  </div>
  <!--页面加载 结束-->
  <!--header 开始-->
  <header>
    <div class="header">
      <h2>物流系统</h2>
      <a class="new-a-jd" id="trigger-overlay" href="javascript:void(0)"> <span>导航菜单</span> </a>
      </div>
  </header>
  <!--header 结束-->
  <div class="page">
    <div class="main">
      <form id="form1" runat="server" method="post" action="?">
        <div class="item item-username">
              <input placeholder='请输入用户名/手机号' class="txt-input txt-username" name="ZNumber" type="text" id="ZNumber" >
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-password">
            <input placeholder='请输入密码' class="txt-input txt-password ciphertext" name="Password" type="password" id="Password" style="display: inline;" >
          <input id="ptext" class="txt-input txt-password plaintext" type="text" placeholder="请输入密码" style="display: none;" name="ptext">
          <b class="tp-btn btn-off"></b> </div>
        <div class="item item-login-option"> <span class="retrieve-password"> <a class="" href="#"> 找回密码</a> </span>
          <div class="clr"></div>
        </div>
        <div class="ui-btn-wrap"> <a class="ui-btn-lg ui-btn-primary" href="#" onclick="loginwl()">用户登录</a> </div>
      </form>
    </div>
    <script type="text/javascript" >
    $(function() {
		$(".input-close").hide();
		displayPwd();
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
		if($("#codeLevel").val()!="" && $("#codeLevel").val()!='0'){
			if($("#validateCode").val()!=""){
				$("#validateCode").siblings(".input-close").show();
			}
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
         });
    });

	//设置password字段的值
	$('.txt-password').bind('input',function(){
		$('#password').val($(this).val());
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
		  	var textInput = $(this).siblings(".plaintext ");
    		var pwdInput = $(this).siblings(".ciphertext");
            textInput.hide();
			pwdInput.val(textInput.val()).show().focusEnd();
          }
    	);
	}

	//一个月免登陆切换
	function remember(){
    	$("#rememberMe").toggle(
          function(){
            $(this).removeClass("login-free-selected");
			 $('#remember').val("false");
          },
          function(){
		  	$(this).addClass("login-free-selected");
		  	 $('#remember').val("true");
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
</div>
</body>
</html>
<script type="text/javascript">
    function loginwl()
    {
        document.getElementById("form1").submit();
    }
</script>