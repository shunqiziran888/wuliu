<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexSG.aspx.cs" Inherits="Logistics.LC.Customer.SignGood.LC_IndexSG" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">

</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->


            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Index/LC_IndexKH.aspx"></a>
                <h1 class="title">货物签收</h1>
            </header>

            <div class="content" style="background:#ededed;">
                <div class="page-index">

                    <ul class="hwqs-ul">
                        <%if (list.Count > 0)
        { %>
                         <%
                               foreach(var v in list)
                               {

                                     %>
                        <li class="hwqs-li">
                            <a href="/LC/Customer/SignGood/LC_SgDetails.aspx?OID=<%=v.OrderID %>&GReceivables=<%=v.GReceivables %>&Freight=<%=v.Freight %>&OtherExpenses=<%=v.OtherExpenses %>&Number=<%=v.Number %>" class="row">
                                <div class="col-90">
                                    <div class="row" style="padding: .2rem 0;">
                                        <div class="col-40"> 发货人： <span><%=v.Consignor %></span></div>
                                        <div class="col-50">货号： <span><%=v.GoodNo %></span></div>
                                    </div>
                                    <div class="row" style="padding: .2rem 0;">
                                        <div class="col-40"> 货名： <span><%=v.GoodName %></span></div>
                                        <div class="col-50">件数： <span><%=v.Number %></span></div>
                                    </div>
                                    <div class="row" style="padding: .2rem 0;">
                                        <div class="col-40"> 代收款： <span><%=v.GReceivables %></span></div>
                                        <div class="col-50">运费： <span><%=v.Freight %></span></div>
                                    </div>
                                    <div class="row" style="padding: .2rem 0;">
                                        <div class="col-40"> 货物状态： <span><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName() %></span></div>
                                        <%if (v.OtherExpenses != null)
                                            {%>
                                             <div class="col-50">合计： <span><%=v.GReceivables+v.Freight+v.OtherExpenses %></span></div>
                                        <%} %>
                                        <%if (v.OtherExpenses == null)
                                                { %>
                                        <div class="col-50">合计： <span><%=v.GReceivables + v.Freight%></span></div>
                                        <%} %>
                                    </div>
                                </div>
                                <div class="col-10" style="padding: .2rem 0;">
                                    <div class="col-10 hwqs-right">
                                        <span class="iconfont icon-gengduo"></span>
                                    </div>
                                </div>
                            </a>
                            <div class="hwqs-bottom" style="  margin: 0.2rem;">
                                <a href="/LC/Customer/SignGood/LC_SgDetails.aspx?OID=<%=v.OrderID %>&GReceivables=<%=v.GReceivables %>&Freight=<%=v.Freight %>&OtherExpenses=<%=v.OtherExpenses %>&Number=<%=v.Number %>" class="hwqs-bottom1">处理订单</a>
                            </div>
                        </li>
                        <%} %>
                        <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>

    <script>
        $(function() {
            $.init();
            $.config = {
                router: false
            }
        });
    </script>

</body>

</html>
