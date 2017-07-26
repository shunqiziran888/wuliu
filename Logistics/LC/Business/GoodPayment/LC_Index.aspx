﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Index.aspx.cs" Inherits="Logistics.LC.Business.GoodPayment.LC_Index" %>

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
        .prompt_msg {
            position: absolute;
            width: 22px;
            height: 22px;
            background: #f00;
            border-radius: 20px;
            color: #fff;
            line-height: 22px;
            top: 50%;
            left: 68%;
            margin-top: -11px;
            font-size: 10px;
            text-align: center;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
               <a href="javascript:;" onclick="window.history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <h1 class="title">货款管理</h1>
            </header>

           
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    
                    <ul class="zbshangjia-ul">
                        <li class="shangjia-li1">
                            <a href="/LC/Business/GoodPayment/Paid/LC_Index.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-long-arrow-up" style="color: #41d9bd;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    上缴货款
                                    <!-- <span class="prompt_msg" >10</span> -->
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li2">
                            <a href="#" onclick="No()" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-circlearrowright" style="color: #b160b3;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    回收货款
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li3">
                             <a href="#" onclick="No()" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-circlearrowleft" style="color: #009621;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    放款
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li7">
                              <a href="#" onclick="No()" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-cached" style="color: #f2a207;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    未上缴货款
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li5">
                             <a href="#" onclick="No()" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-approvalhistory" style="color: #ff0000;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    未回收货款
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>

    <script type="text/javascript">
        $(function () {
            $.init();
            $.config = { router: false }
        });
        function No() {
            alert("功能暂未开放！");
            return;
        }
    </script>

</body>

</html>