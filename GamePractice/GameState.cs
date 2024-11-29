
namespace GamePractice
{
    //Base class for all states
    public abstract class GameState
    {
        protected StateMachine SubStateMachine; //Internal state machine for child states

        public GameState() //initialize the sub state machine when an object is created
        {
            SubStateMachine = new StateMachine();
        }
        public virtual void Enter() { } // Called when entering the state

        public virtual void Update()  // Called repeatedly during the state 
        {
            SubStateMachine.Update();
        }
        public virtual void Exit() { } // Called when Exiting the state.

        public void ChangeSubState(string substateKey)
        {
            SubStateMachine.ChangeState(substateKey);
        }
          
    }

    //Handels the current active state as well as the transisions between them
    public class StateMachine
    {
        private GameState _currentState;
        private Dictionary<string, GameState> _states = new Dictionary<string, GameState>();
        private string _currentStateKey;

        //Register all states with their unieque key
        public void AddState(string key, GameState state) 
        {
            if (!_states.ContainsKey(key))
            {
                _states[key] = state;
            }
        }

        public void ChangeState(string key)
        {
            if (_states.ContainsKey(key))
            {                
                _currentState?.Exit(); //Exit the current state, if there is one                
                _currentState = _states[key]; // Change to the new state
                _currentStateKey = key; //Set a reference to the current state
                _currentState.Enter(); //Enter the new state
            }
            else
            {
                Console.WriteLine($"Invalid State Key: {key}");
            }
        }

        public void Update()
        {
            //Call update on the Current State
            _currentState.Update();
        }

        //Retrieve the current state's key
        public string GetCurrentStateKey()
        {
            return _currentStateKey;
        }

        public GameState GetCurrentState()
        {
            return _currentState;
        }
    }

  

}