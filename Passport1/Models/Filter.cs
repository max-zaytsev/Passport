using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passport1.Models
{
    public class Filter
    {
        public int? SeriesAndNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string RegionOfIssue { get; set; }
        public int? SettlementOfIssue { get; set; }
        public string PassportIssuedBy { get; set; }
        public string SubdivisionCode { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? Sex { get; set; }
        public String CountryOfBirth { get; set; }
        public string RegionOfBirth { get; set; }
        public string SettlementOfBirth { get; set; }
        public string TypeOfRegistration { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string RegionOfRegistration { get; set; }
        public int? SettlementOfRegistration { get; set; }
        public int? Street { get; set; }
        public string House { get; set; }
        public string Building { get; set; }
        public short? Apartment { get; set; }
        public string RegistredBy { get; set; }
    }
}