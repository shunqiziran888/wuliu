<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Index.aspx.cs" Inherits="Logistics.LC.Business.Exception.Cargo.LC_Index" %>

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
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="index.html" class="icon iconfont icon-zuo pull-left"></a>
                
                <h1 class="title">货损申诉</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                        <li class=" white mart_10" style="padding:.5rem 1.5rem;">
                            <p class=" line_he_30 fz_14">
                                <span class="col_40 txt_right">货物名：</span>
                                <span class="fc_ash">
                                    一大箱可口可乐
                                    <i class="fc_red">x12</i>
                                </span>
                                <span class="fc_green">
                                    (现付)
                                </span>
                            </p>
                            <p class="dis_flex line_he_30 fz_14">
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span>发货人：</span>
                                    <span class="fc_ash">司马相如</span>
                                </i>
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span class="fc_ash">电话：</span>
                                    <span class="fc_ash">18990012991</span>
                                </i>
                            </p>
                            <p class="dis_flex line_he_30 fz_14">
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span>收货人：</span>
                                    <span class="fc_ash">司马相如</span>
                                </i>
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span class="fc_ash">电话：</span>
                                    <span class="fc_ash">18990012991</span>
                                </i>
                            </p>
                            <p class="dis_flex line_he_30 fz_14">
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span>运费：</span>
                                    <span class="fc_ash">11111</span>
                                </i>
                                <i class="col_50 dis_flex" style="justify-content:flex-start;">
                                    <span class="fc_ash">代收款：</span>
                                    <span class="fc_ash">1899</span>
                                </i>
                            </p>
                            <p class="line_he_30 fz_14"><span>目标地：</span><span class="fc_ash"> 临沂费县</span></p>
                            <!-- <p class="dis_flex jus_center"><a class="line_he_30 padlr_30 green fc_white fz_14" href="huosunchuli.html">处理</a></p> -->
                        </li>
                         <div class=" white mart_10"   style="padding:.5rem 1.5rem 1rem;">
                             <p class="line_he_30 fz_16">减免运费金额</p>
                             <p class="dis_flex ali_center">
                                 <span class="col_70"><input class="col_90" type="number"></span>
                                 <span class="col_30 dis_flex jus_center mart_10" >
                                     <a class="line_he_30 padlr_30 green fc_white fz_14" href="huosunchuli.html">确认</a></span>
                            </p>
                         </div>
                         <div class=" white mart_10"   style="padding:.5rem 1.5rem 1rem;">
                             <p class="line_he_30 fz_16">减免运费金额</p>
                             <p class="dis_flex ali_center">
                                 <span class="col_70"><input class="col_90" type="number"></span>
                                 <span class="col_30 dis_flex jus_center mart_10" >
                                     <a class="line_he_30 padlr_30 green fc_white fz_14" href="huosunchuli.html">确认</a></span>
                            </p>
                         </div>
                         <div class=" white mart_10"   style="padding:.5rem 1.5rem 1rem;">
                             <p class="line_he_30 fz_16">减免运费金额</p>
                             <p class="dis_flex ali_center">
                                 <span class="col_70"><input class="col_90" type="number"></span>
                                 <span class="col_30 dis_flex jus_center mart_10" >
                                     <a class="line_he_30 padlr_30 green fc_white fz_14" href="huosunchuli.html">确认</a></span>
                            </p>
                         </div>
                         <p class="dis_flex jus_center white pad_10 mart_10"><a class="line_he_30 padlr_30  red fc_white fz_14" href="huosunchuli.html">拒赔</a></p>
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
    </script>

</body>

</html>
