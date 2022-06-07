namespace WebApp.Models
{
    public class BookingClass
    {
        public Room room { get; set; }
        public DaysChecked[] days  { get; set; }

        public BookingClass()
        {
            days = new DaysChecked[14];

            DateTime date = DateTime.Now;
            date = new DateTime(date.Year, date.Month, date.Day);

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new DaysChecked(date);
                date = date.AddDays(1);
            }
        }
    }
}
