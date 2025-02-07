using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCMoment.Models;
using System.IO;

namespace MVCMoment.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        public ActionResult Books()
        {



            var jsonStr = System.IO.File.ReadAllText("wwwroot/data/allBooks.json");

            

            var BooksObj = JsonConvert.DeserializeObject<List<Book>>(jsonStr);


            return View(BooksObj);
        }

        
        public ActionResult AddRead(Book book)
        {

            var jsonAdd = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");
            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonAdd);


            ReadObj.Add(book);

            var updatedJson = JsonConvert.SerializeObject(ReadObj);
            System.IO.File.WriteAllText("wwwroot/data/readBooks.json", updatedJson);

             return RedirectToAction("Read");
        }


          public ActionResult Read()
        {


            var jsonRead = System.IO.File.ReadAllText("wwwroot/data/readBooks.json");

            

            var ReadObj = JsonConvert.DeserializeObject<List<Book>>(jsonRead);


            return View(ReadObj);
        }


    }
}
