﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexSG.aspx.cs" Inherits="Logistics.LC.Customer.SignGood.LC_IndexSG" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流客户端</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
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
                <a href="/LC/Index/LC_IndexKH.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <%--<p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p>--%>
                <h1 class="title">货物签收</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                   <%-- <div class="white">
                                        <p class="dis_flex fc_16 fc_black line_he_40 ali_center">
                                            <span class="col_30 txt_right">选择物流：</span>
                                            <select class="col_60">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                            </select>
                                        </p>
                                        <p class="dis_flex fc_16 fc_black line_he_40 ali_center">
                                            <span class="col_30 txt_right">选择线路：</span>
                                            <select class="col_60">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                            </select>
                                        </p>
                                        
                                        
                                    </div>--%>
                                    <div class="white" style="padding:.5rem 1.5rem;line-height:1.5rem;border-bottom:1px solid #bbb;border-top:1px solid #bbb;">
                                        <p class="fz_16">
                                            共： 
                                            <span><%=list.Count %>单</span>
                                            <span style="margin-left:1rem;">计<%=list.Sum(x=>x.Number) %>件</span>
                                        </p>
                                    </div>
                    <form>
                         <%if (list.Count > 0)
        { %>
                         <%
                               foreach(var v in list)
                               {

                                     %>
                        <label class="dis_flex jus_bet ali_center white" style="padding: .5rem; position: relative; border-bottom: 1px solid #bbb;">

                            <div class="col_100" style="padding-left: 1rem;">
                                <div style="line-height: 1.5rem;">
                                    <div class="dis_flex  ali_center">
                                        <div>
                                            <p class="fz_14">
                                                收货人： 
                                                                <i><%=v.Consignee %></i>
                                            </p>
                                            <p class="fz_14">
                                                货名件数： 
                                                                <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span></i>
                                            </p>
                                            <p class="fz_14">
                                                <i>运费：<span class="fc_ash"><%=v.Freight %></span></i>
                                                <i>代收款：<span class="fc_ash"><%=v.GReceivables %></span></i>
                                            </p>
                                        </div>
                                        <a href="/LC/Customer/SignGood/LC_SgDetails.aspx?OID=<%=v.OrderID %>" class="green fc_white fz_14 padlr_10" >签收货物</a>
                                    </div>
                                    <p class="fz_14">
                                        <i>货号：<span><%=v.GoodNo %></span></i>
                                        <i class="fz_12 fc_ash" style="margin-left: 1rem;"><%=v.DischargeTime%></i>
                                    </p>
                                </div>
                            </div>
                            <i class="sky_blue fc_white fz_12 padlr_10" style="position: absolute; top: 0; right: 0;"><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></i>
                        </label>
                        <%} %>
                        <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
