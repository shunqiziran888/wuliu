<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexYW.aspx.cs" Inherits="Logistics.LC.Index.LC_IndexYW" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流公司业务</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        .shangjia-ul {
            padding: 1rem 1rem;
        }
        
        .shangjia-ul li {
            height: 2.5rem;
            line-height: 2.5rem;
        }
        
        .shangjia-ul .shangjia-li3 .shangjia-left span {
            color: #673ab7;
        }
        
        .shangjia-ul .shangjia-li4 .shangjia-left span {
            color: #259b24;
        }
        
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Index/LC_Index.aspx"></a>
                <h1 class="title">首页</h1>
            </header>

            <!-- <nav class="bar bar-tab">
              <a class="tab-item external active" href="shangjia.html">
                  <span class="icon iconfont icon-shouye"></span>
                  <span class="tab-label">首页</span>
              </a>
              <a class="tab-item external" href="sjdingdan.html">
                  <span class="icon iconfont icon-tty"></span>
                  <span class="tab-label">订单</span>
              </a>
              <a class="tab-item external" href="sjwode.html">
                  <span class="icon iconfont icon-user"></span>
                  <span class="tab-label">我的</span>
              </a>
          </nav> -->
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索订单'/>
                </div>
              </div> -->
                    <ul class="shangjia-ul">
                        <li class="shangjia-li1">
                            <a href="/LC/Business/ReceiptGood/LC_GoodsReceipt.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont icon-huoche"></span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    收货
                                </div>
                                <div class="col-20 shangjia-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <li class="shangjia-li2">
                            <a href="/LC/Business/PretendCar/LC_IndexPC.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont ">&#xeb55;</span>
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
                                    <span class="iconfont">&#xe646;</span>
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
                            <a href="/LC/Business/DschargeGood/IndexDhg.aspx" class="row">
                                <div class="col-30 shangjia-left">
                                    <span class="iconfont ">&#xe67e;</span>
                                </div>
                                <div class="col-50 shangjia-center">
                                    放货
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
        $(function() {
            $.init();
            $.config = {
                router: false
            }
        });
    </script>

</body>

</html>
