using System;
using UnityEngine;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        public event Action<Vector2> ScreenTouch;
        public event Action<Vector2> CameraDrag;
        public bool CameraDragButtonPressed { get; }
        
        public void SetEnabled(bool isEnabled);
    }
}
