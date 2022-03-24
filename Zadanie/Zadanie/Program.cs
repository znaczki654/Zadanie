using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Zadanie {
    internal class Program {
        static void Main(string[] args) {
            //APIConnect();
            FileCreationAndReading();

            Console.ReadLine();
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
                }
            }
        }

        static void FileCreationAndReading() {
            string filePath = @"test.txt"; // literal string

            string test = "testujemy coś";

            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath)) {
                sw.WriteLine(test);
            }
            if (File.Exists(filePath)) {
                List<string> lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines) {
                    Console.WriteLine(line);
                }
            }
        }
    }

}
