using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Code.Clicker
{
    public class SelectableMaterialProvider : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private Material _selectableMaterial;
        
        private const string EmissionBlendPercentProperty = "_EmissionBlendPercent";
        private const string ColorLerpPercentProperty = "_ColorLerpPercent";
        
        private int _emissionPropertyHash;
        private int _colorPropertyHash;

        private float EmissionSelectPercent
        {
            get => _selectableMaterial.GetFloat(_emissionPropertyHash);
            set => _selectableMaterial.SetFloat(_emissionPropertyHash, value);
        }

        private float ColorSelectPercent
        {
            get => _selectableMaterial.GetFloat(_colorPropertyHash);
            set => _selectableMaterial.SetFloat(_colorPropertyHash, value);
        }
        
        private TweenerCore<float, float, FloatOptions> _emissionTween;
        private TweenerCore<float, float, FloatOptions> _colorTween;

        private void Awake()
        {
            _selectableMaterial = _meshRenderer.material;
            CalculateShaderPropertiesHash();
        }

        public void SetSelected()
        {
            StartEmissionTween(1f);
            StartColorTween(1f);
        }

        public void SetDeselected()
        {
            StartEmissionTween(0f);
            StartColorTween(0f);
        }
        
        private void CalculateShaderPropertiesHash()
        {
            _emissionPropertyHash = Shader.PropertyToID(EmissionBlendPercentProperty);
            _colorPropertyHash = Shader.PropertyToID(ColorLerpPercentProperty);
        }
        
        private void StartEmissionTween(float targetValue)
        {
            if(_emissionTween is null || _emissionTween.IsPlaying())
                _emissionTween.Kill();
            
            _emissionTween = DOTween.To(
                    getter: () => EmissionSelectPercent
                    , setter: x => EmissionSelectPercent = x
                    , endValue: targetValue
                    , duration: 0.25f)
                .OnKill(()=> EmissionSelectPercent = targetValue);
        }
        
        private void StartColorTween(float targetValue)
        {
            if(_colorTween is null || _colorTween.IsPlaying())
                _colorTween.Kill();
            
            _colorTween = DOTween.To(
                    getter: () => ColorSelectPercent
                    , setter: newValue => ColorSelectPercent = newValue
                    , endValue: targetValue
                    , duration: 0.25f)
                .OnKill(()=> ColorSelectPercent = targetValue);
        }


    }
}