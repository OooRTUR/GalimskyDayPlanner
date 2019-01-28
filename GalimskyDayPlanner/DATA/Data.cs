using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalimskyDayPlanner
{
    public static class Data
    {
        public static List<PhoneNumber> numbers = new List<PhoneNumber>();
        public static List<DayTasks> dayTasks = new List<DayTasks>(); //лист задач для каждого дня

       
    }

    public class DayTasks
    {
        public List<CalendTask> calendTasks; //задачи на день, их 19 штук

        public void SetExample()
        {
            calendTasks = new List<CalendTask>(19);
            Console.WriteLine(calendTasks.Capacity);
            for (int i = 0; i < calendTasks.Capacity; i++)
            {
                calendTasks.Add(new CalendTask());
                calendTasks.Last().text = "adadk" + i;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i < calendTasks.Count; i++)
            {
                sb.Append(calendTasks[i].text+Environment.NewLine);
            }
            return sb.ToString();
        }


    }

    public class CalendTask
    {
        public string text;
        public bool isDone;
    }
}
