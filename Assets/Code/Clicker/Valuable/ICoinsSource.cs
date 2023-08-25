using UnityEngine;

namespace Code.Clicker
{
    public interface ICoinsSource
    {
        public Vector3 GetRandomEarnPosition();
    }
}