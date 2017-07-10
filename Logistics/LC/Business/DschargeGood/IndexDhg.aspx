<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexDhg.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.IndexDhg" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流公司</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        .row .col-80 {
            width: 80%;
            margin-left: 0%;
        }
        
        p.button.button-fill {
            margin: 0 2rem .5rem;
            height: 1.6rem;
            line-height: 1.6rem;
        }
        
        .wyfh-ul .dingdan-li .dingdan-right {
            margin-top: 0rem;
        }
        
        .dingdan-ul .dingdan-li {
            padding: .5rem .2rem;
            margin-left: 0px;
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
        
        .wyfh-ul {
            padding-top: .5rem;
        }
        
        .dingdan-ul .dingdan-li .col-80 .shang {
            display: flex;
            justify-content: space-between;
            font-size: .5rem;
            margin-bottom: .5rem;
        }
        
        .dingdan-ul .dingdan-li .col-80 .xia {
            display: flex;
            justify-content: space-between;
            font-size: .5rem;
        }
        
        .dingdan-ul .dingdan-li .col-20 {
            margin-top: .3rem;
        }
        
        .dingdan-ul .dingdan-li a {
            color: #fff;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Index/LC_IndexYW.aspx"></a>
                <h1 class="title">放货</h1>
            </header>
            <div class="content" style="background:#fff;">
                <div class="page-index">
                    <!--<p class="button button-fill">客户申请提货消息</p>-->
                    <div class="buttons-tab">
                        <a href="#tab1" class="tab-link active button"><span>待转货单</span></a>
                        <a href="#tab2" class="tab-link button"><span>待送货单</span></a>
                    </div>
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <ul class="dingdan-ul wyfh-ul">
                                    <%if (listzz.Count > 0)
        { %>
                                     <%
                                    foreach(var v in listzz)
                                    {
                                        
                                     %>
                                    <li class="dingdan-li row">
                                        <ul class="col-80">
                                            <li class="shang">
                                                <i>日期：17年3月31日</i>
                                                <i>货单号：<%=v.GoodNo %></i>
                                            </li>
                                            <li class="xia">
                                                <i>收货人：<%=v.Consignee %></i>
                                                <i>名称：<%=v.GoodName %></i>
                                                <i>件数：<%=v.Number %></i>
                                            </li>
                                        </ul>
                                        <div class="col-20">
                                            <a href="/LC/Business/DschargeGood/LC_TransferEdit.aspx?OID=<%=v.OrderID %>" class="button button-fill button-success">中转</a>
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
                            <div id="tab2" class="tab">
                                <ul class="dingdan-ul wyfh-ul">
                                     <%if (list.Count > 0)
        { %>
                                     <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                                    <li class="dingdan-li row">
                                        <ul class="col-80">
                                            <li class="shang">
                                                <i>日期：17年3月31日</i>
                                                <i>货单号：<%=v.GoodNo %></i>
                                            </li>
                                            <li class="xia">
                                                <i>收货人：<%=v.Consignee %></i>
                                                <i>名称：<%=v.GoodName %></i>
                                                <i>件数：<%=v.Number %></i>
                                            </li>
                                        </ul>
                                        <div class="col-20">
                                            <a href="/LC/Business/DschargeGood/LC_Success.aspx?OID=<%=v.OrderID %>" class="button button-fill button-success">放货</a>
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
            </div>
        </div>
    </div>
    <script type="text/javascript" src="/Style/scripts/all.js">
    $(function() { $.init(); $.config = { router: false } });
    </script>
</body>

</html>
