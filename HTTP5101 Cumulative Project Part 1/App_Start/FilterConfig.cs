﻿using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative_Project_Part_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
