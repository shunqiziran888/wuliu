<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_GoodsReceipt.aspx.cs" Inherits="Logistics.LC.business.GoodsReceipt.LC_GoodsReceipt" %>
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
        .zbsh-tab1 .zbsh-li a .zbsh-xd1 .zbsh-yf input {
            width: 40%;
            padding-left: .3rem;
            height: 1.1rem;
        }
        
        .zbsh-tab1 .zbsh-li .xiangdan-btn {
            margin-top: .5rem;
            display: flex;
            justify-content: space-around;
            padding: 0 1.5rem;
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
        .popup .content-block .quedingbtn{
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
                <a class="icon icon-left pull-left" href="/LC/Index/LC_IndexYW.aspx"></a>
                <h1 class="title">收货</h1>
            </header>
            

            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <!-- <div class="buttons-tab">
                <a href="#tab1" class="tab-link active button"><span>新的订单</span></a>
                <a href="#tab2" class="tab-link button"><span>待装车订单</span></a>
              </div> -->
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <div class="content-block">
                                    <ul class="zbsh-tab1">
                                        <%if (list.Count > 0)
                                        { %>
                                        <%
                                            foreach (var v in list)
                                            {

                                        %>
                                        <li class="zbsh-li">
                                            <a href="#" class="row">
                                                <div class="col-100">
                                                    <i class="zbsh-xd1 row">
                                                        <p class="zbsh-shr col-50">收货人： <span><%=v.Consignee %></span></p>
                                                        <p class="zbsh-hh col-50">货号： <span><%=v.GoodNo %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                        <p class="zbsh-mdd col-50">目标地： <span><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name%></span></p>
                                                        <p class="zbsh-hm col-50">货名： <span><%=v.GoodName %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                        <p class="zbsh-fhr col-50">发货人： <span><%=v.Consignor %></span></p>
                                                        <p class="zbsh-hh col-50">件数： <span><%=v.Number %></span></p>
                                                    </i>
                                                    <i class="zbsh-xd1 row">
                                                        <p class="zbsh-yf col-50">运费：
                                                            <input type="text" name="Freight" id="Freight<%=v.OrderID %>" placeholder="￥0.00"></p>
                                                        <p class="zbsh-zffs col-50">付费方式： <span><%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %></span></p>
                                                    </i>

                                                    <%

                                                           var isshow = list2.Where(x => x.End.Value == v.Destination).Count()>0;
                                                        %>

                                                    <i class="zbsh-xd1 row" <%= !isshow? string.Empty : "style=\"display:none\""%>>
                                                        <p class="zbsh-yf col-50">
                                                            目的地：
                                                             <select id="End<%=v.OrderID %>" name="End" style="width: 300px;">
                                                                 <option>请选择</option>
                                                                 <%
                                                                     foreach (var v1 in list2)
                                                                     {
                                                                         if (v.Destination.Value == v1.End.Value)
                                                                         {
                                                                 %>
                                                                 <option selected value="<%=v1.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name%></option>
                                                                 <%
                                                                     }
                                                                     else
                                                                     {
                                                                 %>
                                                                 <option value="<%=v1.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name%></option>
                                                                 <%
                                                                     }
                                                                 %>

                                                                 <%} %>
                                                             </select>
                                                        </p>
                                                    </i>
                                                    <input type="hidden" id="OrderID" name="OrderID" value="<%=v.OrderID %>" />
                                                </div>
                                                <!-- <div class="col-10">
                                <span class="iconfont icon-gengduo"></span>
                              </div> -->
                                            </a>
                                            <div class="xiangdan-btn">
                                                <%--<a href="/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=<%=v.OrderID %>" class="open-about">快速收货</a>--%>
                                                <a href="#" onclick="UpdateYF('<%=v.OrderID %>')">快速收货</a>
                                                <a href="/LC/Business/ReceiptGood/LC_RgDetails.aspx?OID=<%=v.OrderID %>" class="button button-fill">详情</a>
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
                </div>
            </div>
        </div>
    </div>

<%--    <div class="popup popup-about">
        <div class="content-block">
            <div class="tishi-main">
                <span class="iconfont ">&#xe66f;</span>
                <ul class="xiangxi">
                    <li>您的货物已成功收货</li>
                </ul>
            </div>
            <p class="quedingbtn">
                <a href="#" class="close-popup button button-fill button-success">
                我知道了
              </a>
            </p>
        </div>
    </div>--%>
    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

    <script type="text/javascript">
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
<script type="text/javascript">
    function UpdateYF(OID)
    {
        var yf = $("#Freight" + OID).val();
        var finish = $("#End" + OID).val();
        if (yf != "" && yf != undefined &&  finish!="请选择" && finish!=undefined)
        {
            window.location.href = "/LC/Business/ReceiptGood/LC_Success.aspx?OrderID=" + OID + "&YF=" + yf + "&finish="+finish;
        }
        else
        {
            alert("运费和目的地不能为空！");
        }
    }
</script>