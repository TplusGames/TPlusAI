using TPlus.StateMachine;

namespace TPlus.AI
{
    public abstract class State_AI : State_Base
    {
        protected State_AI(StateMachine_Base stateMachine) : base(stateMachine)
        {
        }
    }
}
