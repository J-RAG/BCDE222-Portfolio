using System;
using System.IO;
using System.Text;

namespace UsingFileInConsoleApp
{
    class Program
    {
        public const string FilePath = @".\TestFile.txt";

        private static void UsingStatementDemo()
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.io.file.opentext?view=net-6.0
            // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file?redirectedfrom=MSDN

            //if (!File.Exists(FilePath))
            //{
            //    // Create the file.
            //    using (FileStream fs = File.Create(FilePath))
            //    {
            //        Byte[] info =
            //            new UTF8Encoding(true).GetBytes("This is some text in the file.");

            //        // Add some information to the file.
            //        fs.Write(info, 0, info.Length);
            //    }
            //}

            try
            {
                // using statement
                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(FilePath))
                {
                    string? s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }

                    //// Null-conditional operators ?. 
                    //// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
                    //sr?.Dispose();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static void UsingDeclarationDemo()
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file?redirectedfrom=MSDN

            // Create a string array with the additional lines of text
            string[] lines = { "New line 1", "New line 2" };

            // Set a variable to the Desktop path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // using declaration
            // Write the string array to a new file named "WriteLines.txt".
            using StreamWriter outputFile = new(Path.Combine(docPath, FilePath));
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }

        public static void Main()
        {
            UsingStatementDemo();
            UsingDeclarationDemo();
        }
    }
}
