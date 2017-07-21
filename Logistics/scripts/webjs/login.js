$.LoginOkFun = function () {
    //检测我的权限
    GetHTML("GetToRegUser", {}, function (data) {
        if (CheckHTMLData(data)) {
            let IsReg = data.data.IsReg;
            let ZType = data.data.ZType;

            let Lineletter = GET("Lineletter"); //运号字母
            let acctype = GET("acctype");//访问类型(注册时使用)
            let region = GET("region"); //职位
            let logistics = GET("logistics"); //物流UID
            let isbind = parseInt(GET("isbind")); //物流
            if (isNaN(isbind))
                isbind = 0;
            if (!IsReg) { //如果没有注册则显示需要注册的界面

                //获取省列表
                GetHTML("GetAddressNextList", { id: 1 }, function (csdata) {
                    let obj = {};
                    obj.logistics = logistics;
                    debugger;
                    if (CheckHTMLData(csdata)) {
                        let html = "账号类型错误!";
                        data.shenglist = csdata.data;
                        switch (ZType) {
                            case 1: //物流注册
                                if (StrIsNullOrEmpty(logistics)) {
                                    html = TempToHtml("wlzc", data); //物流总部注册
                                }
                                else {
                                    html = TempToHtml("fs_wlzc", data); //物流附属注册
                                }
                                $("#content").html(html);
                                debugger;
                                $("#regbtn").click(function () {
                                    obj.NickName = $("#NickName").val();
                                    obj.Phone = $("#Phone").val();
                                    obj.sheng = parseInt($("#sheng").val());
                                    obj.shi = parseInt($("#shi").val());
                                    obj.qu = parseInt($("#qu").val());
                                    obj.Lineletter = $("#Lineletter").val(); //货号首字母

                                    //货号首字母不能为空
                                    if (!StrIsNullOrEmpty(logistics)) {
                                        if (StrIsNullOrEmpty(obj.Lineletter)) {
                                            Msg("货号首字母不能为空!");
                                            return;
                                        }
                                    }

                                    if (StrIsNullOrEmpty(obj.NickName)) {
                                        Msg("昵称不能为空!");
                                        return;
                                    }

                                    if (StrIsNullOrEmpty(obj.Phone)) {
                                        Msg("电话不能为空!");
                                        return;
                                    }

                                    if (obj.sheng <= 0) {
                                        Msg("省ID不能为空!");
                                        return;
                                    }

                                    if (obj.shi <= 0) {
                                        Msg("市ID不能为空!");
                                        return;
                                    }

                                    if (obj.qu <= 0) {
                                        Msg("区ID不能为空!");
                                        return;
                                    }
                                    //注册物流账号
                                    GetHTML("BindUser", obj, function (data) {
                                        if (CheckHTMLData(data)) {
                                            Msg("注册成功!");
                                            OutSystem(function () {
                                                Href($.apiUrl + "/login/login.html?appid=" + getAppid());
                                            });
                                        }
                                    });
                                });
                                break;
                            case 3: //普通用户账号
                                html = TempToHtml("hyzc", data);
                                $("#content").html(html);
                                $("#regbtn").click(function () {
                                    obj.NickName = $("#NickName").val();
                                    obj.Phone = $("#Phone").val();
                                    obj.sheng = $("#sheng").val();
                                    obj.shi = $("#shi").val();
                                    obj.qu = $("#qu").val();
                                    if (StrIsNullOrEmpty(obj.NickName)) {
                                        Msg("昵称不能为空!");
                                        return;
                                    }
                                    if (StrIsNullOrEmpty(obj.Phone)) {
                                        Msg("电话不能为空!");
                                        return;
                                    }
                                    if (obj.sheng <= 0) {
                                        Msg("省ID不能为空!");
                                        return;
                                    }
                                    if (obj.shi <= 0) {
                                        Msg("市ID不能为空!");
                                        return;
                                    }
                                    if (obj.qu <= 0) {
                                        Msg("区ID不能为空!");
                                        return;
                                    }
                                    GetHTML("BindUser", obj, function (data) {
                                        if (CheckHTMLData(data)) {
                                            Msg("注册成功!");
                                            OutSystem(function () {
                                                Href($.apiUrl + "/login/login.html?appid=" + getAppid());
                                            });
                                        }
                                    });
                                });
                                break;
                            case 4: //物流员工账号
                                html = TempToHtml("ygzc", data);
                                $("#content").html(html);
                                $("#regbtn").click(function () {
                                    obj.NickName = $("#NickName").val();
                                    obj.Phone = $("#Phone").val();
                                    if (StrIsNullOrEmpty(obj.NickName)) {
                                        Msg("昵称不能为空!");
                                        return;
                                    }

                                    if (StrIsNullOrEmpty(obj.Phone)) {
                                        Msg("电话不能为空!");
                                        return;
                                    }
                                    
                                    GetHTML("BindUser", obj, function (data) {
                                        if (CheckHTMLData(data)) {
                                            Msg("注册成功!");
                                            OutSystem(function () {
                                                Href($.apiUrl + "/login/login.html?appid=" + getAppid());
                                            });
                                        }
                                    });
                                });
                                break;
                        }
                    }
                });
            }
            else {
                //如果已注册
                switch (ZType) {
                    case 1: //物流注册或线路绑定
                        if (isbind == 1 && !StrIsNullOrEmpty(logistics)) {
                            html = TempToHtml("linebind", {});
                            $("#content").html(html);
                            $("#regbtn").click(function () {
                                let _lineletter = $("#Lineletter").val();
                                if (StrIsNullOrEmpty(_lineletter)) {
                                    Msg("请选择一个货号字母!");
                                    return;
                                }
                                GetHTML("LineBinding", { logistics: logistics, lineletter: _lineletter }, function (data) {
                                    if (CheckHTMLData(data)) {
                                        Msg("绑定成功!");
                                        OutSystem(function () {
                                            Href($.apiUrl + "/login/login.html?appid=" + getAppid());
                                        });
                                    }
                                })
                            });
                        }
                        else {
                            Href("/LC/MenuBar/LC_BusinessIndex.aspx");
                        }
                        break;
                    case 3://普通用户账号
                        Href("/LC/Index/LC_IndexKH.aspx");
                        break;
                    case 4://物流员工账号
                        Href("/LC/MenuBar/LC_BusinessIndex.aspx");
                        break;
                }
            }
        }
    });
};

/**
 * 地区联动
 * @param {*} id 
 * @param {*} elename 
 */
function show(id, elename) {
    GetHTML("GetAddressNextList", { id: id }, function (data) {
        if (CheckHTMLData(data)) {
            let list = data.data;
            $("#" + elename).empty();
            $("#" + elename).append("<option>-请选择-</option>");
            for (let i = 0; i < list.length; i++) {
                $("#" + elename).append("<option value='" + list[i].id + "'>" + list[i].Name + "</option>");
            }
        }
    });
}