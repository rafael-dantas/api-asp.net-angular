using System.Web;
using System.Web.Mvc;

namespace Rafael.LocalizaAmigos.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
