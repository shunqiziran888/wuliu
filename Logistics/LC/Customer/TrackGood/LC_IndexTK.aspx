<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexTK.aspx.cs" Inherits="Logistics.LC.Customer.TrackGood.LC_IndexTK" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>



<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流用户</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="shortcut icon" href="/favicon.ico">
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
                <a class="icon icon-left pull-left external" href="/LC/Index/LC_IndexKH.aspx"></a>
                <h1 class="title">货物追踪</h1>
            </header>
            <div class="content" style="background:#fff;">
                <div class="page-index">
                    <!--<p class="button button-fill">客户申请提货消息</p>-->
                    <div class="buttons-tab">
                        <a href="#tab1" class="tab-link active button" onclick="hiddenFH()"><span>接收货物</span></a>
                        <a href="#tab2" class="tab-link button" onclick="hiddenSH()"><span>发出货物</span></a>
                    </div>
                 <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                     <input type="text" id='FHPhone' placeholder='输入发货人电话号码可以快速检索' oninput="FHphonechange(this);" onpropertychange="FHphonechange(this);"/>
                     <input type="text" id='SHPhone' placeholder='输入收货人电话号码可以快速检索' oninput="SHphonechange(this);" onpropertychange="SHphonechange(this);"/>
                </div>
              </div>
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                 <%if (list2.Count > 0)
        { %>
                                <ul class="dingdan-ul wyfh-ul">
                                      <%foreach (var v in list2) { %>
                                    <li class="dingdan-li row">
                                        <ul class="col-80">
                                            <li class="shang">
                                                <i>发货人：<%= v.Consignor%></i>
                                                <i>货单号：<%=v.GoodNo %></i>
                                            </li>
                                            <li class="xia">
                                                <i>名称：<%=v.GoodName %></i>
                                                <i>件数：<%=v.Number %></i>
                                                <i>状态：<%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></i>
                                            </li>
                                        </ul>
                                        <div class="col-20">
                                            <a href="/LC/Customer/TrackGood/LC_TkSHDetails.aspx?OID=<%=v.OrderID %>&GReceivables=<%=v.GReceivables %>&Freight=<%=v.Freight %>&OtherExpenses=<%=v.OtherExpenses %>&Number=<%=v.Number %>" class="button button-fill button-success">详情</a>
                                        </div>
                                    </li>
                                    <%} %>
                                </ul>
                                 <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
                            </div>
                            <div id="tab2" class="tab">
                                  <%if (list.Count > 0)
        { %>
                                <ul class="dingdan-ul wyfh-ul">
                                    <%foreach(var v in list){%>
                                    <li class="dingdan-li row">
                                        <ul class="col-80">
                                            <li class="shang">
                                               <i>收货人：<%= v.Consignee%></i>
                                                <i>货单号：<%=v.GoodNo %></i>
                                            </li>
                                            <li class="xia">
                                                <i>名称：<%=v.GoodName %></i>
                                                <i>件数：<%=v.Number %></i>
                                                <i>状态：<%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></i>
                                            </li>
                                        </ul>
                                        <div class="col-20">
                                            <a href="/LC/Customer/TrackGood/LC_TkFHDetails.aspx?OID=<%=v.OrderID %>&GReceivables=<%=v.GReceivables %>&Freight=<%=v.Freight %>&OtherExpenses=<%=v.OtherExpenses %>&Number=<%=v.Number %>" class="button button-fill button-success">详情</a>
                                        </div>
                                    </li>
                                      <%} %>
                                </ul>
                                <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
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
     <script type="text/javascript">
         $(function () {
             document.getElementById("SHPhone").style.display = "none";
             document.getElementById("FHPhone").style.display = "block";

             if (!StrIsNull("<%=GetValue("sw2")%>"))
             {
                 $("a[href^='#tab2']").eq(0).click();
             }


         });
         function fachu(id) {
             id = parseInt(id);
             if (isNaN(id)) {
                 id = 0;
             }
             var value = id;
             window.location.href = "/LC/Customer/TrackGood/LC_IndexTK.aspx?vau=" + value;
         }
         function hiddenFH() {
             document.getElementById("SHPhone").style.display = "none";
             document.getElementById("FHPhone").style.display = "block";
         }
         function hiddenSH() {
             document.getElementById("FHPhone").style.display = "none";
             document.getElementById("SHPhone").style.display = "block";
         }
         function FHphonechange(element) {
             var FHPhone = $(element).val();
             if (FHPhone.length == 4) {
                 window.location.href = "/LC/Customer/TrackGood/LC_IndexTK.aspx?FHPhone=" + FHPhone;
             }
         }
         function SHphonechange(element) {
             var SHPhone = $(element).val();
             if (SHPhone.length == 4) {
                 window.location.href = "/LC/Customer/TrackGood/LC_IndexTK.aspx?SHPhone=" + SHPhone + "&sw2=1";
             }
         }
     </script>
</body>
</html>

