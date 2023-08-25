using Code.Clicker.HUD;
using EnotoButebrodo;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ValuableStateFactory : MonoBehaviour
    {
        [SerializeField] private BoxCollider _earnAreaCollider;
        [SerializeField] private ValuableHUD _valuableHUD;
        [Inject] private DiContainer _container;
        public ValuableState GetHasCoinsState(ValuableStateMachine context) 
            => new HasCoinsState(context);

        public ValuableState GetReloadState(ValuableStateMachine context) 
            => new ReloadState(context
                , _container.Resolve<ITimersService>()
                , _valuableHUD);

        public ValuableState GetSpawnState(ValuableStateMachine context) 
            => new SpawnedState(context, _valuableHUD);
    }
}