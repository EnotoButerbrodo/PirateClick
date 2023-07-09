using EnotoButerbrodo.StateMachine;

namespace Infrastructure
{
    public interface IGameStateFactory        
    {
        IExitableState GetInitialState(GameStateMachine context);
    }
}