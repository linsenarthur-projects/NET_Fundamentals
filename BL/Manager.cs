using System.ComponentModel.DataAnnotations;
using ProjectFitness.DAL;
using ProjectFitness.Domain;

namespace ProjectFitness.BL;

public class Manager : IManager
{
    private readonly IRepository _repository;

    public Manager(IRepository repository)
    {
        _repository = repository;
    }

    public Member AddMember(string name, DateTime birthdate, double bodyweight)
    {
        var member = new Member
        {
            Name = name,
            Birthdate = birthdate,
            BodyWeight = bodyweight,
        };

        var validationContext = new ValidationContext(member);
        Validator.ValidateObject(member, validationContext, true);
        
        _repository.CreateMember(member);
        return member;
    }
    public IEnumerable<Member> GetAllMembers()
    {
        return _repository.ReadAllMembers();
    }

    public IEnumerable<Member> GetAllMembersWithFitness()
    {
        return _repository.ReadAllMembersWithFitness();
    }

    public Member GetMember(long id)
    {
        return _repository.ReadMember(id);
    }
    public IEnumerable<Member> GetMembersByNameAndDateOfBirth(string name, DateTime? date)
    {
        return _repository.ReadMembersByNameAndDateOfBirth(name, date);
    }

    public Exercise AddExercise(string name, BodyPart bodyPart, int weight)
    {
        var exercise = new Exercise
        {
            Name = name,
            BodyPart = bodyPart,
            Weight = weight
        };
        
        var validationContext = new ValidationContext(exercise);
        Validator.ValidateObject(exercise, validationContext, true);
        
        _repository.CreateExercise(exercise);
        return exercise;
    }
    public IEnumerable<Exercise> GetAllExercise()
    {
        return _repository.ReadAllExercises();
    }

    public IEnumerable<Exercise> GetAlleExercisesWithMember()
    {
        return _repository.ReadAllExercisesWithMember();
    }

    public Exercise GetExercise(long id)
    {
        return _repository.ReadExercise(id);
    }
    public IEnumerable<Exercise> GetExercisesOfBodyPart(BodyPart bodyPart)
    {
        return _repository.ReadExercisesOfBodyPart(bodyPart);
    }

    public void addFitness(string name, string address, int surface)
    {
        var fitness = new Fitness
        {
            Name = name,
            Address = address,
            Surface = surface
        };

        var validationContext = new ValidationContext(fitness);
        Validator.ValidateObject(fitness, validationContext, true);
        _repository.CreateFitness(fitness);
    }

    public IEnumerable<Fitness> GetAllFitnesses()
    {
        return _repository.ReadAllFitnesses();
    }

    public Fitness GetFitness(long id)
    {
        return _repository.ReadFitness(id);
    }

    public MemberExercise GetMemberExercise(Member member, Exercise exercise)
    {
        return _repository.ReadMemberExercise(member, exercise);
    }

    public IEnumerable<MemberExercise> GetAllMemberExercise()
    {
        return _repository.ReadAllMemberExercise();
    }

    public void AddMemberExercise(Exercise exercise, Member member, int reps, int sets)
    {
        var memberExercise = new MemberExercise
        {
            Exercise = exercise,
            Member = member,
            Reps = reps,
            Sets = sets
        };
        var validationContext = new ValidationContext(memberExercise);
        Validator.ValidateObject(memberExercise, validationContext, true);
        _repository.CreateMemberExercise(memberExercise);
    }

    public void DeleteMemberExercise(Member member, Exercise exercise)
    { 
        var memberExercise = _repository.ReadMemberExercise(member, exercise);
        _repository.RemoveMemberExercise(memberExercise);
    }

    public IEnumerable<Exercise> GetExercisesOfMember(int memberId)
    {
        return _repository.ReadExercisesOfMember(memberId);
    }

    public IEnumerable<Member> GetMembersOfExercise(int exerciseId)
    {
        return _repository.ReadMembersOfExercise(exerciseId);
    }

    public IEnumerable<Member> GetMembersOfFitness(int fitnessId)
    {
        return _repository.ReadMembersOfFitness(fitnessId);
    }
}