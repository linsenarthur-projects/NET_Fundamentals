using ProjectFitness.Domain;

namespace ProjectFitness.UI_CA.Extensions;

public static class ExerciseExtensions
{
    public static String StringRepresentation(this Exercise exercise)
    {
        var text = "";
        if (exercise.Weight == null)
        {
            text += $"{exercise.Id} - {exercise.Name,-13} - {exercise.BodyPart,-10} -   0 kg";
        }
        else
        {
            text += $"{exercise.Id} - {exercise.Name,-13} - {exercise.BodyPart,-10} - {exercise.Weight,3:0} kg";    
        }
        return text;
    }
}