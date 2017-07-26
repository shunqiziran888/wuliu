<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Vehicle.aspx.cs" Inherits="Logistics.LC.Business.PretendCar.LC_Vehicle" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
        input[type=checkbox]{
            -webkit-appearance:checkbox;
            height: .8rem;
        }
        .bus_list li.active i.iconfont{
            display: block;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <a onclick="ShowSiJi()" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                <h1 class="title">选择车牌号</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <p class="dis_flex ali_center white padt_10 padb_10 mart_10" style="line-height:1rem;"><span class="col_40 txt_center">运费</span><span  class="col_60"><input class="col_70" type="text" placeholder="只能输入数字" id="largeCar" name="largeCar"></span></p>
                    <ul class="bus_list">
                        <%foreach (var v in list)
                            { %>
                        <li class="dis_flex ali_center yellow mart_10" style="padding:1rem;" mydata="<%=v.ID %>">
                            <div class="col_90 txt_center">
                                <strong class="marb_20" style="font-size:30px;font-weight:400;line-height:50px;"><%=v.VehicleNo %>(<%=v.Carshape %>)</strong>
                                <p class="fz_14"><%=v.Driver %> <span>电话暂不显示</span></p>
                                <p class="fz_12">添加日期：<span><%=v.CreateTime %></span></p>
                            </div>
                            <i class="iconfont fc_green dis_none">&#xe67b;</i>
                        </li>
                        <%} %>
                    </ul>
                </div>
                <div id="siji_box" class="dis_flex col_100 ali_center choose_siji" style="display:none; height:100%; position:fixed;top:0%; justify-content:center;" >
                    <div class="white col_80"  style="padding:1rem; height:150px;position:relative;">
                        <i onclick="$('#siji_box').css('display','none');" style="position:absolute;right:5px;top:0px;" class="iconfont icon-close1 fc_ash"></i>
                        <p class="txt_center" style="padding-bottom:1.5rem;">选择司机</p>
                        <p>
                            <select id="siji">
                                <option value="">请选择</option>
                            </select>
                        </p>
                        <p>
                            <a onclick="Vehie();" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">确定</a>
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

        let lastid = 0;
        $('.bus_list li').click(function () {
            debugger;
            let v = $(this);
            lastid = v.attr("mydata");
            v.addClass('active').siblings('li').removeClass('active');
        })

        PageInit(function () {
            GetHTML("GetDriverList", {}, function (data) {
                debugger;
                if (CheckHTMLData(data)) {
                    $("#siji").empty();
                    $("#siji").append('<option value="">请选择</option>');
                    for (var i = 0; i < data.data.length; i++)
                    {
                        $("#siji").append('<option value="' + data.data[i].ID + '">' + data.data[i].UserName + '<span>(' + data.data[i].Phone+')</span></option>');
                    }
                }
            });
        });
        /**
        * 显示选择司机
        */
        function ShowSiJi() {
            let dcyf = $("#largeCar").val();
            if (StrIsNullOrEmpty(dcyf))
            {
                Msg("大车运费必须填写!");
                return;
            }
            if (lastid <= 0)
            {
                Msg("车辆必须选择!");
                return;
            }
            $("#siji_box").css("display", "");
        };

        function Vehie() {
            var dcyf = document.getElementById("largeCar").value;
            var siji = $("#siji").val();
            if (StrIsNullOrEmpty(siji)) {
                Msg("请选择一个司机");
                return;
            }

            if (lastid <= 0) {
                Msg("车辆必须选择!");
                return;
            }

            if (dcyf != "" && dcyf != undefined && isNaN()) {
                var Ord = sessionStorage.getItem("OID");
                window.location.href = "/LC/Business/PretendCar/LC_Success.aspx?siji="+siji+"&OID=" + Ord + "&VehicleID=" + lastid + "&dcyf=" + dcyf;
            }
            else {
                alert("请填写大车运费！");
            }
        }
    </script>
</body>

</html>