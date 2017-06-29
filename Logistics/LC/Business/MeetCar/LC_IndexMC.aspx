<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_IndexMC.aspx.cs" Inherits="Logistics.LC.Business.MeetCar.LC_IndexMC" %>
<%@ Import Namespace="CustomExtensions" %>
<%@ import Namespace="GlobalBLL" %>
<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>物流商家版</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="/Style/css/sui/sm.min.css">
    <link rel="stylesheet" href="/Style/css/sui/sm-extend.min.css">
    <link href="/Style/css/iconlink.css" rel="stylesheet">
    <link rel="stylesheet" href="/Style/css/style.css">
    <style type="text/css" media="screen">
        .zbsh-tab1 .zbsh-li a .col-10 {
            margin-top: 2rem;
        }
        
        .zbsh-tab1 .zbsh-li .xiangdan-btn a {
            padding: .18rem 1rem;
        }
        .popup{
        	padding-top: 1rem;
        }
        .popup .content-block{
        	display: flex;
        	justify-content: space-around;

        }
        .popup .content-block select{
			width: 50%;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left" href="/LC/Index/LC_IndexYW.aspx"></a>
                <h1 class="title">接车</h1>
            </header>


            <div class="content" style="background:#ededed;">
                <div class="page-index">

                    <div class="content-block">
                        <div class="tabs">
                            <div id="tab1" class="tab active">
                                <div class="content-block">
                                    <ul class="zbsh-tab1">
                                         <%
                                    foreach(var v in list)
                                    {
                                        
                                     %>
                                        <li class="zbsh-li">
                                            <a href="/LC/Business/MeetCar/LC_GoodDetails.aspx?CH=<%=v.VehicleID %>&CFD=<%=v.Initially %>&MDD=<%=v.Destination %>" class="row">
                                                <div class="col-90">
                                                    <i class="zbsh-xd1 row">
                                  <p class="zbsh-shr col-50">
                                  出发地： <span><%=GlobalAddress.GetAddressFromID(v.Initially.Value)?.Item2?.Name %></span></p>
                                  <p class="zbsh-hh col-50">车号： <span><%=v.VehicleID %></span>
                                  </p>
                                </i>
                                                    <i class="zbsh-xd1 row">
                                  <p class="zbsh-mdd col-50">
                                  目的地： <span><%=GlobalAddress.GetAddressFromID(v.Destination.Value)?.Item2?.Name %>
                                      
                                      
                                      </span>
                                  </p>
                                  <p class="zbsh-hm col-50">
                                  总运费： <span><%=v.Freight %></span>
                                  </p>
                                </i>
                                                    <i class="zbsh-xd1 row">
                                  <p class="zbsh-fhr col-50">
                                  总货款： <span>57567</span></p>
                                  <p class="zbsh-hh col-50">
                                  大车运费： <span><%=v.largeCar %></span>
                                  </p>
                                </i>
                                                </div>
                                                <div class="col-10">
                                                    <span class="iconfont icon-gengduo"></span>
                                                </div>
                                            </a>
                                            <div class="xiangdan-btn">
                                                <a href="/LC/Business/MeetCar/LC_GoodDetails.aspx?CH=<%=v.VehicleID %>&CFD=<%=v.Initially %>&MDD=<%=v.Destination %>" class="open-about">接车</a>
                                            </div>
                                        </li>
                                            <%} %>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
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
            $(document).on('click', '.open-about', function() {
                $.popup('.popup-about');
            });

            $(document).on('click', '.open-services', function() {
                $.popup('.popup-services');
            });
        });
    </script>

</body>

</html>
