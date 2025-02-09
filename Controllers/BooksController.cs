using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCMoment.Models;
using System.IO;

namespace MVCMoment.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Books()
        {



            var jsonStr = System.IO.File.ReadAllText("wwwroot/data/allBooks.json");

            

            var BooksObj = JsonConvert.DeserializeObject<List<Book>>(jsonStr);
            
           


            return View(BooksObj);
        }

        
          public ActionResult Read()
        {


            var jsonRead = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");

            

            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonRead);


            return View(ReadObj);
        }

        
        public ActionResult AddRead(Book onebook)
        {

            var jsonAll = System.IO.File.ReadAllText("wwwroot/data/allBooks.json");
            var AllObj = JsonConvert.DeserializeObject<List<Book>>(jsonAll) ?? new List<Book>();

            var jsonAdd = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");
            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonAdd) ?? new List<Book>();


            ReadObj.Add(onebook);

            

            AllObj.RemoveAll(b => b.Title == onebook.Title);

            var updatedRead = JsonConvert.SerializeObject(ReadObj);
            var updatedAll = JsonConvert.SerializeObject(AllObj);

            System.IO.File.WriteAllText("wwwroot/data/allBooks.json", updatedAll);
            System.IO.File.WriteAllText("wwwroot/data/readBooks.json", updatedRead);
            
            ViewBag.Message = $" {onebook.Title} har lagts till i lästa böcker";

             return View("Books", AllObj);
        }




    }
}
