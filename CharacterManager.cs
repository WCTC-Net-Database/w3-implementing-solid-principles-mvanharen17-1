namespace CharacterConsole;

public class CharacterManager
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly string _filePath = "input.csv";

    private string[] lines;

    public CharacterManager(IInput input, IOutput output)
    {
        _input = input;
        _output = output;
    }

    public void Run()
    {
        _output.WriteLine("Welcome to Character Management");

        lines = File.ReadAllLines(_filePath);

        while (true)
        {
            _output.WriteLine("\nMenu:");
            _output.WriteLine("1. Display Characters");
            _output.WriteLine("2. Find Character");
            _output.WriteLine("3. Add Character");
            _output.WriteLine("4. Level Up Character");
            _output.WriteLine("5. Exit");
            _output.Write("Enter your choice: ");
            var choice = _input.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayCharacters();
                    break;
                case "2":
                    FindCharacter();
                    break;
                case "3":
                    AddCharacter();
                    break;
                case "4":
                    LevelUpCharacter();
                    break;
                case "5":
                    return;
                default:
                    _output.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayCharacters()
    {
        // TODO: Implement displaying characters from the CSV file
        CharacterReader characterReader = new CharacterReader();
        characterReader.DisplayCharacters();
        
    }
    public void FindCharacter()
    {
        // TODO: Implement displaying characters from the CSV file
        CharacterReader characterReader = new CharacterReader();
        characterReader.FindCharacter();

    }

    public void AddCharacter()
    {
        // TODO: Implement adding a new character and saving to the CSV file
        CharacterWriter characterWriter = new CharacterWriter();
        characterWriter.AddCharacter();
        
    }

    public void LevelUpCharacter()
    {
        // TODO: Implement leveling up a character and updating the CSV file
        CharacterWriter characterWriter = new CharacterWriter();
        characterWriter.LevelUpCharacter();
    }
}