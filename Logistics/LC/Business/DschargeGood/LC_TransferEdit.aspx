<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_TransferEdit.aspx.cs" Inherits="Logistics.LC.Business.DschargeGood.LC_TransferEdit" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ Import Namespace="GlobalBLL" %>
<%@ Import  Namespace="SuperDataBase" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流管理系统</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        .row {
            margin-left: 0;
        }
        
        .row .col-60 {
            width: 60%;
            margin-left: 0;
        }
        
        .wyfh-ul {
            padding-top: .5rem;
            margin: .5rem;
            background: #fff;
            border: 1px solid #bbb;
            border-radius: 6px;
        }
        
        .dingdan-ul .dingdan-li .col-80 .shang {
            display: flex;
            justify-content: space-between;
            font-size: .5rem;
            margin-bottom: .5rem;
        }
        
        .dingdan-ul .dingdan-li .col-80 .xia {
            display: flex;
            justify-content: space-between;
            font-size: .5rem;
        }
        
        .dingdan-ul .dingdan-li .col-20 {
            margin-top: .3rem;
        }
        
        .dingdan-ul .dingdan-li a {
            color: #fff;
        }
        
        .dingdan-ul div.row {
            margin-bottom: .5rem;
        }
        
        .dingdan-ul div.row .col-60 p {
            display: flex;
            justify-content: space-between;
            font-size: .7rem;
            margin-bottom: .5rem;
        }
        
        .dingdan-ul div.row .col-60 p input {
            width: 60%;
            height: 1.1rem;
        }
        
        .dingdan-ul div.row .col-60 p select {
            width: 60%;
            height: 1.1rem;
        }
        
        .tongzhibtn {
            padding: 0 2rem;
        }
        
        .tongzhibtn .button {
            height: 2rem;
            line-height: 2rem;
        }
        
        .dingdan-ul div.row .col-40 a {
            height: 3rem;
            line-height: 3rem;
            margin-top: 10%;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Business/DschargeGood/IndexDhg.aspx"></a>
                <h1 class="title">物流管理系统</h1>
            </header>
            <div class="content" style="background:#ededed;">
                <div class="page-index">
                    <div class="searchbar">
                        <div class="search-input">
                            <label class="icon icon-search" for="search"></label>
                            <input type="search" id='search' placeholder='搜索订单' />
                        </div>
                    </div>

                    <div class="dingdan-ul wyfh-ul">
                        <div class="row">
                            <div class="col-60">
                                <p class="">目标地 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=DAL.DAL.DALBase.GetAddressFromID(Destination)?.Item2?.Name %>
                                   <%-- <select id="Destination" name="Destination">
                                     <%foreach (var v in list2) { %>
                                    <option value="<%=v.End%>"><%=v.EndCityName %></option>
                                    <%} %>
                                </select>--%>
                                   
                                </p>
                                <p>中转运费<input type="text" name="Freight" id="Freight"></p>
                                <p>中转物流
                                    <select id="logisticsID" name="logisticsID">
                                     <%foreach (var v in list3) { %>
                                    <option value="<%=v.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v.End.Value)?.Item2?.Name %></option>
                                    <%} %>
                                    </select>
                                </p>
                            </div>
                            <div class="col-40">
                                <a id="showaddwl" class="button button-fill button-success">增加物流</a>
                            </div>
                        </div>
                        <div class="tongzhibtn">
                            <a href="#" onclick="Next('<%=OID %>')" class="button button-fill button-success">通知物流取货</a>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
     <div class="popup popup-addwl">
        <div class="content-block">
            <p>添加物流</p>
            <p>请输入物流方手机号</p>
            <p>
                <input id="phone" value="" /></p>
            <p>
                <button type="button" id="addwl">确认添加</button>
                <button type="button" class="close-popup">关闭</button>
            </p>
        </div>
    </div>
     <script type="text/javascript" src="http://wl.mikiboss.com/Style/scripts/all.js"></script>
    <script type="text/javascript">
        $(function () {
            $.init();
            $.config = {
                router: false
            }
            $("#showaddwl").click(function () {
                $.popup('.popup-addwl');
            });

            //添加物流
            $("#addwl").click(function () {
                let phone = $("#phone").val();
                if (StrIsNull(phone)) {
                    alert("手机号码不能为空!");
                    return;
                }
                if (phone.length != 11) {
                    alert("手机号码必须为11位!");
                    return;
                }
                //执行物流绑定
                GetHtml("/Command/AddLogisticsFromPhone.aspx", { phone: phone }, function (data) {
                    let obj = JSON.parse(data);
                    if (obj.Item1 == true) {
                        alert("绑定成功!");
                        $.closeModal(".popup-addwl");
                        window.location.reload();
                    }
                    else {
                        alert(obj.Item2);
                    }
                });
            });
        })
    </script>
</body>

</html>
<script type="text/javascript">
    function Next(OID)
    {
        var Destination = $("#Destination").val();
        var Freight = $("#Freight").val();
        var logisticsID = $("#logisticsID").val();
        window.location.href = "/LC/Business/DschargeGood/LC_Handle.aspx?OID=" + OID + "&Freight=" + Freight + "&logisticsID=" + logisticsID + "&Destination="+Destination;
    }
</script>