﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CT_Success.aspx.cs" Inherits="Logistics.LC.Customer.DeliverGood.CT_Success" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流客户端</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
        input[type=checkbox] {
            -webkit-appearance: checkbox;
            height: .8rem;
        }

        select {
            line-height: 1.4rem;
        }

        select option {
            line-height: 1.4rem;
        }

        .buttons-tab .button.active {
            background: #0894ec;
            border: 1px solid #0894ec;
            color: #fff;
        }

        .tab_nav {
            display: flex;
            justify-content: center;
            background: #f2f2f2;
            border: none;
        }

        .tab_nav .tab_nav_btn {
            border: 1px solid #0894ec;
            height: 30px;
            line-height: 30px;
            background: #fff;
            color: #0894ec;
            font-size: .7rem;
            width: 173px;
        }

        .tab_nav .tab_nav_btn.nav1 {
            border-right: none;
            border-top-left-radius: 10px;
            border-bottom-left-radius: 10px;
        }

        .tab_nav .tab_nav_btn.nav2 {
            border-left: none;
            border-bottom-right-radius: 10px;
            border-top-right-radius: 10px;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:;" onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                
                <h1 class="title">发货完成</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="white box" style="padding: .5rem .5rem 1rem;margin-top:1rem;">
                         <p class="txt_center"> <i class="iconfont fc_green" style="font-size:55px;">&#xe67b;</i></p>
                        <p class="txt_center">发货成功</p> 
                        <p class="col_100 txt_center"><i class="txt_right fz_12 line_he_44">添加日期：</i><i class="txt_left fc_ash fz_12 line_he_44"><%=DdTime %></i></p>
                    </div>
                    <div style="line-height:1.5rem;margin-top:1rem;flex-wrap:wrap;padding-bottom:.5rem;" class="dis_flex white">
                        
                        <p class="col_100 txt_left" style="padding-left:5%;">
                            <i class="txt_right fz_16 col_20 line_he_44">货物名： </i>
                            <i class="txt_left fc_ash fz_14 col_80 line_he_44"><%=GoodName %>
                                 <span class="fc_red">x<%=Number %>件</span>
                                 <span class="fc_green" style="margin-left:.5rem;">(<%=freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span>
                            </i>
                        </p>
                        <p class="dis_flex   col_50" style="flex-direction: column;padding-left:5%;">

                            <i class="txt_left fz_16 line_he_40">收货人： <span class=" fz_14 fc_ash"><%=Consignee %></span></i>
                            <i class="txt_left fz_16 line_he_40">发货人：<span class=" fz_14 fc_ash"><%=Consignor %></span></i>
                            <i class="txt_left fz_16 line_he_40">收货地址：<span class=" fz_14 fc_ash"><%=Destination %></span></i>
                            <i class="txt_left fz_16 line_he_40">其他费用：<span class=" fz_14 fc_ash"><%=OtherExpenses %></span></i>
                            <i class="txt_left fz_16 line_he_40">代收货款：<span class=" fz_14 fc_ash"><%=GReceivables %></span></i>
                            <i class="txt_left fz_16 line_he_40 ">提货方式：<span class=" fz_14 fc_ash"><%=CarryGood.ConvertData<THFSEnum>().EnumToName() %></span></i>
                            <i class="txt_left fz_16 line_he_40 ">收货方式：<span class=" fz_14 fc_ash"><%=ReceiptGood.ConvertData<SHFSENum>().EnumToName() %></span></i>
                        </p>
                        <p class="dis_flex col_50 line_he_44" style="flex-direction: column;padding-left:.5rem;">

                            <i class="txt_left fz_16 line_he_40">电话： <span class=" fz_14 fc_ash"><%=SHPhone %></span></i>
                            <i class="txt_left fz_16 line_he_40">电话：<span class=" fz_14 fc_ash"><%=FHPhone %></span></i>
                        </p>
                    </div> 
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false };
        });
        Href("/LC/Customer/DeliverGood/CT_Delivergod.aspx",300);
    </script>

</body>

</html>
