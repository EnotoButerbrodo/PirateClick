using System;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ClickEffect : MonoBehaviour
    {
        private GameObject o;
        private Camera _camera;
        [Inject] private ClickerEvents _events;
        private void Awake()
        {
            o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.transform.localScale = Vector3.one *0.1f;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _events.ClickableClicked += React;
        }

        private void React(Vector3 clickPosition, IClickable collider)
        {
            o.transform.position = clickPosition;
        }
    }
}