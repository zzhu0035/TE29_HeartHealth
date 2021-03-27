using System.Web;
using System.Web.Mvc;

namespace TE29_HeartHealth_GCardiac
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
