<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexMC.aspx.cs" Inherits="Logistics.LC.Business.MeetCar.LC_IndexMC" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="System.Linq" %>
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

        .check_box .check_main_left form label {
            margin-bottom: .5rem;
        }

        .check_box .check_main_left form label.active {
            color: #5986de;
        }

        .check_box .check_main_left form label.active input {
            display: block;
        }

        .check_box .check_main_right form label {
            margin-bottom: .5rem;
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
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <h1 class="title">接车</h1>
            </header>


            <div class="content" style="background:#f2f2f2; ">
                <div class="page-index">
                    <!-- <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div> -->
                   
                    <ul id="content_list">
                       <%--数据--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script src="/Style/scripts/all.js"></script>
    <script type="text/html" id="content_list_temp">
         {{if data.Count>0}}
         <li class="white mart_10 padb_10">
            <div  class="dis_flex jus_bet ali_center" style="padding:.5rem;">
                <div>
                    <div>
                        <div class="dis_flex ali_center ">
                            <p class="dis_flex" style="flex-direction: column;line-height:1.5rem;">
                                <strong class="fz_16">{{data.StartSheng}}</strong>
                                <i class="fz_16">{{data.StartShi}}</i>
                                <i class="fz_16">{{data.StartQu}}</i>
                                <i class="fz_14 fc_ash"><span>单数： <span>{{data.Count}}</span></span></i>
                                <i class="fz_14 fc_ash"><span>代收款： <span>{{data.GReceivables}}</span></span></i>
                                <i class="fz_14 fc_ash"><span>大车运费： <span>{{data.largeCar}}</span></span></i>
                                <i class="fz_14 fc_ash"><span>司机电话： <span>{{data.DrivePhone}}</span></span></i>
                            </p>
                            <i class="iconfont " style="font-size:30px;margin:0 .5rem">&#xe6d7;</i>
                            <p class="dis_flex" style="flex-direction: column;line-height:1.5rem;">
                                <strong class="fz_16">{{data.EndSheng}}</strong>
                                <i class="fz_16">{{data.EndShi}}</i>
                                <i class="fz_16">{{data.EndQu}}</i>
                                <i class="fz_14 fc_ash"><span>件数： <span>{{data.number}}</span></span></i>
                                <i class="fz_14 fc_ash"><span>总运费：<span>{{data.Freight}}</span></span></i>
                                <i class="fz_14 fc_ash"><span>车号： <span>{{data.VehicleNo}}</span></span></i>
                            </p>
                        </div>              
                    </div>
                </div>            
            </div>
            <p class="dis_flex txt_center fz_16" style="justify-content:center;margin-bottom:.5rem;"><a class="dis_block" style="height:30px; line-height:30px; width:90px; background-color: #a3c478;color:#fff;" href="/LC/Business/MeetCar/LC_GoodDetails.aspx?CH={{data.VehicleID}}&CFD={{data.Initially}}&MDD={{data.finish}}">接车</a></p>
            <p class="txt_center fz_12" style="padding-right:.5rem;">{{data.TruckTime}}</p>
        </li>
        {{else}}
        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
        {{/if}}
    </script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
        PageInit(function () {
            GetHTML("GetMeetCarList", {}, function (data) {
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

