using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConsole
{
    class CharacterWriter
    {
        string[] lines = File.ReadAllLines("input.csv");
        public void AddCharacter()
        {
            Console.Write("\n=== Add a Character ===\n");

            Console.Write("Enter your character's name: ");
            string charName = Console.ReadLine();

            Console.Write("Enter your character's class: ");
            string charClass = Console.ReadLine();

            Console.Write("Enter your character's level: ");
            int level = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's HP: ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's equipment (separate items with a '|'): ");
            string[] equipment = Console.ReadLine().Split('|');

            Console.WriteLine($"Welcome, {charName} the {charClass}! You are level {level} with {hp} HP, and your equipment includes: {string.Join(", ", equipment)}.\n");

            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                writer.WriteLine($"\n{charName},{charClass},{level},{hp},{string.Join("|", equipment)}");
            }
        }
        public void LevelUpCharacter()
        {
            Console.Write("Enter the name of the character to level up: ");
            string nameToLevelUp = Console.ReadLine();

            // Loop through characters to find the one to level up
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                // Check if the name matches the one to level up
                if (line.Contains(nameToLevelUp))
                {
                    if (line.StartsWith("\""))
                    {
                        string firstRemoved = line.Trim('"');
                        var quotePos = firstRemoved.IndexOf('"');
                        string name = firstRemoved.Substring(0, quotePos);

                        var rest = firstRemoved.Substring(name.Length + 2);
                        var splits = rest.Split(",");
                        string charClass = splits[0];
                        var level = splits[1];
                        var hp = splits[2];
                        string[] equipment = splits[3].Split("|");

                        // Level up the character
                        int j = int.Parse(level);
                        var newLevel = Convert.ToString(j + 1);

                        Console.WriteLine($"{name} is now Level {newLevel}");

                        // Update the line with the new level
                        using (StreamWriter writer = new StreamWriter("input.csv", true))
                        {
                            writer.WriteLine($"{name}, {charClass}, {newLevel}, {hp}, {string.Join("|", equipment)}");
                        }
                        break;
                    }
                    else
                    {
                        var cols = lines[i].Split(",");
                        string name = cols[0];
                        string charClass = cols[1];
                        var level = cols[2];
                        var hp = cols[3];
                        var equipment = cols[4];

                        // Level up the character
                        int j = int.Parse(level);
                        var newLevel = Convert.ToString(j + 1);

                        Console.WriteLine($"{name} is now Level {newLevel}");

                        // Update the line with the new level
                        using (StreamWriter writer = new StreamWriter("input.csv", true))
                        {
                            writer.WriteLine($"{name},{charClass},{newLevel}, {hp}, {string.Join("|", equipment)}");
                        }
                        break;
                    }
                }
            }
        }
    }
}
