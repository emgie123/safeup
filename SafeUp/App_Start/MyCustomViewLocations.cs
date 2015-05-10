using System.Web.Mvc;

namespace SafeUp
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