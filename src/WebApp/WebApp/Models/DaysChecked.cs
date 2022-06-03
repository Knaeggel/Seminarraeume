namespace WebApp.Models
{
    public class DaysChecked
    {
        public DateTime date;
        public string[] blocks;

        public DaysChecked(DateTime Date)
        {
            date = Date;
            blocks = new string[8];
        }

    }
}
