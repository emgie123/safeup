using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeUp.Models.LoggedIn
{
    public class User
    {
        public List<File> FileList = new List<File>()
        {
            new File("Przygody Tomka Sawyera.pdf",new DateTime(2015,03,15),"tomek1985" ),
            new File("Forest Gump.avi",new DateTime(2015,05,25),"rzws" ),
            new File("Visual Studio.exe",new DateTime(2015,01,1),"fka" ),
            new File("Tomb Raider.exe",new DateTime(2014,09,22),"pp" ),
            new File("Projekt zespołowy.zip",new DateTime(2014,02,15),"j-cek132" ),
            new File("Król Lew.avi",new DateTime(2013,12,12),"tux" ),
            new File("Call of Duty.exe",new DateTime(2014,09,07),"ffsas" ),
            new File("CS:GO.exe",new DateTime(2015,01,10),"lfds" ),
 
        };

        public List<File> FileList2 = new List<File>()
        {
        
            new File("Projekt zespołowy.zip",new DateTime(2014,02,15),"j-cek132" ),
            new File("Głupi i głupszy.avi",new DateTime(2013,12,12),"tux" ),
            new File("Titanic.avi",new DateTime(2014,09,07),"ffsas" ),
            new File("Dying Light.exe",new DateTime(2015,01,10),"lfds" ),
 
        };





    }
}