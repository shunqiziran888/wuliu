using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    [SuperDataBase.DataBaseAttribute.DataModelOtherName(typeof(LC_Line))]
    public class LC_Line_Other : LC_Line
    {
        public string StartCityName { get; set; }
        public string EndCityName { get; set; }
        public string UserName { get; set; }
    }
}
