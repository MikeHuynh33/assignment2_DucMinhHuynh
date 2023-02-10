using System.Web;
using System.Web.Mvc;

namespace assignment2_DucMinhHuynh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
