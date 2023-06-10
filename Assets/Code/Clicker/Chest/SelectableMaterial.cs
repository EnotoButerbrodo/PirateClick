using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Clicker
{
    public class SelectableMaterial : MonoBehaviour
    {
        [FormerlySerializedAs("_chestRenderers")] 
        [SerializeField] private List<Renderer> _renderers;

        private const string EmissionBlendPercentProperty = "_EmissionBlendPercent";
        private const string ColorLerpPercentProperty = "_ColorLerpPercent";

        private int _emissionPropertyHash;
        private int _colorPropertyHash;
        private List<Material> _chestMaterials;
        private void Start()
        {
            GetMaterials();
            CalculateShaderPropertiesHash();
        }

        private void CalculateShaderPropertiesHash()
        {
            _emissionPropertyHash = Shader.PropertyToID(EmissionBlendPercentProperty);
            _colorPropertyHash = Shader.PropertyToID(ColorLerpPercentProperty);
        }

        private void GetMaterials()
        {
            _chestMaterials = new List<Material>();
            foreach (Renderer chestRenderer in _renderers)
            {
                var material = chestRenderer.material;

                if (_chestMaterials.Contains(material))
                    continue;

                _chestMaterials.Add(chestRenderer.material);
            }
        }

        [ContextMenu("Select")]
        public void SetSelected()
        {
            SetSelectionBlendPercent(1f);
        }

        [ContextMenu("Deselect")]
        public void SetDeselected()
        {
            SetSelectionBlendPercent(0);
        }

        private void SetSelectionBlendPercent(float percent)
        {
            foreach (Material material in _chestMaterials)
            {
                SetEmissionPercent(material, percent);
                SetColorPercent(material, percent);
            }
        }

        private void SetEmissionPercent(Material material, float percent)
        {
            material.SetFloat(_emissionPropertyHash, percent);
        }

        private void SetColorPercent(Material material, float percent)
        {
            material.SetFloat(_colorPropertyHash, percent);
        }
        
    }
}