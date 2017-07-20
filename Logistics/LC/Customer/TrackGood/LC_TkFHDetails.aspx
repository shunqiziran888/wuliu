<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_TkFHDetails.aspx.cs" Inherits="Logistics.LC.Customer.TrackGood.LC_TkDetails" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>客户平台</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
    .zbsh-tab1 .zbsh-li .col-100 .zbsh-xd1{
        display: block;
             margin-left: 0; 
             margin-bottom: .5rem;
    }
    .zbsh-tab1 .zbsh-li .col-100 .zbsh-xd1>p{
        font-size: .6rem;
    }
        .zbsh-tab1 .zbsh-li .col-100 .zbsh-xd1 .zbsh-yf input {
            width: 40%;
            padding-left: .3rem;
            height: 1.1rem;
        }
        .zbsh-tab1 .zbsh-li .col-100>p{
            font-size: .7rem;
            margin-bottom: .5rem;
        }
        .zbsh-tab1 .zbsh-li .col-100 p.p1{
               padding-left: .5rem;
        }
        .zbsh-tab1 .zbsh-li .col-100 p.p2{
            margin-left: 15%;
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
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Customer/TrackGood/LC_IndexTK.aspx?sw2=1"></a>
                <h1 class="title">货单详情</h1>
            </header>


            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <div class="content-block">
                                    <ul class="zbsh-tab1">
                                        <%
                               foreach(var v in list)
                               {

                                     %>
                                        <li class="zbsh-li">
                                                <div class="col-100">
                                                    <i class="zbsh-xd1 row">
                                                        <p class="zbsh-hh col-50">货号： <span><%=v.GoodNo %></span></p>
                                                        <p class="zbsh-shr col-50" style="padding: 0 .6rem;">
                                                            <a class="button button-fill button-success" style="color: #fff;"><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></a>
                                                        </p>
                                                    </i>
                                                     <i class="zbsh-xd1 row">
                                                          <p class="zbsh-shr col-50">收货人： <span><%=v.Consignee %></span></p> 
                                                          <p class="zbsh-mdd col-50">收货人电话： <span><%=v.SHPhone %></span></p>
                                                    </i>
                                                     <i class="zbsh-xd1 row">
                                                           <%if(v.finish==null)
                                                               { %>
                                                         <p class="zbsh-mdd col-50">中转地： <span>未中转</span></p>
                                                          <%}
                                                        else
                                                        {%>
                                                            <p class="zbsh-mdd col-50">中转地： <span><%=DAL.DAL.DALBase.GetAddressFromID(v.finish.Value)?.Item2?.Name %></span></p>
                                                    <%} %>
                                                          <p class="zbsh-mdd col-50">到达地： <span><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                      <p class="zbsh-fhr col-50">货名： <span><%=v.GoodName %></span></p>
                                                      <p class="zbsh-hh col-50">件数： <span><%=v.Number %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                        <%if (v.freightMode == 1)
                                                         {%>
                                                     <p class="zbsh-yf col-50">运费提付： <span><%=Math.Round(v.Freight.ConvertData<decimal>(),2)%></span></p>
                                                        <%}%>
                                                        <%if (v.freightMode == 2)
                                                         {%>
                                                     <p class="zbsh-yf col-50">运费现付： <span><%=Math.Round(v.Freight.ConvertData<decimal>(),2) %></span></p>
                                                        <%}%>
                                                        <%if (v.freightMode == 3)
                                                         {%>
                                                     <p class="zbsh-yf col-50">运费扣付： <span><%=Math.Round(v.Freight.ConvertData<decimal>(),2) %></span></p>
                                                        <%}%>
                                                      <p class="zbsh-yf col-50">其他费用： <span><%=Math.Round(v.OtherExpenses.ConvertData<decimal>(),2) %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                      <p class="zbsh-yf col-50">代收款： <span><%=Math.Round((v.GReceivables).ConvertData<decimal>(),2) %></span></p>
                                                         <%if (v.freightMode == 1)
                                                         {%>
                                                      <p class="zbsh-yf col-50">合计： <span><%=TotalTF %></span></p>
                                                        <%}%>
                                                        <%if (v.freightMode == 2)
                                                         {%>
                                                      <p class="zbsh-yf col-50">合计： <span><%=TotalXF %></span></p>
                                                        <%}%>
                                                        <%if (v.freightMode == 3)
                                                         {%>
                                                     <p class="zbsh-yf col-50">合计： <span><%=TotalKF %></span></p>
                                                        <%}%>
                                                    </i>
                                                    <p class="p1">状态：<%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName() %></p>
                                                    <p class="p2">订单生成 <%=v.DdTime %></p>
                                                    <p class="p2">物流收货 <%=v.ConsigneeTime %></p>
                                                    <p class="p2">物流装车 <%=v.TruckTime %></p>
                                                    <p class="p2">到达目的地 <%=v.MeetCarTime %></p>
                                                </div>
                                        </li>
                                        <%} %>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
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

</body>

</html>

