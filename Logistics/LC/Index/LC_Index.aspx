<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Index.aspx.cs" Inherits="Logistics.LC_Index.LC_Index" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流首页</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
       
    </style>
</head>

<body>
   
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <div class="content" style="background:#ededed;">
                <div>
                    <div><img src="/GetQR.aspx?url=<%=HttpUtility.UrlEncode($"http://wl.mikiboss.com/Login/Register.aspx?ZType=1&LogisticsUid={UID}") %>&logo=http://wl.mikiboss.com/Style/img/success.png"/></div>
                    <p style="font-size:15px">扫描二维码注册账户</p>
                </div>
                <div class="page-index">
                    <ul class="main">
                        <li class="main-li1">
                            <a href="/LC/Index/LC_IndexGL.aspx" class="row">
                                <div class="col-30">
                                    <span class="iconfont icon-gears"></span>
                                </div>
                                <div class="col-70">
                                    物流公司管理
                                </div>
                            </a>
                        </li>
                        <li class="main-li2">
                            <a href="/LC/Index/LC_IndexYW.aspx" class="row">
                                <div class="col-30">
                                    <span class="iconfont icon-car1"></span>
                                </div>
                                <div class="col-70">
                                    物流公司业务
                                </div>
                            </a>
                        </li>
                        <li class="main-li3">
                            <a href="zbcaiwu.html" class="row">
                                <div class="col-30">
                                    <span class="iconfont icon-calculator"></span>
                                </div>
                                <div class="col-70">
                                    物流公司财务
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

    <script>
        $(function() {
            $.init();
            $.config = {
                router: false
            }
        });
    </script>

</body>

</html>