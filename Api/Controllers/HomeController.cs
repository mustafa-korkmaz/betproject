using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Business.WebApi;
using Business.WebApi.Tester;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            //  new ContextCreator().CreateDb(); // create db if not exists
            //todo: delete this method in release

            //var tester = new RivaloTester();

            //while (true)
            //{

            //    await tester.StartTesting();

            //    Thread.Sleep(10000 * tester.MinutesPerRequest);

            //}


            return View();
        }

    }
}
