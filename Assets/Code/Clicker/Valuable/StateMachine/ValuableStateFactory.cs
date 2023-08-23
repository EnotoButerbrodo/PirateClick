using EnotoButebrodo;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ValuableStateFactory : MonoBehaviour
    {
        [SerializeField] private BoxCollider _earnAreaCollider;
        [Inject] private DiContainer _container;
        public ValuableState GetHasCoinsState(ValuableStateMachine context) 
            => new HasCoinsState(context, _earnAreaCollider);

        public ValuableState GetReloadState(ValuableStateMachine context) 
            => new ReloadState(context, _container.Resolve<ITimersService>());
    }
}