using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ValuableFactory : MonoBehaviour, IValuableFactory
    {
        [SerializeField] private Chest _chest;
        [SerializeField] private Valuable _palm;
        
        [Inject] private DiContainer _container;

        public Valuable Get(ValuableType type
            , Vector3 position 
            , Quaternion rotation) =>
            type switch
            {
                ValuableType.Chest => GetChest(position, rotation),
                _ => GetChest(position, rotation)
            };

        private Chest GetChest(Vector3 position, Quaternion rotation)
            => _container.InstantiatePrefabForComponent<Chest>(_chest, position, rotation, null);
    }
}