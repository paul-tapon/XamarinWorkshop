using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinDemo.Models;

namespace XamarinDemo.Services
{
    public class ProductDataStore : IDataStore<Product>
    {
        private List<Product> _products = null;

        public ProductDataStore()
        {
            _products = new List<Product>();
        }
        public Task<bool> AddItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            var client = new RestClient(ApiUrl);
            var request = new RestRequest("product", DataFormat.Json);
            request.Method = Method.GET;

            var response = await client.ExecuteAsync(request);
            var responseData = JsonConvert.DeserializeObject<List<Product>>(response.Content);
         
            return await Task.FromResult(responseData);
        }

        public Task<bool> UpdateItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        private string ApiUrl
        {
            get
            {
                return "https://10.0.2.2:45456/api";
            }
        }
    }
}
