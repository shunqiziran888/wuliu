<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexCt.aspx.cs" Inherits="Logistics.LC.Customer.Contact.LC_IndexCt" %>

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
            <a class="icon icon-left pull-left external" href="/LC/Index/LC_IndexKH.aspx"></a>
            <h1 class="title">联系物流</h1>
          </header>
          
          <div class="content" style="background:#ededed;">
            <div class="page-index">
            <div class="top-btn">
             <a href="/LC/Customer/Contact/LC_AddCt.aspx">新建物流联系人</a>
            </div>
              <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索订单'/>
                </div>
              </div>
              <ul class="dingdan-ul wyfh-ul">
                <p>常用物流</p>
                  <li class="dingdan-li">
                    <a href="#" class="row">
                      <div class="col-90 dingdan-left">
                      <div class="dingdan-bottom">
                          物流名称： <span>联众物流</span>
                        </div>
                        <div class="dingdan-top">
                          <div class="dingdan-top1">
                            物流负责人： <span>陈煜彬</span>
                          </div>
                          <div class="dingdan-top2">
                            电话： <span>13231112342</span>
                          </div>
                        </div>
                        <div class="dingdan-bottom">
                          地址： <span>河北省邯郸市魏县大坝子村</span>
                        </div>
                      </div>
                      <div class="col-10 dingdan-right lxwl-right">
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