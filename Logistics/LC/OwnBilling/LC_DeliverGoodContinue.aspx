<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_DeliverGoodContinue.aspx.cs" Inherits="Logistics.LC.OwnBilling.LC_DeliverGoodContinue" %>

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
        .prompt_msg {
            position: absolute;
            width: 22px;
            height: 22px;
            background: #f00;
            border-radius: 20px;
            color: #fff;
            line-height: 22px;
            top: 50%;
            left: 68%;
            margin-top: -11px;
            font-size: 10px;
            text-align: center;
        }

        select {
            background-size: 20px 20px;
        }
        .check_box span.active button i.iconfont{
            display: block;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/OwnBilling/LC_DeliverGoods.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <a onclick="success()" class="icon pull-right dis_inline green" style="color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                <h1 class="title">收货开单</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index marb_20">
                    <div class="pad_10 white mart_10">
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">货物来源：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_50 active">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        普通客户
                                    </button>
                                </span>
                                <span class="col_50">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        合作物流
                                    </button>
                                </span>
                            </i>
                        </p>
                        <p class="dis_flex jus_bet ali_center  marb_10">
                            <span class="col_30 txt_right fz_16">其他费用：</span>
                            <span class="col_70"><input type="text" name="OtherExpenses" id="OtherExpenses"></span>
                        </p>
                        <p class="dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">备注：</span>
                            <span class="col_70"><textarea style="border:1px solid #bbbbbb;width:100%;height:100px;" ></textarea></span>
                        </p>
                    </div>
                    <div class="pad_10 white mart_10">
                        <p class="dis_flex jus_bet ali_center  marb_10">
                            <span class="col_30 txt_right fz_16">运费金额：</span>
                            <span class="col_70"><input type="text" name="Freight" id="Freight"></span>
                        </p>
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">运费方式：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_30 active" value="1"  name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        提付
                                    </button>
                                </span>
                                <span class="col_30" value="2"  name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        现付
                                    </button>
                                </span>
                                <span class="col_30" value="3" name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        扣付
                                    </button>
                                </span>
                            </i>
                        </p>
                        
                        
                    </div>
                    <div class="pad_10 white mart_10">
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">收货方式：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_30 active" name="ReceiptGood" value="1">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        送到货站
                                    </button>
                                </span>
                                <span class="col_30" name="ReceiptGood" value="2">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        物流来取
                                    </button>
                                </span>
                                <span class="col_30">
                                     <input type="number" placeholder="取货费">
                                </span>
                            </i>
                        </p>
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">付货方式：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_30 active" name="CarryGood" value="1">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        客户自提
                                    </button>
                                </span>
                                <span class="col_30" name="CarryGood" value="2">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position:relative;border:none;">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size:24px;position:absolute;bottom:-5px; right:-15px;color:#8bc34a;"></i>
                                        送货上门
                                    </button>
                                </span>
                                <span class="col_30">
                                    <input type="number" placeholder="取货费">
                                </span>
                            </i>
                        </p>
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
        });
        $('.check_box button').click(function () {
            $(this).parent('span').addClass('active').siblings('span').removeClass('active');
        });
    </script>
    <script type="text/javascript">
        function success() {
            var freightMode = $("span[name='freightMode'][class$='active']").attr("value");
            var ReceiptGood = $("span[name='ReceiptGood'][class$='active']").attr("value");
            var CarryGood = $("span[name='CarryGood'][class$='active']").attr("value");
            var OtherExpenses = $("#OtherExpenses").val();
            var Freight = $("#Freight").val();
            //上个页面的值
            var Consignor = "<%=Consignor%>";
            var FHPhone = "<%=FHPhone%>";
            var GoodName = "<%=GoodName%>";
            var Number = "<%=Number%>";
            var GReceivables = "<%=GReceivables%>";
            var Consignee = "<%=Consignee%>";
            var SHPhone = "<%=SHPhone%>";
            var End = "<%=End%>";
            var finish = "<%=finish%>";
            var BindLogisticsUid ="<%=BindLogisticsUid%>";
            if (OtherExpenses != "" && Freight != "") {
                Href("/LC/OwnBilling/LC_Success.aspx?freightMode=" + freightMode + "&ReceiptGood=" + ReceiptGood + "&CarryGood=" + CarryGood + "&OtherExpenses=" + OtherExpenses + "&Freight=" + Freight + "&Consignor=" + Consignor + "&FHPhone=" + FHPhone + "&GoodName=" + GoodName + "&Number=" + Number + "&GReceivables=" + GReceivables + "&Consignee=" + Consignee + "&SHPhone=" + SHPhone + "&End=" + End + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid);
            }
            else {
                Msg("所有内容均不能为空！");
            }
        }
    </script>
</body>

</html>