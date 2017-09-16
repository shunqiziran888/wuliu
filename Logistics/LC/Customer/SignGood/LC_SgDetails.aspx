<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_SgDetails.aspx.cs" Inherits="Logistics.LC.Customer.SignGood.LC_TgDetails" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
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
                <a href="/LC/Customer/SignGood/LC_IndexSG.aspx" class="icon iconfont icon-zuo pull-left"></a>
                
                <h1 class="title"> 签收货物</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                     <%
                         foreach (var v in list)
                         {

                                     %>
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <div class="white pad_20 mart_10">
                        <p class="fz_14 line_he_30">
                            <span>物流名称：</span>
                            <span><%=DAL.DAL.DALBase.GetUserVoFromUIDKXZ(v.logisticsID).Item3.LogisticsName %></span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流电话：</span>
                            <span><%=DAL.DAL.DALBase.GetUserVoFromUIDKXZ(v.logisticsID).Item3.Phone %></span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流地址：</span>
                            <span><%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item1%>-<%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item2%>-<%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item3%></span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通线路：</span>
                            <span><%=DAL.DAL.DALBase.GetLineCountKXZ(v.logisticsID).Item3 %>条</span>
                        </p>
                        <p class="fz_14 line_he_30 dis_flex ali_center">
                            <span>本次线路：</span>
                            <span><%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item1%>-<%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item2%>-<%=DAL.DAL.DALBase.GetAllAddressNames(v.Destination.ConvertData<int>()).Item3%><i class="iconfont icon-exchange1 marlr_20"></i>本地</span>
                        </p>
                    </div>
                   
                    <div style="line-height:1.5rem;margin-top:.5rem;flex-wrap:wrap;" class=" white">
                        <p class="col_100 txt_center" style="border-bottom:1px solid #bbb;">
                            <i class="txt_right fz_14 line_he_30" >货号：</i><i class="txt_left fc_ash line_he_44"><%=v.GoodNo %></i>
                        </p>
                        <div class="pad_10" style="position: relative;">
                            <i class="green fc_white fz_14 padlr_10" style="position: absolute;top: 0;right: 0;"><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></i>
                            <p class="col_100 txt_left" style="padding-left:5%;" >
                             <i class="txt_right fz_14 col_20 line_he_30">货物名： </i>
                             <i class="txt_left fc_ash fz_14 col_80 line_he_30">
                                 <%=v.GoodName %>
                                 <span class="fc_red">x<%=v.Number %>件</span>
                                 <span class="fc_green" style="margin-left:.5rem;">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span>
                            </i>
                            </p>
                        <div style="padding-left:5%;">
                            <p class="fz_14"><span>发货人：</span><span><%=v.Consignor %></span></p>
                            <p class="fz_14"><span>发货人电话：</span><span><%=v.FHPhone %></span></p>
                            <p class="fz_14"><span>发货件数：</span><span><%=v.GoodName %> <i>x<%=v.Number %>件</i></span></p>
                            <p class="fz_14"><span>发货日期：</span><span><%=v.DdTime %></span></p>
                            <p class="fz_14 dis_flex jus_bet">
                                <i class="col_50"><span>运费：</span><span><%=v.Freight %></span></i>
                                <i class="col_50"><span>代收款：</span><span><%=v.GReceivables %></span></i>
                            </p>
                            <p class="fz_14 dis_flex jus_bet">
                                <i class="col_50"><span>其他费用：</span><span><%=v.OtherExpenses %></span></i>
                                <i class="col_50 fz_18 fc_blue"><span>合计：</span>
                                    <%if (v.freightMode == 1)
                                        { %>
                                    <span id="heji"><%=v.Freight+v.GReceivables+v.OtherExpenses %></span>
                                    <%} %>
                                    <%if (v.freightMode == 2)
                                        { %>
                                    <span id="heji"><%=v.GReceivables+v.OtherExpenses %></span>
                                    <%} %>
                                    <%if (v.freightMode == 3)
                                        { %>
                                    <span id="heji"><%=v.GReceivables+v.OtherExpenses %></span>
                                    <%} %>
                                </i>
                            </p>
                        </div>
                        <p class="dis_flex jus_center mart_10"> <a href="#" class="qianshou_btn green fc_white padlr_30 fz_16 line_he_40">签收货物</a></p>
                        </div>
                         
                    </div>
                    
                    <div class="white dis_none btn_zu" style="position: fixed;top: 40%;width: 100%;padding: 1rem;border-top: 1px solid #bbb;border-bottom: 1px solid #bbb;">
                        <p class="dis_flex jus_bet marb_10">
                            <i class="col_40 dis_flex jus_center line_he_40"><a href="/LC/Customer/SignGood/LC_Transfer.aspx?OID=<%=v.OrderID %>" style="width:116px;" class="green txt_center fc_white">中转</a></i>
                            <i class="col_40 dis_flex jus_center line_he_40"><a href="#" onclick="No()" style="width:116px;" class="blue txt_center fc_white">拒收</a></i>
                        </p>
                        <p class="dis_flex jus_bet">
                            <i class="col_40 dis_flex jus_center line_he_40" ><a href="/LC/Customer/SignGood/LC_Success.aspx?OID=<%=v.OrderID %>" style="width:116px;" class="brown txt_center fc_white">现金提货</a></i>
                            <i class="col_40 dis_flex jus_center line_he_40"><a href="/LC/Customer/SignGood/LC_ApplyGiveGood.aspx?OID=<%=v.OrderID %>" style="width:116px;" class="red txt_center fc_white">申请送货</a></i>
                    </div>
                   
                    <%} %>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
            $('.qianshou_btn').click(function () {
                $('.btn_zu').show();
            })
            //获取合计
            //var values = $("#heji").text();
            //alert(values);
        });
        function No() {
            Msg("功能暂未开放！");
        }
    </script>

</body>

</html>