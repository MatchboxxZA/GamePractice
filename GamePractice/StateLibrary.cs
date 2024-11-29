
namespace GamePractice
{
    public class StateLibrary
    {
        public static Dictionary<string, GameState> CreateStates()
        {
            return new Dictionary<string, GameState>
            {
                //Creates the dictionary with all of the game states below
                {"explore", new ExploreState()},
                {"fight" , new FightState()},
                {"rest" , new RestState()},
                {"shop", new ShopState()}
            };
        }
    }

    //Create different states inheriting from GameState

    //------MAIN STATES-----
    public class ExploreState : GameState
    {
        public ExploreState()
        {

        }
        public override void Enter()
        {
            Console.WriteLine("you go exploring");
            //Initialize child states
            SubStateMachine.AddState("dungeon", new DungeonState());
            SubStateMachine.AddState("forest", new ForestState());
        }

        public override void Exit()
        {
            Console.WriteLine("You stop exploring.");
        }

        public override void Update()
        {
            //Add logic for exploring
            Console.WriteLine("Exploring... (Type 'dungeon' or 'forest' to switch.)");
            string currentStateKey = SubStateMachine.GetCurrentStateKey();
            if(currentStateKey != null)
            {
                base.Update();
            }

        }
    }
    public class FightState : GameState
    {
        public override void Enter()
        {
            Console.WriteLine("You encounter something");
        }

        public override void Exit()
        {
            Console.WriteLine("You leave the battle");
        }

        public override void Update()
        {
            //Add logic for encounters
            Console.WriteLine("You swing with your sword.");
        }
    }
    public class RestState : GameState
    {
        public override void Enter()
        {
            Console.WriteLine("You find a place to rest");
        }

        public override void Exit()
        {
            Console.WriteLine("You continue on your journy");
        }

        public override void Update()
        {
            //Add logic for resting state
            Console.WriteLine("You are resting.");
        }
    }
    public class ShopState : GameState
    {
        public override void Enter()
        {
            Console.WriteLine("You check the shop for goods");
        }

        public override void Exit()
        {
            Console.WriteLine("You leave the shop.");
        }

        public override void Update()
        {
            //Execute shop logic.
            Console.WriteLine("You browse the shop some more.");
        }
    }


    //-----SUBSTATES------

    //---EXPLORE SUBSTATES
    public class DungeonState : GameState
    {
        public override void Enter()
        {
            Console.WriteLine("You Enster a dungeon");
        }

        public override void Update()
        {
            Console.WriteLine("You explore the dungeon corredors");
        }

        public override void Exit()
        {
            Console.WriteLine("You leave the dungeon");
        }
    }
    public class ForestState : GameState
    {
        public override void Enter()
        {
            Console.WriteLine("You enter an overgrown forest");
        }
        public override void Update()
        {
            Console.WriteLine("You explore the forest trails...");
        }
        public override void Exit()
        {
            Console.WriteLine("You leave the forest.");
        }
    }

}
