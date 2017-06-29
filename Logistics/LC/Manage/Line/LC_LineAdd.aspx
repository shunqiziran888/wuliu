<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_LineAdd.aspx.cs" Inherits="Logistics.LC.Line.LC_LineAdd" %>

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
                    <a class="icon icon-left pull-left external" href="/LC/Manage/Line/LC_Line.aspx"></a>
                    <h1 class="title">物流管理系统</h1>
                </header>
                <div class="content" style="background: #ededed;">
                    <div class="page-index">
                        <!-- <div class="top-btn">
                        <a href="newxianlu.html"><span class="iconfont icon-jiahao"></span> 新增线路</a>
                    </div> -->
                       <ul class="xiangqing">
                        <li><span>终点站:</span>省
                            <select id="End1" name="End1" onchange="show(this.value,'End2');">
                                <option>请选择</option>
                                <%
                                    foreach (var p in shengList)
                                    {
                                     %>
                                <option value="<%=p.id %>"><%=p.Name %></option>
                                <%
                                    } %>
                            </select> 
                            </li>
                            <li>
                            市<select id="End2" name="End2" onchange="show(this.value,'End');">
                                <option>请选择</option>
                             </select> 
                            </li>
                            <li>
                            区 <select id="End" name="End">
                                <option>请选择</option>
                              </select> 
                        </li>
                        <li><span>联系电话:</span><span class="tinput"><input type="text" name="Phone" id="Phone" placeholder="联系电话"> </span></li>
                        <li style="padding: 0 1.5rem;">
                            <input type="submit" name="" value="新增加" class="button button-fill button-success" '>
                        </li>
                    </ul>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
<script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#selectBtn').on('click', function () {
            $.areaSelect();
        })

    })

    function show(id, elename)
    {
        GetHtml("/Command/GetAddressNextList.aspx", { id: id }, function (data) {
            let list = JSON.parse(data);
            $("#" + elename).empty();
            for(let i=0;i<list.length;i++)
            {
                $("#" + elename).append("<option value='"+list[i].id+"'>"+list[i].Name+"</option>");
            }
        });
    }

</script>