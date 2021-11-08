using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProvider.Models
{
    public class GeneratePrimeNumberstoValueModel
    {
        //the necessary variables along with getters and setters are created
        public int num { get; set; }

        public int id { get; set; }
        public List<GeneratePrimeNumberstoValueModel> prime { get; set; } = null;
    }
}