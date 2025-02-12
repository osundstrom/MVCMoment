using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCMoment.Models;
using System.IO;

namespace MVCMoment.Controllers
{
    //Kontroller books
    public class BooksController : Controller
    {

        //Metod för alla böcker
        public ActionResult Books()
        {
            //json med alla böcker
            var jsonStr = System.IO.File.ReadAllText("wwwroot/data/allBooks.json");

            //Deserialiserar json till lista med objekt efter Book model
            var BooksObj = JsonConvert.DeserializeObject<List<Book>>(jsonStr);

            //Returnerar vyn och skickar med BooksObj
            return View(BooksObj);
        }

        //metod för lästa böcker
          public ActionResult Read()
        {

            //json med Lästa böcker
            var jsonRead = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");

            //Deserialiserar json till lista med objekt efter Book model
            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonRead);

             //Returnerar vyn och skickar med ReadObj
            return View(ReadObj);
        }

        //Metod för att lägga till bok från alla böcker till lästa
        public ActionResult AddRead(Book onebook)
        {
            //Läser in  json fil allBooks
            var jsonAll = System.IO.File.ReadAllText("wwwroot/data/allBooks.json");

            //Deserialiserar json till lista med objekt efter Book model, ?? new List<Book>() ifall null värde
            var AllObj = JsonConvert.DeserializeObject<List<Book>>(jsonAll) ?? new List<Book>();

            //Läser in json readBooks
            var jsonAdd = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");

            //Deserialiserar json till lista med objekt efter Book model, ?? new List<Book>() ifall null värde
            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonAdd) ?? new List<Book>();

            //Lägger till i readBooks och tar bort får allBooks
            ReadObj.Add(onebook);
            AllObj.RemoveAll(b => b.Title == onebook.Title);

            //Till json
            var updatedRead = JsonConvert.SerializeObject(ReadObj);
            var updatedAll = JsonConvert.SerializeObject(AllObj);

            //Sparar till json filerna
            System.IO.File.WriteAllText("wwwroot/data/allBooks.json", updatedAll);
            System.IO.File.WriteAllText("wwwroot/data/readBooks.json", updatedRead);
            
            //Skickar viewbag med meddelande
            ViewBag.Message = $" {onebook.Title} har lagts till i lästa böcker";

            //Returnerar till books och skickar mednya listan med böcker
             return View("Books", AllObj);
        }




    }
}
