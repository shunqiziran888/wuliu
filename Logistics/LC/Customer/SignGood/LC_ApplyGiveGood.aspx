<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_ApplyGiveGood.aspx.cs" Inherits="Logistics.LC.Customer.SignGood.LC_ApplyGiveGood" %>
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
        select option{
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
                <a href="javascript:;" onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <!-- <a href="jieche_success.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">送货</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">

                    <div style="line-height:1.5rem;margin-top:1rem;" class="dis_flex white">
                        <p class="dis_flex   col_30" style="flex-direction: column;">
                            <i class="txt_right fz_16 line_he_44">货号：</i>
                            <i class="txt_right fz_16  line_he_44">货物名称：</i>
                            <i class="txt_right fz_16  line_he_44">收货人：</i>
                            <i class="txt_right fz_16  line_he_44">收货电话：</i>
                            <i class="txt_right fz_16  line_he_44">运费：</i>
                            <i class="txt_right fz_16  line_he_44">代收款：</i>
                            <i class="txt_right fz_16 line_he_44 ">运费提付：</i>
                            <i class="txt_right fz_16 line_he_44 ">合计金额：</i>
                        </p>
                        <%
                            foreach (var v in list)
                            {
                            %>
                        <p class="dis_flex col_70 line_he_44" style="flex-direction: column;padding-left:.5rem;">
                            <i class="txt_left fc_ash line_he_44"><%=v.GoodNo %></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><%=v.GoodName %><span class="fc_red">x<%=v.Number %>件</spa><span class="fc_green" style="margin-left:.5rem;">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><%=v.Consignee %></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><%=v.SHPhone %></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><%=v.Freight %></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><%=v.GReceivables %></i>
                            <i class="txt_left fc_ash fz_14 line_he_44">暂不显示</i>
                            <i class="txt_left fc_ash fz_14 line_he_44">暂不显示</i>
                            <input type="hidden" id="OID" value="<%=v.OrderID %>"/>
                        </p>
                        <%} %>
                    </div>
                    <div style="line-height:1.5rem;margin-top:.5rem;" class="dis_flex white">
                        <p class="dis_flex   col_30" style="flex-direction: column;">
                            
                            <i class="txt_right fz_16  line_he_44">送货地址：</i>
                            <i class="txt_right fz_16  line_he_44">送货费用：</i>
                        </p>
                        <p class="dis_flex col_70 line_he_44" style="flex-direction: column;padding-left:.5rem;">
                            
                            <i class="txt_left fc_ash fz_14 line_he_44"><input class="col_90"  id="DetailedAddress" name="DetailedAddress"  type="text" value="<%=DAL.DAL.DALBase.GetAllAddressNames(list.GetIndexValue(0).Destination.ConvertData<int>()).Item1 %>&nbsp;&nbsp;<%=DAL.DAL.DALBase.GetAllAddressNames(list.GetIndexValue(0).Destination.ConvertData<int>()).Item2 %>&nbsp;&nbsp;<%=DAL.DAL.DALBase.GetAllAddressNames(list.GetIndexValue(0).Destination.ConvertData<int>()).Item3 %>"></i>
                            <i class="txt_left fc_ash fz_14 line_he_44"><input class="col_90" id="DeliveryCost" name="DeliveryCost" type="text" placeholder="输入数字"></i>
                        </p>
                        
                    </div>
                    <p class="dis_flex white padb_10" style="justify-content:center;"><a style="line-height: 30px;background: #a3c478;color: #fff;width: 90px;text-align: center;border: 1px solid #a3c478;margin-top:1rem;" onclick="SQSH()">确认</a></p>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
     <script src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>
</body>
</html>
<script type="text/javascript">
    function SQSH()
    {
        var OID = document.getElementById("OID").value;
        var DetailedAddress = document.getElementById("DetailedAddress").value;
        var DeliveryCost = document.getElementById("DeliveryCost").value;
        //alert(OID + " and " + DetailedAddress + " and " + DeliveryCost);
        <%--href = "/LC/Customer/SignGood/LC_GiveSuccess.aspx?OID=<%=list.GetIndexValue(0).OrderID%>--%>
        window.location.href = "/LC/Customer/SignGood/LC_GiveSuccess.aspx?OID=" + OID + "&DetailedAddress=" + DetailedAddress + "&DeliveryCost=" + DeliveryCost+"";
    }
</script>