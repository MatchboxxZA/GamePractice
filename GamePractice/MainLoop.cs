
namespace GamePractice
{
    internal class MainLoop
    {
        public static void Main(string[] args)
        {
            //----------MAIN INITIALIZATION-----------------

            bool startup = true;
            StateMachine stateMachine = new StateMachine();            
            //Create states int he state Library
            foreach (var state in StateLibrary.CreateStates())
            {
                stateMachine.AddState(state.Key, state.Value);
            }
            //Start in the explore state
            stateMachine.ChangeState("rest");
            
            //Initialize menu
            Menu mainMenu = new Menu();
            InitializeMainMenu(mainMenu, stateMachine);





            //-----------GAME LOOP SIMULATION--------------

            while (true) 
            {
                Console.Clear();
                stateMachine.Update(); //Update the current game state
                mainMenu.Display(); //Show menu option

                Console.WriteLine("Enter a command:");
                string input = Console.ReadLine();

                if (!mainMenu.HandleInput(input))
                {
                    Console.WriteLine("Press any key to try again..");
                    Console.ReadKey();
                }

                         
            }

        }

        private static void InitializeMainMenu(Menu menu, StateMachine stateMachine)
        {
            //Add dynamic menu options
            menu.AddOption(new MenuOption("save", "Save the current game state", () =>
            {
                GameSaveData saveData = new GameSaveData(stateMachine.GetCurrentStateKey());
                SaveGame.SaveState(saveData);
            }));

            menu.AddOption(new MenuOption("load", "Load the saved game state", () =>
            {
                string loadedStateKey = SaveGame.LoadState().currentStateKey;
                if (!string.IsNullOrEmpty(loadedStateKey))
                {
                    stateMachine.ChangeState(loadedStateKey);
                }
            }));

            menu.AddOption(new MenuOption("rest", "Switch to the Rest state", () =>
            {
                stateMachine.ChangeState("rest");
            }));

            menu.AddOption(new MenuOption("explore", "Switch to the Explore state", () =>
            {
                stateMachine.ChangeState("explore");
            }));

            menu.AddOption(new MenuOption("fight", "Switch to the Fight state", () =>
            {
                stateMachine.ChangeState("fight");
            }));

            menu.AddOption(new MenuOption("exit", "Exit the game", () =>
            {
                Console.WriteLine("Exiting the game. Goodbye!");
                Environment.Exit(0);
            }));

        }
    }
}
