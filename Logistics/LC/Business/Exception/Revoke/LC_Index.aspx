<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Index.aspx.cs" Inherits="Logistics.LC.Business.Exception.Revoke.LC_Index" %>

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
        input[type="checkbox" i] {
            -webkit-appearance: checkbox;
            box-sizing: border-box;
        }

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
                <a href="index.html" class="icon iconfont icon-zuo pull-left"></a>
                <a href="/LC/Business/Exception/Revoke/LC_Cancel.aspx" class="icon pull-right dis_inline red" style="color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">确认取消</a>
                <h1 class="title">发货撤销</h1>
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


                        <div class="check_tab_nav jus_bet dis_flex ali_center ">
                            <div class="check_left col_40 txt_right row_44 li_row_44">
                                <span>一周</span>
                                <span class="iconfont fz_18" style="color: #7d7d7d;">&#xe637;</span>
                            </div>
                            <div class="check_right col_40 txt_left row_44 li_row_44">
                                <span>线路</span>
                                <span class="iconfont fz_18" style="color: #7d7d7d;">&#xe637;</span>
                            </div>
                        </div>



                        <div class="check_main check_main_left pos_a col_100 white bor_top  dis_none" style="top:2.2rem; z-index:2;">
                            <form class="bor_bottom" style="padding:1rem; margin: 0 .3rem;">
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    今天
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                 </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40 active">
                                    最近一周
                                    <input name="time" type="radio" class="col_50 bor_none  dis_none txt_right iconfont icon-right"/> 
                                </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    最近一月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    最近三月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                </label>
                            </form>
                            <div class="dis_flex jus_aro bor_bottom" style="padding:.5rem;">
                                <input class="gray col_30" type="date" placeholder="2017.07.12" value="2017-07-21">
                                <span class="iconfont icon-hengxian"></span>
                                <input class="gray col_30" type="date" placeholder="2017.07.12" value="2017-08-31">
                                <input class="close_btn  col_25" type="button" style="color:#5986de; border:1px solid #5986de;padding: 0;" value="确定">
                            </div>
                        </div>



                        <div class="check_main check_main_right pos_a col_100 white bor_top dis_none" style="top:2.2rem; z-index:2;">
                            <ul>
                                <form class="bor_bottom" style="padding:1rem 0; margin: 0 .3rem;">
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/> 
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40 active">
                                        山东淄博---------河北邯郸
                                        <input name="city" type="radio" class="bor_none col_30  dis_none txt_right iconfont icon-right"/> 
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸 
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/>
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸 
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/>
                                    </label>
                                </form>
                            </ul>
                            <div class="dis_flex bor_bottom" style="padding:.5rem;justify-content: flex-end;">
                                <input class="close_btn col_25" type="button" style="color:#5986de; border:1px solid #5986de;padding: 0;" value="确定">
                            </div>
                        </div>



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

                        <li class="zbsh-li dis_flex ali_center">
                            <i  class="col_10"><input class="col_40" type="checkbox"></i>
                            <a href="#">
                                <div class="col-90">
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">货物名： <span class="huo_name fc_ash fz_14">一大箱可口可乐 <i class="huo_num">x12</i></span>
                                    <span class="huo_fnagshi">(现付)</span></p>
                                    </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14">司马相如</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14">包大人</span></p>
                                  
                                </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">运费： <span class="ft_color_ash fz_14">3010</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14">1899</span></p>
                                  
                                </i>
                                    <p class="fz_16 dis_flex jus_bet ali_center fc_red"><i>合计金额： <span>123</span></i><i class="fz_12 fc_ash">2016年-12月-23日 09：21</i></p>
                                </div>

                            </a>

                        </li>
                         <li class="zbsh-li dis_flex ali_center">
                            <i  class="col_10"><input class="col_40" type="checkbox"></i>
                            <a href="#">
                                <div class="col-90">
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">货物名： <span class="huo_name fc_ash fz_14">一大箱可口可乐 <i class="huo_num">x12</i></span>
                                    <span class="huo_fnagshi">(现付)</span></p>
                                    </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14">司马相如</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14">包大人</span></p>
                                  
                                </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">运费： <span class="ft_color_ash fz_14">3010</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14">1899</span></p>
                                  
                                </i>
                                    <p class="fz_16 dis_flex jus_bet ali_center fc_red"><i>合计金额： <span>123</span></i><i class="fz_12 fc_ash">2016年-12月-23日 09：21</i></p>
                                </div>

                            </a>

                        </li>
                         <li class="zbsh-li dis_flex ali_center">
                            <i  class="col_10"><input class="col_40" type="checkbox"></i>
                            <a href="#">
                                <div class="col-90">
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">货物名： <span class="huo_name fc_ash fz_14">一大箱可口可乐 <i class="huo_num">x12</i></span>
                                    <span class="huo_fnagshi">(现付)</span></p>
                                    </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14">司马相如</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14">包大人</span></p>
                                  
                                </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">运费： <span class="ft_color_ash fz_14">3010</span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14">1899</span></p>
                                  
                                </i>
                                    <p class="fz_16 dis_flex jus_bet ali_center fc_red"><i>合计金额： <span>123</span></i><i class="fz_12 fc_ash">2016年-12月-23日 09：21</i></p>
                                </div>

                            </a>

                        </li>

                    </ul>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
     <script src="/Style/scripts/main.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>