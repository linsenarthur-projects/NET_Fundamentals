using System.ComponentModel.DataAnnotations;
using ProjectFitness.BL;
using ProjectFitness.Domain;
using ProjectFitness.UI_CA.Extensions;

namespace ProjectFitness.UI_CA;

public class ConsoleUi
{
    private readonly IManager _manager;

    public ConsoleUi(IManager manager)
    {
        _manager = manager;
    }

    public void Run()
    {
        int number;

        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("==========================");
            Console.WriteLine("0) Quit");
            Console.WriteLine("1) Show all exercises");
            Console.WriteLine("2) Show all members");
            Console.WriteLine("3) Show all fitnesses");
            Console.WriteLine("4) Show all exercises of body part");
            Console.WriteLine("5) Show all members with name and/or date of birth");
            Console.WriteLine("6) Add an exercise");
            Console.WriteLine("7) Add a member");
            Console.WriteLine("8) Add exercise to member");
            Console.WriteLine("9) Remove exercise from member");

            Console.Write("Choice (0-9): ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (number)
            {
                case 0:
                    break;
                case 1:
                    PrintAllExercises();
                    break;
                case 2:
                    PrintAllMembers();
                    break;
                case 3:
                    PrintAllFitnesses();
                    break;
                case 4:
                    PrintExercisesOfBodyPart();
                    break;
                case 5:
                    PrintMembersByNameAndDateOfBirth();
                    break;
                case 6:
                    AddExercise();
                    break;
                case 7:
                    AddMember();
                    break;
                case 8:
                    AddExerciseToMember();
                    break;
                case 9:
                    RemoveExerciseFromMember();
                    break;
                default:
                    Console.WriteLine("An error occured, please enter an existing number !");
                    Run();
                    break;
            }

            Console.WriteLine();
        } while (number != 0);
    }

    private void PrintAllExercises()
    {
        Console.WriteLine("All exercises");
        Console.WriteLine("==============");
        var allExercises = _manager.GetAllExercise();
        List<Exercise> exercises = new List<Exercise>(allExercises);
        foreach (var exercise in exercises)
        {
            Console.WriteLine(exercise.StringRepresentation());
            foreach (var member in _manager.GetMembersOfExercise(Convert.ToInt32(exercise.Id)))
            {
                Console.WriteLine("\t " + member.StringRepresentation());
            }
        }
    }

    private void PrintAllMembers()
    {
        Console.WriteLine("All members");
        Console.WriteLine("===========");

        var allMembers = _manager.GetAllMembers();
        List<Member> members = new List<Member>(allMembers);

        foreach (var member in members)
        {
            Console.WriteLine(member.StringRepresentation());
            foreach (var exercise in _manager.GetExercisesOfMember(Convert.ToInt32(member.Id)))
            {
                Console.WriteLine("\t " + exercise.StringRepresentation());
            }
        }
    }

    private void PrintAllFitnesses()
    {
        Console.WriteLine("All fitnesses");
        Console.WriteLine("=============");

        var allFitnesses = _manager.GetAllFitnesses();
        List<Fitness> fitnesses = new List<Fitness>(allFitnesses);

        foreach (var fitness in fitnesses)
        {
            Console.WriteLine(fitness.StringRepresentation());
            foreach (var member in _manager.GetMembersOfFitness(Convert.ToInt32(fitness.Id)))
            {
                Console.WriteLine("\t " + member.StringRepresentation());
            }
        }
    }

    private void PrintExercisesOfBodyPart()
    {
        bool validated;

        Console.WriteLine("All body parts");
        Console.WriteLine("==============");

        Console.Write("Bodypart : ");

        var bodyParts = Enum.GetValues(typeof(BodyPart));
        int i = 1;
        foreach (var bodyPart in bodyParts)
        {
            Console.Write("{0}: {1} | ", bodyPart, i);
            i++;
        }
        
        string choice;
        BodyPart bp = BodyPart.Back;

        var totalBodyParts = i - 1;
        do
        {
            int choiceNumber;
            do
            {
                Console.Write("Choice (1-6): ");
                choice = Console.ReadLine();
                validated = Int32.TryParse(choice, out choiceNumber);
            } while (!validated);

            if (0 < choiceNumber && choiceNumber <= totalBodyParts)
            {
                if (choice != null) bp = Enum.Parse<BodyPart>(choice);
                Console.WriteLine();
                Console.WriteLine("All exercises of bodypart : " + bp);
                foreach (var exercise in _manager.GetExercisesOfBodyPart(bp))
                {
                    Console.WriteLine(exercise.StringRepresentation());
                }
            }
            else
            {
                Console.WriteLine("\nAn error occured, please enter a valid number !");
                PrintExercisesOfBodyPart();
            }
        } while (choice == null);
    }

    private void PrintMembersByNameAndDateOfBirth()
    {
        Console.Write("Enter full/part name of member: ");
        string name = Console.ReadLine();
        
        bool validated;
        DateTime date = new DateTime();
        IEnumerable<Member> membersByNameAndDate;
        List<Member> members;
        do
        {
            Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
            try
            {
                string bd = Console.ReadLine();
                
                if (bd == "")
                {
                    membersByNameAndDate = _manager.GetMembersByNameAndDateOfBirth(name, null);
                    members = new List<Member>(membersByNameAndDate);
                    members.ForEach(member => Console.WriteLine(member.StringRepresentation()));
                }
                else
                {
                    date = DateTime.ParseExact(bd, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                
                validated = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Give the correct date format (yyyy/mm/dd)");
                validated = false;
            }
        } while (!validated);

        membersByNameAndDate = _manager.GetMembersByNameAndDateOfBirth(name, date);
        members = new List<Member>(membersByNameAndDate);
        members.ForEach(member => Console.WriteLine(member.StringRepresentation()));
    }

    private void AddExercise()
    {
        bool validated;
        string input;

        Console.Write("Name : ");
        var name = Console.ReadLine();

        Console.Write("Bodypart : ");
        var bodyParts = Enum.GetValues(typeof(BodyPart));
        int i = 1;
        foreach (var bodyPart in bodyParts)
        {
            Console.Write("{0}: {1} | ", bodyPart, i);
            i++;
        }
        
        string choice;
        BodyPart bp = BodyPart.Back;
        
        var totalBodyParts = i - 1;
        do
        {
            do
            {
                Console.Write("Choice (1-6): ");
                choice = Console.ReadLine();
                validated = Int32.TryParse(choice, out _);
            } while (!validated);
            
            if (choice != null) bp = Enum.Parse<BodyPart>(choice);
        } while (choice == null);

        int weight;
        do
        {
            Console.Write("Added weight : ");
            input = Console.ReadLine();
            validated = Int32.TryParse(input, out weight);
        } while (!validated);

        Exercise exercise = new Exercise()
        {
            Name = name,
            BodyPart = bp,
            Weight = weight
        };

        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(exercise, new ValidationContext(exercise), validationResults, true);
        if (!valid)
        {
            foreach (var validationResult in validationResults)
                Console.WriteLine(validationResult.ErrorMessage);
            Console.WriteLine("An error occured, one or more fields are filled in incorrect !");
            AddExercise();
        }
        else
        {
            _manager.AddExercise(name, bp, weight);
        }
    }

    private void AddMember()
    {
        bool validated;
        string input;
        
        Console.Write("Name : ");
        var name = Console.ReadLine();

        DateTime birthdate = new DateTime();
        do
        {
            Console.Write("Birthdate (dd/mm/yyyy): ");
            try
            {
                string bd = Console.ReadLine();
                birthdate = DateTime.ParseExact(bd, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                validated = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Give the correct date format (dd/mm/yyyy)");
                validated = false;
            }
        } while (!validated);

        int bodyweight;
        do
        {
            Console.Write("Bodyweight : ");
            input = Console.ReadLine();
            validated = Int32.TryParse(input, out bodyweight);
        } while (!validated);

        Member member = new Member()
        {
            Name = name,
            BodyWeight = bodyweight,
            Birthdate = birthdate
        };

        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(member, new ValidationContext(member), validationResults, true);
        if (!valid)
        {
            foreach (var validationResult in validationResults)
                Console.WriteLine(validationResult.ErrorMessage);
            Console.WriteLine("An error occured, one or more fields are filled in incorrect !");
            AddMember();
        }
        else
        {
            _manager.AddMember(name, birthdate, bodyweight);
        }
    }

    private void AddExerciseToMember()
    {
        bool validated;
        string input;

        int idExercise;
        Console.WriteLine("Geef een exercise die je wilt toevoegen aan de memberexercise: ");
        foreach (var exercise in _manager.GetAllExercise())
        {
            Console.WriteLine(exercise.StringRepresentation());
        }

        do
        {
            do
            {
                Console.Write("Geef ID van de exercise: ");
                input = Console.ReadLine();
                validated = Int32.TryParse(input, out idExercise);
            } while (!validated);
        } while (idExercise > _manager.GetAllExercise().Count() || idExercise <= 0);


        int idMember;
        Console.WriteLine("Geef een member die je wilt toevoegen aan de memberexercise: ");
        foreach (var member in _manager.GetAllMembers())
        {
            Console.WriteLine(member.StringRepresentation());
        }

        do
        {
            do
            {
                Console.Write("Geef de ID van de member: ");
                input = Console.ReadLine();
                validated = Int32.TryParse(input, out idMember);
            } while (!validated);
        } while (idMember > _manager.GetAllMembers().Count() || idMember <= 0);
        
        int reps;
        do
        {
            Console.Write("Geef het aantal reps: ");
            input = Console.ReadLine();
            validated = Int32.TryParse(input, out reps);
        } while (!validated);

        int sets;
        do
        {
            Console.Write("Geef het aantal sets: ");
            input = Console.ReadLine();
            validated = Int32.TryParse(input, out sets);
        } while (!validated);
        
        Exercise e = _manager.GetExercise(idExercise);
        Member m = _manager.GetMember(idMember);

        MemberExercise memberExercise = new MemberExercise()
        {
            Exercise = e,
            Member = m,
            Reps = reps,
            Sets = sets
        };

        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(memberExercise, new ValidationContext(memberExercise),
            validationResults, true);
        if (!valid)
        {
            foreach (var validationResult in validationResults)
                Console.WriteLine(validationResult.ErrorMessage);
            Console.WriteLine("An error occured, one or more fields are filled in incorrect !");
            AddExerciseToMember();
        }
        else
        {
            _manager.AddMemberExercise(e, m, reps, sets);
        }
    }

    private void RemoveExerciseFromMember()
    {
        bool validated;
        string input;

        int idMember;
        foreach (var member in _manager.GetAllMembers())
        {
            Console.WriteLine(member.StringRepresentation());
        }

        do
        {
            do
            {
                Console.Write("Geef de ID van de member: ");
                input = Console.ReadLine();
                validated = Int32.TryParse(input, out idMember);
            } while (!validated);
        } while (idMember > _manager.GetAllMembers().Count() || idMember <= 0);

        int idExercise;
        foreach (var exercise in _manager.GetExercisesOfMember(idMember))
        {
            Console.WriteLine(exercise.StringRepresentation());
        }

        do
        {
            do
            {
                Console.Write("Geef ID van de exercise: ");
                input = Console.ReadLine();
                validated = Int32.TryParse(input, out idExercise);
            } while (!validated);
        } while (idExercise > _manager.GetAllExercise().Count() || idExercise <= 0);

        Member m = _manager.GetMember(idMember);
        Exercise e = _manager.GetExercise(idExercise);


        MemberExercise memberExercise = new MemberExercise()
        {
            Exercise = e,
            Member = m
        };

        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(memberExercise, new ValidationContext(memberExercise),
            validationResults, true);
        if (!valid)
        {
            foreach (var validationResult in validationResults)
                Console.WriteLine(validationResult.ErrorMessage);
            Console.WriteLine("An error occured, one or more fields are filled in incorrect !");
            RemoveExerciseFromMember();
        }
        else
        {
            _manager.DeleteMemberExercise(m, e);
        }
    }
}