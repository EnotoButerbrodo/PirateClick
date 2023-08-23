namespace EnotoButerbrodo.StateMachine
{
    public interface IUpdateableState
    {
        void UpdateState();
    }

    public interface IFixedUpdateState
    {
        void FixedUpdateState();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IExitableState
    {
        void Exit();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}