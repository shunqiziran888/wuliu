using System;
using Model.Model;
using CustomExtensions;
namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_User : BLLBase
    {
        public LC_User()
        {}
        /// <summary>
        /// ע���û�
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User)
        {
            //if (lC_User.UserName.StrIsNull())
            //    return new Tuple<bool, string>(false, "�ǳƲ���Ϊ��!");
            return DAL.DAL.LC_User.Add(lC_User);
        }
    }
}
