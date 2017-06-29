<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_GoodDetails.aspx.cs" Inherits="Logistics.LC.Business.MeetCar.LC_GoodDetails" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        .wyfh-ul .dingdan-li .dingdan-right {
            margin-top: 0rem;
        }
        
        .dingdan-ul .dingdan-li {
            height: 50px;
            line-height: 50px;
            padding: 0 1rem;
        }
        
        .top-btn {
            padding: .5rem 2rem;
        }
        
        .top-btn a {
            height: 2.5rem;
            line-height: 2.5rem;
        }
        
        .top-btn a span {
            font-size: .7rem;
            margin-right: .2rem;
        }
        
        .xiangqing {
            margin: .5rem;
            background: #fff;
            border-radius: 10px;
            padding: .5rem;
            border: 1px solid #bbb;
        }
        
        .xiangqing .row {
            margin-left: 0;
            border-bottom: 1px solid #d0d0d0;
        }
        
        .xiangqing .row:last-child {
            border: none;
            margin-bottom: 0;
            padding-bottom: 0;
        }
        
        .xiangqing .row .col-20 {
            margin-left: 0;
            width: 20%;
            text-align: center;
        }
        
        .p-tongji {
            font-size: .7rem;
            text-align: center;
            margin-bottom: .3rem;
        }
        
        .xiangqing li {
            font-size: .8rem;
            margin-bottom: .25rem;
            padding-bottom: .25rem;
        }
        
        .xiangqing .td-body {
            border-bottom: 1px solid #bbb;
        }
        
        .xiangqing .td-header span {
            font-size: .6rem;
        }
        
        .xiangqing .td-body span {
            font-size: .5rem;
        }
        
        .col-12 {
            width: 12%!important;
        }
        
        .col-15 {
            width: 15%!important;
        }
        
        .col-33 {
            width: 33%!important;
        }
        
        .xlmingcheng {
            font-size: .7rem;
            text-align: center;
            position: relative;
        }
        
        .xlmingcheng .zhuangtai {
            position: absolute;
            left: 1rem;
            top: .6rem;
        }
        
        .xlmingcheng .shoufadi {
            font-size: .8rem;
        }
        
        .jieche_btn {
            text-align: center;
            display: block;
            margin-top: 1rem;
        }
        
        .jieche_btn i {
            padding: .5rem 2.5rem;
            background: #2dbd4a;
            color: #fff;
            border-radius: 4px;
            font-size: 16px;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Business/MeetCar/LC_IndexMC.aspx"></a>
                <h1 class="title">物流管理系统</h1>
            </header>
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <ul class="xiangqing xlmingcheng">
                        <span class="zhuangtai">已装车</span>
                        <span class="shoufadi"><%=GlobalAddress.GetAddressFromID(CFD)?.Item2?.Name %>---<%=GlobalAddress.GetAddressFromID(MDD)?.Item2?.Name %></span>
                    </ul>
                    <ul class="xiangqing">

                        <li class="row td-header">
                            <span class="col-20">收货人</span>
                            <span class="col-20">货名</span>
                            <span class="col-20 col-12">件数</span>
                            <span class="col-20 col-15">运费</span>
                            <span class="col-20 col-33">货号</span>
                        </li>
                         <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                        <li class="row td-body">
                            <span class="col-20"><%=v.Consignee %></span>
                            <span class="col-20"><%=v.GoodName %></span>
                            <span class="col-20 col-12"><%=v.Number %></span>
                            <span class="col-20 col-15"><%=v.Freight %></span>
                            <span class="col-20 col-33"><%=v.GoodNo %></span>
                        </li>
                        <%} %>
                    </ul>
                    <a href="/LC/Business/MeetCar/LC_Success.aspx?CH=<%=list.GetIndexValue(0).VehicleID%>&Start=<%=list.GetIndexValue(0).Initially %>&End=<%=list.GetIndexValue(0).Destination %>" class="jieche_btn"><i>确认接车</i></a>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js">
    $(function() { $.init(); $.config = { router: false } });
    </script>
</body>

</html>
