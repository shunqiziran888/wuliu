﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_PaymentDay.aspx.cs" Inherits="Logistics.LC.Business.PaymentDay.LC_PaymentDay" %>

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
            top: -10px;
            right: -35px;
            font-size: 16px;
            color: #f00;
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
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/MenuBar/LC_BusinessIndex.aspx" class="icon iconfont icon-zuo pull-left"></a>
               <%-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="#"></a>
                    <i class="add_txt">历史记录</i>
                </p>--%>
                <h1 class="title">日结账</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
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


                    <div class="zongji mart_10" id="PaidCount_list">
                       <%--数据统计--%>
                    </div>
                    <ul class="zbsh-tab1" id="PaymentDay_list">
                        <%--数据--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script id="PaidCount_list_temp" type="text/html">
        <p class="zongji_top dis_flex  marb_10">
            <i class="col_50 fz_16">汇总运费： <span class="fz_14">{{data.Freight}}</span></i>
            <i class="col_50 fz_16">汇总代收： <span class="fz_14">{{data.GReceivables}}</span></i>
        </p>

        <p class="zongji_top dis_flex marb_10">
            <i class="col_50 fz_16">微信收款： <span class="fz_14">0元</span></i>
            <i class="col_50 fz_16">现金收款： <span class="fz_14">0元</span></i>
        </p>
        <p class="zongji_top dis_flex ">
            <i class="col_50 fz_16">支付宝： <span class="fz_14">0元</span></i>
            <i class="col_50 fz_16">银行卡： <span class="fz_14">0元</span></i>
        </p>
    </script>
    <script type="text/html" id="PaymentDay_list_temp">
         {{if data.length>0}}
         {{each data as v}}
          <li class="zbsh-li">
              <a href="#">
                  <div class="col-100">
                      <i class="zbsh-xd2">
                          <p class="zbsh-zffs fz_16">
                              货物名： <span class="huo_name fc_ash fz_14">{{v.lcc.GoodName}} <i class="huo_num">x{{v.lcc.Number}}</i></span>
                              <span class="huo_fnagshi">({{v.freightModeName}})</span>
                          </p>
                      </i>
                      <i class="zbsh-xd1">
                          <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14">{{v.lcc.Consignor}}</span></p>
                          <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14">{{v.lcc.Consignee}}</span></p>

                      </i>
                      <i class="zbsh-xd1">
                          <p class="zbsh-shr col_50 fz_16">运费： <span class="ft_color_ash fz_14">{{v.lcc.Freight}}</span></p>
                          <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14">{{v.lcc.GReceivables}}</span></p>
                      </i>
                      <p class="fz_16 dis_flex jus_bet ali_center fc_red" style="padding: 0 10%;">
                          {{if v.lcc.freightMode==1}}
                          <i>合计金额： <span>{{v.lcc.Freight+v.lcc.GReceivables+v.lcc.OtherExpenses}}</span></i>
                          {{/if}}
                          {{if v.lcc.freightMode==2}}
                          <i>合计金额： <span>{{v.lcc.GReceivables+v.lcc.OtherExpenses}}</span></i>
                          {{/if}}
                          {{if v.lcc.freightMode==3}}
                          <i>合计金额： <span>{{(v.lcc.GReceivables-v.lcc.Freight)+v.lcc.OtherExpenses}}</span></i>
                          {{/if}}
                          <i class="fz_12 fc_ash">{{v.lch.HistoryTime}}</i>
                      </p>
                  </div>
              </a>
          </li> 
         {{/each}}
         {{else}}
        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
         {{/if}}
    </script>
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
                <input class="gray col_30" type="date" id="startTime">
                <span class="iconfont icon-hengxian"></span>
                <input class="gray col_30" type="date" id="endTime">
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
                        <input name="endline" id="endline" startdata="{{v.UID}}" value="{{v.BindLogisticsUid}}" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right">
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
     <script src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });


        PageInit(function () {
            GetHTML("PaymentDay", {}, function (data) {
                if (CheckHTMLData(data)) {
                    let html = TempToHtml("PaymentDay_list_temp", data);
                    $("#PaymentDay_list").html(html);
                }
            });
            GetHTML("GetPaidCount", { state: 1 }, function (data) {
                if (CheckHTMLData(data)) {
                    let html = TempToHtml("PaidCount_list_temp", data);
                    $("#PaidCount_list").html(html);
                }
            });
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
                        let startline = $('input[name="endline"]:checked').attr("startdata");
                        let endline = $('input[name="endline"]:checked').val();
                        RunSouSuo(startTime, endTime, startline, endline);
                    });
                }
            });
        }
        });
        //进后台
        function RunSouSuo(startTime, endTime, startline, endline) {
            if (startTime == "" && endTime == "") {
                //线路查询
                GetHTML("PaymentDay", {enduid: endline, startuid: startline }, function (data) {
                    if (CheckHTMLData(data)) {
                        let html = TempToHtml("PaymentDay_list_temp", data);
                        $("#PaymentDay_list").html(html);
                    }
                });
            }
            else {
                //日期查询
                var accuracystartTime = startTime + " 00:00:00";
                var accuracyendTime = endTime + " 23:59:59";
                GetHTML("PaymentDay", {starttime: accuracystartTime, endtime: accuracyendTime }, function (data) {
                    if (CheckHTMLData(data)) {
                        let html = TempToHtml("PaymentDay_list_temp", data);
                        $("#PaymentDay_list").html(html);
                    }
                });
            }
        }
        //获取今天日期
        function SelectDate() {
            var myDate = new Date();
            var yue = myDate.getMonth() + 1
            var dqDate = myDate.getFullYear() + "-" + yue + "-" + myDate.getDate();
            var dqDate2 = Format(new Date(Date.parse(dqDate)), "yyyy-MM-dd");
            $("#startTime").val(dqDate2);
            $("#endTime").val(dqDate2);
        }
        //当前时间
        function CurrentDate() {
            var myDate = new Date();
            var yue = myDate.getMonth() + 1
            var dqDate = myDate.getFullYear() + "-" + yue + "-" + myDate.getDate();
            var dqDate2 = Format(new Date(Date.parse(dqDate)), "yyyy-MM-dd");
            $("#endTime").val(dqDate2);
        }
        //获取一周前的日期
        function aweek() {
            debugger;
            var now = new Date();
            var date = new Date(now.getTime() - 7 * 24 * 3600 * 1000);
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var day = date.getDate();
            var AweekDate = year + "-" + month + "-" + day;
            $("#startTime").val(Format(new Date(Date.parse(AweekDate)), "yyyy-MM-dd"));
            var yue = now.getMonth() + 1
            var dqDate = now.getFullYear() + "-" + yue + "-" + now.getDate();
            var dqDate2 = Format(new Date(Date.parse(dqDate)), "yyyy-MM-dd");
            $("#endTime").val(dqDate2);
        }
        //前一个月
        function OneMonth() {
            var nowdate = new Date();
            nowdate.setMonth(nowdate.getMonth() - 1);
            var year = nowdate.getFullYear();
            var month = nowdate.getMonth() + 1;
            var day = nowdate.getDate();
            var AweekDate = year + "-" + month + "-" + day;
            $("#startTime").val(Format(new Date(Date.parse(AweekDate)), "yyyy-MM-dd"));
            CurrentDate();
        }
        //前三个月
        function ThreeMonth() {
            var nowdate = new Date();
            nowdate.setMonth(nowdate.getMonth() - 3);
            var year = nowdate.getFullYear();
            var month = nowdate.getMonth() + 1;
            var day = nowdate.getDate();
            var AweekDate = year + "-" + month + "-" + day;
            $("#startTime").val(Format(new Date(Date.parse(AweekDate)), "yyyy-MM-dd"));
            CurrentDate();
        }
    </script>
</body>
</html>
