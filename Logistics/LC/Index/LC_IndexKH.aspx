<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexKH.aspx.cs" Inherits="Logistics.LC.Index.LC_IndexKH" %>

<!DOCTYPE html>

<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    
  </head>
  <body>
    <div class="page-group">
        <div class="page page-current">
        <!-- 你的html代码 -->
         <header class="bar bar-nav">
            <h1 class="title">首页</h1>
          </header>
          
          <nav class="bar bar-tab">
              <a class="tab-item external active" href="/LC/Index/LC_IndexKH.aspx">
                  <span class="icon iconfont icon-shouye"></span>
                  <span class="tab-label">首页</span>
              </a>
              <a class="tab-item external" href="/LC/Customer/Other/CT_Order/Index_CT_Order.aspx">
                  <span class="icon iconfont icon-tty"></span>
                  <span class="tab-label">订单</span>
              </a>
              <a class="tab-item external" href="/LC/Customer/Other/CT_Personal/LC_CT_Personal.aspx">
                  <span class="icon iconfont icon-user"></span>
                  <span class="tab-label">我的</span>
              </a>
          </nav>
          <div class="content" style="background:#ededed;">
            <div class="page-index">
              <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索订单'/>
                </div>
              </div>
              <ul class="shangjia-ul">
                  <li class="shangjia-li1">
                    <a href="/LC/Customer/DeliverGood/CT_Delivergod.aspx"  class="row">
                      <div class="col-30 shangjia-left">
                        <span class="iconfont icon-huoche"></span>
                      </div>
                      <div class="col-50 shangjia-center">
                        我要发货
                      </div>
                      <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
                  </li>
                  <li class="shangjia-li2">
                    <a href="/LC/Customer/TrackGood/LC_IndexTK.aspx"  class="row">
                      <div class="col-30 shangjia-left">
                        <span class="iconfont icon-rss"></span>
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
                    <a href="/LC/Customer/SignGood/LC_IndexSG.aspx"  class="row">
                      <div class="col-30 shangjia-left">
                        <span class="iconfont icon-xiaolian"></span>
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
                    <a href="/LC/Customer/Contact/LC_IndexCt.aspx"  class="row">
                      <div class="col-30 shangjia-left">
                        <span class="iconfont icon-phonesquare"></span>
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
    
     <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

<script>
    $(function() {
        $.init();
        $.config = {router: false}
    });
</script>

  </body>
</html>
