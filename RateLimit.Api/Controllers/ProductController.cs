using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> Products = new List<Product>();
        public ProductController()
        {
            InitProducts();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Products);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(Products.Where(x => x.Name.ToLower().Contains(name.ToLower())));
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public void InitProducts()
        {
            Products.Add(new Product
            {
                Id = 1,
                Name = "Siemens A++ Buzdolabı",
                Price = 3500
            });
            Products.Add(new Product
            {
                Id = 2,
                Name = "Arçelik A++ Çamaşır Makinesi",
                Price = 2000
            });
        }
    }
}