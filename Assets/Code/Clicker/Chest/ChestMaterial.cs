using System.Collections.Generic;
using UnityEngine;

namespace Code.Clicker
{
    public class ChestMaterial : MonoBehaviour
    {
        [SerializeField] private Material _selectedMaterial;
        [SerializeField] private Material _deselectedMaterial;

        [SerializeField] private List<Renderer> _chestRenderers;
        [SerializeField] private List<Renderer> _goldRenderers;        

        [ContextMenu("Select")]
        public void SetSelected()
        {
            foreach (Renderer chestRenderer in _chestRenderers)
            {
                chestRenderer.material = _selectedMaterial;
            }
        }

        [ContextMenu("Deselect")]
        public void SetDeselected()
        {
            foreach (Renderer chestRenderer in _chestRenderers)
            {
                chestRenderer.material = _deselectedMaterial;
            }
        }
        
    }
}