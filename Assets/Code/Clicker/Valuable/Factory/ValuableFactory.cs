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
                ValuableType.Chest => 
                    _container.InstantiatePrefabForComponent<Valuable>(_chest, position, rotation, null),
                ValuableType.Palm =>
                    _container.InstantiatePrefabForComponent<Valuable>(_palm, position, rotation, null),
                _ => 
                    _container.InstantiatePrefabForComponent<Valuable>(_chest, position, rotation, null)
            };


    }
}