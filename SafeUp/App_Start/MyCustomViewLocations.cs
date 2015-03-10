using System.Web.Mvc;

namespace SafeUp.App_Start
{
    public class MyCustomViewLocations : RazorViewEngine
    {
        public MyCustomViewLocations()
        {
            ViewLocationFormats = new string[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}"
            };
            MasterLocationFormats = ViewLocationFormats;
            PartialViewLocationFormats = ViewLocationFormats;
        }

       
    }
}