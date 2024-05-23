using System.ComponentModel.DataAnnotations;

namespace ProjectFitness.Domain;

public class MemberExercise
{
    public long Id { get; set; }
    [Required]
    public Exercise Exercise { get; set; }
    [Required]
    public Member Member { get; set; }
    [Range(1, 99)]
    public int Reps { get; set; }
    [Range(1, 99)]
    public int Sets { get; set; }
}