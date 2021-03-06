﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_GoodsReceipt.aspx.cs" Inherits="Logistics.LC.business.GoodsReceipt.LC_GoodsReceipt" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统 </title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

   <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>

        .zbsh-zffs .huo_name {
            position: relative;
        }

        .zbsh-zffs .huo_num {
            position: absolute;
            top: -10px;
            right: -35px;
            font-size: 16px;
            color: #f00;
        }
        .huo_fnagshi{
             margin-left: 80px;
             color: #009621;
        }
        
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/MenuBar/LC_BusinessIndex.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="/LC/Business/ReceiptGood/LC_HistoryIndex.aspx"></a>
                    <i class="add_txt">历史记录</i>
                </p>
                <h1 class="title">收货</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <ul class="zbsh-tab1">
                          <%if (list.Count > 0)
                                        { %>
                                        <%
                                            foreach (var v in list)
                                            {

                                        %>
                        <li class="zbsh-li">
                            <a href="#">
                                <input type="hidden" id="freightMode" value="<%=v.freightMode %>" />
                                <input type="hidden" id="GReceivables" value="<%=v.GReceivables %>" />
                                <input type="hidden" id="PickupCost"  value="<%=v.PickupCost %>"/>
                                <input type="hidden" id="GivegoodCost"  value="<%=v.GivegoodCost %>"/>
                                <div class="col-100">
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs">货物名： <span class="huo_name ft_color_ash"><%=v.GoodName %> <i class="huo_num">x<%=v.Number %></i></span> <span class="huo_fnagshi">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span></p>
                                    </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr">发货人： <span class="ft_color_ash"><%=v.Consignor %></span></p>
                                  <p class="zbsh-hh ft_color_ash">电话： <span><%=v.FHPhone %></span></p>
                                </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-mdd">收货人： <span class="ft_color_ash"><%=v.Consignee %></span></p>
                                  <p class="zbsh-hm ft_color_ash">电话： <span><%=v.SHPhone %></span></p>
                                </i>
                                     <i class="zbsh-xd1">
                                  <p class="zbsh-mdd">收货方式： <span class="ft_color_ash"><%=v.ReceiptGood.ConvertData<SHFSENum>().EnumToName() %></span></p>
                                  <p class="zbsh-hm ft_color_ash">提货方式： <span><%=v.CarryGood.ConvertData<THFSEnum>().EnumToName() %></span></p>
                                </i>
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-yf">运费： <input type="text" name="Freight" id="Freight<%=v.OrderID %>" placeholder="￥0.00"></p>
                                </i>
                                     <%
                                             var isshow = list2.Where(x => x.End.Value == v.Destination).Count()>0;
                                                        %>
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-yf dis_flex ali_center"><span class="col_30">中转地：</span> <select class="col_70" id="End<%=v.OrderID %>" name="End" style="width: 300px;">
                                                                 <option>请选择</option>
                                                                 <%
                                                                     foreach (var v1 in list2)
                                                                     {
                                                                         if (v.Destination.Value == v1.End.Value)
                                                                         {
                                                                 %>
                                                                 <option selected value="<%=v1.End %>|<%=v1.BindLogisticsUid %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name%></option>
                                                                 <%
                                                                     }
                                                                     else
                                                                     {
                                                                 %>
                                                                 <option value="<%=v1.End %>|<%=v1.BindLogisticsUid %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name%></option>
                                                                 <%
                                                                     }
                                                                 %>

                                                                 <%} %>
                                                             </select></p>
                                </i>
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs">目的地： <span class="ft_color_ash"><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name%></span></p>
                                </i>
                                </div>

                            </a>
                            <div class="xiangdan-btn">
                                <%if (v.freightMode == 2)
                                    { %>
                                <a onclick="zhifu('<%=v.OrderID %>')">快速收货</a>
                                <%} %>
                                <%else if (v.freightMode == 1 || v.freightMode == 3)
    { %>
                                <a href="#" onclick="UpdateYF('<%=v.OrderID %>')">快速收货</a>
                                <%} %>
                                <a href="/LC/Business/ReceiptGood/LC_RgDetails.aspx?OID=<%=v.OrderID %>&Number=<%=v.Number %>">更多设置</a>
                            </div>
                        </li>
                          <%} %>
                                        <%}
                                        else
                                        {%>
                                        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
                                        <%} %>
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
<script type="text/javascript">
    //快速收货
    function UpdateYF(OID)
    {
        var yf = $("#Freight" + OID).val();
        let arr = $("#End" + OID).val().split("|");
        var finish = arr[0];
        let BindLogisticsUid = arr[1];
        var Total; //合计
        var freightMode = $("#freightMode").val(); 
        var GReceivables = $("#GReceivables").val();
        if (freightMode == 1) {
            //提付合计
            Total = parseInt(yf) + parseInt(GReceivables);
        }
        //现付合计
        else if (freightMode == 2) {
            Total = GReceivables;
        }
        //扣付合计
        else if (freightMode == 3 && parseInt(GReceivables) > yf) {
            Total = parseInt(GReceivables) - parseInt(yf);
        }
        if (yf != "" && yf != undefined && finish != "请选择" && finish != undefined) {
            if (parseInt(GReceivables) < parseInt(yf))
            {
                Msg("收货失败！运费不能大于代收款");
            }
            else if (parseInt(GReceivables) > parseInt(yf))
            {
                var PickupCost = $("#PickupCost").val();
                var GivegoodCost = $("#GivegoodCost").val();
                var newFreight = (parseInt(yf) + parseInt(PickupCost) + parseInt(GivegoodCost));
                window.location.href = "/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=" + OID + "&YF=" + newFreight + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid + "&Total=" + Total;
            }   
        }
        else {
            Msg("内容不完整，请重试！");
        }
    }
    //现付
    function zhifu(OID)
    {
        var yf = $("#Freight" + OID).val();
        let arr = $("#End" + OID).val().split("|");
        var finish = arr[0];
        let BindLogisticsUid = arr[1];
        if (yf != "" && yf != undefined && finish != "请选择" && finish != undefined)
        {
            window.location.href = "/LC/Business/ReceiptGood/LC_Receivables.aspx?OrderID=" + OID + "&YF=" + yf + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid;
        }
        else
        {
            Msg("内容不完整，请重试!");
        }
    }
</script>