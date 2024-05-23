using System.ComponentModel.DataAnnotations;
using ProjectFitness.Domain;

namespace ProjectFitness.UI_MVC.Models.Dto;
public class AddMemberExercisesDto
{
    public long Id { get; set; }
    public int ExerciseId { get; set; }
    public int MemberId { get; set; }
    public int Reps { get; set; }
    public int Sets { get; set; }
}