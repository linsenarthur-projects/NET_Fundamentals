using System.ComponentModel.DataAnnotations;
using ProjectFitness.Domain;

namespace ProjectFitness.UI_MVC.Models;

public class AddMemberViewModel : IValidatableObject
{
    public long Id { get; set; }
    [Required] [MinLength(3)] public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    [Range(40, 150)] public double BodyWeight { get; set; }
    public Fitness Fitness { get; set; }
    public ICollection<MemberExercise> MembersExercises { get; set; }

    public AddMemberViewModel()
    {
        MembersExercises = new List<MemberExercise>();
        Fitness = new Fitness();
    }

    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (this.Birthdate > DateTime.Now)
        {
            results.Add(
                new ValidationResult("Date should not be in the future !",
                    new string[] { "Birthdate" }));
        }

        return results;
    }
}