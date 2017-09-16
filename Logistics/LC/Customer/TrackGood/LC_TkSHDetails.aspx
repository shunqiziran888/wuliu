<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_TkSHDetails.aspx.cs" Inherits="Logistics.LC.Customer.TrackGood.LC_TkSHDetails" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
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
                <a href="/LC/Customer/TrackGood/LC_IndexTK.aspx?sw2=1" class="icon iconfont icon-zuo pull-left"></a>
                <h1 class="title">接收货物详情</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <%
                        foreach (var v in list)
                        {

                                     %>
                    <input type="hidden" value="<%=v.State %>" id="ZT"/>
                    <div style="line-height:1.5rem;margin-top:.5rem;flex-wrap:wrap;" class="dis_flex white">
                        <p class="col_100 txt_center marlr_20" style="border-bottom:1px solid #bbb;">
                            <i class="txt_right fz_14 line_he_44" >货号：</i><i class="txt_left fc_ash line_he_44"><%=v.GoodNo %></i>
                        </p>
                         <p class="col_100 txt_left" style="padding-left:5%;" >
                             <i class="txt_right fz_14 col_20 line_he_44">货物名： </i>
                             <i class="txt_left fc_ash fz_14 col_80 line_he_44">
                                 <%=v.GoodName %>
                                 <span class="fc_red">x<%=v.Number %>件</span>
                                 <span class="fc_green" style="margin-left:.5rem;">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span>
                            </i>
                            </p>
                        <p class="dis_flex   col_50" style="flex-direction: column;padding-left:5%;">
                            
                            <i class="txt_left fz_14 line_he_40">
                                收货人： 
                                <span class=" fz_14 fc_ash"><%=v.Consignee %></span>
                            </i>
                            <i class="txt_left fz_14 line_he_40">
                                发货人： 
                                <span class=" fz_14 fc_ash"><%=v.Consignor %></span>
                            </i>
                            <i class="txt_left fz_14 line_he_40">
                                运费：
                                <span class=" fz_14 fc_ash"><%=v.Freight %></span>
                            </i>
                            <i class="txt_left fz_14 line_he_40">
                                实收件数：
                                <span class=" fz_14 fc_ash"><%=v.Number %></span>
                            </i>
                            
                        </p>
                        <p class="dis_flex col_50 line_he_44" style="flex-direction: column;padding-left:.5rem;">
                            
                            <i class="txt_left fz_14 fc_ash line_he_40">
                                电话： 
                                <span class=" fz_14 fc_ash"><%=v.SHPhone %></span>
                            </i>
                            <i class="txt_left fz_14 fc_ash line_he_40">
                                电话： 
                                <span class=" fz_14 fc_ash"><%=v.FHPhone %></span>
                            </i>
                            <i class="txt_left fz_14 line_he_40">
                                代收款： 
                                 <span class=" fz_14 fc_ash"><%=v.GReceivables %></span>
                            </i>
                            <i class="txt_left fz_14 line_he_40">
                                其他费用：
                                <span class=" fz_14 fc_ash"><%=v.OtherExpenses %></span>
                            </i>
                        </p>
                    </div>
                    <div style="padding:1.5rem 1rem;position: relative;" class="white mart_10">
                        <%if (v.State != 4)
                            { %>
                        <i class="blue fc_white fz_12 padlr_10 line_he_30" style="position:absolute;top:0;right:0;"><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></i>
                         <%} %>
                        <%if (v.State == 4)
                            { %>
                        <a href="/LC/Customer/SignGood/LC_SgDetails.aspx?OID=<%=v.OrderID %>" class="blue fc_white fz_12 padlr_10 line_he_30" style="position:absolute;top:0;right:0;"><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></a>
                        <%} %>
                        <ul>
                            <li class="dis_flex jus_bet ali_center marb_10" id="luru">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">1</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">货单录入：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.DdTime %></span>
                                </div>
                            </li>
                            <%if (v.State == 2 || v.State==3 || v.State==4 || v.State==5 || v.State==6 || v.State==7)
                                { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="shouhuo">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">2</span>
                                </i>
                                <div class="col_90"  style="margin-left:10px;">
                                    <span class="fz_12">物流收货：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.ConsigneeTime %></span>
                                </div>
                            </li>
                            <%} %>
                             <%if (v.State == 3 || v.State==4 || v.State==5 || v.State==6 || v.State==7)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="fache">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">3</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">物流发车：</span>
                                    <span class="fz_12"  style="margin-left:10px;"><%=v.TruckTime %></span>
                                </div>
                            </li>
                            <%} %>
                             <%if (v.State == 4 || v.State==5 || v.State==6 || v.State==7)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="daoda">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">4</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">货物到达：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.MeetCarTime %></span>
                                </div>
                            </li>
                            <%} %>
                             <%if (v.State == 5 || v.State==6)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="tihuo">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">5</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">客户提货：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.DeliveryTime %></span>
                                </div>
                            </li>
                            <%} %>
                             <%if (v.State==6)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="success">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">6</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">订单完成：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.DischargeTime %></span>
                                </div>
                            </li>
                            <%} %>
                            <%if (v.State==7)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10" id="zhongzhuan">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">5</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">申请中转：</span>
                                    <span class="fz_12" style="margin-left:10px;"><%=v.TransferTime %></span>
                                </div>
                            </li>
                            <%} %>
                             <%if (v.State == 10)
                                 { %>
                            <li class="dis_flex jus_bet ali_center marb_10">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">6</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">货款回收：</span>
                                    <span class="fz_12" style="margin-left:10px;">暂</span>
                                </div>
                            </li>
                            <li class="dis_flex jus_bet ali_center marb_10">
                                <i class="fz_12 col_10 dis_flex jus_center">
                                    <span class="fz_12 dis_block" style="border:1px solid;width: 20px;height: 20px;line-height: 20px;text-align: center;border-radius: 20px;">7</span>
                                </i>
                                <div class="col_90" style="margin-left:10px;">
                                    <span class="fz_12">客户结款：</span>
                                    <span class="fz_12" style="margin-left:10px;">暂</span>
                                </div>
                            </li>
                            <%} %>
                        </ul>
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
        });
        var States = $("#ZT").val();
        if (States == 1) {
            $("#luru").addClass("fc_green");
        }
        else if (States == 2) {
            $("#shouhuo").addClass(" fc_green");
        }
        else if (States == 3) {
            $("#fache").addClass(" fc_green");
        }
        else if (States == 4) {
            $("#daoda").addClass(" fc_green");
        }
        else if (States == 5) {
            $("#tihuo").addClass(" fc_green");
        }
        else if (States == 6) {
            $("#success").addClass(" fc_green");
        }
        else if (States == 7) {
            $("#zhongzhuan").addClass(" fc_green");
        }
        function No() {
            Msg("功能暂未开放！");
        }
    </script>

</body>

</html>
