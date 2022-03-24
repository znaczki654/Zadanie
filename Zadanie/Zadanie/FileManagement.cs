using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie {
    public class FileManagement {
        public static void FileCreationAndReading(string ApiResponse) {
            string filePath = @"test.txt";
            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath)) {
                sw.WriteLine(ApiResponse);
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
