﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClincaApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync > Product > ();
                    Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }

            return View();
        }
    }
}