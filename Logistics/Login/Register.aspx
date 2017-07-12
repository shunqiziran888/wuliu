<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Logistics.Login.Register" %>
<%@ Import Namespace="GlobalBLL" %>
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
          <%switch (GetValue<AccountTypeEnum>("ZType"))
              {
                  case AccountTypeEnum.物流账号:
                  %>
        <div class="item item-username">
             <input name="LogisticsName" class="txt-input txt-username" type="text" id="LogisticsName" placeholder="公司名称">
          <b class="input-close" style="display: none;"></b> </div>
          <div class="item item-username">
             <input name="Phone" class="txt-input txt-username" type="text" id="Phone" placeholder="手机号">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-password">
            <input name="Password" class="txt-input txt-password ciphertext" type="text" id="Password" size="15" placeholder="请输入密码" style="display: inline;">
          <input id="ptext" class="txt-input txt-password plaintext" type="text" placeholder="请输入密码" style="display: none;" name="ptext">
          <b class="tp-btn btn-off"></b> </div>
          <div class="item item-username">
              <select id="End1" name="End1" style="width:300px" onchange="shows(this.value,'End2');"> 
                                    <option>请选择</option>
                                    <%
                                        foreach (var p in shengList)
                                        {
                                     %>
                                <option value="<%=p.id %>"><%=p.Name %></option>
                                    
                                <%
                                    } %>
                                </select>省份&nbsp &nbsp &nbsp 
                                 <select id="End2" name="End2" style="width:300px" onchange="shows(this.value,'End');"> 
                                </select>城市&nbsp &nbsp &nbsp 
                                 <select id="End" name="End" style="width:300px" > 
                                </select>区县&nbsp &nbsp &nbsp
          </div>
          <input type="hidden" id="ZType" name="ZType" value="1"/>
          <input type="hidden" id="State" name="State" value="1"/>
          <input type="hidden" id="LogisticsUid" name="LogisticsUid" value="<%=GetValue("LogisticsUid")%>"/>
         <input type="hidden" id="FalseValue" name="FalseValue" value="10"/>
        <div class="ui-btn-wrap"> <a class="ui-btn-lg ui-btn-primary" href="#" onclick="loginwl()">物流注册</a> </div>
      <%
                  break;
              case AccountTypeEnum.普通用户账号:
                  %>
             <div class="item item-username">
             <input name="UserName" class="txt-input txt-username" type="text" id="UserName" placeholder="用户昵称" style="display:none">
          <b class="input-close" style="display: none;"></b> </div>
          <div class="item item-username">
             <input name="Phone" class="txt-input txt-username" type="text" id="Phone" placeholder="请输入手机号注册或绑定物流" oninput="phonechange(this);" onpropertychange="phonechange(this);">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-password">
            <input name="Password" class="txt-input txt-password ciphertext" type="text" id="Password" size="15" placeholder="请输入密码" style="display: none;" >
          <input id="ptext" class="txt-input txt-password plaintext" type="text" placeholder="请输入密码" style="display: none;" name="ptext">
          <b class="tp-btn btn-off"></b> </div>

          <input type="hidden" id="ZType" name="ZType" value="3"/>
          <input type="hidden" id="State" name="State" value="1"/>
          <input type="hidden" id="yonghu" name="yonghu" value="yhbd"/>
          <input type="hidden" id="LogisticsUid" name="LogisticsUid" value="<%=GetValue("LogisticsUid")%>"/>
          <input type="hidden"  id="UIDS" name="UIDS" value="heheda"/>
        <div class="ui-btn-wrap"> <button class="ui-btn-lg ui-btn-primary" disabled="disabled"  id="yhvalue" type="button" onclick="loginwl()">用户注册</button> </div>
          <%
                  break;
              case AccountTypeEnum.物流公司员工账号:
                                        %>
          <div class="item item-username">
             <input name="UserName" class="txt-input txt-username" type="text" id="UserName" placeholder="真实姓名">
          <b class="input-close" style="display: none;"></b> </div>
           <div class="item item-username">
            <%-- <input name="PositionID" class="txt-input txt-username" type="text" id="PositionID" placeholder="职位">--%>
               <select id="PositionID" name="PositionID">
                   <option>请选择</option>
                   <option value="1">司机</option>
                   <option value="2">财务</option>
                   <option value="3">客服</option>
                   <option value="4">营销员</option>
               </select>
          <b class="input-close" style="display: none;"></b> </div>
          <div class="item item-username">
             <input name="Phone" class="txt-input txt-username" type="text" id="Phone" placeholder="手机号">
          <b class="input-close" style="display: none;"></b> </div>
        <div class="item item-password">
            <input name="Password" class="txt-input txt-password ciphertext" type="text" id="Password" size="15" placeholder="请输入密码" style="display: inline;">
          <input id="ptext" class="txt-input txt-password plaintext" type="text" placeholder="请输入密码" style="display: none;" name="ptext">
          <b class="tp-btn btn-off"></b> </div>
          <div class="item item-username">
              <select id="End1" name="End1" style="width:300px" onchange="shows(this.value,'End2');"> 
                                    <option>请选择</option>
                                    <%
                                        foreach (var p in shengList)
                                        {
                                     %>
                                <option value="<%=p.id %>"><%=p.Name %></option>
                                    
                                <%
                                    } %>
                                </select>省份&nbsp &nbsp &nbsp 
                                 <select id="End2" name="End2" style="width:300px" onchange="shows(this.value,'End');"> 
                                </select>城市&nbsp &nbsp &nbsp 
                                 <select id="End" name="End" style="width:300px" > 
                                </select>区县&nbsp &nbsp &nbsp
          </div>
          <input type="hidden" id="ZType" name="ZType" value="4"/>
          <input type="hidden" id="State" name="State" value="0"/>
          <input type="hidden" id="LogisticsUid" name="LogisticsUid" value="<%=GetValue("LogisticsUid")%>"/>
        <div class="ui-btn-wrap"> <a class="ui-btn-lg ui-btn-primary" href="#" id="updatebtn" onclick="loginwl()">员工注册</a> </div>

          <%
                  break;
          } 
          %>
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
		setTimeout(displayClearBtn, 200); //延迟显示,应对浏览器记住密码
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
	$('.input-close').click(function (e) {
	    $(e.target).parent().find(":input").val("");
	    $(e.target).hide();
	    $($(e.target).parent().find(":input")).each(function (i) {
	        if (this.id == "ptext" || this.id == "password") {
	            $("#password").val('');
	            $("#ptext").val('');
	        }
	        if (this.id == "ptext_PwdTwo" || this.id == "password_PwdTwo") {
	            $("#password_PwdTwo").val('');
	            $("#ptext_PwdTwo").val('');
	        }
	    });
	    //设置password字段的值
	    $('.txt-password').bind('input', function () {
	        $('#password').val($(this).val());
	    });
	    $('.txt-password_PwdTwo').bind('input', function () {
	        $('#password_PwdTwo').val($(this).val());
	    });
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
	        var Phone = $("#Phone").val();
	        var Password = $("#Password").val();
	        GetHtml("/Login/Register.aspx", { Phone: Phone, Password: Password }, function (data) {
	        });
	        document.getElementById("form1").submit();
	    }
	        //$("#updatebtn").click(function () {
	        //    var LogisticsName = $("#LogisticsName").val();
	        //    var Password = $("#Password").val();
	        //    alert(LogisticsName+" and "+Password);
	        //    let url = GetNowHrefNoParam() + "?ZNumber=" + LogisticsName + "&Pwd=" + Password;
	        //    Href(url);
        //});
	    function phonechange(element) {
	        var Phone = $(element).val();
	        if (Phone.length == 11) {
	            GetHtml("/Command/RegisterUserBinding.aspx", { Phone: Phone }, function (data) {
	                debugger;
	                let vo = JSON.parse(data);
	                if (vo.Item1) {
	                    let list = vo.Item3;
	                    if(list.length>0)
	                    {
	                        document.getElementById("yhvalue").text = "确认绑定";
	                        var UIDS = list[0].UID;
	                        document.getElementById("UIDS").value = "" + UIDS + "";
	                    }
	                    else
	                    {
	                        document.getElementById("UserName").style.display = "block";
	                        document.getElementById("Password").style.display = "block";
	                        document.getElementById("yonghu").text = "yhzc";
	                        document.getElementById("yhvalue").text = "用户注册";
	                    }
	                    $("#yhvalue").removeAttr("disabled");
	                }
	            });
	        }
	    }
</script>
</body>
</html>