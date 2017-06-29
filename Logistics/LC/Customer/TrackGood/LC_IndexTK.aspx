<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexTK.aspx.cs" Inherits="Logistics.LC.Customer.TrackGood.LC_IndexTK" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>



<!DOCTYPE html>

<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
      .zbsh-tab1 .zbsh-li a .col-90{
            padding: 0 .5rem;
      }
      .zbsh-tab1 .zbsh-li a .col-10{
        margin-top: .5rem;
      }
      .zbsh-tab1 .zbsh-li a .col-90 .zbsh-xd1{
            display: flex;
    justify-content: space-between;
      }
    </style>
  </head>
  <body>
    <div class="page-group">
        <div class="page page-current">
        <!-- 你的html代码 -->
         <header class="bar bar-nav">
            <a class="icon icon-left pull-left" href="/LC/Index/LC_IndexKH.aspx"></a>
            <h1 class="title">货物追踪</h1>
          </header>
          
          
          <div class="content" style="background:#ededed;">
            <div class="page-index">
            <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                  <input type="search" id='search' placeholder='搜索货号或者姓名'/>
                </div>
              </div>
              <div class="buttons-tab">
                <a href="#tab1" onclick="fachu(0)" class="tab-link button <%=GetValue<int>("vau")==0 ? " active" : string.Empty %>"><span>接收货物</span></a>
                <a href="#tab2" onclick="fachu(1)" class="tab-link button <%=GetValue<int>("vau")==1 ? " active" : string.Empty %>"><span>发出货物</span></a>
              </div>
              <div class="content-block">
                <div class="tabs">
                  <div id="tab1" class="tab <%=GetValue<int>("vau")==0 ? " active" : string.Empty %>">
                    <div class="content-block">
                      <ul class="zbsh-tab1">
                          <li class="zbsh-li">
                            <a href="#" class="row">
                              <div class="col-90">
                                <i class="zbsh-xd1">
                                  <p class="zbsh-shr">收货人： <span>刘一泽</span></p>
                                  <p class="zbsh-hh">货号： <span>B170105175-10</span></p>
                                </i>
                                <i class="zbsh-xd1">
                                  
                                  <p class="zbsh-hm">货名： <span>不锈钢</span></p><p class="zbsh-hm">件数： <span>10</span></p>
                                  <p class="zbsh-mdd">状态： <span>已到达</span></p>
                                </i>
                              </div>
                              <div class="col-10">
                                <span class="iconfont icon-gengduo"></span>
                              </div>
                            </a>
                          </li>
                      </ul>
                    </div>
                  </div>
                  <div id="tab2" class="tab <%=GetValue<int>("vau")==1 ? " active" : string.Empty %>">
                    <div class="content-block">
                      <ul class="zbsh-tab1">

                           <%
                               foreach(var v in list)
                               {

                                     %>
                          <li class="zbsh-li">
                            <a href="/LC/Customer/TrackGood/LC_TkDetails.aspx?OID=<%=v.OrderID %>" class="row">
                              <div class="col-90">
                                <i class="zbsh-xd1">
                                  <p class="zbsh-shr">收货人： <span><%=v.Consignee %></span></p>
                                  <p class="zbsh-hh">货号： <span><%=v.GoodNo %></span></p>
                                </i>
                                <i class="zbsh-xd1">
                                  
                                  <p class="zbsh-hm">货名： <span><%=v.GoodName %></span></p><p class="zbsh-hm">件数： <span><%=v.Number %></span></p>
                                  <p class="zbsh-mdd">状态： <span><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName()%></span></p>
                                </i>
                              </div>
                              <div class="col-10">
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
     <script type="text/javascript">
         function fachu(id)
         {
             id = parseInt(id);
             if (isNaN(id)) {
                 id = 0;
             }
             var value = id;
             window.location.href = "/LC/Customer/TrackGood/LC_IndexTK.aspx?vau=" + value;
         }
     </script>

  </body>
</html>
