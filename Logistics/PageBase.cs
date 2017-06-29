using CustomExtensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Tools;

namespace Logistics
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// GET POST列表
        /// </summary>
        protected Dictionary<string, string> _require_list = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Session列表
        /// </summary>
        protected Dictionary<string, object> _session_list = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        private bool _getpost_flag = false;


        /// <summary>
        /// 获取远程IP地址
        /// </summary>
        /// <returns></returns>

        public string GetIp()
        {
            try
            {
                return this.Request.UserHostAddress;
            }
            catch (Exception ex)
            {
                Tools.SaveLog.AddLog(ex.Message);
            }
            return string.Empty;
        }



        /// <summary>
        /// 获取Request中的数据
        /// </summary>
        /// <param name="_encoding"></param>
        /// <returns></returns>
        public string GetBody(Encoding _encoding = null)
        {
            try
            {
                Encoding encoding = _encoding ?? Encoding.UTF8;
                string html = string.Empty;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream, encoding))
                {
                    html = sr.ReadToEnd();
                }
                return html;
            }
            catch (Exception ex)
            {
                Tools.SaveLog.AddLog(ex.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取GET POST 的字符串数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            this.Init_GETPOST();
            string v = default(string);

            if (_require_list.ContainsKey(key))
            {
                _require_list.TryGetValue(key, out v);
                return v;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取数据并进行处理
        /// </summary>
        /// <param name="key"></param>
        /// <param name="makeFun"></param>
        /// <returns></returns>
        public string GetValue(string key, Func<string, string> makeFun)
        {
            string v = GetValue(key);
            if (makeFun != null)
                return makeFun(v);
            return v;
        }
        /// <summary>
        /// 获取数据并进行处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="makeFun"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public T GetValue<T>(string key, Func<T, T> makeFun, T _default = default(T))
        {
            var v = GetValue<T>(key, _default);
            if (makeFun != null)
                return makeFun(v);
            return v;
        }

        /// <summary>
        /// 获取除了字符串以外的任何GET POST 数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="_default">如果是空的返回指定默认值</param>
        /// <returns></returns>
        public T GetValue<T>(string key, T _default = default(T))
        {
            Init_GETPOST();
            string v = string.Empty;
            if (_require_list.ContainsKey(key))
            {
                _require_list.TryGetValue(key, out v);
            }
            else
            {
                return _default;
            }
            if (!string.IsNullOrEmpty(v))
            {
                try
                {
                    return v.ConvertData<T>();
                }
                catch (Exception ex)
                {
                    SaveLog.AddLog("强制转换数据错误" + ex.Message + " 内容:" + v + "转换为:" + typeof(T).Name + "类型", "强制数据类型转换错误");
                    return _default;
                }
            }
            else
            {
                return _default;
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void UnLogin()
        {
            this.SessionClear();
        }

        /// <summary>
        /// 初始化所有session
        /// </summary>
        protected void Init_Session()
        {
            string key = string.Empty;
            foreach (var v in Session)
            {
                if (v != null)
                {
                    key = v.ToString();
                    if (!_session_list.ContainsKey(key))
                    {
                        if (Session[key] != null)
                        {
                            _session_list.Add(key, Session[key]);
                        }
                        else
                        {
                            _session_list.Add(key, null);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 是否存在键值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HaveKey(string key)
        {
            return _require_list.ContainsKey(key);
        }


        public void SessionClear()
        {
            Session.Clear();
        }

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetSession(string name, object value)
        {
            Session[name] = value;
        }

        /// <summary>
        /// 获取Session数据
        /// </summary>
        /// <param name="key">要获取的键值</param>
        /// <param name="_cv">是否清空True获取后清空,False不做任何此操作</param>
        /// <returns></returns>
        public string GetSessionValue(string key, bool _cv = false)
        {
            Init_Session();
            object v = null;
            if (_session_list.ContainsKey(key))
            {
                _session_list.TryGetValue(key, out v);
                if (_cv)
                    _session_list.Remove(key);
            }
            return v?.ToString() ?? null;
        }


        /// <summary>
        /// 初始化GET和Post
        /// </summary>
        /// <param name="flag">如果为True则每次都重新初始化数据</param>
        internal void Init_GETPOST(bool flag = false)
        {
            if (flag)
                _require_list.Clear();
            if (_getpost_flag)
            {
                return;
            }
            NameValueCollection post_nvc = Request.Form;
            NameValueCollection get_nvc = Request.QueryString;
            string key = string.Empty;
            foreach (var v in post_nvc)
            {
                if (v != null)
                {
                    key = v.ToString();
                    if (!_require_list.ContainsKey(key))
                    {
                        _require_list.Add(key, post_nvc[key]);
                    }
                }
            }
            foreach (var v in get_nvc)
            {
                if (v != null)
                {
                    key = v.ToString();
                    if (!_require_list.ContainsKey(key))
                    {
                        _require_list.Add(key, get_nvc[key]);
                    }
                }
            }
        }
    }
}