<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Success.aspx.cs" Inherits="Logistics.LC.Business.GoodPayment.Paid.LC_Success" %>

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
                <a href="javascript:;" onclick="window.history.go(-1)"  class="icon iconfont icon-zuo pull-left"></a>
                
                <h1 class="title">收款成功</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="txt_center white" style="padding:1rem;margin-top:1rem;">
                        <p> 
                            <i class="iconfont fc_green" style="font-size:55px;">&#xe67b; </i>
                        </p>
                        <p>
                            收款成功
                        </p>
                        <p>
                            收款金额： 
                            <span>
                                ￥1213
                            </span>
                        </p>
                        <p class="fz_12 txt_right mart_20">
                            收款日期： 
                            <span>2017-07-20 00：57</span>
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
        setInterval(function(){
            window.history.go(-1);
        },2000)
    </script>

</body>

</html>
