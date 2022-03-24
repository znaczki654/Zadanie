using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Zadanie {
    internal class Program {
        static void Main(string[] args) {
            APIConnect();
        }



        static void APIConnect() {
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://catfact.ninja/fact");
            responseTask.Wait();
            if (responseTask.IsCompleted) {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();
                    Console.WriteLine("Message from WebAPI: " + messageTask.Result);
                    Console.ReadLine();
                }
            }
        }
    }
}
