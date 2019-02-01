using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalimskyDayPlanner
{
    public class DataWorker
    {
        private static DataWorker inst;
        private string dataDir;

        private DataWorker()
        { }

        public static DataWorker get()
        {
            if (inst == null)
                inst = new DataWorker();
            return inst;
        }

        public void Run()
        {
            Console.WriteLine(Environment.CurrentDirectory);
            dataDir = Path.Combine(Environment.CurrentDirectory, "DATA");
            if (Directory.Exists(dataDir))
                Console.WriteLine("Директория существует");
            else
                Directory.CreateDirectory(dataDir);

            //OverWriteAllFiles();
        }

        public void OverWriteAllFiles()
        {
            foreach (var item in Data.days)
            {
                string tmpPth = dataDir +@"\"+ "d"+item.Key + ".txt";
                Console.WriteLine(tmpPth);
                //writing to file
                
                using(FileStream fs = File.Open(tmpPth, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(item.Value.ToString());
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public void ReadAllFiles()
        {
            string[] files = Directory.GetFiles(dataDir, "d*.txt");
            
            foreach (var file in files) {
                int counter = 0;
                string line;
                Console.WriteLine(Path.GetFileName(file));
                StreamReader reader = new StreamReader(file);
                while((line = reader.ReadLine()) != null){
                    Console.WriteLine(line);
                    counter++;
                }
                reader.Close();
                Console.WriteLine();

                /*
                using (FileStream fs = File.Open(file,FileMode.Open,FileAccess.Read,FileShare.None))
                {
                    byte[] buffer;
                    int length = (int)fs.Length;  // get file length
                    buffer = new byte[length];            // create buffer
                    int count;                            // actual number of bytes read
                    int sum = 0;                          // total number of bytes read

                    // read until Read method returns 0 (end of the stream has been reached)
                    while ((count = fs.Read(buffer, sum, length - sum)) > 0)
                        sum += count;  // sum is a buffer offset for next reading
                    string res = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(res);
                }
                */
            }
        }


    }
}
