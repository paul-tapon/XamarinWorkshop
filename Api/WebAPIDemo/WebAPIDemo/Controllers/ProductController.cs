using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ProductController : ApiController
    {
        public IHttpActionResult Get()
        {
            var context = new WebApiDemoContext();
            return Ok(context.Products.ToList());
        }

        [Route("api/product/filter")]
        public IHttpActionResult Get(string field,string value,string sortField,string sortDir)
        {
            var context = new WebApiDemoContext();

            IQueryable<Product> query = context.Products;

            if (field.ToUpper() == "CATEGORY")
            {
                query = query.Where(p => p.Category == value);
            }
            else if (field.ToUpper() == "DESCRIPTION")
            {
                query = query.Where(p => p.Description.Contains(value));
            }
            else if (field.ToUpper() == "NUMBER")
            {
                query = query.Where(p => p.ProductNumber == value);
            }
            else
            {
                throw new Exception("Field is not available for filtering...");
            }

            if (sortField.ToUpper() == "NAME")
            {
                if (sortDir.ToUpper() == "ASC")
                    query = query.OrderBy(p => p.Name);
                else
                    query = query.OrderByDescending(p => p.Name);
            }
            else if (sortField.ToUpper() == "PRICE")
            {
                if (sortDir.ToUpper() == "ASC")
                    query = query.OrderBy(p => p.UnitPrice);
                else
                    query = query.OrderByDescending(p => p.UnitPrice);
            }
            else
            {
                query = query.OrderBy(p => p.ProductId);
            }

            var responseData = query.Select(p=>new { p.ProductId,p.Name,p.Category,p.Description }).ToList();

            return Ok(responseData);
        }

    }
}