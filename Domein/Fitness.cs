namespace ProjectFitness.Domain;

public class Fitness
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Surface { get; set; }

    public ICollection<Member> Members { get; set; }

    public Fitness()
    {
        Members = new List<Member>();
    }
}