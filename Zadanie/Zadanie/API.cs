using System;
using System.Net.Http;


namespace Zadanie {
    public class API {
        public static void APIConnect() {
            string ApiResponse = "";
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://catfact.ninja/fact");
            responseTask.Wait();
            if (responseTask.IsCompleted) {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();
                    
                    ApiResponse = messageTask.Result;
                    Console.WriteLine("Message from WebAPI: " + messageTask.Result);
                    Console.WriteLine("__________________\nPlik:\n");
                    FileManagement.FileCreationAndReading(ApiResponse);
                }
            }
        }
    }
}
