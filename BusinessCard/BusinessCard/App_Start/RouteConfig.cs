using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace BusinessCard
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.EnableFriendlyUrls();
            routes.MapPageRoute("BusinessCardCreate", "BusinessCard/Upload", "~/Pages/BC_Pages/Create.aspx");
            routes.MapPageRoute("SearchBusinessCardByCompany", "BusinessCard/SearchBusinessCardByCompany", "~/Pages/BC_Pages/Search.aspx");
            routes.MapPageRoute("RootDefault", "", "~/Pages/BC_Pages/Start.aspx");
            routes.MapPageRoute("Default", "BusinessCard/Start", "~/Pages/BC_Pages/Start.aspx");
            routes.MapPageRoute("BusinessCardList", "BusinessCard/ListAll", "~/Pages/BC_Pages/PersonList.aspx");
            routes.MapPageRoute("BusinessCardUpdate", "BusinessCard/{id}/Update", "~/Pages/BC_pages/Update.aspx");
        }
    }
}
