namespace WebApp.Models
{
    public class DaysChecked
    {
        public DateTime date { get; set; }
        public bool[] blocks { get; set; }

        public DaysChecked()
        {

        }

        public DaysChecked(DateTime Date)
        {
            
            date = Date;
            blocks = new bool[8];
            
        }

    }
}
