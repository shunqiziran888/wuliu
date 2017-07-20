<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Commodity.aspx.cs" Inherits="Logistics.LC.Business.PretendCar.LC_Commodity" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
        input[type=checkbox]{
            -webkit-appearance:checkbox;
            height: .8rem;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/Business/PretendCar/LC_IndexPC.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <a href="/LC/Business/PretendCar/LC_Vehicle.aspx" class="icon pull-right dis_inline" style="background:#009621;color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                <h1 class="title">选择货物</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div> -->
                    <div class="white mart_20" style="padding:1rem;line-height:1.5rem;">
                        <p class="fz_16">装车： <span>23单</span><span style="margin-left:1rem;">计289件</span></p>
                        <p class="dis_flex fz_14 jus_bet fc_ash"><i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i></p>
                        <p class="dis_flex fz_14 jus_bet fc_ash"><i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i><i class="col_30">运费： <span>2523元</span></i></p>
                    </div>
                    <form>
                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding:.5rem">
                            <input type="checkbox" class="col_10">
                            <a href="#">
                                <div style="line-height:1.5rem;">
                                <p class="fz_14">收货人： <i>小强003</i></p>
                                <p class="fz_14">货名件数： <i>啤酒 <span class="fc_red">x15件</span></i></p>
                                <p class="fz_14"><i>运费：<span>2099</span></i><i>代收款：<span>291</span></i></p>
                                <p class="fz_14"><i>货号：<span>PExx101010</span></i><i class="fz_12" style="margin-left:1rem;">2016年-12月-23日 09：21</i></p>
                            </div>
                            </a>
                            
                        </label>
                        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding:.5rem">
                            <input type="checkbox" class="col_10">
                            <a href="choose_bus.html">
                                <div style="line-height:1.5rem;">
                                <p class="fz_14">收货人： <i>小强003</i></p>
                                <p class="fz_14">货名件数： <i>啤酒 <span class="fc_red">x15件</span></i></p>
                                <p class="fz_14"><i>运费：<span>2099</span></i><i>代收款：<span>291</span></i></p>
                                <p class="fz_14"><i>货号：<span>PExx101010</span></i><i class="fz_12" style="margin-left:1rem;">2016年-12月-23日 09：21</i></p>
                            </div>
                            </a>
                            
                        </label>
                        
                    </form>
                </div>


            </div>
        </div>
    </div>

  <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js" charset='utf-8'></script>
    <%--<script type="text/javascript" src="js/main.js" charset='utf-8'></script>--%>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>

</body>

</html>
<script type="text/javascript">
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
    function Test()
    {
        var obj = document.getElementsByName("checkCommd");
        var s=''; 
        for(var i=0; i<obj.length; i++){ 
            if(obj[i].checked) s+=obj[i].value+',';
        }
        if (s == "") { alert("你还没有选择任何物品"); }
        else
        {
            sessionStorage.setItem("OID", s);         
            window.location.href = "/LC/Business/PretendCar/LC_Vehicle.aspx";
        }
    }
</script>
