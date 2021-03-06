﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Receivables.aspx.cs" Inherits="Logistics.LC.Business.ReceiptGood.LC_Receivables" %>

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
            left: 62%;
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

                <h1 class="title">收款</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="padtb_10 martb_10 white">
                        <p class="dis_flex jus_bet marb_10">
                            <span class="col_20 txt_right fz_16">
                                应收款：
                            </span>
                            <span class="col_80 txt_left">
                                <%=yf %>
                            </span>
                        </p>
                        <p class="dis_flex jus_bet">
                            <span class="col_20 txt_right fz_16">
                                实收款：
                            </span>
                            <span class="col_80 txt_left">
                                <input  class="col_80" type="number" placeholder="请输入数字" id="yunfei">
                            </span>
                        </p>
                    </div>
                    <div class="white pad_10">
                        <p class="fz_16 marb_20">选择收款方式</p>
                        <div class="dis_flex jus_bet padlr_30">
                            <a onclick="No()" class="dis_flex flex_dir_col ali_center jus_center" >
                                 <span class="iconfont icon-cntencentwechat fc_green fz_32" ></span>
                                 <span class="fc_ash">微信支付</span>
                             </a>
                            <a onclick="No()" class="dis_flex flex_dir_col ali_center jus_center" >
                                 <span class="iconfont icon-cc-visa fc_ash fz_32"></span>
                                 <span class="fc_ash">银行卡</span>
                             </a>
                            <a onclick="success()" class="dis_flex flex_dir_col ali_center jus_center" >
                                 <span class="iconfont icon-money fc_orange fz_32"></span>
                                 <span class="fc_ash">现金</span>
                             </a>
                        </div> 
                    </div>
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
<script type="text/javascript">
    function No()
    {
        Msg("请点击现金支付！");
    }
    function success()
    {
        var yunfei = $("#yunfei").val();
        var finish = "<%=finish%>";
        let BindLogisticsUid = "<%=BindLogisticsUid%>";
        var OIDs = "<%=OID%>";
        var yf = "<%=yf%>";
        if (yunfei != "" && yunfei != undefined)
        {

            window.location.href = "/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=" + OIDs + "&YF=" + yunfei + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid;
        }
        else
        {
            window.location.href = "/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=" + OIDs + "&YF=" + yf + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid;
        }
    }
</script>
