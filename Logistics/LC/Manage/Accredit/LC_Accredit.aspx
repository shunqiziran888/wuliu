<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Accredit.aspx.cs" Inherits="Logistics.LC.Manage.Accredit.LC_Accredit" %>

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
    <style>
        i.iconfont.icon-shanchu {
            font-size: .9rem;
        }
        
        .tabs {
            padding-top: 10px;
        }
        
        .buttons-tab {
            height: 2.6rem;
            padding: 0;
        }
        
        .row .col-10 {
            width: 10%;
            margin-left: 0;
        }
        
        .row .col-20 {
            width: 20%;
            margin-left: 0;
        }
        
        .row .col-30 {
            width: 30%;
            margin-left: 0;
        }
        
        .td-header {
            margin-left: 0;
        }
        
        .td-header span,
        .td-body span {
            text-align: center;
            font-size: 10px;
        }
        
        .td-body .shenhe_btn {
            display: flex;
            flex-direction: column;
        }
        
        .td-body .shenhe_btn .shenhe_ok {
            background: #9ccc65;
            color: #fff;
            padding: 2.5px 0;
        }
        
        .td-body .shenhe_btn .shenhe_no {
            background: #f00;
            color: #fff;
            padding: 2.5px 0;
        }
        
        .td-body {
            margin-left: 0;
            display: flex;
            align-items: center;
            margin: 10px 2px;
            border: 1px solid #f0f0f0;
            border-radius: 6px;
            background: #f0f0f0;
        }
        
        #tab1 .td-body {
            padding: 10px 0;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Index/LC_IndexGL.aspx"></a>
                <h1 class="title">授权管理</h1>
            </header>


            <div class="content" style="background:#fff;">
                <div class="page-index">
                    <div class="buttons-tab">
                        <a href="#tab1" class="tab-link active button"><span>公司成员</span></a>
                        <a href="#tab2" class="tab-link button"><span>待审核名单</span></a>
                    </div>
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <ul class="xiangqing">
                                     <%if (list2.Count > 0)
        { %>
                                    <li class="row td-header">
                                        <span class="col-20">姓名</span>
                                        <span class="col-30">电话</span>
                                        <!--<span class="col-20">日期</span>-->
                                        <span class="col-30">权限</span>
                                        <span class="col-20"><i>编辑</i></span>
                                    </li>
                                      <%
                                    foreach(var v1 in list2)
                                    {
                                        
                                     %>
                                    <li class="row td-body">
                                        <span class="col-20"><%=v1.UserName %></span>
                                        <span class="col-30"><%=v1.Phone %></span>
                                        <!--<span class="col-20">17年11月22日</span>-->
                                        <span class="col-30">管理员</span>
                                        <span class="col-20"><i class="iconfont icon-shanchu"></i></span>
                                    </li>
                                     <%} %>
                                      <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
                                </ul>
                            </div>
                            <div id="tab2" class="tab">
                                <ul class="xiangqing">
                                     <%if (list.Count > 0)
        { %>
                                    <li class="row td-header">
                                        <span class="col-20">姓名</span>
                                        <span class="col-30">电话</span>
                                        <!--<span class="col-20">日期</span>-->
                                        <span class="col-30">权限</span>
                                        <span class="col-20"><i>审核</i></span>
                                    </li>
                                     <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                                    <li class="row td-body">
                                        <span class="col-20"><%=v.UserName %></span>
                                        <span class="col-30"><%=v.Phone %></span>
                                        <!--<span class="col-20">17年11月22日</span>-->
                                        <span class="col-30">管理员</span>
                                        <span class="col-20 shenhe_btn">
                                            <a href="/LC/Manage/Accredit/LC_AccreditYes.aspx?UID=<%=v.UID %>" class="shenhe_ok">同意</a>
                                            <a href="/LC/Manage/Accredit/LC_AccreditNo.aspx?UID=<%=v.UID %>" class="shenhe_no">拒绝</a>
                                        </span>
                                    </li>
                                     <%} %>
                                    <%}
        else
        {%>
    <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
    <%} %>
                                </ul>
                            </div>

                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>

   <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

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
