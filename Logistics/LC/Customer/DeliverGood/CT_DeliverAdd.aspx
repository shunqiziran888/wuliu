<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CT_DeliverAdd.aspx.cs" Inherits="Logistics.LC.Customer.CT_DeliverAdd" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
<%@ Import  Namespace="SuperDataBase" %>
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
        #MoreCity{
            color:#a3c478;
            cursor:pointer;
        }
        select {
            background-size: 20px 20px;
        }
        dis_none{
            display:none;
        }
        .check_box span.active button i.iconfont {
            display: block;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:;" onclick="window.history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <a onclick="Next()" class="icon pull-right dis_inline green" style="color: #fff; border: 1px solid #bbb; line-height: 1.5rem; padding: 0 1rem; margin-top: .28rem;">下一步</a>
                <%--<input type="submit" value="下一步" class="icon pull-right dis_inline green  col_20" style="color: #fff; border: 1px solid #bbb; line-height: 1.5rem; padding: 0 1rem; margin-top: .28rem; width: 110px;" />--%>
                <h1 class="title">我要发货</h1>
            </header>


            <div class="content" style="background: #f2f2f2;">
                <div class="page-index marb_20">
                    <div class="pad_20 white mart_10">
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">收货人：</span>
                            <span class="col_70">
                                <input name="Consignee" type="text" id="Consignee" value="<%=shr %>" placeholder="请输入收货人姓名">
                            </span>
                        </p>
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">收货电话：</span>
                            <span class="col_70">
                                <input name="SHPhone" type="text" id="SHPhone" oninput="phonechange(this);" onpropertychange="phonechange(this);" value="<%=shrdh %>" placeholder="收货人手机号">
                            </span>
                        </p>
                        
                    </div>
                    <div class="pad_20 white mart_10">
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">收货地址：</span>
                            <span class="col_70">
                                <select id="logisticsID" name="logisticsID" onchange="AutoAddress(this)">
                                    <option value="0">请选择物流</option>
                                    <%
                                        if (list.Count > 0)
                                        {
                                            foreach (var p in list)
                                            {
                                                var v = p.GetDicVO<Model.Model.LC_User>();
                                                var line = p.GetDicVO<Model.Model.LC_Line>();
                                                var name = DAL.DAL.DALBase.GetAddressFromID(line.End.ConvertData<int>()).Item2.Name;
                                    %>
                                    <option value="<%=v.UID %>,<%=v.ProvincesID %>,<%=v.CityID %>,<%=v.AreaID %>,<%=name %>,<%=line.End %>"><%=v.LogisticsName %>(<%=DAL.DAL.DALBase.GetAddressFromID(v.ProvincesID.Value)?.Item2?.Name %>---<%=DAL.DAL.DALBase.GetAddressFromID(v.CityID.Value)?.Item2?.Name %>---<%=DAL.DAL.DALBase.GetAddressFromID(v.AreaID.Value)?.Item2?.Name %>)</option>
                                    <%
                                            }
                                        }
                                    %>
                                </select>
                            </span>
                        </p>
                        <%--<p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">目标地：</span>
                            <span class="col_60">
                                <select id="logisticsID" name="logisticsID" onchange="AutoAddress(this)">
                                    <option value="0">请选择</option>
                                    <%
                                        if (list.Count > 0)
                                        {
                                            foreach (var p in list)
                                            {
                                                var v = p.GetDicVO<Model.Model.LC_User>();
                                                var line = p.GetDicVO<Model.Model.LC_Line>();
                                                var name = DAL.DAL.DALBase.GetAddressFromID(line.End.ConvertData<int>()).Item2.Name;
                                    %>
                                    <option value="<%=v.UID %>,<%=v.ProvincesID %>,<%=v.CityID %>,<%=v.AreaID %>,<%=name %>,<%=line.End %>"><%=v.LogisticsName %>(<%=DAL.DAL.DALBase.GetAddressFromID(v.ProvincesID.Value)?.Item2?.Name %>---<%=DAL.DAL.DALBase.GetAddressFromID(v.CityID.Value)?.Item2?.Name %>---<%=DAL.DAL.DALBase.GetAddressFromID(v.AreaID.Value)?.Item2?.Name %>)</option>
                                    <%
                                            }
                                        }
                                    %>
                                </select>
                            </span>
                            <span class="col_10 txt_right"><i class="txt_right fz_28 iconfont " data-aid="1" id="MoreCity">&#xe608;</i></span>
                        </p>--%>
                        <p class="dis_none jus_bet line_he_40 citylist">
                            <span class="col_30 txt_right">省份：</span>
                            <span class="col_70">
                                <select id="End1" name="End1" onchange="show(this.value,'End2');">
                                    <option>请选择</option>
                                    <%
                                        foreach (var p in shengList)
                                        {
                                    %>
                                    <option value="<%=p.id %>"><%=p.Name %></option>

                                    <%
                                        } %>
                                </select>
                            </span>
                        </p>
                        <p class="dis_none jus_bet line_he_40 citylist" >
                            <span class="col_30 txt_right">城市：</span>
                            <span class="col_70">
                                <select id="End2" name="End2" onchange="show(this.value,'End');">
                                </select>
                            </span>
                        </p>
                         <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">目标地：</span>
                            <span class="col_60">
                                <select id="End" name="End">
                                </select>
                            </span>
                            <span class="col_10 txt_right"><i class="txt_right fz_28 iconfont " data-aid="1" id="MoreCity">&#xe608;</i></span>
                        </p>
        <%--                <p class="dis_none jus_bet line_he_40 citylist">
                            <span class="col_30 txt_right">区县：</span>
                            <span class="col_70">
                                <select id="End" name="End">
                                </select>
                            </span>
                        </p>--%>
                        
                    </div>
                    <div class="pad_20 white mart_10">
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">货物名称：</span>
                            <span class="col_70">
                                <input name="GoodName" type="text" id="GoodName" placeholder="请输入货物名称">
                            </span>
                        </p>
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">件数：</span>
                            <span class="col_70">
                                <input name="Number" type="text" id="Number" placeholder="请输入发货件数">
                            </span>
                        </p>
                        <p class="dis_flex jus_bet line_he_40">
                            <span class="col_30 txt_right">代收货款：</span>
                            <span class="col_70">
                                <input name="GReceivables" type="text" id="GReceivables" placeholder="请输入代收货款">
                            </span>
                        </p>
                    </div>
                    <div class="pad_10 white mart_10">
                        <p class="dis_flex jus_bet ali_center  marb_10">
                            <span class="col_30 txt_right fz_16">其他费用：</span>
                            <span class="col_70">
                                <input name="OtherExpenses" type="text" id="OtherExpenses" placeholder="请输入其他费用">
                        </p>
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">运费方式：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_30" value="1" name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20  ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        提付
                                    </button>
                                </span>
                                <span class="col_30" value="2" name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20 ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        现付
                                    </button>
                                </span>
                                <span class="col_30" value="3" name="freightMode">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_20 ash " style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
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
                                <span class="col_30" name="ReceiptGood" value="1" onclick="QhfText()">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        送到货站
                                    </button>
                                </span>
                                <span class="col_30" name="ReceiptGood" value="2" onclick="QhfText()">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        物流来取
                                    </button>
                                </span>
                                <span class="col_30" style="display:none" id="qhf">
                                    <input type="number" placeholder="取货费" id="PickupCost" name="PickupCost">
                                </span>
                            </i>
                        </p>
                        <p class="check_box dis_flex jus_bet ali_center marb_10">
                            <span class="col_30 txt_right fz_16">付货方式：</span>
                            <i class="col_70 dis_flex jus_aro">
                                <span class="col_30" name="CarryGood" value="1" onclick="ShfText()">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        客户自提
                                    </button>
                                </span>
                                <span class="col_30" name="CarryGood" value="2" onclick="ShfText()">
                                    <button class="fc_white ash line_he_30 fz_12 padlr_10 ash" style="position: relative; border: none;" type="button">
                                        <i class="iconfont icon-checkmark3 dis_none fc_green fz_32" style="font-size: 24px; position: absolute; bottom: -5px; right: -15px; color: #8bc34a;"></i>
                                        送货上门
                                    </button>
                                </span>
                                <span class="col_30" style="display:none" id="shf">
                                    <input type="number" placeholder="送货费" id="GivegoodCost" name="GivegoodCost">
                                </span>
                            </i>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>

    <script type="text/javascript">
        $(function () {
            $.init();
            $.config = { router: false }
            $('.check_box button').click(function () {
                debugger;
                $(this).parent('span').addClass('active').siblings('span').removeClass('active');
            })
            let yffs = "<%=uffs%>";
            let cg ="<%=CarryGood%>";
             let RG = "<%=ReceiptGood%>";
                $("span[name='freightMode'][value='" + yffs + "']").attr("class", "active");
                $("span[name='CarryGood'][value='" + cg + "']").attr("class", "active");
                $("span[name='ReceiptGood'][value='" + RG + "']").attr("class", "active");
            //默认选择物流
            let wlid = "<%=GetValue("wlid")%>";
                if (!StrIsNull(wlid)) {
                    //获取所有物流列表
                    let list = $("#logisticsID option");
                    if (list != null) {
                        for (let i = 0; i < list.length; i++) {
                            let v = list[i];
                            let vStr = $(v).val();
                            let arr = vStr.split(',');
                            if (arr != null) {
                                if (arr.length > 0) {
                                    if (arr[0] == wlid) {
                                        $(v).attr("selected", true);
                                        AutoAddress($("#logisticsID"));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
        });
        var isAuto = 0;
        //根据物流筛选的线路
        function AutoAddress(element) {
            isAuto = true;
            try {
                var v = $(element).val().split(',');

                let uid = v[0];
                let mbd = "<%=GetValue("mbd")%>";
                    GetHtml("/Command/GetLogisticsLineListFromUid.aspx", { uid: uid }, function (data) {
                        let vo = JSON.parse(data);
                        if (vo.Item1) {
                            let list = vo.Item3;
                            if (list.length > 0) {
                                $("#End").empty();
                                for (let i = 0; i < list.length; i++) {
                                    let v = list[i];
                                    if (v.End == mbd) {
                                        //$("#End1").append("<option value='0' selected>" + v.ShengName + "</option>");
                                        //$("#End2").append("<option value='0' selected>" + v.QuName + "</option>");
                                        $("#End").append("<option value='" + v.End + "' selected>" + v.EndName + "</option>");
                                    }
                                    else {
                                        //$("#End1").append("<option value='0' selected>" + v.ShengName + "</option>");
                                        //$("#End2").append("<option value='0' selected>" + v.QuName + "</option>");
                                        $("#End").append("<option value='" + v.End + "'>" + v.EndName + "</option>");
                                    }
                                }
                            }
                        }
                    });
                }
                catch (e)
                { }
            }
            //地区联动
        function show(id, elename) {
            if (isAuto != 0)
                return;
            GetHtml("/Command/GetAddressNextList.aspx", { id: id }, function (data) {
                let list = JSON.parse(data);
                $("#" + elename).empty();
                $("#" + elename).append("<option>-请选择-</option>");
                for (let i = 0; i < list.length; i++) {
                    $("#" + elename).append("<option value='" + list[i].id + "'>" + list[i].Name + "</option>");
                }
            });
        }
        //下一步完成
        function Next() {
            var PickupCost = $("#PickupCost").val();
            var GivegoodCost = $("#GivegoodCost").val();
            var freightMode = $("span[name='freightMode'][class$='active']").attr("value");
            var ReceiptGood = $("span[name='ReceiptGood'][class$='active']").attr("value");
            var CarryGood = $("span[name='CarryGood'][class$='active']").attr("value");
            var Consignee = $("#Consignee").val();
            var SHPhone = $("#SHPhone").val();
            var logisticsID = $("#logisticsID").val();
            var End = $("#End").val();
            var GoodName = $("#GoodName").val();
            var Number = $("#Number").val();
            var GReceivables = $("#GReceivables").val();
            var OtherExpenses = $("#OtherExpenses").val();
            if (Consignee == "" || SHPhone == "" || logisticsID == "" || End == 0 || GoodName == "" || Number == 0 || GReceivables == 0 || freightMode == undefined || ReceiptGood == undefined || CarryGood == undefined || OtherExpenses == 0) {
                Msg("所有内容均不能为空！");
                return;
            }

            //判断第一个控件是否显示
            if (document.getElementById("qhf").style.display == "block") {

                PickupCost = parseFloat(PickupCost);
                if (isNaN(PickupCost))
                    PickupCost = 0;

                if (PickupCost <= 0) {
                    Msg("所有内容均不能为空！");
                    return;
                }
            }


            if (document.getElementById("shf").style.display == "block") {
                GivegoodCost = parseFloat(GivegoodCost);
                if (isNaN(GivegoodCost))
                    GivegoodCost = 0;

                if (GivegoodCost <= 0) {
                    Msg("所有内容均不能为空！");
                    return;
                }
            }

            Href("/LC/Customer/DeliverGood/CT_DeliverAdd.aspx?Consignee=" + Consignee + "&SHPhone=" + SHPhone + "&logisticsID=" + logisticsID + "&End=" + End + "&GoodName=" + GoodName + "&Number=" + Number + "&GReceivables=" + GReceivables + "&freightMode=" + freightMode + "&ReceiptGood=" + ReceiptGood + "&CarryGood=" + CarryGood + "&OtherExpenses=" + OtherExpenses + "&PickupCost=" + PickupCost + "&GivegoodCost=" + GivegoodCost);


        }
        $(function () {
            $('#MoreCity').click(function () {
                isAuto = false;
                var id = $(this).attr('data-aid');
                if (id == 1) {
                    $('.citylist').css('display', 'flex');
                    $(this).html('&#xe603;');
                    $(this).attr('data-aid','2');
                } else {
                    $('.citylist').css('display', 'none');
                    $(this).html('&#xe608;');
                    $(this).attr('data-aid', '1');
                }
                
            })
           
           
        })
        function QhfText()
        {
            var freightMode = $("span[name='ReceiptGood'][class$='active']").attr("value");
            if (freightMode == 2)
            {
                document.getElementById("qhf").style.display = "block";
            }
            else
            {
                document.getElementById("qhf").style.display = "none";
            }
        }
        function ShfText() {
            var CarryGood = $("span[name='CarryGood'][class$='active']").attr("value");
            if (CarryGood == 2) {
                document.getElementById("shf").style.display = "block";
            }
            else {
                document.getElementById("shf").style.display = "none";
            }
        }
    </script>
</body>

</html>
