using System;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Position : BLLBase
    {
        public LC_Position()
        {}

        public static (bool, string, object) GetPositionList(HttpContextBase web)
        {
            return DAL.DAL.LC_Position.GetPositionList();
        }
    }
}
