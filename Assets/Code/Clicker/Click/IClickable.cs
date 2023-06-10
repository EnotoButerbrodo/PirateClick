using System;

namespace Code.Clicker
{
    public interface IClickable
    {
        public event Action Clicked;
        public void React();
    }
}