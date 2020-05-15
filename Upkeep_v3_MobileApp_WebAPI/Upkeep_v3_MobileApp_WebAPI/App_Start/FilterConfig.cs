using System.Web;
using System.Web.Mvc;

namespace Upkeep_v3_MobileApp_WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
