using System;
using UnityEngine;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        public event Action<Vector2> ScreenTouch;

        public void SetEnabled(bool isEnabled);
    }
}
