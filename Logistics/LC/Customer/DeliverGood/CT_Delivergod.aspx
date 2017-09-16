<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CT_Delivergod.aspx.cs" Inherits="Logistics.LC.Customer.CT_Delivergod" %>
<%@ import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流客户端</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
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

        select {
            line-height: 1.4rem;
        }

        select option {
            line-height: 1.4rem;
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
                <a href="/LC/Index/LC_IndexKH.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <!-- <a href="jieche_success.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">我要发货</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <p class="dis_flex white pad_30 mart_10" style="justify-content:center;"><a class=" txt_center fz_14" style="line-height: 40px;background: #a3c478;color: #fff;width: 150px;text-align: center;border: 1px solid #a3c478;"
                            href="/LC/Customer/DeliverGood/CT_DeliverAdd.aspx?Ident=1">我要发货</a></p>
                    <div class="mart_10">
                        <p class="white line_he_44 fz_16 padlr_10" style="border-bottom:1px solid #f2f2f2">近期收货人列表</p>
                        <ul class="white padtb_10">
                              <%if (list.Count > 0)
        { %>
                   <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                            <li style="border-bottom:1px solid #f2f2f2;">
                                <a href="/LC/Customer/DeliverGood/CT_DeliverAdd.aspx?shr=<%=v.Consignee %>&shrdh=<%=v.SHPhone %>&mbd=<%=v.Destination %>&uffs=<%=v.freightMode %>&wlid=<%=v.logisticsID %>&CarryGood=<%=v.CarryGood %>&ReceiptGood=<%=v.ReceiptGood %>&Ident=1" class="dis_flex jus_bet padlr_10 ali_center" >
                                    <div class="col_90">
                                        <p class="fz_14 dis_flex jus_bet line_he_40">
                                            <i class="col_50"><span>收货人：</span><span class="fc_ash"><%=v.Consignee %></span></i>
                                            <i class="col_50"><span>电话：</span><span class="fc_ash"><%=v.SHPhone %></span></i>
                                        </p>
                                        <p class="fz_14 line_he_40"><span>目标地：</span><span class="fc_ash"><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name %></span></p>
                                    </div>
                                    <span class="col_10"><i class="iconfont icon-angle-right "></i></span>
                                </a>
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

    <script type="text/javascript" src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
<script type="text/javascript">
    function phonechange(element)
    {
        var SHPhone = $(element).val();
        if (SHPhone.length == 4)
        {
            window.location.href="/LC/Customer/DeliverGood/CT_Delivergod.aspx?SHPhone=" + SHPhone;
        }
    }
</script>