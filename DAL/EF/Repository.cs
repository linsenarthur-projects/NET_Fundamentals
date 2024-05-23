using Microsoft.EntityFrameworkCore;
using ProjectFitness.Domain;

namespace ProjectFitness.DAL.EF;

public class Repository : IRepository
{
    private readonly FitnessDbContext _context;
    public Repository(FitnessDbContext context)
    {
        _context = context;
    }

    public void CreateMember(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
    }

    public IEnumerable<Member> ReadAllMembers()
    {
        IQueryable<Member> result = _context.Members;
        return result;
    }

    public IEnumerable<Member> ReadAllMembersWithFitness()
    {
        return _context.Members.Include(member => member.Fitness).AsEnumerable();
    }

    public Member ReadMember(long id)
    {
        return _context.Members.Include(member => member.MembersExercises)
            .ThenInclude(me => me.Exercise)
            .Single(member => member.Id == id);
    }

    public IEnumerable<Member> ReadMembersByNameAndDateOfBirth(string name, DateTime? date)
    {
        IQueryable<Member> result = _context.Members;
        
        
            if (name != null) //naam
            {
                if (date != null) //naam en datum gekend
                {
                    result = _context.Members.Where(member => member.Name.ToLower().Contains(name.ToLower()) && member.Birthdate == date);
                }
                else // naam gekend, datum null
                {
                    result = _context.Members.Where(member => member.Name.ToLower().Contains(name.ToLower()));
                }
            }
            else //naam null
            {
                if (date != null) //naam null en datum gekend
                {
                    result = _context.Members.Where(member => member.Birthdate == date);
                }
                else //naam en datum null
                {
                    result = _context.Members;
                }
            }
        
        return result;
    }

    public void CreateExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
    }

    public IEnumerable<Exercise> ReadAllExercises()
    {
        IQueryable<Exercise> result = _context.Exercises;
        return result;
    }

    public IEnumerable<Exercise> ReadAllExercisesWithMember()
    {
        return _context.Exercises.Include(exercise => exercise.MembersExercises)
            .ThenInclude(memberExercise => memberExercise.Member)
            .AsEnumerable();
    }

    public Exercise ReadExercise(long id)
    {
        return _context.Exercises.Find(id);
    }

    public IEnumerable<Exercise> ReadExercisesOfBodyPart(BodyPart bodyPart)
    {
        return _context.Exercises.Where(exercise => exercise.BodyPart.Equals(bodyPart));
    }

    public void CreateFitness(Fitness fitness)
    {
        _context.Fitnesses.Add(fitness);
        _context.SaveChanges();
    }

    public IEnumerable<Fitness> ReadAllFitnesses()
    {
        return _context.Fitnesses;
    }

    public Fitness ReadFitness(long id)
    {
        return _context.Fitnesses.Find(id);
    }

    public MemberExercise ReadMemberExercise(Member member, Exercise exercise)
    {
        return _context.MemberExercises.Single(memberExercise => memberExercise.Member == member 
                                                                 && memberExercise.Exercise == exercise);
    }

    public IEnumerable<MemberExercise> ReadAllMemberExercise()
    {
        return _context.MemberExercises.AsEnumerable();
    }

    public void CreateMemberExercise(MemberExercise memberExercise)
    {
        _context.MemberExercises.Add(memberExercise);
        _context.Members.Find(memberExercise.Member.Id).MembersExercises.Add(memberExercise);
        _context.Exercises.Find(memberExercise.Exercise.Id).MembersExercises.Add(memberExercise);
        _context.SaveChanges();
    }

    public void RemoveMemberExercise(MemberExercise memberExercise)
    {
        _context.MemberExercises.Remove(memberExercise);
        _context.Members.Find(memberExercise.Member.Id).MembersExercises.Remove(memberExercise);
        _context.Exercises.Find(memberExercise.Exercise.Id).MembersExercises.Remove(memberExercise);
        _context.SaveChanges();
    }

    public IEnumerable<Exercise> ReadExercisesOfMember(int memberId)
    {
        return _context.Exercises.Where(exercise =>
            exercise.MembersExercises.Any(memberExercise => memberExercise.Member.Id == memberId)).AsEnumerable();
    }

    public IEnumerable<Member> ReadMembersOfExercise(int exerciseId)
    {
        return _context.Members.Where(member =>
            member.MembersExercises.Any(memberExercise => memberExercise.Exercise.Id == exerciseId)).AsEnumerable();
    }

    public IEnumerable<Member> ReadMembersOfFitness(int fitnessId)
    {
        return _context.Members.Where(member => member.Fitness.Id == fitnessId);
    }
}