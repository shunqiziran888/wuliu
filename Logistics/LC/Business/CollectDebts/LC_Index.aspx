<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Index.aspx.cs" Inherits="Logistics.LC.Business.CollectDebts.LC_Index" %>

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

                <h1 class="title">收欠款</h1>
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
                        
                        <li class="white pad_20 mart_10">
                            <a href="/LC/Business/CollectDebts/LC_CDtDetails.aspx" class="dis_flex ali_center">
                                <div class="col_90">
                                    <p class=" line_he_30 fz_16">
                                        收货人：<span class="fz_14 fc_ash">马大哈</span>
                                    </p>
                                    <p class=" line_he_30 fz_16">
                                        起始日期：<span class="fz_14 fc_ash">2016-01-26----2017 05-20</span>
                                    </p>
                                    <div>
                                        <p class="dis_flex line_he_30 fz_16">
                                            <i class="col_50">
                                                欠款单数：
                                                <span class="fz_14 fc_ash">
                                                    1544单
                                                </span>
                                            </i>
                                            <i class="col_50">
                                                欠运费：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                        </p>
                                        <p class="dis_flex line_he_30 fz_16">
                                            <i class="col_50">
                                                欠代收：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                            <i class="col_50">
                                                欠款总额：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                        </p>
                                    </div>
                                </div>
                                <i class="iconfont col_10">&#xe633;</i>
                            </a>
                        </li>
                        <li class="white pad_20 mart_10">
                            <a href="/LC/Business/CollectDebts/LC_CDtDetails.aspx" class="dis_flex ali_center">
                                <div class="col_90">
                                    <p class=" line_he_30 fz_16">
                                        收货人：<span class="fz_14 fc_ash">马大哈</span>
                                    </p>
                                    <p class=" line_he_30 fz_16">
                                        起始日期：<span class="fz_14 fc_ash">2016-01-26----2017 05-20</span>
                                    </p>
                                    <div>
                                        <p class="dis_flex line_he_30 fz_16">
                                            <i class="col_50">
                                                欠款单数：
                                                <span class="fz_14 fc_ash">
                                                    1544单
                                                </span>
                                            </i>
                                            <i class="col_50">
                                                欠运费：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                        </p>
                                        <p class="dis_flex line_he_30 fz_16">
                                            <i class="col_50">
                                                欠代收：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                            <i class="col_50">
                                                欠款总额：
                                                <span class="fz_14 fc_ash">
                                                    1544
                                                </span>
                                            </i>
                                        </p>
                                    </div>
                                </div>
                                <i class="iconfont col_10">&#xe633;</i>
                            </a>
                        </li>
                    </ul>
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
