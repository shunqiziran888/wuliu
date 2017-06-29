<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_VehicleAdd.aspx.cs" Inherits="Logistics.LC.Manage.Vehicle.LC_VehicleAdd" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <link rel="stylesheet" href="/Style/css/SG_area_select.css">
    <script type="text/javascript" src="/Style/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Style/scripts/iscroll.js"></script>   
    <script type="text/javascript" src="/Style/scripts/SG_area_select.js"></script>
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
        margin: 1rem;
        background: #fff;
        border-radius: 10px;
        padding: .5rem 1rem;
        border: 1px solid #bbb;
    }
    
    .xiangqing li {
        font-size: .7rem;
        margin-bottom: .5rem;
        padding-left: .5rem;
        display: flex;
        justify-content: space-between;
        line-height: 40px;
        height: 40px;
    }
    
    .xiangqing li .tinput {
        width: 70%;
    }
    .code {
            padding: 2px 4px;
            font-size: 14px;
            color: #c7254e;
            background-color: #f9f2f4;
            border-radius: 4px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" method="post" action="?">
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Manage/Vehicle/LC_Vehicle.aspx"></a>
                <h1 class="title">物流管理系统</h1>
            </header>
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <ul class="xiangqing">
                        <li><span>车牌号:</span><span class="tinput"><input type="text" name="VehicleNo"  placeholder="车牌号">  </span></li>
                        <li><span>司机:</span><span class="tinput"><input type="text" name="Driver"  placeholder="司机"> </span></li>
                        <li style="padding: 0 1.5rem;">
                            <input type="submit" name="" value="新增加" class="button button-fill button-success">
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type='text/javascript' src='all.js' charset='utf-8'></script>
    <script>  
    $(function() { $.init(); $.config = { router: false } }); 
    function Msg(){ $.toast('操作成功，正在跳转...', 1000, 'success top'); window.onlocation.href=''}
    </script>
        </form>
</body>

</html>

