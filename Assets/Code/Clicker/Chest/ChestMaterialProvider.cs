using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Clicker
{
    public class ChestMaterialProvider : MonoBehaviour
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