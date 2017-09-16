<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_DeliverGoods.aspx.cs" Inherits="Logistics.LC.OwnBilling.LC_DeliverGoods" %>

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
        .prompt_msg {
            position: absolute;
            width: 22px;
            height: 22px;
            background: #f00;
            border-radius: 20px;
            color: #fff;
            line-height: 22px;
            top: 50%;
            left: 68%;
            margin-top: -11px;
            font-size: 10px;
            text-align: center;
        }

        select {
            background-size: 20px 20px;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="/LC/MenuBar/LC_BusinessIndex.aspx"  class="icon iconfont icon-zuo pull-left"></a>
                <a onclick="Next()" class="icon pull-right dis_inline green" style="color:#fff;border:1px solid #bbb; line-height:1.5rem; padding:0 1rem;margin-top:.28rem;">下一步</a>
                <h1 class="title">收货开单</h1>
            </header>

           
                <div class="content" style="background: #f2f2f2;">
                     <form id="form1" runat="server" method="post" action="?"  accept-charset="utf-8">
                    <div class="page-index marb_20">
                        <div class="pad_20 white mart_10">
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">发货人：</span>
                                <span class="col_70">
                                    <input type="text" placeholder="请输入发货人姓名" name="Consignor" id="Consignor"></span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">发货电话：</span>
                                <span class="col_70">
                                    <input type="number" placeholder=" 发货人手机号" name="FHPhone" id="FHPhone"></span>
                            </p>
                        </div>
                        <div class="pad_20 white mart_10">
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">货物名称：</span>
                                <span class="col_70">
                                    <input type="text" placeholder="货物名称" id="GoodName" name="GoodName"></span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">件数：</span>
                                <span class="col_70">
                                    <input type="number" placeholder="请输入数字" id="Number" name="Number"></span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">代收货款：</span>
                                <span class="col_70">
                                    <input type="number" placeholder="请输入金额" id="GReceivables" name="GReceivables"></span>
                            </p>
                        </div>
                        <div class="pad_20 white mart_10">
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">收货人：</span>
                                <span class="col_70">
                                    <input type="text" placeholder="请输入收货人姓名" id="Consignee" name="Consignee"></span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">收货电话：</span>
                                <span class="col_70">
                                    <input type="number" placeholder="收货人手机号" id="SHPhone" name="SHPhone"></span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">收货地址：</span>
                                <span class="col_70">
                                    <select  id="finishBingLineID" name="finishBingLineID">
                                        <option>请选择</option>
                                        <%
                                            foreach (var v1 in LineList)
                                            {
                                        %>
                                        <option selected value="<%=v1.End %>|<%=v1.BindLogisticsUid %>"><%=DAL.DAL.DALBase.GetAddressFromID(v1.End.Value)?.Item2?.Name%></option>
                                        <%} %>
                                    </select>
                                </span>
                            </p>
                        </div>
                        <div class="pad_20 white mart_10">

                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">省份：</span>
                                <span class="col_70">
                                    <select id="End1" name="End1"  onchange="show(this.value,'End2');"> 
                                    <option>请选择</option>
                                    <%
                                    foreach (var p in shengList)
                                    {
                                     %>
                                <option value="<%=p.id %>"><%=p.Name %></option>
                                    
                                <%
                                    } %>
                                </select>
                                </span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">城市：</span>
                                <span class="col_70">
                                   <select id="End2" name="End2" onchange="show(this.value,'End');"> 
                                </select>
                                </span>
                            </p>
                            <p class="dis_flex jus_bet line_he_40">
                                <span class="col_30 txt_right">区县：</span>
                                <span class="col_70">
                                    <select id="End" name="End"> 
                                </select>
                                </span>
                            </p>
                        </div>
                    </div>
                    </form>
                </div>
            
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });
    </script>
    <script type="text/javascript">
        //地区联动
        function show(id, elename) {
            //if (isAuto != 0)
            //    return;
            GetHtml("/Command/GetAddressNextList.aspx", { id: id }, function (data) {
                let list = JSON.parse(data);
                $("#" + elename).empty();
                $("#" + elename).append("<option>-请选择-</option>");
                for (let i = 0; i < list.length; i++) {
                    $("#" + elename).append("<option value='" + list[i].id + "'>" + list[i].Name + "</option>");
                }
            });
        }
        function Next()
        {
            let arr = $("#finishBingLineID").val().split("|");
            var finish = arr[0];
            let BindLogisticsUid = arr[1];
            var Consignor = $("#Consignor").val();
            var FHPhone = $("#FHPhone").val();
            var GoodName = $("#GoodName").val();
            var Number = $("#Number").val();
            var GReceivables = $("#GReceivables").val();
            var Consignee = $("#Consignee").val();
            var SHPhone = $("#SHPhone").val();
            var End = $("#End").val();
            if (Consignor == "" || FHPhone == "" || GoodName == "" || Number == "" || GReceivables == "" || Consignee == "" || SHPhone == "" || End == "" || End=="-请选择-")
            {
                Msg("所有内容均不能为空");
            }
            else
            {
                Href("/LC/OwnBilling/LC_DeliverGoodContinue.aspx?Consignor=" + Consignor + "&FHPhone=" + FHPhone + "&GoodName=" + GoodName + "&Number=" + Number + "&GReceivables=" + GReceivables + "&Consignee=" + Consignee + "&SHPhone=" + SHPhone + "&End=" + End + "&finish=" + finish + "&BindLogisticsUid=" + BindLogisticsUid);
            }
        }
    </script>
</body>

</html>
