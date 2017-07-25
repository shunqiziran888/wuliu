<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Logistics.LC.MenuBar.Personal" %>

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
        .header .header_main {
            display: flex;
            justify-content: flex-start;
            height: 105px;
            background-color: #a3c478;
            width: 100%;
            align-items: center;
            padding-left: 10%;
        }

        .header .header_main img {
            width: 70px;
            height: 70px;
            /* height: auto; */
            line-height: normal;
            border-radius: 80px;
        }

        .header .header_main i {
            color: #fff;
            margin-left: 30px;
            font-size: 14px;
        }

        .ul_main {
            padding: 1rem 0;
        }

        .ul_main .li_list {
            padding: 1rem;
            background: #fff;
            margin-bottom: .5rem;
        }

        .ul_main .li_list .li_title {
            margin-bottom: .8rem;
        }

        .ul_main .li_list a.a_box {
            display: flex;
            justify-content: space-around;
            align-items: flex-start;
        }

        .ul_main .li_list a.a_box i.iconfont {
            color: #a6a6a6;
        }

        .ul_main .li_list .a_box .p_mian {
            margin-bottom: 5px;
            font-size: 14px;
        }

        .ul_main .li_list .a_box .p_mian .span_name {
            margin-right: .8rem;
            color: #a6a6a6;
        }

        .ul_main .li_list .a_box .p_mian .span_bottom {
            color: #db4b42;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current">
            <!-- 你的html代码 -->
            <header class="bar bar-nav">
                <!-- <p class="add_wuliu">
                    <a class="add_icon icon iconfont icon-plus pull-right" href="index.html"></a>
                    <i class="add_txt">添加物流</i>
                </p> -->
                <h1 class="title">我的</h1>
            </header>

            <nav class="bar bar-tab">
                <a class="tab-item external " href="/LC/MenuBar/LC_BusinessIndex.aspx">
                  <span class="icon iconfont icon-filetexto"></span>
                  <span class="tab-label">物流业务</span>
              </a>
                <a class="tab-item external" href="/LC/MenuBar/OperationCountIndex.aspx">
                  <span class="icon iconfont icon-fcstubiao19"></span>
                  <span class="tab-label">运营统计</span>
              </a>
                <a class="tab-item external" href="/manage/index.html">
                  <span class="icon iconfont icon-guanli"></span>
                  <span class="tab-label">物流管理</span>
              </a>
                <a class="tab-item external active" href="/LC/MenuBar/Personal.aspx">
                  <span class="icon iconfont icon-user-circle"></span>
                  <span class="tab-label">我的</span>
              </a>
            </nav>
            <div class="content" style="background:#f2f2f2;">
                <div class="page-index">
                    <%--内容--%>
                </div>


            </div>
        </div>
    </div>

   <script type="text/javascript" src="/Style/scripts/all.js" charset='utf-8'></script>

    <script>
        $(function () {
            $.init();
            $.config = { router: false }
        });

        PageInit(function () {
            GetHTML("GetLoginData", {}, function (data) {
                debugger;
                if (CheckHTMLData(data)) {
                    let html = TempToHtml("page-index-temp", data.data);
                    $(".page-index").html(html);
                }
            });
        });
    </script>
    <script id="page-index-temp" type="text/html">
        <div class="header">
            <div class="header_main">
                <img src="{{HeadPic}}"><i>{{NickName}}</i>
            </div>
        </div>
        <ul class="ul_main">
            <li class="li_list">
                <p class="li_title">账户总览</p>
                <a class="a_box" href="#">
                    <div>
                        <p class="p_mian"><span class="span_name">今日结余</span><span class="span_top">￥192020.21</span></p>
                        <p class="p_mian"><span class="span_name">昨日收款</span><span class="span_bottom">￥192020</span></p>
                    </div>
                    <i class="iconfont icon-angle-right"></i>
                </a>
            </li>
            <li class="li_list">
                <p class="li_title">收支概况</p>
                <a class="a_box" href="#">
                    <div>
                        <p class="p_mian"><span class="span_name">本月支出</span><span class="span_top">￥192020.21</span></p>
                        <p class="p_mian"><span class="span_name">本月收款</span><span class="span_bottom">￥192020</span></p>
                    </div>
                    <i class="iconfont icon-angle-right"></i>
                </a>
            </li>
            <li class="li_list">
                <p class="li_title">应收应付</p>
                <a class="a_box" href="#">
                    <div>
                        <p class="p_mian"><span class="span_name">本月应收</span><span class="span_top">￥192020.21</span></p>
                        <p class="p_mian"><span class="span_name">本月应付</span><span class="span_bottom">￥192020</span></p>
                    </div>
                    <i class="iconfont icon-angle-right"></i>
                </a>
            </li>
        </ul>
    </script>
</body>

</html>
