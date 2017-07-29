<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Inventory.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.LC_Inventory" %>
<%@ import Namespace="GlobalBLL" %>
<%@ Import Namespace="CustomExtensions" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

     <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
        input[type=checkbox] {
            -webkit-appearance: checkbox;
            height: .8rem;
        }

        .buttons-tab .button.active {
            background: #0894ec;
            border: 1px solid #0894ec;
            color: #fff;
        }

        .tab_nav {
            display: flex;
            justify-content: center;
            background: #f2f2f2;
            border: none;
        }

        .tab_nav .tab_nav_btn {
            border: 1px solid #0894ec;
            height: 30px;
            line-height: 30px;
            background: #fff;
            color: #0894ec;
            font-size: .7rem;
            width: 173px;
        }

        .tab_nav .tab_nav_btn.nav1 {
            border-right: none;
            border-top-left-radius: 10px;
            border-bottom-left-radius: 10px;
        }

        .tab_nav .tab_nav_btn.nav2 {
            border-left: none;
            border-bottom-right-radius: 10px;
            border-top-right-radius: 10px;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="#" onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                 <a onclick="Test()" class="icon pull-right dis_inline green" style="color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">确认</a> 
                <h1 class="title">盘点</h1>
            </header>

            <%if (list.Count > 0)
                { %>
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="white mart_10" style="padding:1rem;line-height:1.5rem;">
                        <p class="fz_16">装车： <span>23单</span><span style="margin-left:1rem;">计289件</span></p>
                    </div>
                    <form>
                        <%foreach (var v in list)
    {%>
                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding:.5rem">
                            <input type="checkbox" name="checkCommd" value="<%=v.OrderID %>" class="col_10"/>
                            <a href="/LC/Business/DschargeGood/ItySuccess.aspx?OID=<%=v.OrderID %>">
                                <input type="hidden"  id="OIDSS" name="OIDSS" value="<%=v.OrderID %>"/>
                                <div style="line-height:1.5rem;">
                                    <div class="dis_flex jus_bet ali_center">
                                        <div class="col_70">
                                            <p class="fz_14">收货人： <i><%=v.Consignee %></i></p>
                                            <p class="fz_14">货名件数： <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span></i></p>
                                            <p class="fz_14"><i>运费：<span><%=v.Freight %></span></i><i>代收款：<span><%=v.GReceivables %></span></i></p>
                                        </div>
                                        <i class="iconfont col_30 fc_green" style="font-size:55px;">&#xe67b;</i>
                                    </div>
                                <p class="fz_14"><i>货号：<span><%=v.GoodNo %></span></i><i class="fz_12" style="margin-left:1rem;">暂时不显示（时间）</i></p>
                            </div>
                            </a>
                            <%} %>
                        </label>
                    </form>
                </div>
            </div>
            <%} %>
            <%else
    { %>
            <div style="text-align: center; line-height: 200px; overflow:hidden;">无任何数据</div>
            <%} %>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script src="/Style/scripts/all.js"></script>
    <script type="text/javascript">
        $(function () {
            $.init();
            $.config = { router: false }
        });
        $(function () {
            $("input[type='checkbox']").each(function () {
                this.checked = true;
            });
            isCheckAll = true;
        });
        var isCheckAll = false;
        function swapCheck() {
            if (isCheckAll) {
                $("input[type='checkbox']").each(function () {
                    this.checked = false;
                });
                isCheckAll = false;
            } else {
                $("input[type='checkbox']").each(function () {
                    this.checked = true;
                });
                isCheckAll = true;
            }
        }
        function Test() {
            var obj = document.getElementsByName("checkCommd");
            var OIDSS = $("#OIDSS").val();
            var s = '';
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].checked) s += obj[i].value + ',';
            }
            if (s == "") { alert("你还没有选择任何记录"); }
            else {
                window.location.href = "/LC/Business/DschargeGood/BatchSuccess.aspx?OID=" + OIDSS + "";
                
            }
        }
    </script>

</body>

</html>
