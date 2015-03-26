using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace App_Code
{
    [ValidationProperty("DateText")]
    public class MyCalendar : System.Web.UI.WebControls.Calendar
    {
        public string DateText
        {
            get
            {
                string dateString = this.SelectedDate.ToString("yyyy/MM/dd");
                //ASP.NET calendar control returns 0001/01/01 if no date is selected so return an empty string to the validation control for this scenario.
                if (dateString == "0001/01/01")
                    return "";
                return dateString;
            }
        }
    }
}