using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passport1.Models
{
    public class ShortPasportInfo
    {
        public int SeriesAndNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SettlementOfBirth { get; set; }
    }
}