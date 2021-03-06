﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Commodity.aspx.cs" Inherits="Logistics.LC.Business.PretendCar.LC_Commodity" %>
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
                    input[type=checkbox] {
                        -webkit-appearance: checkbox;
                        height: .8rem;
                    }
                </style>
            </head>

            <body>
                <div class="page-group">
                    <div class="page page-current">
                        <!-- 你的html代码 -->
                        <header class="bar bar-nav">
                            <a href="/LC/Business/PretendCar/LC_IndexPC.aspx" class="icon iconfont icon-zuo pull-left"></a>
                            <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                            <a href="#" onclick="Test()" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                            <h1 class="title">选择货物</h1>
                        </header>


                        <div class="content" style="background:#f2f2f2;">
                            <div class="page-index">
                                <!-- <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div> -->
                                <div class="white mart_20" style="padding: 1rem; line-height: 1.5rem;">
                                    <p class="fz_16 dis_flex">
                                        <span class="col_20">装车：</span>
                                        <span class="col_30"><%=list.Count %>单</span>
                                        <span class="col_40">计<%=list.Sum(x=>x.Number)%>件</span>
                                    </p>
                                    <p class="dis_flex fz_14 jus_bet fc_ash">
                                        <i class="col_50 dis_flex ali_center">
                                            <span class="col_30">运费：</span> 
                                            <%--<span class="col_70"><%=list.Sum(x=>Math.Round(x.Freight.ConvertData<decimal>(),2)) %>元</span>--%>
                                            <span class="col_70" id="testyf"></span>
                                        </i>
                                        <i class="col_50 dis_flex ali_center">
                                            <span class="col_30">代收：</span> 
                                            <%--<span class="col_70"><%=list.Sum(x=>Math.Round(x.GReceivables.ConvertData<decimal>(),2)) %>元</span>--%>
                                            <span class="col_70" id="testdsk"></span>
                                        </i>
                                        
                                    </p>
                                    <p class="dis_flex fz_14 jus_bet fc_ash">
                                        <i class="col_50 dis_flex ali_center"><span class="col_30">现付：</span> 
                                            <%--<span class="col_70"><%=Math.Round(xianfu.ConvertData<decimal>(),2)%>元</span>--%>
                                             <span class="col_70" id="xf"></span>
                                        </i>
                                        <i class="col_50 dis_flex ali_center"><span>提付：</span> 
                                           <%-- <span class="col_70"><%=Math.Round(tifu.ConvertData<decimal>(),2)%>元</span>--%>
                                             <span class="col_70" id="tf"></span>
                                        </i>
                                       
                                    </p>
                                    <p class="dis_flex fz_14 jus_bet fc_ash">
                                       
                                        <i class="col_50 dis_flex ali_center">
                                            <span class="col_30">扣付：</span> 
                                            <%--<span class="col_70"><%=Math.Round(koufu.ConvertData<decimal>(),2)%>元</span>--%>
                                             <span class="col_70" id="kf"></span>
                                        </i>
                                            <i class="col_50 dis_flex ali_center">
                                            <span class="col_30">其他：</span> 
                                            <%--<span class="col_70"><%=list.Sum(x=>Math.Round(x.OtherExpenses.ConvertData<decimal>(),2)) %>元</span>--%>
                                                <span class="col_70" id="qt"></span>
                                        </i>
                                    </p>
                                </div>
                                <form>
                                    <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding:.5rem">
                            <input type="checkbox" name="checkCommd" value="<%=v.OrderID %>,<%=v.Freight %>,<%=v.GReceivables %>,<%=v.freightMode %>,<%=v.OtherExpenses %>" class="col_10" id="valuess" onclick="Selected()"/>
                            <a href="#">
                                <div style="line-height:1.5rem;">
                                <p class="fz_14">收货人： <i><%=v.Consignee %></i></p>
                                <p class="fz_14">货名件数： <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span></i></p>
                                <p class="fz_14"><i>运费：<span id="yunfei"><%=Math.Round(v.Freight.ConvertData<decimal>(),2) %>&nbsp;&nbsp;&nbsp;</span></i><i>代收款：<span><%=Math.Round(v.GReceivables.ConvertData<decimal>(),2) %></span></i></p>
                                <p class="fz_14"><i>货号：<span><%=v.GoodNo %></span></i><i class="fz_12" style="margin-left:1rem;"><%=v.ConsigneeTime %></i></p>
                            </div>
                            </a>
                        </label>
                                        <%} %>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

                <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
                <%----%>
                    <script>
                        $(function () {
                            $.init();
                            $.config = { router: false }
                        });
                    </script>

            </body>

            </html>
            <script type="text/javascript">
                $(function () {
                    $("input[type='checkbox']").each(function () {
                        this.checked = true;
                    });
                    isCheckAll = true;
                    document.getElementById("tf").innerHTML = "0元";
                    document.getElementById("xf").innerHTML = "0元";
                    document.getElementById("kf").innerHTML = "0元";
                    Selected();
                });
                var isCheckAll = false;
                function swapCheck() {
                    if (isCheckAll) {
                        $("input[type='checkbox']").each(function () {
                            this.checked = false;
                        });
                        isCheckAll = false;
                    } else {
                        $("input[type='checkbox']").each(function () {
                            this.checked = true;
                        });
                        isCheckAll = true;
                    }
                }
                function Test() {
                    debugger;
                    var obj = document.getElementsByName("checkCommd");
                    var s = '';
                    for (var i = 0; i < obj.length; i++) {
                        if (obj[i].checked) s += obj[i].value.split(",")[0] + ',';
                    }
                    if (s == "") { Msg("您还没有选择任何物品!"); }
                    else {
                        sessionStorage.setItem("OID", s);
                        window.location.href = "/LC/Business/PretendCar/LC_Vehicle.aspx";
                    }
                }
                function Selected()
                {
                    let yf = 0;
                    let dsk = 0;
                    let fm = 0;
                    let qt = 0;
                    var obj = document.getElementsByName("checkCommd");
                    for (var i = 0; i < obj.length; i++) {
                        if (obj[i].checked)
                        {
                            let arr = obj[i].value.split(",");
                            yf += parseFloat(arr[1]);
                            dsk += parseFloat(arr[2]);
                            fm = parseFloat(arr[3]);
                            qt += parseFloat(arr[4]);
                        }
                    }
                    if (fm == 1)
                    {
                        document.getElementById("tf").innerHTML = yf + "元";
                    }
                    else if (fm == 2)
                    {
                        document.getElementById("xf").innerHTML = yf + "元";
                    }
                    else if (fm == 3)
                    {
                        document.getElementById("kf").innerHTML = yf + "元";
                    }
                    else if (fm==0)
                    {
                        document.getElementById("tf").innerHTML = "0元";
                        document.getElementById("xf").innerHTML = "0元";
                        document.getElementById("kf").innerHTML = "0元";
                    }
                    document.getElementById("testyf").innerHTML = yf + "元";
                    document.getElementById("testdsk").innerHTML = dsk + "元";
                    document.getElementById("qt").innerHTML = qt + "元";
                }
            </script>