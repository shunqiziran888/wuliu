<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexDhg.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.IndexDhg" %>
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
                <!-- <a href="jieche_success.html" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a> -->
                <h1 class="title">放货</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <div class="buttons-tab ali_center tab_nav">
                        <a href="#tab1" class="tab-link active button fz_14 tab_nav_btn nav1">客户提货信息</a>
                        <a href="#tab2" class="tab-link button fz_14 tab_nav_btn nav2">未放货库存</a>

                    </div>
                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <%if (list.Count > 0)
                                    { %>
                                <%
                                    foreach (var v in list)
                                    {

                                %>
                                <div class="content-block">
                                    <form>
                                        <label class="dis_flex ali_center mart_10 white" style="padding: .5rem">
                                            <div class="col_100">
                                                <div style="line-height: 1.5rem;">
                                                    <p class="fz_14 fc_black">收货人： <i><%=v.Consignee %></i></p>
                                                    <p class="fz_14 fc_black">货名件数： <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span><span class="fc_green" style="margin-left: 10px;">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span></i></p>
                                                    <p class="fz_14 dis_flex jus_bet fc_black"><i>运费：<span class="fc_ash"><%=v.Freight %></span></i><i>代收款：<span class="fc_ash"><%=v.GReceivables %></span></i> <i>应收合计：<span class="fc_ash">暂时不显示（合计）</span></i></p>
                                                    <p class="fz_14 dis_flex jus_bet fc_black"><i>货号：<span><%=v.GoodNo %></span></i><i class="fz_12 fc_ash" style="margin-left: 1rem;">暂时不显示（时间）</i></p>
                                                    <%if (v.State == 5)
                                                        {%>
                                                    <p class="dis_flex" style="justify-content: center;"><a style="line-height: 30px; background: #a3c478; color: #fff; width: 90px; text-align: center; border: 1px solid #a3c478;" href="/LC/Business/DschargeGood/LC_FHEdit.aspx?OID=<%=v.OrderID %>">放货</a></p>
                                                    <%} %>
                                                    <%if (v.State == 7)
                                                        {%>
                                                    <p class="dis_flex" style="justify-content: center;"><a style="line-height: 30px; background: #a3c478; color: #fff; width: 90px; text-align: center; border: 1px solid #a3c478;" href="/LC/Business/DschargeGood/LC_TransferEdit.aspx?OID=<%=v.OrderID %>&Destination=<%=v.Destination %>">中转</a></p>
                                                    <%} %>
                                                </div>
                                            </div>
                                        </label>
                                    </form>
                                </div>
                                <%} %>
                                <%}
                                    else
                                    {%>
                                <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
                                <%} %>
                            </div>
                            <div id="tab2" class="tab">
                                <div class="content-block">
                                    <div>
                                        <p class="dis_flex fc_black line_he_40 ali_center">
                                            <span class="col_30 txt_right">选择物流：</span>
                                            <select id="logisticsID" name="logisticsID">
                                                <%foreach (var v in LineList)
                                                { %>
                                                <option value="<%=v.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v.End.Value)?.Item2?.Name %></option>
                                                <%} %>
                                            </select>
                                        </p>
                                        <p class="dis_flex line_he_40 ali_center" style="justify-content: center;">
                                            <a href="/LC/Business/DschargeGood/LC_Inventory.aspx" class="line_he_30 green txt_center fc_white fz_14" style="width: 115px">盘点</a>
                                            <span style="width: 1rem;"></span>
                                            <a onclick="Test()" class="line_he_30 green txt_center fc_white fz_14" style="width: 115px">快速放货</a>
                                        </p>
                                    </div>
                                    <%if (DFHList.Count > 0)
                                {%>
                                    <div class="white mart_20" style="padding: 1rem; line-height: 1.5rem;">
                                        <p class="fz_16">装车： <span>23单</span><span style="margin-left: 1rem;">计289件</span></p>
                                        <p class="dis_flex fz_14 jus_bet fc_ash">
                                            <i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i>
                                            <i class="col_30">运费： <span>2523元</span></i>
                                        </p>
                                        <p class="dis_flex fz_14 jus_bet fc_ash">
                                            <i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i>
                                            <i class="col_30">运费： <span>2523元</span></i>
                                        </p>
                                    </div>
                                    <form>
                                        <%foreach (var v in DFHList)
                                        { %>
                                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding: .5rem">
                                            <input type="checkbox" name="checkCommd" value="<%=v.OrderID %>" class="col_10"/>
                                            <input type="hidden" id="OIDSS" name="OIDSS" value="<%=v.OrderID %>"/>
                                            <a href="choose_bus.html">
                                                <div style="line-height: 1.5rem;">
                                                    <p class="fz_14">收货人： <i><%=v.Consignee %></i></p>
                                                    <p class="fz_14">货名件数： <i><%=v.GoodName %> <span class="fc_red">x<%=v.Number %>件</span></i></p>
                                                    <p class="fz_14"><i>运费：<span><%=v.Freight %></span></i><i>代收款：<span><%=v.GReceivables %></span></i></p>
                                                    <p class="fz_14"><i>货号：<span><%=v.GoodNo %></span></i><i class="fz_12" style="margin-left: 1rem;">暂时不显示（时间）</i></p>
                                                </div>
                                            </a>
                                        </label>
                                        <%} %>
                                    </form>
                                </div>
                            </div>
                            <%} %>
                            <%else
                            { %>
                            <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
                            <%} %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script src="/Style/scripts/main.js"></script>
    <script>
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
                window.location.href = "/LC/Business/DschargeGood/FastSuccess.aspx?OID=" + OIDSS + "";
            }
        }
    </script>

</body>

</html>