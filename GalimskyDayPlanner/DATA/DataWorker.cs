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
                Console.WriteLine(GetDate(file));
                StreamReader reader = new StreamReader(file);
                while((line = reader.ReadLine()) != null){
                    //Console.WriteLine(line);
                    TaskTmp task = new TaskTmp();
                    task = GetTask(line);
                    //Console.WriteLine(task);
                    counter++;
                }
                reader.Close();
                Console.WriteLine();

                
            }
        }
        //ключ получили
        private string GetDate(string str)
        {
            int count=0;
            int k=0;
            string searchStr = "__.";
            StringBuilder sb = new StringBuilder();
            for(int i=1;i < str.Length; i++)
            {
                if (str[i] == searchStr[k])
                {
                    string tmp = str.Substring(i - (count-1), count-1);
                    sb.Append(tmp);
                    count = 0;
                    k++;
                    if (k >= searchStr.Length)
                        break;
                }
                count++;
            }
            return sb.ToString();
        }
        private TaskTmp GetTask(string str)
        {
            string searchStr = "::";
            int count = 0;
            int k = 0;
            TaskTmp task = new TaskTmp();
            for(int i=0; i<str.Length; i++)
            {
                if (str[i] == searchStr[k])
                {
                    string tmp = str.Substring(i - count, count);
                    count = 0;
                    Console.WriteLine(tmp);
                    /*
                    switch (k)
                    {
                        case 0:
                            task.SetTask(tmp);
                            break;
                        case 1:
                            task.SetNum(tmp);
                            break;
                        case 2:
                            task.SetDone(tmp);
                            break;
                        default:
                            break;
                    }
                    */
                    k++;
                    if (k >= searchStr.Length)
                        break;
                }
                count++;
            }
            return task;
        }
    }

    public class TaskTmp
    {
        public string task;
        public int num;
        public bool isDone;
        

        public void SetTask(string str)
        {
            task = str;
        }
        public void SetNum(string str)
        {
            num = Int32.Parse(str);
        }
        public void SetDone(string str)
        {
            if (str[0] == '1')
                isDone = true;
            else
                isDone = false;
        }

        public override string ToString()
        {
            return task + " | " + num + " | " + isDone;
        }
    }
}

/* энкрипт здесь хорошо работает, надо запомнить
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
