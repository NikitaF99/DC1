using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registry.Models
{
    public class PublishModel
    {
        //Variables along with respective getters and setters are created
        public String Name { get; set; }

        public String Description { get; set; }

        public String Api_endpoint { get; set; }

        public int number_of_operands { get; set; }

        public String operand_type { get; set; }

        public int id { get; set; }
    }
}