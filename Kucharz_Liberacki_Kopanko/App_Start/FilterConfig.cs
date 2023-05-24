using System.Web;
using System.Web.Mvc;

namespace Kucharz_Liberacki_Kopanko
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
