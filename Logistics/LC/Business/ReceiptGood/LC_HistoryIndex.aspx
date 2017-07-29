<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_HistoryIndex.aspx.cs" Inherits="Logistics.LC.Business.ReceiptGood.LC_HistoryIndex" %>
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
        .zbsh-zffs .huo_name {
            position: relative;
        }

        .zbsh-zffs .huo_num {
            position: absolute;
            top: -15px;
            right: -80px;
            font-size: 16px;
            color: #f00;
            width: 80px;
            text-align: left;
        }

        .huo_fnagshi {
            margin-left: 80px;
            color: #009621;
        }

        .zongji {
            padding: .8rem 10%;
            background: #fff;
        }


        .check_box .check_main_left form label.active {
            color: #5986de;
        }

        .check_box .check_main_left form label.active input {
            display: block;
        }


        .check_box .check_main_right form label.active {
            color: #5986de;
        }

        .check_box .check_main_right form label.active input {
            display: block;
        }

        .huo_num {
            text-align: right;
        }

        .huo_num input {
            width: 30%;
            padding: 0;
            height: 1.2rem;
            line-height: 1.2rem;
        }

        .yunfei input {
            width: 50%;
            height: 1.2rem;
            line-height: 1.2rem;
        }

        .mudidi input {
            height: 1.2rem;
            line-height: 1.2rem;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/Business/ReceiptGood/LC_GoodsReceipt.aspx" class="icon iconfont icon-zuo pull-left"></a>
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-eventnote pull-right" href="history_log.html"></a>
                    <i class="add_txt">历史记录</i>
                </p> -->
                <h1 class="title">历史记录</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>
                    <div class="check_box row_44 white pos_r">


                        <div class="check_tab_nav jus_bet dis_flex ali_center ">
                            <div class="check_left col_40 txt_right row_44 li_row_44">
                                <span>一周</span>
                                <span class="iconfont fz_18" style="color: #7d7d7d;">&#xe637;</span>
                            </div>
                            <div class="check_right col_40 txt_left row_44 li_row_44">
                                <span>线路</span>
                                <span class="iconfont fz_18" style="color: #7d7d7d;">&#xe637;</span>
                            </div>
                        </div>



                        <div class="check_main check_main_left pos_a col_100 white bor_top  dis_none" style="top:2.2rem; z-index:2;">
                            <form class="bor_bottom" style="padding:1rem; margin: 0 .3rem;">
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    今天
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                 </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40 active">
                                    最近一周
                                    <input name="time" type="radio" class="col_50 bor_none  dis_none txt_right iconfont icon-right"/> 
                                </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    最近一月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                </label>
                                <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                    最近三月 
                                    <input name="time" type="radio" class="col_50 bor_none dis_none txt_right iconfont icon-right"/>
                                </label>
                            </form>
                            <div class="dis_flex jus_aro bor_bottom" style="padding:.5rem;">
                                <input class="gray col_30" type="date" placeholder="2017.07.12" value="2017-07-21">
                                <span class="iconfont icon-hengxian"></span>
                                <input class="gray col_30" type="date" placeholder="2017.07.12" value="2017-08-31">
                                <input class="close_btn  col_25" type="button" style="color:#5986de; border:1px solid #5986de;padding: 0;" value="确定">
                            </div>
                        </div>



                        <div class="check_main check_main_right pos_a col_100 white bor_top dis_none" style="top:2.2rem; z-index:2;">
                            <ul>
                                <form class="bor_bottom" style="padding:1rem 0; margin: 0 .3rem;">
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/> 
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40 active">
                                        山东淄博---------河北邯郸
                                        <input name="city" type="radio" class="bor_none col_30  dis_none txt_right iconfont icon-right"/> 
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸 
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/>
                                    </label>
                                    <label class="dis_flex jus_bet ali_center fz_14 line_he_40">
                                        山东淄博---------河北邯郸 
                                        <input name="city" type="radio" class="bor_none col_30 dis_none txt_right iconfont icon-right"/>
                                    </label>
                                </form>
                            </ul>
                            <div class="dis_flex bor_bottom" style="padding:.5rem;justify-content: flex-end;">
                                <input class="close_btn col_25" type="button" style="color:#5986de; border:1px solid #5986de;padding: 0;" value="确定">
                            </div>
                        </div>



                    </div>
                    <!-- 选择 -->


                    <div class="zongji mart_10">
                        <p class="zongji_top dis_flex  marb_10">
                            <i class="col_50 fz_16">汇总运费： <span class="fz_14">1201.1</span></i>
                            <i class="col_50 fz_16">汇总代收： <span class="fz_14">1201.1</span></i>
                        </p>
                        <p class="zongji_top dis_flex">
                            <i class="col_50 fz_16">未装运费： <span class="fz_14">1201.1</span></i>
                            <i class="col_50 fz_16">未装代收： <span class="fz_14">1201.1</span></i>
                        </p>
                    </div>
                    <ul class="zbsh-tab1">
                         <%if (list.Count > 0)
                                        { %>
                        <%foreach (var v in list)
                            { %>
                        <li class="zbsh-li">
                            <a href="#">
                                <div class="col-100">
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">货号： <span class="fc_ash fz_14"><%=v.GoodNo %><input type="text" id="OID" name="OID" value="<%=v.OrderID %>" hidden="hidden"/><input type="text" id="ZT" name="ZT" value="<%=v.State %>" hidden="hidden"/></span></p>
                                    </i>
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">货物名： <span class="huo_name fc_ash fz_14"><%=v.GoodName %> <i class="huo_num" id="jianshu">x<%=v.Number %></i><input type="text" id="Number" name="Number" style="width:50px;height:20px;display:none"/></span>
                                    <span class="huo_fnagshi">(<%=v.freightMode.ConvertData<YFFSEnum>().EnumToName() %>)</span></p>
                                    </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">发货人： <span class="ft_color_ash fz_14"><%=v.Consignor %></span></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">收货人： <span class="fz_14"><%=v.Consignee %></span></p>
                                  
                                </i>
                                    <i class="zbsh-xd1">
                                  <p class="zbsh-shr col_50 fz_16">运费： <span class="yunfei ft_color_ash fz_14" id="yunfie"><%=v.Freight %></span><input  type="text" id="Freight" name="Freight" style="display:none;width:100px;height:20px;"/></p>
                                  <p class="zbsh-hh fc_ash col_50 fz_16">代收款： <span class="fz_14"><%=v.GReceivables %></span></p>
                                  
                                </i>
                                    <i class="zbsh-xd2">
                                  <p class="zbsh-zffs fz_16">目的地： <span class="mudidi fc_ash fz_14" id="mdd"><%=DAL.DAL.DALBase.GetAddressFromID(v.finish.Value)?.Item2?.Name %></span>
                                      <select id="finish" style="display:none;width:150px;height:35px;">
                                          <option value="5">沾化区</option>
                                          <option>2</option>
                                          <option>3</option>
                                      </select></p>
                                    </i>
                                    <p class="fz_16 dis_flex jus_bet ali_center fc_red" style="padding:0 10%;"><i>合计金额： <span>暂不显示</span></i><i class="fz_12 fc_ash"><%=v.ConsigneeTime %></i></p>
                                </div>

                            </a>
                            <p class="dis_flex jus_center" id="genggai"><button class="change_btn line_he_30 padlr_30 green fc_white fz_14 mart_10" style="border:none;" onclick="Shows()">更改</button></p>
                            <p class="dis_flex jus_center"><button class="change_btn line_he_30 padlr_30 green fc_white fz_14 mart_10" style="border:none; display:none" id="OK" onclick="UpdateHistory()">确定</button></p>
                        </li>
                         <%} %>
                         <%}
                                        else
                                        {%>
                                        <div style="text-align: center; line-height: 200px; overflow: hidden;">无任何数据</div>
                                        <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>
     <script src="/Style/scripts/main.js"></script>
    <script>
        $(function () {
            //$.init();
            //$.config = { router: false }
            //$('.change_btn').click(function () {
            //    var v = $(this);
            //    var val = v.html()
            //    if (val == '更改') {
            //        v.html('确认')
            //            .parents('.zbsh-li').find('.huo_num,.mudidi,.yunfei').html('<input type="text" class="col_60"/>');
            //    } else {
            //        v.html('更改');
            //        var huonum = v.parents('.zbsh-li').find('.huo_num input').val();
            //        v.parents('.zbsh-li').find('.huo_num').html('x' + huonum);
            //        var huonum = v.parents('.zbsh-li').find('.mudidi input').val();
            //        v.parents('.zbsh-li').find('.mudidi').html(huonum);
            //        var huonum = v.parents('.zbsh-li').find('.yunfei input').val();
            //        v.parents('.zbsh-li').find('.yunfei').html(huonum);
            //    }
            //})
        });
        function Shows() {
            $("#jianshu").hide();
            $("#yunfie").hide();
            $("#genggai").hide();
            $("#mdd").hide();
            $("#Number").show();
            $("#Freight").show();
            $("#finish").show();
            $("#OK").show();
        }
        function UpdateHistory()
        {
            var OID = document.getElementById("OID").value;
            var Number = document.getElementById("Number").value;
            var Freight = document.getElementById("Freight").value;
            var finish = document.getElementById("finish").value;
            var ZT = document.getElementById("ZT").value;
            window.location.href = "/LC/Business/ReceiptGood/LC_HistoryEdit.aspx?OID=" + OID + "&Number=" + Number + "&Freight=" + Freight + "&finish=" + finish + "&ZT=" + ZT + "";
        }
    </script>

</body>

</html>