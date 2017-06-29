<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_AddCt.aspx.cs" Inherits="Logistics.LC.Customer.Contact.LC_AddCt" %>

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
        .modal-inner {
            padding: 4rem;
            border-radius: .35rem .35rem 0 0;
            position: relative;
            background: #2baf2b;
            color: #fff;
        }
        
        .modal-button {
            color: black;
        }
    </style>

</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->


            <header class="bar bar-nav">
                <a class="icon icon-left pull-left external" href="/LC/Customer/Contact/LC_IndexCt.aspx"></a>
                <h1 class="title">添加物流</h1>
            </header>

            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <form id="form1" runat="server" method="post" action="?"  class="khfh-form" accept-charset="utf-8">
                        <div class="row">
                            <div class="col-30 ">
                                物流名称
                            </div>
                            <div class="col-70">
                                <input type="text" placeholder="物流名称" id="logisticsName" name="logisticsName">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                物流电话
                            </div>
                            <div class="col-70">
                                <input type="text" placeholder="物流电话" id="logisticsPhone" name="logisticsPhone">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                联系人
                            </div>
                            <div class="col-70">
                                <input type="text" placeholder="联系人">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                目的地
                            </div>
                            <div class="col-70">
                                <input type="text" placeholder="目的地" id="Destination" name="Destination">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-30 ">
                                接货地址
                            </div>
                            <div class="col-70">
                                <input type="text" placeholder="接货地址" id="DeliveryAdress" name="DeliveryAdress">
                            </div>
                        </div>

                        <div class="row" style="margin:0 auto">
                            <div class="col-50 " style="margin:0;">
                                <p class="khfh-input1" style="margin:0;"><input onclick="window.location='sjxinjianwuliuerweima.html'" style="width:100%;padding:0; background:#ffa726; border-color:#ffa726;" type="button" value="扫一扫添加"></p>
                            </div>
                            <div class="col-50" style="float: right;margin:0;">
                                <p class="khfh-input1" style="margin:0;"><%--<input class="alert-text" style="width:100%;padding:0;" type="button" value="确认">--%>
                                    <input type="submit" value="确认" class="alert-text" style="width:100%;padding:0;"/>
                                </p>
                                <!--<p class="khfh-input1" style="margin:0;"><a href="#" style="width:100%;padding:0;  line-height: 2.5rem;  border-radius: 8px;    text-align: center;  display: block;    height: 2.5rem; background: #9ccc65; border-color: #7cb342;color: #fff;" class="alert-text">Alert With Text</a></p>-->
                            </div>
                        </div>


                    </form>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>

    <script>
        // $(function() {
        //     $.init();
        //     $.config = {
        //         router: false
        //     }
        // });


     
            //$(document).on('click', '.alert-text', function() {
            //    $.alert('新建物流成功');
            //});
    </script>

</body>

</html>
