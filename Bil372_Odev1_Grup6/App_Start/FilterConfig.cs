using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
