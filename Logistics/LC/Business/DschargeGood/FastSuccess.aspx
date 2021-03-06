﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FastSuccess.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.FastSuccess" %>

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
        input[type=checkbox]{
            -webkit-appearance:checkbox;
            height: .8rem;
        }
        .bus_list li.active i.iconfont{
            display: block;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:;"  onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <!-- <a href="choose_bus.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">中转货物</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="txt_center white" style="padding:1rem;margin-top:1rem;">
                        <p> <i class="iconfont fc_green" style="font-size:55px;">&#xe67b;</i></p>
                        <p>放货成功</p>
                        <p class="dis_flex" style="justify-content:center;"><i class="col_50 txt_left">运费： <span>￥1213</span></i></p>
                        <p class="dis_flex" style="justify-content:center;"><i class="col_50 txt_left">电话： <span>12345678901</span></i></p>
                        <strong  style="font-size:25px; font-weight:400;">三鑫物流</strong>
                        <p class="fz_12 txt_right mart_20">添加日期： <span>2017-07-20 00：57</span></p>
                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
        //setInterval(function(){
        //    window.location.href ="/LC/Business/DschargeGood/IndexDhg.aspx"
        //},2000)
        Href("/LC/Business/DschargeGood/IndexDhg.aspx", 200);
    </script>

</body>

</html>
