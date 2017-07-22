<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_AccreditYes.aspx.cs" Inherits="Logistics.LC.Manage.Accredit.LC_AccreditEdit" %>

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
            <h1 class="title">审核成功</h1>
          </header>
          
          <div class="content" style="background:#ededed;">
            <div class="page-index">
              <div class="cgfh-main">
                <div class="cgfh-top row">
                  <div class="col-30">
                    <span class="iconfont icon-checksquare"></span>
                  </div>
                  <div class="col-70">
                    <p><span>已同意</span></p>
                  </div>
                </div>
                <a href="/LC/Manage/Accredit/LC_Accredit.aspx">我知道了</a>
              </div>
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
