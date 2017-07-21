$.LoginOkFun = function () {
    //检测我的权限
    GetHTML("GetToRegUser", {}, function (data) {
        if (CheckHTMLData(data)) {
            let IsReg = data.data.IsReg;
            let ZType = data.data.ZType;
            if (!IsReg) { //如果没有注册则显示需要注册的界面

                //获取省列表
                GetHTML("GetAddressNextList", { id: 1 }, function (csdata) {
                    debugger;
                    if (CheckHTMLData(csdata)) {
                        let html = "账号类型错误!";
                        data.shenglist = csdata.data;
                        switch (ZType) {
                            case 1: //物流注册
                                html = TempToHtml("wlzc", data);
                                break;
                            case 3: //普通用户账号
                                html = TempToHtml("hyzc", data);
                                break;
                            case 4: //物流员工账号
                                html = TempToHtml("ygzc", data);
                                break;
                        }
                        $("#content").html(html);

                    }
                });
            }
            else {
                //如果已注册
                switch (ZType) {
                    case 1: //物流注册
                        Href("/LC/MenuBar/LC_BusinessIndex.aspx");
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