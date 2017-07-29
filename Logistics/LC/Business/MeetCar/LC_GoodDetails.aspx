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
    <link rel="shortcut icon" href="/favicon.ico">
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
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/Business/MeetCar/LC_IndexMC.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <a href="/LC/Business/MeetCar/LC_Success.aspx?CH=<%=list.GetIndexValue(0).VehicleID%>&Start=<%=list.GetIndexValue(0).Initially %>&End=<%=list.GetIndexValue(0).Destination %>" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                <h1 class="title">接车</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div> -->
                    <div class="white mart_20" style="padding:1rem;line-height:1.5rem;">
                       <p class="fz_16">装车： <span><%=list.Count %>单</span><span style="margin-left:1rem;">计<%=list.Sum(x=>x.Number)%>件</span></p>
                        <p class="dis_flex fz_14 jus_bet fc_ash"><i class="col_30">运费： <span><%=list.Sum(x=>Math.Round(x.Freight.ConvertData<decimal>(),2)) %>元</span></i><i class="col_30">代收： <span><%=list.Sum(x=>Math.Round(x.GReceivables.ConvertData<decimal>(),2)) %>元</span></i><i class="col_30">其他： <span><%=list.Sum(x=>Math.Round(x.OtherExpenses.ConvertData<decimal>(),2)) %>元</span></i></p>
                        <p class="dis_flex fz_14 jus_bet fc_ash"><i class="col_30">现付： <span><%=Math.Round(xianfu.ConvertData<decimal>(),2)%>元</span></i><i class="col_30">提付： <span><%=Math.Round(tifu.ConvertData<decimal>(),2)%>元</span></i><i class="col_30">扣付： <span><%=Math.Round(koufu.ConvertData<decimal>(),2)%>元</span></i></p>
                    </div>
                    <form>
                        <%
                            foreach (var v in list)
                            {
                                     %>
                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding:.5rem">
                            <div>
                                <div style="line-height:1.5rem;">
                                <p class="fz_14">收货人： <i><%=v.Consignee %></i></p>
                                <p class="fz_14">货名件数： <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span></i></p>
                                <p class="fz_14"><i>运费：<span><%=v.Freight %></span></i><i>代收款：<span><%=v.GReceivables %></span></i></p>
                                <p class="fz_14"><i>货号：<span><%=v.GoodNo %></span></i><i class="fz_12" style="margin-left:1rem;">暂时不显示（时间）</i></p>
                            </div>
                            </div>
                        </label>
                        <%} %>
                    </form>
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
    </script>

</body>

</html>
