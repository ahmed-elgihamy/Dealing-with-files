using System.IO.Compression;

namespace fileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {

          
        }
        static void Exm1()
        {
            string path = "C:\\Users\\Ahmed Mahmoud\\OneDrive\\Desktop\\testfile.txt";

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine($"Length: {fs.Length}"); // Total size of the file in bytes
                Console.WriteLine($"CanWrite: {fs.CanWrite}"); // Whether the stream supports writing
                Console.WriteLine($"CanRead: {fs.CanRead}"); // Whether the stream supports reading
                Console.WriteLine($"CanSeek: {fs.CanSeek}"); // Whether the stream supports seeking (changing position)
                Console.WriteLine($"CanTimeout: {fs.CanTimeout}"); // Whether the stream supports timeouts (usually false for file streams)
                Console.WriteLine($"Position: {fs.Position}"); // Current position within the stream
            }
        }

        static void Exm3()
        {
            string path = "D:\\demy_data\\f1.txt";

            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
               
                byte[] buffer = new byte[fs.Length];

                int numBytesToRead= (int)fs.Length;
                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {

                    int n = fs.Read(buffer,numBytesRead,numBytesToRead);    

                    if (n == 0)
                        break;

                    numBytesToRead -= n;
                    numBytesRead += n;
                }

                foreach (var b in buffer)
                    Console.WriteLine((char)b);





                string newpath = "D:\\demy_data\\f3.txt";
                using (var fsn = new FileStream(newpath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fsn.Write(buffer ,0,numBytesRead  );
                }

            }
        }

       //=========================================================== Adopters
        static void StreamWriter()

        {
            string path = "D:\\demy_data\\f7.txt";

            using (var fsw = new StreamWriter(path))
            {

                fsw.WriteLine("Ahmed Mahmoud ");
            }
        }

        static void StreamReaderAndPeek()

        {
            string path = "D:\\demy_data\\f7.txt";

            using (var str = new StreamReader(path))
            {
                while (str.Peek() > 0)
                {
                
                    Console.WriteLine((char)str.Read());
                }
            }
        }
        static void StreamReaderAndReadLine()

        {
            string path = "D:\\demy_data\\f7.txt";

            using (var str = new StreamReader(path))
            {
                string Line;
                while (( Line =str.ReadLine()) is not null)
                {

                    Console.WriteLine(Line);
                }
            }
        }
     //============================================================= Decorator
        static void WriteAllLines()

        {
            string path = "D:\\demy_data\\f9.txt";
            string [] lines = { " owen", "sucess" };

            File.WriteAllLines(path,lines);
        }
        static void WriteAllText()

        {
            string path = "D:\\demy_data\\f9.txt";
            string text = "owen";

            File.WriteAllText(path,text);   
        }
        static void ReadAllText()

        {
            string path = "D:\\demy_data\\f8.txt";
            
            string text = File.ReadAllText(path);
            Console.WriteLine(text);



        }
        static void CompressionMode()
        {
            // Compress data and write to file
            using (var str = File.Create("D:\\demy_data\\data.bin"))
            {
                using (var ds = new DeflateStream(str, System.IO.Compression.CompressionMode.Compress))
                {
                    ds.WriteByte(65);
                    ds.WriteByte(66);
                }
            }

            // Decompress data and read from file
            using (var stream = File.OpenRead("D:\\demy_data\\data.bin"))
            {
                using (var ds = new DeflateStream(stream, System.IO.Compression.CompressionMode.Decompress))
                {
                    int byteRead;
                    while ((byteRead = ds.ReadByte()) != -1)
                    {
                        Console.WriteLine(byteRead);
                    }
                }
            }

        
        }
        static void Deletefile()
        {
            try
            {
                File.Delete("D:\\demy_data\\data.bin");
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
        static void CopyFile()
        {
            try
            {
                string sourcePath = "D:\\demy_data\\data.bin";
                string destinationPath = "D:\\backup\\data_copy.bin";

                File.Copy(sourcePath, destinationPath, true); // true تعني استبدال الملف إذا كان موجودًا
                Console.WriteLine("File copied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }
        static void MoveFile()
        {
            try
            {
                string sourcePath = "D:\\demy_data\\data.bin";
                string destinationPath = "D:\\new_location\\data.bin";

                File.Move(sourcePath, destinationPath);
                Console.WriteLine("File moved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving file: {ex.Message}");
            }
        }
        static void CreateFile()
        {
            try
            {
                string filePath = "D:\\demy_data\\new_file.txt";
                File.WriteAllText(filePath, "Hello, this is a test file.");
                Console.WriteLine("File created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }
        static void CheckIfFileExists()
        {
            string filePath = "D:\\demy_data\\data.bin";

            if (File.Exists(filePath))
                Console.WriteLine("File exists.");
            else
                Console.WriteLine("File does not exist.");
        }

    }
}
