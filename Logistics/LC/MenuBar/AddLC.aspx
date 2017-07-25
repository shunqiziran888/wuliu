<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLC.aspx.cs" Inherits="Logistics.LC.MenuBar.AddLC" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

   <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
       
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:;" onclick="window.history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-plus pull-right" href="share.html"></a>
                    <i class="add_txt">添加物流</i>
                </p> -->
                <h1 class="title">添加物流</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="white" style="padding:1rem;margin-top:1rem;">
                       <p class="txt_center"><img class="col_50" src="/Style/img/erweima.png"></p>
                       <p class="txt_center" style="margin-top:1rem;">扫描分享二维码</p>
                    </div>
                    <p class="dis_flex ali_center row_44 white" onclick="window.location.href='add_wuliu_details.html'" style="justify-content:center;margin-top:.5rem;"><span class="iconfont icon-share" style="color: #009621;"></span><span style="margin:0 2rem;">分享注册链接</span><span class="iconfont icon-angle-right"></span></p>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <%--<script src="/Style/scripts/main.js"></script>--%>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
