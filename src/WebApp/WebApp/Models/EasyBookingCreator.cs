using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class EasyBookingCreator
    {
        public string role;
        public string classes;
        public string prettyRole;
        public string bookable;

        public EasyBookingCreator(string Role)
        {
            role = Role;
            classes = "buttonEmpty btncheck btn btn-outline-primary";
            prettyRole = "Empty";
            bookable = "true";

            switch (role)
            {
                case "Timetable":
                    classes = "buttonTT btncheck btn btn-outline-secondary";
                    prettyRole = "TT";
                    break;

                case "Student":
                    classes = "buttonStud btncheck btn btn-outline-success";
                    prettyRole = "Stud";
                    break;

                case "Prof":
                    classes = "buttonProf btncheck btn btn-outline-danger";
                    prettyRole = "Prof";
                    break;
            }
        }
        public EasyBookingCreator()
        {

        }

        public string getButton()
        {
            string ret = "<label class=\"buttonEmpty btn btn-outline-primary\" isChecked=\"false\" >Empty</label>";
            switch (role)
            {
                case "Timetable":
                    ret = "<label class=\"buttonTT btn btn-outline-secondary\" isChecked=\"false\" >TT</label>";
                    break;

                case "Student":
                    ret = "< label class=\"buttonStud btn btn-outline-success\" isChecked=\"false\" >Stud</label>";
                    break;

                case "Prof":
                    ret = "<label class=\"btn btn-outline - danger\" isChecked=\"false\" >Prof</label>";
                    break;
            }

            return ret;
        }

        /*
        public string getButton(bool Role)
        {
            string ret = "<label class=\"buttonEmpty btn btn-outline-primary\" isChecked=\"false\" bookable=\"" + Overbookable(Role) + "\">Empty</label>";
            switch (role)
            {
                case "Timetable":
                    ret = "<label class=\"buttonTT btn btn-outline-secondary\" isChecked=\"false\" bookable=\"" + Overbookable(Role) + "\">TT</label>";
                    break;

                case "Student":
                    ret = "< label class=\"buttonStud btn btn-outline-success\" isChecked=\"false\" bookable=\"" + Overbookable(Role) + "\">Stud</label>";
                    break;

                case "Prof":
                    ret = "<label class=\"btn btn-outline - danger\" isChecked=\"false\" bookable=\"" + Overbookable(Role) + "\">Prof</label>";
                    break;
            }

            return ret;
        }
        */

        public void Overbookable(string otherRole)
        {
            var ret = "true";
            switch (role)
            {
                case "Timetable":
                    ret = "false";
                    break;

                case "Prof":
                    ret = "false";
                    break;

                case "Student":
                    if (otherRole == "Student")
                    {
                        ret = "false";
                    }
                    break;
            }

            bookable = ret;
        }

        public static async Task<List<EasyBookingCreator[]>> CreateEasyBookingList(List<Day> days, List<Ticket> tickets, UserManager<IdentityUser> userMgr)
        {
            List<EasyBookingCreator[]> retList = new List<EasyBookingCreator[]>();

            foreach (var day in days)
            {
                EasyBookingCreator[] tempArr = new EasyBookingCreator[8];

                for (int i = 0; i < 8; i++)
                {
                    int id = day.getTicketId(i);
                    EasyBookingCreator newBooking = null;

                    if (id != 0)
                    {
                        Ticket ticket = null;
                        IdentityUser user = null;
                        IList<string> role = null;

                        foreach (var ticketItem in tickets)
                        {
                            if (ticketItem.id == id)
                            {
                                ticket = ticketItem;
                                break;
                            }
                        }

                        if (ticket != null)
                        {
                            user = await userMgr.FindByNameAsync(ticket.user);
                        }

                        if (user != null)
                        {
                            role = await userMgr.GetRolesAsync(user);
                        }

                        if (role != null)
                        {
                            newBooking = new EasyBookingCreator(role.ElementAt(0));
                        }
                    }
                    else
                    {
                        newBooking = new EasyBookingCreator("");
                    }

                    tempArr[i] = newBooking;
                }
                retList.Add(tempArr);
            }
            


            return retList;
        }
    }
}
