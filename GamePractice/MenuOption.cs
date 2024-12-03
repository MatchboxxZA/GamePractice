namespace GamePractice
{

    //35007862071708
    public class MenuOption
    {
        //Represents a single menu option
        public string Command {  get; }
        public string Description { get; }
        public Action Execute { get; }

        public MenuOption(string command, string description, Action execute)
        {
            Command = command;
            Description = description;
            Execute = execute;
        }
       
    }

    //Represents a collection of Menu options
    public class Menu
    {
        private List<MenuOption> options = new List<MenuOption>();

        public void AddOption(MenuOption option)
        {
            options.Add(option);
        }

        public void Display()
        {
            Console.WriteLine("=== Menu ===");
            foreach(var option in options)
            {
                Console.WriteLine($"{option.Command} - {option.Description}");
            }
        }

        public bool HandleInput(string input)
        {
            foreach (var option in options)
            {
                if(option.Command.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    option.Execute();
                    return true;
                }                
            }
            Console.WriteLine($"Invalid command: {input}");
            return false;
        }

    }
}
