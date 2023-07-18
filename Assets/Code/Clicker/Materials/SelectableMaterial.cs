using System.Collections.Generic;
using UnityEngine;

namespace Code.Clicker
{
    public class SelectableMaterial : MonoBehaviour
    {
        [SerializeField] private List<SelectableMaterialProvider> _materials;

        [ContextMenu("Select")]
        public void SetSelected()
        {
            foreach (SelectableMaterialProvider material in _materials)
            {
                material.SetSelected();
            }
        }

        [ContextMenu("Deselect")]
        public void SetDeselected()
        {
            foreach (SelectableMaterialProvider material in _materials)
            {
                material.SetDeselected();
            }
        }

    }
}