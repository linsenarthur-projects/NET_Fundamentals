#nullable enable
using ProjectFitness.Domain;

namespace ProjectFitness.DAL;

public interface IRepository
{
    void CreateMember(Member member);
    IEnumerable<Member> ReadAllMembers();
    IEnumerable<Member> ReadAllMembersWithFitness();
    Member ReadMember(long id);
    IEnumerable<Member> ReadMembersByNameAndDateOfBirth(string name, DateTime? date);

    void CreateExercise(Exercise exercise);
    IEnumerable<Exercise> ReadAllExercises();
    IEnumerable<Exercise> ReadAllExercisesWithMember();
    Exercise ReadExercise(long id);
    IEnumerable<Exercise> ReadExercisesOfBodyPart(BodyPart bodyPart);

    void CreateFitness(Fitness fitness);
    IEnumerable<Fitness> ReadAllFitnesses();
    public Fitness ReadFitness(long id);

    MemberExercise ReadMemberExercise(Member member, Exercise exercise);
    IEnumerable<MemberExercise> ReadAllMemberExercise();
    
    void CreateMemberExercise(MemberExercise memberExercise);
    void RemoveMemberExercise(MemberExercise memberExercise);
    IEnumerable<Exercise> ReadExercisesOfMember(int memberId);
    IEnumerable<Member> ReadMembersOfExercise(int exerciseId);
    IEnumerable<Member> ReadMembersOfFitness(int fitnessId);
}