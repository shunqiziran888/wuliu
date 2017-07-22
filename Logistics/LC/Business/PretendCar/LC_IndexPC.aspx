<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexPC.aspx.cs" Inherits="Logistics.LC.Business.PretendCar.LC_IndexPC" %>
<%@ Import Namespace="SuperDataBase" %>
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
                <h1 class="title">装车</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                   
                    <ul>
                         <%
                             foreach(var v in list)
                             {
                                 Model.Model.LC_Line line = v.GetDicVO<Model.Model.LC_Line>();
                                 Model.Model.LC_User user = v.GetDicVO<Model.Model.LC_User>();
                                 var addressvoStart = DAL.DAL.DALBase.GetAllAddress(line.Start.Value);
                                 var addressvoEnd = DAL.DAL.DALBase.GetAllAddress(line.End.Value);
                                     %>
                        <li class="white mart_10">
                            <a href="/LC/Business/PretendCar/LC_Commodity.aspx?Initially=<%=line.Start %>&Destination=<%=line.End %>"  class="dis_flex jus_bet ali_center" style="padding:.5rem;">
                                <div>
                                    <div>
                                        <div class="dis_flex ali_center ">
                                            <p class="dis_flex" style="flex-direction: column;line-height:1.5rem;">
                                                <strong class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoStart.Item1.Value)?.Item2?.Name%></strong>
                                                <i class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoStart.Item2.Value)?.Item2?.Name%></i>
                                                <i class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoStart.Item3.Value)?.Item2?.Name%></i>
                                            </p>
                                            <i class="iconfont " style="font-size:30px;margin:0 .5rem">&#xe6d7;</i>
                                            <p class="dis_flex" style="flex-direction: column;line-height:1.5rem;">
                                                <strong class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoEnd.Item1.Value)?.Item2?.Name%></strong>
                                                <i class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoEnd.Item2.Value)?.Item2?.Name%></i>
                                                <i class="fz_16"><%=DAL.DAL.DALBase.GetAddressFromID(addressvoEnd.Item3.Value)?.Item2?.Name%></i>
                                            </p>
                                        </div>
                                        <div style="line-height:1.5rem;margin-top:.5rem;">
                                            <p class="fz_14 fc_ash">收货： <span>23单</span> <span>计289件</span></p>
                                            <p class="fz_14 fc_ash"><i>运费： <span>2523元</span></i><i>代收运费： <span>1523元</span></i></p>
                                        </div>
                                    </div>
                                </div>
                                <i class="iconfont"> &#xe633;</i>
                            </a>
                            <p class="txt_right fz_12" style="padding-right:.5rem;">2016年-12月-23日 09：31</p>
                        </li>
                        <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
<%--    <script type="text/javascript" src="js/main.js" charset='utf-8'></script>--%>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>