<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doc.aspx.cs" Inherits="Logistics.doc.doc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文档生成页面</title>
    <style type="text/css">
        .auto-style1 {
            width: 508px;
        }
        .auto-style3 {
            width: 188px;
            height: 22px;
        }
        .auto-style4 {
            height: 22px;
        }
    </style>
</head>
<body>
    <table width="100%" border="1">
        <tbody>
            <tr style="font-weight: 700">
                <td class="auto-style3">功能名称</td>
                <td class="auto-style4">命令ACTION</td>
                <td class="auto-style4">参数</td>
            </tr>
            <% if (dv.state == 1)
                {
                    foreach (var w in dv.data)
                    {
            %>
            <tr style="font-size:18px; background-color:#D3D3D3"; font-weight:800;">
                <td colspan="3"><%=w.Key %></td>
            </tr>
            <%
                foreach (var v in w.Value)
                {
            %>
            <tr style="font-size:12; font-weight:100">
                <td class="auto-style1"><%=v.docName %></td>
                <td><%=v.docKey %></td>
                <td>
                    <% foreach (var p in v.inputDocList)
                        {
                    %>
                    <table border="1" style="margin: 10px">
                        <tr style="font-size: 12px">
                            <td><%=p.description %></td>
                            <td><%=p.key %></td>
                        </tr>
                    </table>
                    <%} %>
                </td>
            </tr>
            <% 
                        }
                    }
                } %>
        </tbody>
    </table>

</body>
</html>
