<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_CtDetails.aspx.cs" Inherits="Logistics.LC.Customer.Contact.LC_CtDetails" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流客户端</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
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
                <a href="/LC/Customer/Contact/LC_IndexCt.aspx" class="icon iconfont icon-zuo pull-left"></a>
                
                <h1 class="title"> 物流公司详情</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                   <p class="txt_center white fz_16 line_he_44 mart_10" style="border-bottom:1px solid #bbb;">物流名称：金帝物流</p>
                    <div class="white pad_20" style="border-bottom:1px solid #bbb;">
                        <p class="fz_14 line_he_30 dis_flex ali_center">
                            <span>开通线路：</span>
                            <span>本地<i class="iconfont icon-exchange1 marlr_20"></i>山东省-临沂市-兰区</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流名称：</span>
                            <span>金帝物流</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流电话：</span>
                            <span>12345678901</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流地址：</span>
                            <span>光明大道255号院内</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通线路：</span>
                            <span>15条</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通时间：</span>
                            <span>2017年9月8日</span>
                        </p>
                    </div>
                    <div class="white pad_20" style="border-bottom:1px solid #bbb;">
                        <p class="fz_14 line_he_30 dis_flex ali_center">
                            <span>开通线路：</span>
                            <span>本地<i class="iconfont icon-exchange1 marlr_20"></i>山东省-临沂市-兰区</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流名称：</span>
                            <span>金帝物流</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流电话：</span>
                            <span>12345678901</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流地址：</span>
                            <span>光明大道255号院内</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通线路：</span>
                            <span>15条</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通时间：</span>
                            <span>2017年9月8日</span>
                        </p>
                    </div>
                    <div class="white pad_20"  style="border-bottom:1px solid #bbb;">
                        <p class="fz_14 line_he_30 dis_flex ali_center">
                            <span>开通线路：</span>
                            <span>本地<i class="iconfont icon-exchange1 marlr_20"></i>山东省-临沂市-兰区</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流名称：</span>
                            <span>金帝物流</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流电话：</span>
                            <span>12345678901</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>物流地址：</span>
                            <span>光明大道255号院内</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通线路：</span>
                            <span>15条</span>
                        </p>
                        <p class="fz_14 line_he_30">
                            <span>开通时间：</span>
                            <span>2017年9月8日</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
            $('.qianshou_btn').click(function(){
                $('.btn_zu').show();
            })
        });
    </script>

</body>

</html>