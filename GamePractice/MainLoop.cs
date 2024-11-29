
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
            






            //-----------GAME LOOP SIMULATION--------------

            while (true) 
            {

                //Simulate an update call
                stateMachine.Update();

                //Example of state transition (this would normally depend on player actions)
                Console.WriteLine("What would you like to do?");
                string input = Console.ReadLine();
                Console.Clear();


                //----USER INPUT AND LOGIC-----
                switch (input)
                {
                    case "save":
                        Console.Clear();
                        GameSaveData gameData = new GameSaveData(stateMachine.GetCurrentStateKey());
                        SaveGame.SaveState(gameData);
                        break;
                    case "load":
                        Console.Clear();
                        GameSaveData loadData = SaveGame.LoadState();
                        if(loadData != null)
                        {
                            stateMachine.ChangeState(loadData.currentStateKey);
                        }
                        break;
                    default:
                        if(input == "fight" || input == "rest" || input == "explore")
                        {
                            stateMachine.ChangeState(input);
                        }
                        else if (input == "dungeon" || input == "forest")
                        {
                            // Ensure SubStateMachine exists before calling ChangeState
                            if (stateMachine.GetCurrentState() is ExploreState exploreState)
                            {
                                exploreState.ChangeSubState(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid substate transition.");
                            }
                        }

                        break;
                }

                         
            }

        }
    }
}
