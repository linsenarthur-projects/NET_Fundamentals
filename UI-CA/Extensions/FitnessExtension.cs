using ProjectFitness.Domain;

namespace ProjectFitness.UI_CA.Extensions;

public static class FitnessExtension
{
    public static String StringRepresentation(this Fitness fitness)
    {
        var text = "";
        text += $"{fitness.Name}, {fitness.Address}, {fitness.Surface} m²";

        return text;
    }
}