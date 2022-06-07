namespace WebApp.Models
{
    public class DaysChecked
    {
        public DateTime date { get; set; }
        public string[] blocks { get; set; }

        public DaysChecked()
        {

        }

        public DaysChecked(DateTime Date)
        {
            
            date = Date;
            blocks = new string[8];
            
        }

    }
}
