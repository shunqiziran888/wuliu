<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CT_DeliverAdd.aspx.cs" Inherits="Logistics.LC.Customer.CT_DeliverAdd" %>
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
    <style>
        .danxuan_zu {
            display: flex;
            justify-content: space-between;
        }
        
        .danxuan_zu .danxuan {
            position: relative;
            width: 2.8rem;
            height: 1.4rem;
        }
        
        .danxuan_zu .danxuan>i {
            position: absolute;
            top: 0;
            text-align: center;
            width: 100%;
            padding: px;
            border: 1px solid #bbb;
            height: 1.3rem;
            line-height: 1.3rem;
            border-radius: 4px;
        }
        
        .danxuan_zu .danxuan>input {
            position: absolute;
            z-index: -111;
            display: none;
        }
        
        input[type="radio"]:checked+i {
            background: #9ccc65;
            color: #fff;
            border-radius: 4px;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->


            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Customer/DeliverGood/CT_Delivergod.aspx"></a>
                <h1 class="title">我要发货</h1>
            </header>

            <div class="content" style="background:#ededed;">
                <div class="page-index">
                        <form id="form1" runat="server" method="post" action="?"  class="khfh-form" accept-charset="utf-8">
                        <div class="row">
                            <div class="col-30 ">
                                收货人
                            </div>
                            <div class="col-70">
                                 <input name="Consignee" type="text" id="Consignee" size="15">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                物流
                            </div>
                            <div class="col-40">
                                <select id="logisticsID" name="logisticsID" onchange="Test()">
                                    <option>请选择物流</option>
                                    <%foreach (var v in list) { %>
                                    <option value="<%=v.UID %>,<%=v.AreaID %>"><%=v.LogisticsName %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                收货人电话
                            </div>
                            <div class="col-70">
                                <input name="SHPhone" type="text" id="SHPhone" size="15">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                到达地
                            </div>
                            <div class="col-70">
                                <select id="End1" name="End1" style="width:300px" onchange="show(this.value,'End2');"> 
                                    <option>请选择</option>
                                    <%
                                    foreach (var p in shengList)
                                    {
                                     %>
                                <option value="<%=p.id %>"><%=p.Name %></option>
                                    
                                <%
                                    } %>
                                </select>省份&nbsp &nbsp &nbsp 
                                 <select id="End2" name="End2" style="width:300px" onchange="show(this.value,'End');"> 
                                </select>城市&nbsp &nbsp &nbsp 
                                 <select id="End" name="End" style="width:300px" > 
                                </select>区县&nbsp &nbsp &nbsp
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                付费方式
                            </div>
                            <div class="col-70">
                                <div class="danxuan_zu">
                                    <label class="danxuan">
                                        <input name="freightMode" type="radio" value="1"/>
                                        <i>提付</i> 
                                    </label>
                                    <label class="danxuan">
                                        <input name="freightMode" type="radio" value="2" />
                                        <i>现付</i> 
                                    </label>
                                    <label class="danxuan">
                                        <input name="freightMode" type="radio" value="3" />
                                        <i>扣付</i> 
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                货物名称
                            </div>
                            <div class="col-70">
                                <input name="GoodName" type="text" id="GoodName" size="15">
                            </div>
                        </div>
                        <div class="row khfh-input">
                            <div class="col-30 ">
                                件数
                            </div>
                            <div class="col-70">
                                <input name="Number" type="text" id="Number" size="15">
                            </div>
                        </div>
                        <div class="row khfh-input">
                            <div class="col-30 ">
                                代收款
                            </div>
                            <div class="col-70">
                                <input name="GReceivables" type="text" id="GReceivables" size="15">
                            </div>
                        </div>
                        <div class="row khfh-input">
                            <div class="col-30 ">
                                提货方式
                            </div>
                            <div class="col-50 ">
                                <div class="danxuan_zu">
                                    <label class="danxuan">
                                        <input name="CarryGood" type="radio" value="1"/>
                                        <i>客户自提</i> 
                                    </label>
                                    <label class="danxuan">
                                        <input name="CarryGood" type="radio" value="2" />
                                        <i>送货上门</i> 
                                    </label>
                                </div>
                            </div>
                            <div class="col-20">
                                <input type="text" placeholder="111">
                            </div>
                        </div>
                        <div class="row khfh-input">
                            <div class="col-30 ">
                                收货方式
                            </div>
                            <div class="col-50 ">
                                <div class="danxuan_zu">
                                    <label class="danxuan">
                                        <input name="ReceiptGood" type="radio" value="1"/>
                                        <i>我方去送</i> 
                                    </label>
                                    <label class="danxuan">
                                        <input name="ReceiptGood" type="radio" value="2" />
                                        <i>物流来提</i> 
                                    </label>
                                </div>
                            </div>

                        </div>

                        <p class="khfh-input1"><input type="submit" value="确认发货"></p>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

    <script type="text/javascript">
        $(function() {
            $.init();
            $.config = {
                router: false
            }
        });
        //物流筛选地区
        function LCID()
        {
            //var values = $("#logisticsID").val();
            //GetHtml("/Command/GetLineListFromLogisticsId.aspx?logid=" + values, {}, function (data) {
            //    var obj = JSON.parse(data);
            //    if (obj.Item1 == true) {
            //        $("#Initially").empty();
            //        $("#Destination").empty();
            //        for (var o in obj.Item3) {
            //            let v = obj.Item3[o];
            //            $("#Initially").prepend("<option value=" + v.Start + ">" + v.StartName + "</option>");
            //            $("#Destination").prepend("<option value=" + v.End + ">" + v.EndName + "</option>");
            //        }
            //    }
            //}, function (error) {
            //});
        }

        function show(id, elename) {
            GetHtml("/Command/GetAddressNextList.aspx", { id: id }, function (data) {
                let list = JSON.parse(data);
                $("#" + elename).empty();
                $("#" + elename).append("<option>请选择</option>");
                for (let i = 0; i < list.length; i++) {
                    $("#" + elename).append("<option value='" + list[i].id + "'>" + list[i].Name + "</option>");
                }
            });
        }
    </script>

</body>

</html>