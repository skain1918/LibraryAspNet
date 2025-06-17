using System.ComponentModel.DataAnnotations;

namespace LibraryAspNet.Data; 
public record Author {
    [Key]
    public int Id { get; set; }
    [MaxLength(20), Display(Name = "First Name")]
    public string? Name { get; set; }
    [MaxLength(30), Required, Display(Name = "Last Name")]
    public string Surname { get; set; }
    public string FullName => $"{Name} {Surname}";
    [Display(Name="Year of Birth")]
    public int? YearOfBirth { get; set; }
    [Display(Name = "Year of Death")]
        public int? YearOfDeath { get; set; }

    [DataType(DataType.MultilineText), Display(Name="About author (biography)")]
    public string? Biography { get; set; }

    }

