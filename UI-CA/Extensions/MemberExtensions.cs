using ProjectFitness.Domain;

namespace ProjectFitness.UI_CA.Extensions;

public static class MemberExtensions
{
    public static String StringRepresentation(this Member member)
    {
        var text = $"{member.Id} - {member.Name,-18}- {member.Birthdate:dd-MM-yyyy} - {member.BodyWeight,0:0.0} kg";
        return text;
    }
}