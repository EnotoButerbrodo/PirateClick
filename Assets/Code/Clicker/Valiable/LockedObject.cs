using NaughtyAttributes;
using UnityEngine;

namespace Code.Clicker
{
    public class LockedObject : MonoBehaviour, ILockedObject
    {
        [SerializeField] private LockedObjectMaterial _material;
        
        [Button()]
        public void Lock()
        {
            _material.Lock();
        }
        
        [Button()]
        public void Unlock()
        {
            _material.Unlock();
        }
    }
}