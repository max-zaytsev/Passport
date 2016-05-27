namespace Passport1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passport")]
    public partial class Passport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeriesAndNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }

        public byte RegionOfIssueID { get; set; }

        public int SettlementOfIssueID { get; set; }

        [Required]
        [StringLength(200)]
        public string PassportIssuedBy { get; set; }

        [Required]
        [StringLength(10)]
        public string SubdivisionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PatronymicName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public bool Sex { get; set; }

        public byte CountryOfBirthID { get; set; }

        public byte RegionOfBirthID { get; set; }

        public int SettlementOfBirthID { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeOfRegistration { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfRegistration { get; set; }

        public byte RgionOfRegistrationID { get; set; }

        public int SettlementOfRegistrationID { get; set; }

        public int? StreetId { get; set; }

        [StringLength(5)]
        public string House { get; set; }

        [StringLength(10)]
        public string Building { get; set; }

        public short? Apartment { get; set; }

        [Required]
        [StringLength(200)]
        public string RegistredBy { get; set; }

        public virtual Country CountryOfBirth { get; set; }

        public virtual Region RegionOfIssue { get; set; }

        public virtual Region RegionOfBirth { get; set; }

        public virtual Region RegionOfRegistration { get; set; }

        public virtual Settlement SettlementOfBirth { get; set; }

        public virtual Settlement SettlementOfIssue { get; set; }

        public virtual Settlement SettlementOfRegistration { get; set; }

        public virtual Street Street { get; set; }
    }
}
