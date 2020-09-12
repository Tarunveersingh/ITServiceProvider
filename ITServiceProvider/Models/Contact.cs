using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITServiceProvider.Models
{
    public class Contact
    {
        //global variable to pass the value textbox to database
        public String txtName { get; set; }
        public String txtEmail { get; set; }
        public String txtMessage { get; set; }
    }
}