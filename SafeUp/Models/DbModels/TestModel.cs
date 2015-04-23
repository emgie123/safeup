using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeUp.Models.DBAL.Interfaces;
using SafeUp.Models.DBAL.Abstraction;

namespace SafeUp.Models.DbModels
{
    public class TestModel : Table
    {

        public TestModel()
        {
            //  ogólnie dodawany tutaj do słownika za każdym razem klucz (key) jest trochę chujowy, bo i tak nazwa i warość danej kolumny
            //  przechowywane są w wartości słownika (value). musimy tak coś pomyślę, by zastąpić klucz czymś bardziej uniwersalnym albo 
            //  lepszym bo póki co powtarzamy dane.
            this.TableName = "test";

            //ogólnie dodawanie danych do tabeli już działa, ale wydaje mi się, że to jest trochę chujowe jak musimy w modelu dodawać elementy
            //do słownika po czym dopiero zatwierdzać inserta. Jutro musimy to obmyśleć. Aha nie robiłem autoincrementa id bo nie wiem czy
            //nie przemodelujemy tego tam :)
            this.Row.Add("id", new Column<object>("id", 1));
            this.Row.Add("nazwa", new Column<object>("nazwa", "sdas"));
        }

 

    }
}