<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_SgDetails.aspx.cs" Inherits="Logistics.LC.Customer.SignGood.LC_TgDetails" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
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
    <style>
        .l_ys {
            border: 1px solid #bbb;
            color: #bbb;
        }
        
        .l_tx {
            text-align: left;
            margin: 1% 4%;
            background: #fff;
            border: 1px solid #bbbbbb;
            border-radius: 10px;
            padding: 1rem .5rem;
        }
        
        .l_zt {
            font-size: .7rem;
        }
        
        .allBtn .col-50 p {
            padding: 0 .5rem;
        }
        
        .allBtn .col-50 p a {
            font-size: .7rem!important;
            padding: 0;
        }
        
        .modal.toast.modal-in {
            background: #ffa726;
            display: block;
            height: auto;
            width: 13.5rem;
            border-radius: 6px;
            word-wrap: break-word;
            line-height: 1.2rem;
            padding: .5rem .5rem;
            margin-left: -6.75rem!important;
        }
        
        .modal.toast.modal-out {
            background: #ffa726;
            display: block;
            height: auto;
            width: 13.5rem;
            border-radius: 6px;
            word-wrap: break-word;
            line-height: 1.2rem;
            padding: .5rem .5rem;
            margin-left: -6.75rem!important;
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
    </style>

</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->


            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Customer/SignGood/LC_IndexSG.aspx"></a>
                <h1 class="title">联系物流</h1>
            </header>

            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <%
                               foreach(var v in list)
                               {

                                     %>
                    <div class="l_tx cgfh-main">
                        <div class="row">
                            <div class="col-40 l_zt">
                                <p>发货地：<%=DAL.DAL.DALBase.GetAddressFromID(v.Initially.Value)?.Item2?.Name %></p>
                            </div>
                            <div class="col-60 l_zt">
                                <p>订单号：<%=v.OrderID %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-40 l_zt">
                                <p>发货人：<%=v.Consignor %> </p>
                            </div>
                            <div class="col-60 l_zt">
                                <p>电话：<%=v.FHPhone %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-40 l_zt">
                                <p>货名：<%=v.GoodName %> </p>
                            </div>
                            <div class="col-60 l_zt">
                                <p>发货日期：<%=v.DdTime %></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-40 l_zt">
                                <p>件数：<%=v.Number %> </p>
                            </div>
                            <div class="col-60 l_zt">
                                <%if (v.freightMode == 1)
                                        {%>
                                <p>运费提付：<%=Math.Round(v.Freight.ConvertData<decimal>(), 2)%></p>
                                <%} %>
                                <%if (v.freightMode == 2)
                                        {%>
                                <p>运费现付：<%=Math.Round(v.Freight.ConvertData<decimal>(), 2)%></p>
                                <%} %>
                                <%if (v.freightMode == 3)
                                        {%>
                                <p>运费扣付：<%=Math.Round(v.Freight.ConvertData<decimal>(), 2)%></p>
                                <%} %>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-40 l_zt">
                                <p>其他费用：<%=v.OtherExpenses %> </p>
                            </div>
                            <div class="col-60 l_zt">
                                <p>代收款：<%=Math.Round(v.GReceivables.ConvertData<decimal>(),2) %></p>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-40 l_zt">

                            </div>
                            <div class="col-60 " style="float:right;">
                                   <%if (v.freightMode == 1)
                                       {%>
                                <p>应收合计：<%=TotalTF %></p>
                                <%} %>
                                 <%if (v.freightMode == 2)
                                       {%>
                                <p>应收合计：<%=TotalXF %></p>
                                <%} %>
                                 <%if (v.freightMode == 3)
                                       {%>
                                <p>应收合计：<%=TotalKF %></p>
                                <%} %>
                            </div>
                        </div>


                        <div class="row allBtn" style="margin-top:1rem;    padding:0 1rem;">
                            <div class="col-50 l_zt">
                                <p><a href="/LC/Customer/SignGood/LC_Success.aspx?OID=<%=v.OrderID %>" class="button button-big open_xianjin" style="background:#2baf2b;border:none;color:#fff;">现金提货 </a></p>
                            </div>
                            <div class="col-50 " style="float:right;">
                                <p><a href="#" class="button button-big open-about" style="background:#ff7043;border:none;color:#fff;">在线支付</a></p>
                            </div>
                        </div>


                        <div class="row allBtn" style="margin-top:1rem;    padding:0 1rem;">
                            <div class="col-50 l_zt">
                                <p><a href="/LC/Customer/SignGood/LC_Transfer.aspx?OID=<%=v.OrderID %>" class="button button-big shenqingzhongzhuan" style="background:#29b6f6;border:none;color:#fff;">申请中转 </a></p>
                            </div>
                            <div class="col-50 " style="float:right;">
                                <p><a href="#" class="button button-big shenqingzhongzhuan" style="background:#7e57c2;border:none;color:#fff;">申请送货</a></p>
                            </div>
                        </div>
                        <p style="    margin-top: 1rem;    padding:0 2.5rem;"><a href="#" class="button button-big shenqingzhongzhuan" style="background:#ffa726;border:none;color:#fff;">不去原返</a></p>
                    </div>
                    <%} %>



                </div>


            </div>




        </div>
    </div>


    <div class="popup popup-about">
        <div class="content-block">
            <div class="tishi-main">
                <ul class="xiangxi">
                    <li style="text-align: center;">应付金额：1111122</li>
                    <li style="display: flex;line-height: 1.4rem;margin: .25rem 0;">其他金额： <input type="text" placeholder="输入其他金额" style="width: 60%;"></li>
                </ul>
            </div>
            <p class="quedingbtn">
                <a href="#" class="close-popup button button-fill button-success">
                确认支付
              </a>
            </p>
        </div>
    </div>

    <script type='text/javascript' src='all.js' charset='utf-8'></script>

    <script>
        $(function() {
            $.init();
            $.config = {
                router: false
            }

            $(document).on('click', '.shenqingzhongzhuan', function() {
                $.toast("订单已处理，等待物流确认操作");
            });
            $(document).on('click', '.open_xianjin', function() {
                $.toast("请让收款人员确认，确认后可提货");
            });

            $(document).on('click', '.open-about', function() {
                $.popup('.popup-about');
            });
            $(document).on('click', '.open-qiankuantihuo', function() {
                $.toast("已移动至欠款用户");
            });
        });
    </script>

</body>

</html>
