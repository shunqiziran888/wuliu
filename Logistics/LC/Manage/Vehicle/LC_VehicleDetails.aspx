<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_VehicleDetails.aspx.cs" Inherits="Logistics.LC.Manage.Vehicle.LC_VehicleDetails" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
            <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>
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
    .xiangqing {
        margin: .5rem;
    background: #fff;
    border-radius: 10px;
    padding: .5rem;
    border: 1px solid #bbb;
    }
    .xiangqing li{
        font-size: .8rem;
    margin-bottom: .5rem;
    padding-left: .5rem;
    }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Manage/Vehicle/LC_Vehicle.aspx"></a>
                <h1 class="title">物流管理系统</h1>
            </header>
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <div class="top-btn">
                        <a href="/LC/Manage/Line/LC_LineAdd.aspx"><span class="iconfont icon-jiahao " ></span> 新增车辆</a>
                    </div>
                    <ul class="xiangqing">
                        <%
                            foreach (var v in list)
                            {
                                     %>
                        <li><span>车牌号:</span><span><%=v.VehicleNo %></span></li>
                        <li><span>司机:</span><span><%=v.Driver%></span></li>
                        <li><span>创建时间:</span><span><%=v.CreateTime %></span></li>
                          <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

