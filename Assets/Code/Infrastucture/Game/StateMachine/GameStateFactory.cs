using EnotoButerbrodo.StateMachine;
using Zenject;

namespace Infrastructure
{
    public class GameStateFactory : IGameStateFactory
    {
        private DiContainer _container;
        public IExitableState GetInitialState(GameStateMachine context) 
            => new InitialState(context);
    }
}