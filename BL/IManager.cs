using ProjectFitness.Domain;

namespace ProjectFitness.BL;

public interface IManager
{
    Member AddMember(string name, DateTime birthdate, double bodyweight);
    IEnumerable<Member> GetAllMembers();
    IEnumerable<Member> GetAllMembersWithFitness();
    Member GetMember(long id);
    IEnumerable<Member> GetMembersByNameAndDateOfBirth(string name, DateTime? date);

    Exercise AddExercise(string name, BodyPart bodyPart, int weight);
    IEnumerable<Exercise> GetAllExercise();
    IEnumerable<Exercise> GetAlleExercisesWithMember();
    Exercise GetExercise(long id);
    IEnumerable<Exercise> GetExercisesOfBodyPart(BodyPart bodyPart);

    void addFitness(string name, string address, int surface);
    IEnumerable<Fitness> GetAllFitnesses();
    public Fitness GetFitness(long id);
    
    MemberExercise GetMemberExercise(Member member, Exercise exercise);
    IEnumerable<MemberExercise> GetAllMemberExercise();
    
    void AddMemberExercise(Exercise exercise, Member member, int reps, int sets);
    void DeleteMemberExercise(Member member, Exercise exercise);
    IEnumerable<Exercise> GetExercisesOfMember(int memberId);
    IEnumerable<Member> GetMembersOfExercise(int exerciseId);
    IEnumerable<Member> GetMembersOfFitness(int fitnessId);
}