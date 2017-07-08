<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_RgDetails.aspx.cs" Inherits="Logistics.LC.Business.ReceiptGood.LC_RgDetails" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        . {
            display: flex;
            justify-content: space-between;
        }
        
        .row .col-50 {
            margin-left: 0;
        }
        
        .qrsh-ul li {
            font-size: .5rem;
        }
        
        .qrsh-ul li input {
            height: 1.1rem;
        }
        
        .qrsh-ul li:last-child a {
            padding: .3rem 1.25rem;
        }
        
        .popup .content-block {
            margin: 50% auto;
            width: 200px;
            border: 1px solid #bbb;
            border-radius: 6px;
            padding: 1rem .5rem;
        }
        
        .popup .content-block .tishi-main {
            display: flex;
            justify-content: space-around;
            margin-bottom: .5rem;
        }
        
        .popup .content-block .tishi-main span.iconfont {
            font-size: 1.5rem;
            color: #8bc34a;
        }
        
        .popup .content-block .tishi-main .xiangxi {
            font-size: .7rem;
        }
        
        .popup .content-block .quedingbtn {
            padding: 0 1rem;
        }
        
        .button-success.button-fill {
            line-height: 1.5rem;
            height: 1.5rem;
        }
        
        .qrsh-ul li:last-child a:last-child {
            margin-left: 0;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Business/ReceiptGood/LC_GoodsReceipt.aspx"></a>
                <h1 class="title">收货</h1>
            </header>


            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <ul class="qrsh-ul">
                         <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                        <p>货号： <span><%=v.GoodNo %></span></p>

                        <li>
                            目的地： <span><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name%></span>
                        </li>
                        <li class=" row">
                            <p class="col-50">发货人： <span><%=v.Consignor %></span></p>
                            <p class="col-50">货物来源： <span>客户自发</span></p>
                        </li>

                        <li class=" row">
                            <p class="col-50">货名： <span><%=v.GoodName %></span></p>
                            <p class="col-50">件数： <span><%=v.Number %></span></p>
                        </li>
                        <li class=" row">
                            <p class="col-50">付费方式： <span><%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %></span></p>
                            <p class="col-50">代收款： <span><%=v.GReceivables %></span></p>
                        </li>
                        <li class=" row">
                            <p class="col-50">收货人： <span><%=v.Consignee %></span></p>
                            <p class="col-50">电话： <span><%=v.SHPhone %></span></p>
                        </li>
                        <li>
                            实收件数：<input type="text" placeholder="150" id="SSNumber" name="SSNumber">
                        </li>
                        <li>
                            运费金额：<input type="text" placeholder="30000" id="Freight" name="Freight">
                        </li>
                        <li>
                            中转费用：<input type="text" placeholder="5000" id="zzCost" name="zzCost">
                        </li>
                           <%if(v.CarryGood==2) { %>
                        <li>
                            送货费用：<input type="text" placeholder="20000" id="ShzzCost" name="ShzzCost">
                        </li>
                          <%}%>
                        <li>
                            <%--<a href="/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=<%=v.OrderID %>" class="open-about">收货</a>--%>
                            <a href="#" onclick="Submits('<%=v.OrderID %>')">收货</a>
                        </li>
                         <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

     <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

    <script>
        $(function() {
            $.init();
            $.config = {
                router: false
            }
        });
        $(document).on('click', '.open-about', function() {
            $.popup('.popup-about');
        });

        $(document).on('click', '.close-popup', function() {
            $.closeModal('.popup-about');
        });
    </script>
    <script type="text/javascript">
        function Submits(OID)
        {
            var ssnumber = $("#SSNumber").val();//实收件数
            var Freight = $("#Freight").val();//运费
            var zzCost = $("#zzCost").val();//中转费用
            var ShzzCost = $("#ShzzCost").val();//送货费用
            window.location.href = "/LC/Business/ReceiptGood/LC_Success.aspx?OIDDetaila=" + OID + "&ssnumber=" + ssnumber + "&FreightDetail=" + Freight + "&zzCost=" + zzCost + "&ShzzCost="+ShzzCost;
        }
    </script>
</body>

</html>
