using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.utilities
{
    public static class Clear
    {
        public static void ClearControl(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                else if (control is Label)
                {
                    ((Label)control).Text = string.Empty;
                }
                ClearControl(control);
            }
        }
    }
}