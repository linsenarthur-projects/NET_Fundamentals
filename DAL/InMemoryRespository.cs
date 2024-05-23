using ProjectFitness.DAL;
using ProjectFitness.Domain;

namespace ProjectFitness.DAL;


public class InMemoryRespository : IRepository
{
    private readonly List<Member> _members;
    private readonly List<Fitness> _fitnesses;
    private readonly List<Exercise> _exercises;

    public InMemoryRespository()
    {
        _members = new List<Member>();
        _fitnesses = new List<Fitness>();
        _exercises = new List<Exercise>();
        
        Seed();
    }

    public void CreateMember(Member member)
    {
        member.Id = _members.Count + 1;
        _members.Add(member);
    }
    public IEnumerable<Member> ReadAllMembers()
    {
        return _members;
    }

    public IEnumerable<Member> ReadAllMembersWithFitness()
    {
        throw new NotImplementedException();
    }

    public Member ReadMember(long id)
    {
        return _members.Find(member => member.Id.Equals(id));
    }

    public IEnumerable<Member> ReadMembersByNameAndDateOfBirth(string name, DateTime? date)
    {
        ICollection<Member> result = new List<Member>();
        
        foreach (var member in _members)
        {
            if (name != null) //naam
            {
                if (date != null) //naam en datum gekend
                {
                    if (member.Name.Contains(name) && member.Birthdate == Convert.ToDateTime(date))
                    {
                        result.Add(member);
                    }
                }
                else // naam gekend, datum null
                {
                    if (member.Name.Contains(name))
                    {
                        result.Add(member);
                    }
                }
            }
            else //naam null
            {
                if (date != null) //naam null en datum gekend
                {
                    if (member.Birthdate == Convert.ToDateTime(date))
                    {
                        result.Add(member);
                    }
                }
                else //naam en datum null
                {
                    result.Add(member);
                }
            }
        }
        return result;
    }

    public void CreateExercise(Exercise exercise)
    {
        exercise.Id = _exercises.Count + 1;
        _exercises.Add(exercise);
    }
    public IEnumerable<Exercise> ReadAllExercises()
    {
        return _exercises.ToList();
    }

    public IEnumerable<Exercise> ReadAllExercisesWithMember()
    {
        throw new NotImplementedException();
    }

    public Exercise ReadExercise(long id)
    {
        return _exercises.Find(exercise => exercise.Id.Equals(id));
    }

    public IEnumerable<Exercise> ReadExercisesOfBodyPart(BodyPart bodyPart)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exercise> ReadExercisesOfBodyPart(string choice)
    {
        ICollection<Exercise> result = new List<Exercise>();
        var query = from exercises in _exercises
            where exercises.BodyPart == Enum.Parse<BodyPart>(choice)
            select exercises;
        
        foreach (var exercise in query)
        {
            result.Add(exercise);
        }

        return result;
    }
    
    public void CreateFitness(Fitness fitness)
    {
        fitness.Id = _fitnesses.Count + 1;
        _fitnesses.Add(fitness);
    }

    public IEnumerable<Fitness> ReadAllFitnesses()
    {
        return _fitnesses.ToList();
    }

    public Fitness ReadFitness(long id)
    {
        throw new NotImplementedException();
    }

    public MemberExercise ReadMemberExercise(Member member, Exercise exercise)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MemberExercise> ReadAllMemberExercise()
    {
        throw new NotImplementedException();
    }

    public void CreateMemberExercise(MemberExercise memberExercise)
    {
        throw new NotImplementedException();
    }

    public void RemoveMemberExercise(MemberExercise memberExercise)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exercise> ReadExercisesOfMember(int memberId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Member> ReadMembersOfExercise(int exerciseId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Member> ReadMembersOfFitness(int fitnessId)
    {
        throw new NotImplementedException();
    }


    private void Seed()
    {
        var m1 = new Member
        {
            Name = "Kobe Wouters",
            Birthdate = new DateTime(2002, 03, 21),
            BodyWeight = 75
        };
        CreateMember(m1);

        var m2 = new Member();
        m2.Name = "Thomas Verlinden";
        m2.Birthdate = new DateTime(2003, 05, 19);
        m2.BodyWeight = 68.5;
        CreateMember(m2);

        var m3 = new Member();
        m3.Name = "Senne David";
        m3.Birthdate = new DateTime(2003, 09, 04);
        m3.BodyWeight = 65;
        CreateMember(m3);

        var m4 = new Member();
        m4.Name = "Julie Heylen";
        m4.Birthdate = new DateTime(2004, 10, 02);
        m4.BodyWeight = 52.3;
        CreateMember(m4);
        
        var e1 = new Exercise();
        e1.Name = "Bench press";
        e1.BodyPart = BodyPart.Chest;
        e1.Weight = 80;
        CreateExercise(e1);

        var e2 = new Exercise();
        e2.Name = "Pull up";
        e2.BodyPart = BodyPart.Back;
        e2.Weight = null;
        CreateExercise(e2);

        var e3 = new Exercise();
        e3.Name = "Squat";
        e3.BodyPart = BodyPart.Legs;
        e3.Weight = 100;
        CreateExercise(e3);

        var e4 = new Exercise();
        e4.Name = "Dips";
        e4.BodyPart = BodyPart.Triceps;
        e4.Weight = null;
        CreateExercise(e4);
        
        var f1 = new Fitness();
        f1.Name = "KD sports";
        f1.Address = "Lierseweg 317D, 2200 Herentals";
        f1.Surface = 120;
        CreateFitness(f1);
    }
}