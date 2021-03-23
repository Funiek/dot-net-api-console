using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using ProductSender.Models;
using Newtonsoft.Json;
using System.Text;

namespace ProductSender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Product product = new Product();
            product.nazwa = "Chleb";
            product.cena = 2.50;
            await PostProduct(product);

        }

        private static async Task PostProduct(Product product)
        {
            string jsonProduct = JsonConvert.SerializeObject(product);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var response = await client.PostAsync("api/product", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));
            if(response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }
    }
}
