<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_HistoryIndex.aspx.cs" Inherits="Logistics.LC.Business.ReceiptGood.LC_HistoryIndex" %>

<%@ Import Namespace="GlobalBLL" %>
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
        .zbsh-zffs .huo_name {
            position: relative;
        }

        .zbsh-zffs .huo_num {
            position: absolute;
            top: -15px;
            right: -80px;
            font-size: 16px;
            color: #f00;
            width: 80px;
            text-align: left;
        }

        .huo_fnagshi {
            margin-left: 80px;
            color: #009621;
        }

        .zongji {
            padding: .8rem 10%;
            background: #fff;
        }


        .check_box .check_main_left form label.active {
            color: #5986de;
        }

            .check_box .check_main_left form label.active input {
                display: block;
            }


        .check_box .check_main_right form label.active {
            color: #5986de;
        }

            .check_box .check_main_right form label.active input {
                display: block;
            }

        .huo_num {
            text-align: right;
        }

            .huo_num input {
                width: 30%;
                padding: 0;
                height: 1.2rem;
                line-height: 1.2rem;
            }

        .yunfei input {
            width: 50%;
            height: 1.2rem;
            line-height: 1.2rem;
        }

        .mudidi input {
            height: 1.2rem;
            line-height: 1.2rem;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/Business/ReceiptGood/LC_GoodsReceipt.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <h1 class="title">历史记录</h1>
            </header>


            <div class="content" style="background: #f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <div class="check_box row_44 white pos_r">
                        <!--搜索用个控件-->
                    </div>
                    <!-- 选择 -->


                    <div class="zongji mart_10">
                        <p class="zongji_top dis_flex  marb_10">
                            <i class="col_50 fz_16">汇总运费： <span class="fz_14">1201.1</span></i>
                            <i class="col_50 fz_16">汇总代收： <span class="fz_14">1201.1</span></i>
                        </p>
                        <p class="zongji_top dis_flex">
                            <i class="col_50 fz_16">未装运费： <span class="fz_14">1201.1</span></i>
                            <i class="col_50 fz_16">未装代收： <span class="fz_14">1201.1</span></i>
                        </p>
                    </div>
                    <ul class="zbsh-tab1">
                        <%if (list.Count > 0)
                            { %>
                        <%
                            foreach (var v in list)
                            {
                        %>
                        <li class="zbsh-li">
                            <a href="#">
                                <div class="col-100">
                                    <i class="zbsh-xd2">
                                        <p class="zbsh-zffs fz_16">货号： <span class="fc_ash fz_14"><%=v.GoodNo %><input type="text" id="OID" name="OID" value="<%=v.OrderID %>" hidden="hidden" /><input type="text" id="ZT" name="ZT" value="<%=v.State %>" hidden="hidden" /></span></p>
                                    </i>
                                    <i class="zbsh-xd2">
                                        <p class="zbsh-zffs fz_16">
                                            货物名： <span class="huo_name fc_ash fz_14"><%=v.GoodName %> <i class="huo_num" id="jianshu<%=v.OrderID %>">x<%=v.Number %></i><input type="text" id="Number<%=v.OrderID %>" name="Number" style="width: 50px; height: 20px; display: none" /></span>
                                            <span class="huo_fnagshi">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span>
                                        </p>
                                    </i>
                                    <i class="zbsh-xd1">
                                        <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14"><%=v.Consignor %></span></p>
                                        <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14"><%=v.Consignee %></span></p>

                                    </i>
                                    <i class="zbsh-xd1">
                                        <p class="zbsh-shr col_50 fz_16">运费： <span class="yunfei ft_color_ash fz_14" id="yunfie<%=v.OrderID %>"><%=v.Freight %></span><input type="text" id="Freight<%=v.OrderID %>" name="Freight" style="display: none; width: 100px; height: 20px;" /></p>
                                        <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14"><%=v.GReceivables %></span></p>

                                    </i>
                                    <i class="zbsh-xd2">
                                        <p class="zbsh-zffs fz_16">
                                            目的地： <span class="mudidi fc_ash fz_14" id="mdd<%=v.OrderID %>"><%=DAL.DAL.DALBase.GetAddressFromID(v.finish.Value)?.Item2?.Name %></span>
                                            <select id="finish<%=v.OrderID %>" style="display: none; width: 150px; height: 35px;">
                                                <%
                                                foreach (var v1 in list2)
                                                {
                                                %>
                                                <option value="<%=v1.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name %></option>
                                                <%
                                                    }
                                                %>
                                            </select>
                                        </p>
                                    </i>
                                    <p class="fz_16 dis_flex jus_bet ali_center fc_red" style="padding: 0 10%;"><i>合计金额： <span>暂不显示</span></i><i class="fz_12 fc_ash"><%=v.ConsigneeTime %></i></p>
                                </div>

                            </a>
                            <p class="dis_flex jus_center" id="genggai<%=v.OrderID %>">
                                <button class="change_btn line_he_30 padlr_30 green fc_white fz_14 mart_10" style="border: none;" onclick="Shows('<%=v.OrderID %>')">更改</button>
                            </p>
                            <p class="dis_flex jus_center">
                                <button class="change_btn line_he_30 padlr_30 green fc_white fz_14 mart_10" style="border: none; display: none" id="OK<%=v.OrderID %>" onclick="UpdateHistory('<%=v.OrderID %>')">确定</button>
                            </p>
                        </li>
                        <%
                            }
                        }else{
                        %>
                        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
                        <%
                            }
                        %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>


    <script id="kongjian_temp" type="text/html">

        <div class="check_tab_nav jus_bet dis_flex ali_center ">
            <div class="check_left col_40 txt_right row_44 li_row_44">
                <span>一周</span>
                <span class="iconfont fz_18" style="color: #7d7d7d;"></span>
            </div>
            <div class="check_right col_40 txt_left row_44 li_row_44">
                <span>线路</span>
                <span class="iconfont fz_18" style="color: #7d7d7d;"></span>
            </div>
        </div>

        <div class="check_main check_main_left pos_a col_100 white bor_top  dis_none" style="top: 2.2rem; z-index: 2;">
            <form class="bor_bottom" style="padding: 1rem; margin: 0 .3rem;">
                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                    今天
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right" onclick="SelectDate()">
                   <input type="hidden" id="dqDate" value="<%=DateTime.Now %>"/>
                </label>
                <label class="dis_flex jus_bet ali_center fz_14 line_he_40 active">
                    最近一周
                                    <input name="time" type="radio" class="col_50 bor_none  dis_none txt_right iconfont icon-right" onclick="aweek()">
                </label>
                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                    最近一月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right" onclick="OneMonth()">
                </label>
                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                    最近三月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right" onclick="ThreeMonth()">
                </label>
            </form>
            <div class="dis_flex jus_aro bor_bottom" style="padding: .5rem;">
                <input class="gray col_30" type="date"  id="startTime">
                <span class="iconfont icon-hengxian"></span>
                <input class="gray col_30" type="date"  id="endTime">
                <input class="close_btn  col_25" type="button" style="color: #5986de; border: 1px solid #5986de; padding: 0;" name="SouSuo" value="确定">
            </div>
        </div>

        <div class="check_main check_main_right pos_a col_100 white bor_top dis_none" style="top: 2.2rem; z-index: 2;">
            <ul>
                <form class="bor_bottom" style="padding: 1rem 0; margin: 0 .3rem;">
                    {{if data.length>0}}
                    {{each data as v}}
                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                        {{v.start_sheng}} {{v.start_shi}} {{v.start_qu}}---------{{v.end_sheng}} {{v.end_shi}} {{v.end_qu}}
                       <input name="endline" id="endline" value="{{v.BindLogisticsUid}}" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right">
                    </label>
                    {{/each}}
                    {{/if}}
                </form>
            </ul>
            <div class="dis_flex bor_bottom" style="padding: .5rem; justify-content: flex-end;">
                <input class="close_btn col_25" type="button" style="color: #5986de; border: 1px solid #5986de; padding: 0;" name="SouSuo" value="确定">
            </div>
        </div>
    </script>
    <script>
        PageInit(function () {
            debugger;
            if ($(".check_box.row_44.white.pos_r") != null) {
                GetHTML("GetMyLineList", {}, function (data) {
                    if (CheckHTMLData(data)) {
                        let html = TempToHtml("kongjian_temp", data);
                        $(".check_box.row_44.white.pos_r").html(html);
                        InitKongJian();
                        //增加搜索按钮事件
                        $("input[name^='SouSuo']").click(function () {
                            //取选择的时间
                            let startTime = $("#startTime").val();
                            let endTime = $("#endTime").val();
                            //let endline = $("#endline").val();
                            let endline = $('input[name="endline"]:checked').val();
                            RunSouSuo(startTime, endTime, endline);
                        });
                    }
                });
            }
        });

        function RunSouSuo(startTime, endTime, endline) {
            if (startTime == "" && endTime == "")
            {
                window.location.href = "/LC/Business/ReceiptGood/LC_HistoryIndex.aspx?End=" + endline;
            }
            else
            {
                var accuracystartTime = startTime + " 00:00:00";
                var accuracyendTime = endTime + " 23:59:59";
                window.location.href = "/LC/Business/ReceiptGood/LC_HistoryIndex.aspx?StartTime=" + accuracystartTime + "&endTime=" + accuracyendTime;
            }   
        }
    </script>


    <script>
        function Shows(OID) {
            $("#jianshu" + OID).hide();
            $("#yunfie" + OID).hide();
            $("#genggai" + OID).hide();
            $("#mdd" + OID).hide();
            $("#Number" + OID).show();
            $("#Freight" + OID).show();
            $("#finish" + OID).show();
            $("#OK" + OID).show();
        }
        function UpdateHistory(OID) {
            debugger;
            var Number = document.getElementById("Number" + OID).value;
            var Freight = document.getElementById("Freight" + OID).value;
            var finish = document.getElementById("finish" + OID).value;
            var ZT = document.getElementById("ZT").value;
            window.location.href = "/LC/Business/ReceiptGood/LC_HistoryEdit.aspx?OID=" + OID + "&Number=" + Number + "&Freight=" + Freight + "&finish=" + finish + "&ZT=" + ZT + "";
        }
        //获取今天日期
        function SelectDate()
        {
            var dqDate = Format(new Date(Date.parse($("#dqDate").val())),"yyyy-MM-dd");
            $("#startTime").val(dqDate);
            $("#endTime").val(dqDate);
        }
        //获取一周前的日期
        function aweek()
        {
            debugger;
            var now = new Date();
            var date = new Date(now.getTime() - 7 * 24 * 3600 * 1000);
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var day = date.getDate();
            //var hour = date.getHours();
            //var minute = date.getMinutes();
            //var second = date.getSeconds();
            if (month.toString().length == 1 && day.toString().length == 1)
            {
                var AweekDate = year + "-0" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 1)
            {
                var AweekDate = year + "-" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 1 && day.toString().length == 2) {
                var AweekDate = year + "-0" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 2) {
                var AweekDate = year + "-" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
        }
        //前一个月
        function OneMonth()
        {
            var nowdate = new Date();
            nowdate.setMonth(nowdate.getMonth() - 1);
            var year = nowdate.getFullYear();
            var month = nowdate.getMonth() + 1;
            var day = nowdate.getDate();
            if (month.toString().length == 1 && day.toString().length == 1) {
                var AweekDate = year + "-0" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 1) {
                var AweekDate = year + "-" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 1 && day.toString().length == 2) {
                var AweekDate = year + "-0" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 2) {
                var AweekDate = year + "-" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
        }
        //前三个月
        function ThreeMonth()
        {
            var nowdate = new Date();
            nowdate.setMonth(nowdate.getMonth() - 3);
            var year = nowdate.getFullYear();
            var month = nowdate.getMonth() + 1;
            var day = nowdate.getDate();
            if (month.toString().length == 1 && day.toString().length == 1) {
                var AweekDate = year + "-0" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 1) {
                var AweekDate = year + "-" + month + "-0" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 1 && day.toString().length == 2) {
                var AweekDate = year + "-0" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
            else if (month.toString().length == 2 && day.toString().length == 2) {
                var AweekDate = year + "-" + month + "-" + day;
                $("#startTime").val(AweekDate);
                $("#endTime").val(Format(new Date(Date.parse($("#dqDate").val())), "yyyy-MM-dd"));
            }
        }
    </script>

</body>

</html>
