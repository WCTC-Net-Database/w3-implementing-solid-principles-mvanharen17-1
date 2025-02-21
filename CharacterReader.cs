using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConsole
{
    class CharacterReader
    {
        string[] lines = File.ReadAllLines("input.csv");
        public void DisplayCharacters()
        {
            // Skip the header row
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                string name;
                int commaIndex;

                // Check if the name is quoted
                if (line.StartsWith("\""))
                {
                    string firstRemoved = line.Trim('"');
                    var quotePos = firstRemoved.IndexOf('"');
                    name = firstRemoved.Substring(0, quotePos);

                    var rest = firstRemoved.Substring(name.Length + 2);
                    var splits = rest.Split(",");
                    string charClass = splits[0];
                    var level = splits[1];
                    var hp = splits[2];
                    string[] equipment = splits[3].Split("|");

                    Console.WriteLine($"\nName: {name}");
                    Console.WriteLine($"Job: {charClass}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"Hit Points: {hp}");
                    Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");
                }
                else
                {
                    var cols = lines[i].Split(",");
                    name = cols[0];
                    string charClass = cols[1];
                    var level = cols[2];
                    var hp = cols[3];
                    string[] equipment = cols[4].Split("|");

                    Console.WriteLine($"\nName: {name}");
                    Console.WriteLine($"Job: {charClass}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"Hit Points: {hp}");
                    Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");
                }
            }
        }
        public void FindCharacter()
        {
            Console.Write("Enter the name of the character you want to find: ");
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

                        Console.WriteLine($"\nName: {name}");
                        Console.WriteLine($"Job: {charClass}");
                        Console.WriteLine($"Level: {level}");
                        Console.WriteLine($"Hit Points: {hp}");
                        Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");

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

                        Console.WriteLine($"\nName: {name}");
                        Console.WriteLine($"Job: {charClass}");
                        Console.WriteLine($"Level: {level}");
                        Console.WriteLine($"Hit Points: {hp}");
                        Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");

                        break;
                    }
                }
            }
        }
    }
}
