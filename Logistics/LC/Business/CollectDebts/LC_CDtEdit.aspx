<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_CDtEdit.aspx.cs" Inherits="Logistics.LC.Business.CollectDebts.LC_CDtEdit" %>

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
                <a href="javascript:;" onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <!-- <a href="jieche_success.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">收欠款</h1>
            </header>


            <div class="content" style="background:#f2f2f2;" id="content_list">
           <%--数据--%>
            </div>
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script type="text/html" id="content_list_temp">
         {{if data.length>0}}
        {{each data as v}}
                 <div class="page-index" >
                    <div class="white box" style="padding:2rem .5rem;margin-top:1rem;">
                         <p class="dis_flex" style="justify-content:center;">
                            <a onclick="Next()" class="btn queren_btn fc_white green fz_14">确认收款</a>
                        </p> 
                        <!-- <p class="txt_center"> <i class="iconfont fc_green" style="font-size:55px;">&#xe67b;</i></p>
                        <p class="txt_center">原返成功</p> -->
                    </div>
                    <div style="line-height:1.5rem;margin-top:1rem;flex-wrap:wrap;" class="dis_flex white">
                               <p class="col_100 txt_center" ><i class="txt_right fz_16 line_he_44">货号：</i><i class="txt_left fc_ash line_he_44">{{v.GoodNo}}</i></p>
                         <p class="col_100 txt_left" style="padding-left:5%;" >
                             <i class="txt_right fz_16 col_20 line_he_44">货物名： </i>
                             <i class="txt_left fc_ash fz_14 col_80 line_he_44">{{v.GoodName}}
                                 <span class="fc_red">x{{v.Number}}件</span>
                                {{if v.freightMode==1}}
                                 <span class="fc_green" style="margin-left:.5rem;">(提付)</span>
                                 {{/if}}
                                 {{if v.freightMode==2}}
                                 <span class="fc_green" style="margin-left:.5rem;">(现付)</span>
                                 {{/if}}
                                 {{if v.freightMode==3}}
                                 <span class="fc_green" style="margin-left:.5rem;">(扣付)</span>
                                 {{/if}}
                            </i>
                            </p>
                        <p class="dis_flex   col_50" style="flex-direction: column;padding-left:5%;">
                            
                            <i class="txt_left fz_16 line_he_40">收货人： <span class=" fz_14 fc_ash">{{v.Consignee}}</span></i>
                            <i class="txt_left fz_16 line_he_40">发货人： <span class=" fz_14 fc_ash">{{v.Consignor}}</span></i>
                            <i class="txt_left fz_16 line_he_40">运费：<span class=" fz_14 fc_ash">{{v.Freight}}</span></i>
                            <i class="txt_left fz_16 line_he_40">代收款：<span class=" fz_14 fc_ash">{{v.GReceivables}}</span></i>
                            {{if v.freightMode==1}}
                            <i class="txt_left fz_16 line_he_40 ">运费提付：<span class=" fz_14 fc_ash">{{v.Freight}}</span></i>
                            {{/if}}
                             {{if v.freightMode==2}}
                            <i class="txt_left fz_16 line_he_40 ">运费现付：<span class=" fz_14 fc_ash">{{v.Freight}}</span></i>
                            {{/if}}
                             {{if v.freightMode==3}}
                            <i class="txt_left fz_16 line_he_40 ">运费扣付：<span class=" fz_14 fc_ash">{{v.Freight}}</span></i>
                            {{/if}}
                            <i class="txt_left fz_16 line_he_40 ">合计金额：<span class=" fz_14 fc_ash" id="TotalAmount">{{v.Total}}</span></i>
                        </p>
                        <p class="dis_flex col_50 line_he_44" style="flex-direction: column;padding-left:.5rem;">
                            
                            <i class="txt_left fz_16 line_he_40">电话： <span class=" fz_14 fc_ash">{{v.SHPhone}}</span></i>
                            <i class="txt_left fz_16 line_he_40">电话： <span class=" fz_14 fc_ash">{{v.FHPhone}}</span></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="{{v.Freight}}" id="SSyf"></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="{{v.GReceivables}}" id="SSdsk"></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="{{v.Freight}}" id="SStf"></i>
                            <i class="txt_left fz_16 line_he_40">实收： <input class=" fz_14 col_60" type="text" placeholder="{{v.Total}}" id="SShj" onkeyup="fillB()"></i>
                        </p>
                    </div>
                    <div style="line-height:1.5rem;margin-top:.5rem; margin-bottom:.5rem;padding:.5rem;" class=" white">
                        <p class="dis_flex ali_center col_100" style="flex-direction: column;">
                            <i class="txt_left fz_16 line_he_30 ">应收合计：<span class=" fz_14 fc_ash">{{v.Total}}</span></i>
                            <i class="txt_right fz_16 line_he_30">实收合计： <span class=" fz_14 fc_ash" id="TestSSHJ"></span></i>
                            <i class="txt_right fz_16 line_he_30">欠款金额： <span class=" fz_14 fc_ash">0</span></i>
                        </p>
                        <p class="txt_right fz_12 fc_ash">{{v.ArrearsTime}}</p>
                    </div>
                </div>
        {{/each}}
        {{else}}
        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
        {{/if}}
    </script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
            var TotalAmount = document.getElementById("TotalAmount").innerHTML;
            document.getElementById("TestSSHJ").innerHTML = "" + TotalAmount + "";
        });
        PageInit(function () {
            let OID = GET("OID");
            GetHTML("GetCollectDebtsEdit", { OID: OID }, function (data) {
                if (CheckHTMLData(data)) {
                    let html = TempToHtml("content_list_temp", data);
                    $("#content_list").html(html);
                    RemoveLuyou();
                }
            });
        });
    </script>

</body>

</html>
<script type="text/javascript">
        function Next()
        {
            let OID = GET("OID");
            var SSyf = $("#SSyf").val();//实收运费
            var SSdsk = $("#SSdsk").val();//实收代收款
            var SShj = $("#SShj").val();//实收合计
            var TotalAmount = document.getElementById("TotalAmount").innerHTML;
            window.location.href = "/LC/Business/CollectDebts/LC_Payment.aspx?OID=" + OID + "&SSyf=" + SSyf + "&SSdsk=" + SSdsk + "&SShj=" + SShj + "&TotalAmount=" + TotalAmount;
        }
        function fillB() {
            var a = document.getElementById("SShj").value;
            if (a != "") {
                document.getElementById("TestSSHJ").innerHTML = parseInt(a);
            }
            else if (a == "") {
                var TotalAmount = document.getElementById("TotalAmount").innerHTML;
                document.getElementById("TestSSHJ").innerHTML = "" + TotalAmount + "";
            }
        }
</script>