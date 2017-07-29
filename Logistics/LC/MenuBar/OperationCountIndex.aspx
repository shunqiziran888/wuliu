﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperationCountIndex.aspx.cs" Inherits="Logistics.LC.MenuBar.OperationCountIndex" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>运营统计</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
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
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-plus pull-right" href="index.html"></a>
                    <i class="add_txt">添加物流</i>
                </p> -->
                <h1 class="title">运营统计</h1>
            </header>

            <nav class="bar bar-tab">
                <a class="tab-item external " href="/LC/MenuBar/LC_BusinessIndex.aspx">
                  <span class="icon iconfont icon-filetexto"></span>
                  <span class="tab-label">物流业务</span>
              </a>
                <a class="tab-item external active" href="/count/">
                  <span class="icon iconfont icon-fcstubiao19"></span>
                  <span class="tab-label">运营统计</span>
              </a>
                <a class="tab-item external" href="/manage/index.html">
                  <span class="icon iconfont icon-guanli"></span>
                  <span class="tab-label">物流管理</span>
              </a>
                 <a class="tab-item external" href="/LC/MenuBar/Personal.aspx">
                  <span class="icon iconfont icon-user-circle"></span>
                  <span class="tab-label">我的</span>
              </a>
            </nav>
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索订单'/>
                </div>
              </div> -->
                    <ul class="zbshangjia-ul">
                        <li class="shangjia-li1">
                            <a href="/LC/OperationOverview/LC_Index.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-filter5" style="color: #b160b3;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    运营概况
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li2">
                            <a href="caiwu.html" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-jpy" style="color: #009621;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    财务情况
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li3">
                            <a href="fengongsi.html" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-done_all" style="color: #a6a6a6;"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    分公司运营情况
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

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
