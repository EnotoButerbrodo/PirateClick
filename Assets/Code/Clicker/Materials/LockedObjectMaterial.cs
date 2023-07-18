using System.Collections.Generic;
using UnityEngine;

namespace Code.Clicker
{
    public class LockedObjectMaterial : MonoBehaviour
    {
        [SerializeField] private List<LockedObjectMaterialProvider> _materials;

        public void Unlock()
        {
            foreach (var material in _materials)
            {
                material.Unlock();
            }
        }
    }
}