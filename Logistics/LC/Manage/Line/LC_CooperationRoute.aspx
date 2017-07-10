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
        $(window).load(function () {
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
                <a class="new-a-jd" id="trigger-overlay" href="javascript:void(0)"><span>导航菜单</span> </a>
            </div>
        </header>
        <!--header 结束-->
        <div class="page">
            <div class="main">
                <form id="form1" runat="server" method="post" action="?">

                    <div class="item item-username">
                        物流运号首字母:
                        <select id="Lineletter" name="Lineletter">
                            <option value="">请选择</option>
                            <option value="A">A</option>
                            <option value="B">B</option>
                            <option value="C">C</option>
                            <option value="D">D</option>
                            <option value="E">E</option>
                            <option value="F">F</option>
                            <option value="G">G</option>
                            <option value="H">H</option>
                            <option value="I">I</option>
                            <option value="J">J</option>
                            <option value="K">K</option>
                            <option value="L">L</option>
                            <option value="M">M</option>
                            <option value="N">N</option>
                            <option value="O">O</option>
                            <option value="P">P</option>
                            <option value="Q">Q</option>
                            <option value="R">R</option>
                            <option value="S">S</option>
                            <option value="T">T</option>
                            <option value="U">U</option>
                            <option value="V">V</option>
                            <option value="W">W</option>
                            <option value="X">X</option>
                            <option value="Y">Y</option>
                            <option value="Z">Z</option>
                        </select>
                        <b class="input-close" style="display: none;"></b>
                    </div>


                    <div class="item item-username">
                        <input name="ZNumber" class="txt-input txt-username" type="text" id="ZNumber" placeholder="填写您的物流账号">
                        <b class="input-close" style="display: none;"></b>
                    </div>
                    <div class="item item-username">
                        <input name="Pwd" class="txt-input txt-username" type="password" id="Pwd" placeholder="填写您的物流密码">
                        <b class="input-close" style="display: none;"></b>
                    </div>
                    <div class="ui-btn-wrap"><a class="ui-btn-lg ui-btn-primary" id="updatebtn">确定绑定</a> </div>
                </form>
            </div>
            <script type="text/javascript" src="/Style/scripts/all.js"></script>
            <script>
                $(function () {
                    $("#updatebtn").click(function () {
                        let ZNumber = $("#ZNumber").val();
                        let Pwd = $("#Pwd").val();
                        let Lineletter = $("#Lineletter").val();
                        let binduid = GET("binduid");
                        let xl = GET("xl");

                        if (StrIsNull(Lineletter)) {
                            alert("物流运号首字母必须选择!");
                            return;
                        }
                        if (StrIsNull(ZNumber) || StrIsNull(Pwd))
                        {
                            alert("账号密码不能为空!");
                            return;
                        }

                        if (StrIsNull(binduid))
                        {
                            alert("要绑定的UID不存在!");
                            return;
                        }

                        if (StrIsNull(xl))
                        {
                            alert("绑定人货运号首字母参数错误!");
                            return;
                        }

                        let url = GetNowHrefNoParam() + "?ZNumber=" + ZNumber + "&Pwd=" + Pwd + "&Lineletter=" + Lineletter + "&xl=" + xl;
                        url = url + "&binduid=" + binduid;
                        Href(url);
                        //$("#form1").submit();
                    });
                });
            </script>
</body>
</html>
