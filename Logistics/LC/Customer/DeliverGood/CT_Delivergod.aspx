<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CT_Delivergod.aspx.cs" Inherits="Logistics.LC.Customer.CT_Delivergod" %>
<%@ import Namespace="GlobalBLL" %>
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
            <h1 class="title">我要发货</h1>
          </header>
          
          <div class="content" style="background:#ededed;">
            <div class="page-index">
            <div class="top-btn">
             <a href="/LC/Customer/DeliverGood/CT_DeliverAdd.aspx"><span class="iconfont icon-huoche"></span> 我要发货</a>
            </div>
              <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='输入区域或者电话号码可以快速检索'/>
                </div>
              </div>
              <ul class="dingdan-ul wyfh-ul">
                <p>近期发货列表</p>
                   <%if (list.Count > 0)
        { %>
                   <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                  <li class="dingdan-li">
                    <a href="/LC/Customer/DeliverGood/CT_DeliverAdd.aspx?shr=<%=v.Consignee %>&shrdh=<%=v.SHPhone %>&mbd=<%=v.Destination %>&uffs=<%=v.freightMode %>&wlid=<%=v.logisticsID %>" class="row">
                      <div class="col-90 dingdan-left">
                        <div class="dingdan-top">
                          <div class="dingdan-top1">
                            收货人： <span><%=v.Consignee %></span>
                          </div>
                          <div class="dingdan-top2">
                            收货人电话： <span><%=v.SHPhone %></span>
                          </div>
                        </div>
                        <div class="dingdan-bottom">
                          地址： <span><%=DAL.DAL.DALBase.GetAddressFromID(v.Destination.Value)?.Item2?.Name %></span>
                        </div>
                      </div>
                      <div class="col-10 dingdan-right">
                        <span class="iconfont icon-gengduo"></span>
                      </div>
                    </a>
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
    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>
  </body>
</html>
