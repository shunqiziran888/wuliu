<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Pick.aspx.cs" Inherits="Logistics.LC_Pick" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1">
            <thead>
                <tr>
                    <td>用户名称</td>
                    <td>职位</td>
                    <td>联系电话</td>
                    <td>注册时间</td>
                    <td>操作</td>
                </tr>
            </thead>
            <tbody>
                <%
                    foreach (var v in lists)
                    {
                  %>
                <tr>
                    <td><%=v.UserName %></td>
                    <td><%=v.PositionID %></td>
                    <td><%=v.Phone %></td>
                    <td><%=v.CreateTime %></td>
                    <td><a href="/LC/Line/LC_LineAdd.aspx?uID=<%=v.ID %>&uname=<%=v.UserName %>">选取</a></td>
                </tr>
                 <%} %>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
