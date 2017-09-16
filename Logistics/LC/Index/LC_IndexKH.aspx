<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexKH.aspx.cs" Inherits="Logistics.LC.Index.LC_IndexKH" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流客户端</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
        .prompt_msg {
            position: absolute;
            width: 22px;
            height: 22px;
            background: #f00;
            border-radius: 20px;
            color: #fff;
            line-height: 22px;
            top: 50%;
            left: 62%;
            margin-top: -11px;
            font-size: 10px;
            text-align: center;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <!-- <p class="add_wuliu" onclick="window.location.href='shouhuokaidan.html'">
                    <a class="add_icon icon iconfont icon-kaidan pull-right" style="font-size:1rem;" href="javascript:;"></a>
                    <i class="add_txt">自主开单</i>
                </p> -->
                <h1 class="title">物流客户端</h1>
            </header>

            <nav class="bar bar-tab">
                <a class="tab-item external active" href="/LC/Index/LC_IndexKH.aspx">
                  <span class="icon iconfont icon-shouye"></span>
                  <span class="tab-label">首页</span>
              </a>
               
                <a class="tab-item external" href="/LC/Customer/Other/CT_Personal/LC_CT_Personal.aspx">
                  <span class="icon iconfont icon-user"></span>
                  <span class="tab-label">我的</span>
              </a>
            </nav>
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    
                    <ul class="zbshangjia-ul">
                        <li class="shangjia-li1">
                            <a href="/LC/Customer/DeliverGood/CT_Delivergod.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-localshipping"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    我要发货
                                    <!-- <span class="prompt_msg" >150</span> -->
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li2">
                            <a href="/LC/Customer/TrackGood/LC_IndexTK.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-traffic"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    货物追踪
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li3">
                            <a href="/LC/Customer/SignGood/LC_IndexSG.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-beenhere"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    货物签收
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li4">
                            <a href="/LC/Customer/Contact/LC_IndexCt.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-supervisoraccount"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                   联系物流
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js"></script>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
<script type="text/javascript">
    function phonechange(element)
    {
        var OrderNo = $(element).val();
        if (OrderNo.length == 19)
        {
            window.location.href = "/LC/Customer/Other/CT_Order/Index_CT_Order.aspx?OrderNo=" + OrderNo;
        }
    }
</script>