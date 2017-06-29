<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexGL.aspx.cs" Inherits="Logistics.LC.LC_IndexGL" %>

<!DOCTYPE html>

<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/Style/favicon.ico">
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
            <a class="icon icon-left pull-left" href="/LC/Index/LC_Index.aspx"></a>
            <h1 class="title">首页</h1>
          </header>
          
          
          <div class="content" style="background:#ededed;">
            <div class="page-index">
             
              <ul class="zbshangjia-ul">
                  <li class="shangjia-li1">
                    <a href="/LC/Manage/Line/LC_Line.aspx"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-bus"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        线路管理
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                  <li class="shangjia-li2">
                    <a href="/LC/Manage/Accredit/LC_Accredit.aspx"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-globe"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        授权管理
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                   <li class="shangjia-li2">
                    <a href="/LC/Manage/Vehicle/LC_Vehicle.aspx"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-globe"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        车辆管理
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                  <li class="shangjia-li3">
                    <a href="yygaikuang.html"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-huoche"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        运营概况
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                  <li class="shangjia-li4">
                    <a href="cwgaikuang.html"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-balancescale"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        财务概况
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                  <li class="shangjia-li5">
                    <a href="fgsyygaikuang.html"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-cny"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        分公司运营概况
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
                    </a>
                  </li>
                  <li class="shangjia-li6">
                    <a href="kehugaikuang.html"  class="row">
                      <!-- <div class="col-30 shangjia-left">
                        <span class="iconfont icon-fax"></span>
                      </div> -->
                      <div class="col-100 shangjia-center">
                        客户概况
                      </div>
                      <!-- <div class="col-20 shangjia-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div> -->
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