using SuperCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CustomExtensions;
namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取文档
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetSysApiDoc), "获取文档")]
    public class CMD_GetSysApiDoc : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public CMD_GetSysApiDoc() : base(false) { }
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            Dictionary<string, List<object>> objList = new Dictionary<string, List<object>>();
            Assembly ass = Assembly.GetAssembly(this.GetType());
            bool b = false;
            foreach (Type t in ass.GetTypes())
            {
                b = false;
                if (t.IsClass)
                {
                    foreach (var p in t.GetInterfaces())
                    {
                        if (p.Name.StartsWith("ICommandBase"))
                        {
                            b = true;
                            break;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                    if (b)
                    {
                        var docAttr = t.GetCustomAttribute<SuperCommand.Attribute.DocAttribute>();

                        if (docAttr != null)
                        {
                            var doc = docAttr.GetDocToVO();
                            var inputDocList = t.GetCustomAttributes<SuperCommand.Attribute.InputDocAttribute>().Select((x) =>
                            {
                                var vo = x.GetDicToVO();
                                return new
                                {
                                    vo.key,
                                    vo.description
                                };
                            }).ToList();
                            var arr = t.FullName.StringToArray('.');
                            string fullName = arr?.GetIndexValue<string>(arr.Length - 2) ?? string.Empty;
                            //获取KEY
                            if (fullName.StrIsNotNull())
                            {
                                if (objList.TryGetValue(fullName, out List<object> dic))
                                {
                                    dic.Add(new
                                    {
                                        fullName = arr?.GetIndexValue<string>(arr.Length - 2) ?? string.Empty,
                                        docKey = doc.key.Replace("CMD_", ""),
                                        docName = doc.description,
                                        inputDocList
                                    });
                                }
                                else
                                {
                                    List<object> obj = new List<object>();
                                    obj.Add(new
                                    {
                                        fullName = arr?.GetIndexValue<string>(arr.Length - 2) ?? string.Empty,
                                        docKey = doc.key.Replace("CMD_", ""),
                                        docName = doc.description,
                                        inputDocList
                                    });
                                    objList.Add(fullName, obj);
                                }
                            }
                        }
                    }
                }
            }
            //输出权限列表
            return Show<TCommandState>(objList.OrderBy(x => x.Key));
        }
    }
}