<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_CT_Personal.aspx.cs" Inherits="Logistics.LC.Customer.Other.CT_Personal.LC_CT_Personal" %>

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
    <style type="text/css" media="screen">
      .wode-main li.wode-li1 a.row .wode-left{
        padding-left: 1rem;
      }
    </style>
  </head>
  <body>
    <div class="page-group">
        <div class="page page-current">
        <!-- 你的html代码 -->
         
          <nav class="bar bar-tab">
              <a class="tab-item external" href="/LC/Index/LC_IndexKH.aspx">
                  <span class="icon iconfont icon-shouye"></span>
                  <span class="tab-label">首页</span>
              </a>
              <a class="tab-item external" href="/LC/Customer/Other/CT_Order/Index_CT_Order.aspx">
                  <span class="icon iconfont icon-tty"></span>
                  <span class="tab-label">订单</span>
              </a>
              <a class="tab-item external active" href="/LC/Customer/Other/CT_Personal/LC_CT_Personal.aspx">
                  <span class="icon iconfont icon-user"></span>
                  <span class="tab-label">我的</span>
              </a>
          </nav>
          <div class="content" style="background:#ededed;">
            <div class="page-index">
              <div class="wode-header">
                <p class="wode-header1"><img src="/Style/img/user-img.jpg" alt=""></p>
                <p class="wode-header2">陈煜彬</p>
              </div>
              <ul class="wode-main">
                  <li class="wode-li1">
                    <a href="#" class="row">
                      <div class="col-20 wode-left">
                        <span class="iconfont icon-dollar"></span>
                      </div>
                      <div class="col-60 wode-center">
                        余额
                      </div>
                      <div class="col-20 wode-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
                  </li>
                  <li class="wode-li1">
                    <a href="#" class="row">
                      <div class="col-20 wode-left">
                        <span class="iconfont icon-users"></span>
                      </div>
                      <div class="col-60 wode-center">
                        客户管理
                      </div>
                      <div class="col-20 wode-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
                  </li>
                  <li class="wode-li1">
                    <a href="#" class="row">
                      <div class="col-20 wode-left">
                        <span class="iconfont icon-exchange"></span>
                      </div>
                      <div class="col-60 wode-center">
                        供应商管理
                      </div>
                      <div class="col-20 wode-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
                  </li>
                  <li class="wode-li1">
                    <a href="#" class="row">
                      <div class="col-20 wode-left">
                        <span class="iconfont icon-calculator"></span>
                      </div>
                      <div class="col-60 wode-center">
                        结算明细
                      </div>
                      <div class="col-20 wode-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
                  </li>
                  <li class="wode-li1">
                    <a href="#" class="row">
                      <div class="col-20 wode-left">
                        <span class="iconfont icon-gears"></span>
                      </div>
                      <div class="col-60 wode-center">
                        个人信息设置
                      </div>
                      <div class="col-20 wode-right">
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
        $.config = {router: false}
    });
</script>

  </body>
</html>
