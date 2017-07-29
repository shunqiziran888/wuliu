<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_BusinessIndex.aspx.cs" Inherits="Logistics.LC.MenuBar.LC_BusinessIndex" %>

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
                <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-plus pull-right" href="/manage/line_share.html"></a>
                    <i class="add_txt">自主开单</i>
                </p>
                <h1 class="title">物流业务</h1>
            </header>

            <nav class="bar bar-tab">
                <a class="tab-item external active" href="/LC/MenuBar/LC_BusinessIndex.aspx">
                  <span class="icon iconfont icon-filetexto"></span>
                  <span class="tab-label">物流业务</span>
              </a>
                <a class="tab-item external" href="/count/">
                  <span class="icon iconfont icon-fcstubiao19"></span>
                  <span class="tab-label">运营统计</span>
              </a>
                <a class="tab-item external" href="/manage/index.html">
                  <span class="icon iconfont icon-guanli"></span>
                  <span class="tab-label">物流管理</span>
              </a>
                <a class="tab-item external" href="/LC/MenuBar/Personal.aspx">
                  <span class="icon iconfont icon-user-circle"></span>
                  <span class="tab-label">我的</span>
              </a>
            </nav>
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索订单'/>
                </div>
              </div> -->
                    <ul class="zbshangjia-ul">
                        <li class="shangjia-li1">
                            <a href="/LC/Business/ReceiptGood/LC_GoodsReceipt.aspx" class="row external">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-localshipping"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    收货
                                    <span class="prompt_msg" ><%=list.Count%></span>
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li2">
                            <a href="/LC/Business/PretendCar/LC_IndexPC.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-traffic"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    装车
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li3">
                            <a href="/LC/Business/MeetCar/LC_IndexMC.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-beenhere"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    接车
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li4">
                            <a href="/LC/Business/DschargeGood/IndexDhg.aspx" class="row external">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-supervisoraccount"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    放货
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li5">
                            <a href="/LC/Business/PaymentDay/LC_PaymentDay.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-building"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    日结账
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li6">
                             <a href="/LC/Business/CollectDebts/LC_Index.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-money"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    收欠款
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>

                        <li class="shangjia-li7">
                             <a href="/LC/Business/Exception/LC_Index.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-usertimes1"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    异常业务处理
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li8">
                             <a href="/business/huokuanguanli.html"  class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-jpy"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    货款管理
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

  <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
<script type="text/javascript">
    function No()
    {
        alert("功能暂未开放！");
    }
</script>
