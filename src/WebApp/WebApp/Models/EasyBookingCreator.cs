using Microsoft.AspNetCore.Identity;
using WebApp.Manager;

namespace WebApp.Models
{
    public class EasyBookingCreator
    {
        public UserRoles role;
        public string classes;
        public string prettyRole;
        public string bookable = "false";

        public EasyBookingCreator(UserRoles Role)
        {
            role = Role;
            classes = "buttonEmpty btncheck btn btn-outline-primary";
            prettyRole = "Empty";
            bookable = "true";

            switch (role)
            {
                case UserRoles.TimeTable:
                    classes = "buttonTT btncheck btn btn-outline-secondary";
                    prettyRole = "TT";
                    break;

                case UserRoles.Student:
                    classes = "buttonStud btncheck btn btn-outline-success";
                    prettyRole = "Stud";
                    break;

                case UserRoles.Prof:
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
                case UserRoles.TimeTable:
                    ret = "<label class=\"buttonTT btn btn-outline-secondary\" isChecked=\"false\" >TT</label>";
                    break;

                case UserRoles.Student:
                    ret = "< label class=\"buttonStud btn btn-outline-success\" isChecked=\"false\" >Stud</label>";
                    break;

                case UserRoles.Prof:
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

        public void Overbookable(UserRoles otherRole)
        {
            var ret = "false";
            
            switch (role)
            {
                case UserRoles.TimeTable:
                    ret = "false";
                    break;

                case UserRoles.Prof:
                    ret = "false";
                    break;

                case UserRoles.Student:
                    if (otherRole == UserRoles.Student)
                    {
                        ret = "false";
                    }
                    else
                    {
                        ret = "true";
                    }
                    break;
            }

            if (role == UserRoles.empty)
            {
                ret = "true";
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
                    int id = day.getTicketId(i+1);
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
                        
                        newBooking = new EasyBookingCreator(await RoleManagerP.getRole(userMgr, user));
                    }
                    else
                    {
                        newBooking = new EasyBookingCreator(UserRoles.empty);
                    }

                    tempArr[i] = newBooking;
                }
                retList.Add(tempArr);
            }
            


            return retList;
        }
    }
}
