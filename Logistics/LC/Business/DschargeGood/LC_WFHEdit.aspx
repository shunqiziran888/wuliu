<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_WFHEdit.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.LC_WFHEdit" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
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
                <a href="/LC/Business/DschargeGood/IndexDhg.aspx?sw2=1" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <!-- <a href="jieche_success.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">放货</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="white" style="padding:1rem .5rem;margin-top:1rem;">
                        <p class="dis_flex jus_aro marb_10">
                            <a class="btn col_35 fz_14 txt_center green fc_white" href="/LC/Business/DschargeGood/LC_TransferEdit.aspx?OID=<%=list.GetIndexValue(0)?.OrderID %>&Destination=<%=list.GetIndexValue(0)?.Destination %>">中转</a>
                            <a class="btn col_35 fz_14 txt_center blue fc_white" href="yuanfan.html">原返</a>
                        </p>
                        <p class="dis_flex jus_aro">
                            <a class="btn col_35 fz_14 txt_center brown fc_white" onclick="CashReceipt('<%=list.GetIndexValue(0)?.OrderID %>')">现金提货</a>
                            <a class="btn col_35 fz_14 txt_center red fc_white" href="/LC/Business/DschargeGood/LC_ArrearsSuccess.aspx?OID=<%=list.GetIndexValue(0).OrderID %>">欠款提货</a>
                        </p>
                    </div>
                    <%foreach (var v in list)
                        { %>
                    <div style="line-height:1.5rem;margin-top:1rem;flex-wrap:wrap;" class="dis_flex white">
                        <p class="col_100 txt_center" ><i class="txt_right fz_16 line_he_44">货号：</i><i class="txt_left fc_ash line_he_44"><%=v.GoodNo %></i></p>
                         <p class="col_100 txt_left" style="padding-left:5%;" >
                             <i class="txt_right fz_16 col_20 line_he_44">货物名： </i>
                             <i class="txt_left fc_ash fz_14 col_80 line_he_44"><%=v.GoodName %>
                                 <span class="fc_red">x<%=v.Number %>件</span>
                                 <span class="fc_green" style="margin-left:.5rem;">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span>
                            </i>
                            </p>
                        <p class="dis_flex   col_50" style="flex-direction: column;padding-left:5%;">
                            
                            <i class="txt_left fz_16 line_he_40">收货人： <span class=" fz_14 fc_ash"><%=v.Consignee %></span></i>
                            <i class="txt_left fz_16 line_he_40">发货人： <span class=" fz_14 fc_ash"><%=v.Consignor %></span></i>
                            <i class="txt_left fz_16 line_he_40">运费：<span class=" fz_14 fc_ash"><%=v.Freight %></span></i>
                            <i class="txt_left fz_16 line_he_40">代收款：<span class=" fz_14 fc_ash"><%=v.GReceivables %></span></i>
                              <%if (v.freightMode == 1)
                                {%>
                                 <i class="txt_left fz_16 line_he_40 ">运费提付：<span class=" fz_14 fc_ash"><%=v.Freight %></span></i>
                            <%}%>
                            <%if (v.freightMode == 2)
                                {%>
                                 <i class="txt_left fz_16 line_he_40 ">运费现付：<span class=" fz_14 fc_ash"><%=v.Freight %></span></i>
                            <%}%>
                            <%if (v.freightMode == 3)
                                {%>
                                 <i class="txt_left fz_16 line_he_40 ">运费扣付：<span class=" fz_14 fc_ash"><%=v.Freight %></span></i>
                            <%}%>
                            <%if (list.GetIndexValue(0).freightMode == 1)
                                    {%>
                                    <i class="txt_left fz_16 line_he_40 ">合计金额：<span class=" fz_14 fc_ash" id="TotalAmount"><%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).Freight+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 2)
                                    {%>
                                        <i class="txt_left fz_16 line_he_40 ">合计金额：<span class=" fz_14 fc_ash" id="TotalAmount"><%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 3)
                                    {%>
                                        <i class="txt_left fz_16 line_he_40 ">合计金额：<span class=" fz_14 fc_ash" id="TotalAmount"><%=(list.GetIndexValue(0).GReceivables-list.GetIndexValue(0).Freight)+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                        </p>
                        <p class="dis_flex col_50 line_he_44" style="flex-direction: column;padding-left:.5rem;">
                            
                           <i class="txt_left fz_16 line_he_40">电话： <span class=" fz_14 fc_ash"><%=v.SHPhone %></span></i>
                            <i class="txt_left fz_16 line_he_40">电话： <span class=" fz_14 fc_ash"><%=v.FHPhone %></span></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=v.Freight %>" id="SSyf"></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=v.GReceivables %>" id="SSdsk"></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=v.Freight %>" id="SStf"></i>
                            
                            <%if (list.GetIndexValue(0).freightMode == 1)
                                    {%>
                                <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).Freight+list.GetIndexValue(0).OtherExpenses %>" id="SShj" onkeyup="fillB()"></i>
                            <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 2)
                                    {%>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).OtherExpenses %>" id="SShj" onkeyup="fillB()"></i>
                                <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 3)
                                    {%>
                             <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="<%=(list.GetIndexValue(0).GReceivables-list.GetIndexValue(0).Freight)+list.GetIndexValue(0).OtherExpenses %>" id="SShj" onkeyup="fillB()"></i>    
                            <%}%>
                        </p>
                    </div>
                    <%} %>
                    <div style="line-height:1.5rem;margin-top:.5rem; margin-bottom:.5rem;padding:.5rem;" class=" white">
                        <p class="dis_flex ali_center col_100" style="flex-direction: column;">

                            <i class="txt_right fz_16 line_he_30 col_100 dis_flex "><span class="col_40">应收合计：</span> 
                                <%if (list.GetIndexValue(0).freightMode == 1)
                                    {%>
                                    <i class="col_60 txt_left"><span class="fc_ash"><%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).Freight+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 2)
                                    {%>
                                    <i class="col_60 txt_left"><span class="fc_ash"><%=list.GetIndexValue(0).GReceivables+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                                <%if (list.GetIndexValue(0).freightMode == 3)
                                    {%>
                                    <i class="col_60 txt_left"><span class="fc_ash"><%=(list.GetIndexValue(0).GReceivables-list.GetIndexValue(0).Freight)+list.GetIndexValue(0).OtherExpenses %></span></i>
                                <%}%>
                               <%-- <span class=" fz_14 fc_ash"></span>--%>

                            </i>
                             <i class="txt_right fz_16 line_he_30 col_100 dis_flex "><span class="col_40">实收合计：</span><span style="padding:0;" class="col_60 fz_16 txt_left"  id="TestSSHJ" ></span></i>
                        </p>
                        <p class="txt_right fz_12 fc_ash"><%=list.GetIndexValue(0).MeetCarTime %></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
            var TotalAmount = document.getElementById("TotalAmount").innerHTML;
            document.getElementById("TestSSHJ").innerHTML = "" + TotalAmount + "";
        });
    </script>
    <script type="text/javascript">
        function CashReceipt(OID)
        {
            var SSyf = $("#SSyf").val();
            var SSdsk = $ ("#SSdsk").val();
            var SStf = $("#SStf").val();
            var SShj = $("#SShj").val();
            var TotalAmount = document.getElementById("TotalAmount").innerHTML;
            window.location.href = "/LC/Business/DschargeGood/LC_Receivables.aspx?OID=" + OID + "&SSyf=" + SSyf + "&SSdsk=" + SSdsk + "&SStf=" + SStf + "&SShj=" + SShj + "&TotalAmount=" + TotalAmount;
        }
        function fillB() {
            var a = document.getElementById("SShj").value;
            if (a != "")
            {
                document.getElementById("TestSSHJ").innerHTML = parseInt(a);
            }
            else if (a == "")
            {
                var TotalAmount = document.getElementById("TotalAmount").innerHTML;
                document.getElementById("TestSSHJ").innerHTML = "" + TotalAmount + "";
            }
        }
    </script>
</body>

</html>
