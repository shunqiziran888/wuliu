<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexPC.aspx.cs" Inherits="Logistics.LC.Business.PretendCar.LC_IndexPC" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流公司商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
    .wyfh-ul .dingdan-li .dingdan-right {
        margin-top: 0rem;
    }
    
    .dingdan-ul .dingdan-li {
        height: 50px;
        line-height: 50px;
        padding: 0 1rem;
    }
    
    .top-btn {
        padding: .5rem 2rem;
    }
    
    .top-btn a {
        height: 2.5rem;
        line-height: 2.5rem;
    }
    
    .top-btn a span {
        font-size: .7rem;
        margin-right: .2rem;
    }
    .wyfh-ul {
    padding-top: .5rem;
}
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Index/LC_IndexYW.aspx"></a>
                <h1 class="title">装车</h1>
            </header>
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <!-- <div class="top-btn">
                        <a href="newxianlu.html"><span class="iconfont icon-jiahao"></span> 新增线路</a>
                    </div> -->
                    <!-- <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='输入区域或者电话号码可以快速检索'/>
                </div>
              </div> -->
                    <ul class="dingdan-ul wyfh-ul">
                        <!-- <p>近期发货列表</p> -->
                        <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                        <li class="dingdan-li">
                            <a href="/LC/Business/PretendCar/LC_Commodity.aspx?Initially=<%=v.Start %>&Destination=<%=v.End %>&StartCityName=<%=v.StartCityName %>&EndCityName=<%=v.EndCityName %>" class="row">
                                <div class="col-10 dingdan-right">
                                    <span class="iconfont icon-handoright"></span>
                                </div>
                                <div class="col-80 dingdan-left">
                                    <%=v.StartCityName%>---------------------------------
                                     <%=v.EndCityName%>
                                </div>
                                <div class="col-10 dingdan-right">
                                    <span class="iconfont icon-gengduo"></span>
                                </div>
                            </a>
                        </li>
                        <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>
    <script type="text/javascript">
        $(function() { $.init(); $.config = { router: false } });
        </script>
</body>

</html>