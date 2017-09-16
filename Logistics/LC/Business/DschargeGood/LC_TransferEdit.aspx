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
    <!-- <link rel="shortcut icon" href="/favicon.ico"> -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

   <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style>
       
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a href="javascript:;" onclick="history.go(-1)" class="icon iconfont icon-zuo pull-left"></a>
                <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-plus pull-right"  id="showaddwl"></a>
                    <i class="add_txt">添加物流</i>
                </p>
                <h1 class="title">物流业务</h1>
            </header>


            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <div class="white" style="padding:1rem;">
                        <p class="dis_flex ali_center"><span class="col_30 line_he_44 txt_center fz_16">目标地</span> <%=DAL.DAL.DALBase.GetAddressFromID(Destination)?.Item2?.Name %></p>
                        <p class="dis_flex ali_center"><span class="col_30 line_he_44 txt_center fz_16">中转费用</span> <input type="text" name="Freight" id="Freight"></p>
                        <p class="dis_flex ali_center"><span class="col_30 line_he_44 txt_center fz_16">中转物流</span> <select id="logisticsID" name="logisticsID">
                                     <%foreach (var v in list3) { %>
                                    <option value="<%=v.End %>"><%=DAL.DAL.DALBase.GetAddressFromID(v.End.Value)?.Item2?.Name %></option>
                                    <%} %>
                                    </select></p>
                        <p class="dis_flex" style="justify-content:center; margin:.5rem 0;"><a style="line-height: 30px;background: #a3c478;color: #fff;padding:0 1rem;text-align: center;border: 1px solid #a3c478;"
                               href="#" onclick="Next('<%=OID %>')">通知物流取货</a></p>
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
    <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });

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
    </script>

</body>

</html>
<script type="text/javascript">
    function Next(OID)
    {
        var Destination = $("#Destination").val();
        var Freight = $("#Freight").val();
        var beforeyf = '<%=yf%>';
        var Final = parseInt(beforeyf) + parseInt(Freight);
        var logisticsID = $("#logisticsID").val();
        window.location.href = "/LC/Business/DschargeGood/LC_Handle.aspx?OID=" + OID + "&Freight=" + Final + "&logisticsID=" + logisticsID + "&Destination="+Destination;
    }
</script>