using ProjectFitness.Domain;

namespace ProjectFitness.DAL.EF;

public static class ProjectFitnessInitializer
{
    private static bool _hasBeenInitialized = false;
    
    public static void Initialize(FitnessDbContext context,
        bool dropDatabase = false)
    {
        if (!_hasBeenInitialized)
        {
            if (dropDatabase)
                context.Database.EnsureDeleted();

            if (context.Database.EnsureCreated())
                Seed(context);

            _hasBeenInitialized = true;
        }
    }

    private static void Seed(FitnessDbContext context)
    {
        var m1 = new Member
        {
            Name = "Vince Jeugmans",
            Birthdate = new DateTime(2002, 7, 15),
            BodyWeight = 63,
            MembersExercises = new List<MemberExercise>()
        };
        var m2 = new Member
        {
            Name = "Arne Gabriels",
            Birthdate = new DateTime(2002, 10, 20),
            BodyWeight = 78,
            MembersExercises = new List<MemberExercise>()
        };
        var m3 = new Member
        {
            Name = "Kobe Wouters",
            Birthdate = new DateTime(2002, 03, 21),
            BodyWeight = 75,
            MembersExercises = new List<MemberExercise>()
        };
        var m4 = new Member
        {
            Name = "Thomas Verlinden",
            Birthdate = new DateTime(2003, 05, 19),
            BodyWeight = 69,
            MembersExercises = new List<MemberExercise>()
        };

        var e1 = new Exercise()
        {
            Name = "Bicep curl",
            BodyPart = BodyPart.Biceps,
            Weight = 12,
            MembersExercises = new List<MemberExercise>()
        };
        var e2 = new Exercise
        {
            Name = "Lateral raise",
            BodyPart = BodyPart.Shoulders,
            Weight = 8,
            MembersExercises = new List<MemberExercise>()
        };
        var e3 = new Exercise()
        {
            Name = "Bench press",
            BodyPart = BodyPart.Chest,
            Weight = 80,
            MembersExercises = new List<MemberExercise>()
        };
        var e4 = new Exercise()
        {
            Name = "Pull up",
            BodyPart = BodyPart.Back,
            Weight = null,
            MembersExercises = new List<MemberExercise>()
        };
        var e5 = new Exercise()
        {
            Name = "Squat",
            BodyPart = BodyPart.Legs,
            Weight = 100,
            MembersExercises = new List<MemberExercise>()
        };
        var e6 = new Exercise()
        {
            Name = "Dips",
            BodyPart = BodyPart.Triceps,
            Weight = null,
            MembersExercises = new List<MemberExercise>()
        };

        var f1 = new Fitness
        {
            Name = "KD sports",
            Address = "Lierseweg 317D, 2200 Herentals",
            Surface = 120,
            Members = new List<Member>()
        };
        var f2 = new Fitness
        {
            Name = "Basic fit Herentals",
            Address = "Belgiëlaan 58, 2200 Herentals",
            Surface = 180,
            Members = new List<Member>()
        };

        var me1 = new MemberExercise
        {
            Member = m1,
            Exercise = e1,
            Reps = 12,
            Sets = 3
        };
        var me2 = new MemberExercise
        {
            Member = m1,
            Exercise = e2,
            Reps = 10,
            Sets = 3
        };
        var me3 = new MemberExercise
        {
            Member = m2,
            Exercise = e3,
            Reps = 15,
            Sets = 4
        };
        var me4 = new MemberExercise
        {
            Member = m2,
            Exercise = e4,
            Reps = 8,
            Sets = 5
        };
        var me5 = new MemberExercise
        {
            Member = m2,
            Exercise = e5,
            Reps = 6,
            Sets = 4
        };
        var me6 = new MemberExercise
        {
            Member = m3,
            Exercise = e6,
            Reps = 12,
            Sets = 5
        };
        var me7 = new MemberExercise
        {
            Member = m3,
            Exercise = e1,
            Reps = 14,
            Sets = 4
        };
        var me8 = new MemberExercise
        {
            Member = m4,
            Exercise = e5,
            Reps = 10,
            Sets = 5
        };
        var me9 = new MemberExercise
        {
            Member = m4,
            Exercise = e1,
            Reps = 12,
            Sets = 3
        };
        var me10 = new MemberExercise
        {
            Member = m4,
            Exercise = e6,
            Reps = 16,
            Sets = 4
        };

        // fitness 1
        f1.Members.Add(m1);
        f1.Members.Add(m2);
        m1.Fitness = f1;
        m2.Fitness = f1;
        
        // fitness 2
        f2.Members.Add(m3);
        f2.Members.Add(m4);
        m3.Fitness = f2;
        m4.Fitness = f2;

        // member 1
        me1.Exercise = e1;
        me1.Member = m1;
        m1.MembersExercises.Add(me1);
        e1.MembersExercises.Add(me1);

        me2.Exercise = e2;
        me2.Member = m1;
        m1.MembersExercises.Add(me2);
        e2.MembersExercises.Add(me2);

        // member 2
        me3.Exercise = e3;
        me3.Member = m2;
        m2.MembersExercises.Add(me3);
        e3.MembersExercises.Add(me3);

        me4.Exercise = e4;
        me4.Member = m2;
        m2.MembersExercises.Add(me4);
        e4.MembersExercises.Add(me4);

        me5.Exercise = e5;
        me5.Member = m2;
        m2.MembersExercises.Add(me5);
        e5.MembersExercises.Add(me5);
        
        // member 3
        me6.Exercise = e6;
        me6.Member = m3;
        m3.MembersExercises.Add(me6);
        e6.MembersExercises.Add(me6);

        me7.Exercise = e1;
        me7.Member = m3;
        m3.MembersExercises.Add(me7);
        e1.MembersExercises.Add(me7);
        
        // member 4
        me8.Exercise = e5;
        me8.Member = m4;
        m4.MembersExercises.Add(me8);
        e5.MembersExercises.Add(me8);

        me9.Exercise = e1;
        me9.Member = m4;
        m4.MembersExercises.Add(me9);
        e1.MembersExercises.Add(me9);

        me10.Exercise = e6;
        me10.Member = m4;
        m4.MembersExercises.Add(me10);
        e6.MembersExercises.Add(me10);
        
        // context => databank
        context.Fitnesses.Add(f1);
        
        context.Members.Add(m1);
        context.Members.Add(m2);
        context.Members.Add(m3);
        context.Members.Add(m4);
        
        context.Exercises.Add(e1);
        context.Exercises.Add(e2);
        context.Exercises.Add(e3);
        context.Exercises.Add(e4);
        context.Exercises.Add(e5);
        context.Exercises.Add(e6);

        context.MemberExercises.Add(me1);
        context.MemberExercises.Add(me2);
        context.MemberExercises.Add(me3);
        context.MemberExercises.Add(me4);
        context.MemberExercises.Add(me5);
        context.MemberExercises.Add(me6);
        context.MemberExercises.Add(me7);
        context.MemberExercises.Add(me8);
        context.MemberExercises.Add(me9);
        context.MemberExercises.Add(me10);

        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}