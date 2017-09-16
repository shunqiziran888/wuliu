<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_CDtDetails.aspx.cs" Inherits="Logistics.LC.Business.CollectDebts.LC_CDtDetails" %>

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
                <a href="/LC/Business/CollectDebts/LC_Index.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <%--<a onclick="Test()" class="icon pull-right dis_inline green " style="color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>--%>
                <h1 class="title">收欠款</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <!-- <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div> -->
                    <div class="white mart_20" style="padding:1rem;line-height:1.5rem;" id="content_top_list">
                      <%--上面数据--%>
                    </div>
                    <form id="content_list">
                        <%--数据--%>
                    </form>
                </div>
            </div>
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
    <script type="text/html" id="content_list_temp">
         {{if data.length>0}}
        {{each data as v}}
        <label class="dis_flex jus_bet ali_center mart_10 white" style="padding: .5rem">
            <a href="/LC/Business/CollectDebts/LC_CDtEdit.aspx?OID={{v.OrderID}}">
                <div style="line-height: 1.5rem;">
                    <p class="fz_14">收货人： <i>{{v.Consignee}}</i></p>
                    <p class="fz_14">货名件数： <i>啤酒 <span class="fc_red">x{{v.Number}}件</span></i></p>
                    <p class="fz_14"><i>运费：<span class="fc_ash">{{v.Freight}}</span></i><i>代收款：<span class="fc_ash">{{v.GReceivables}}</span></i></p>
                    <p class="fz_14"><i>货号：<span>{{v.GoodNo}}</span></i><i class="fz_12" style="margin-left: 1rem;">{{v.ArrearsTime}}</i></p>
                </div>
            </a>
        </label>
          {{/each}}
        
        {{else}}
        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
        {{/if}}
    </script>
    <script type="text/html" id="content_top_list_temp">
         {{if data.length>0}}
        {{each data as v}}
          <p class="fz_16">收货人： <span>{{v.Consignee}}</span></p>
            <p class="fz_16">起始日期： <span class="fc_ash fz_14">{{v.StartTime}}----{{v.EndTime}}</span></p>
            <p class="dis_flex fz_16 jus_bet">
                <i class="col_50">欠款单数： <span class="fz_14 fc_ash">{{v.SHPhone1}}单</span></i>
                <i class="col_50">欠运费： <span class="fz_14 fc_ash">{{v.Freight}}元</span></i>
            </p>
            <p class="dis_flex fz_16 jus_bet">
                <i class="col_50">欠代收： <span class="fz_14 fc_ash"> {{v.GReceivables}}元</span></i>
                <i class="col_50">欠款总额： <span class="fz_14 fc_ash"> {{v.Freight+v.GReceivables}}元</span></i>
            </p>
        {{/each}}
        
        {{else}}
        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
        {{/if}}
    </script>
     <script src="/Style/scripts/all.js"></script>
    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
        PageInit(function () {
            let SHPhone = GET("SHPhone");
            GetHTML("GetCollectDebtsDetail", { SHPhone: SHPhone}, function (data) {
                if (CheckHTMLData(data)) {
                    let html = TempToHtml("content_list_temp", data);
                    $("#content_list").html(html);
                    RemoveLuyou();
                }
            });
                GetHTML("GetCollectDebtsDetailTop", { SHPhone: SHPhone }, function (data) {
                    if (CheckHTMLData(data)) {
                        let html = TempToHtml("content_top_list_temp", data);
                        $("#content_top_list").html(html);
                        RemoveLuyou();
                    }
                });
        });
    </script>

</body>

</html>