using System;
using Model.Model;
using CustomExtensions;
namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Line : BLLBase
    {
        public LC_Line()
        {}
        public static Tuple<bool,string> Add(Model.Model.LC_Line LC_Line)
        {
            return DAL.DAL.LC_Line.Add(LC_Line);
        }
    }
}
