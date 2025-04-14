using System;
using System.Collections.Generic;
using System.IO;

// Base Goal class
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString() => $"{(_isComplete ? "[X]" : "[ ]")} {_name} ({_description})";
    public abstract string GetStringRepresentation();
    public int GetPoints() => _points;
    public string GetName() => _name;
}

// SimpleGoal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false) 
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
    }
}

// EternalGoal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Eternal goals are never complete
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}

// ChecklistGoal class
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
        _isComplete = (amountCompleted >= target);
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    public int GetBonus() => _bonus;
    public int GetAmountCompleted() => _amountCompleted;
    public int GetTarget() => _target;
}

// GoalManager class
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        LoadGoals();
        DisplayMenu();
    }

    private void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            Goal goal = _goals[goalNumber];
            goal.RecordEvent();
            
            int pointsEarned = goal.GetPoints();
            
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.GetBonus();
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points (including bonus)!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
            
            _score += pointsEarned;
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        string filename = "goals.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score:{_score}");
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        string filename = "goals.txt";
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');

            switch (type)
            {
                case "Score":
                    _score = int.Parse(details[0]);
                    break;
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        details[0], 
                        details[1], 
                        int.Parse(details[2]), 
                        int.Parse(details[4]), 
                        int.Parse(details[3]),
                        int.Parse(details[5])));
                    break;
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("This program helps you track and achieve your goals.");
        
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}