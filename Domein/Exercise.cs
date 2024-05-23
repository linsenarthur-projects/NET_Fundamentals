using System.ComponentModel.DataAnnotations;

namespace ProjectFitness.Domain;

public class Exercise
{
    public long Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [EnumDataType(typeof(BodyPart))]
    public BodyPart BodyPart { get; set; }
    public int? Weight { get; set; }
    public ICollection<MemberExercise> MembersExercises { get; set; }
    public Exercise()
    {
        MembersExercises = new List<MemberExercise>();
    }
}