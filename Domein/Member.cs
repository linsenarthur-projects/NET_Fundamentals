using System.ComponentModel.DataAnnotations;

namespace ProjectFitness.Domain;

public class Member : IValidatableObject
{
    public long Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    [Range(40, 150)]
    public double BodyWeight { get; set; }
    public Fitness Fitness { get; set; }
    public ICollection<MemberExercise> MembersExercises { get; set; }
    public Member()
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