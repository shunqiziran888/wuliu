<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index_CT_Order.aspx.cs" Inherits="Logistics.LC.Customer.Other.CT_Order.Index_CT_Order" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
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
         
          
         <nav class="bar bar-tab">
              <a class="tab-item external" href="/LC/Index/LC_IndexKH.aspx">
                  <span class="icon iconfont icon-shouye"></span>
                  <span class="tab-label">首页</span>
              </a>
              <a class="tab-item external active" href="/LC/Customer/Other/CT_Order/Index_CT_Order.aspx">
                  <span class="icon iconfont icon-tty"></span>
                  <span class="tab-label">订单</span>
              </a>
              <a class="tab-item external" href="/LC/Customer/Other/CT_Personal/LC_CT_Personal.aspx">
                  <span class="icon iconfont icon-user"></span>
                  <span class="tab-label">我的</span>
              </a>
          </nav>
          <div class="content" style="background:#ededed;">
            <div class="page-index">
              <div class="searchbar">
                <div class="search-input">
                  <label class="icon icon-search" for="search"></label>
                   <input type="text" id='search' placeholder='输入单号可以快速检索' oninput="phonechange(this);" onpropertychange="phonechange(this);"/>
                </div>
              </div>
              <ul class="dingdan-ul">
                     <%if (list.Count > 0)
        { %>
                  <%foreach (var v in list)
                      {%>
                  <li class="dingdan-li">
                    <a href="/LC/Customer/Other/CT_Order/Details_CT_Order.aspx?OID=<%=v.OrderID %>&GReceivables=<%=v.GReceivables %>&Freight=<%=v.Freight %>&OtherExpenses=<%=v.OtherExpenses %>&Number=<%=v.Number %>" class="row">
                      <div class="col-90 dingdan-left">
                        <div class="dingdan-top">
                          <div class="dingdan-top1">
                            订单号： <span><%=v.OrderID %></span>
                          </div>
                            <div class="dingdan-top2">
                             发货人： <span><%=v.Consignor %></span>
                          </div>
                          <div class="dingdan-top2">
                            货号： <span><%=v.GoodNo %></span>
                          </div>
                        </div>
                        <div class="dingdan-middle">
                          货名： <span><%=v.GoodName %></span>
                        </div>
                        <div class="dingdan-bottom">
                          状态： <span><%=v.State.Value.ConvertData<OrderStateEnum>().EnumToName() %></span>
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
    
   <script type="text/javascript" src="/Style/scripts/all.js"></script>

<script>
    $(function() {
        $.init();
        $.config = {router: false}
    });
</script>

  </body>
</html>
<script type="text/javascript">
    function phonechange(element)
    {
        var OrderNo = $(element).val();
        if (OrderNo.length == 19)
        {
            window.location.href = "/LC/Customer/Other/CT_Order/Index_CT_Order.aspx?OrderNo=" + OrderNo;
        }
    }
</script>