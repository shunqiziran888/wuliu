using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL
{
    public class GlobalAddress
    {
        private static Dictionary<int, Model.Model.w_address_basic_data> addressDic = null;
        private static object _lockobj = new object();
        /// <summary>
        /// 获取地区数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Tuple<bool, Model.Model.w_address_basic_data> GetAddressFromID(int id)
        {
            lock(_lockobj)
            {
                Model.Model.w_address_basic_data lcr = null;

                if (addressDic == null)
                    addressDic = DAL.DAL.w_address_basic_data.GetAllAddress();

                if(addressDic.TryGetValue(id, out lcr))
                {
                    return new Tuple<bool, Model.Model.w_address_basic_data>(true, lcr);
                }
                return new Tuple<bool, Model.Model.w_address_basic_data>(false,null);
            }
        }

        
    }
}
