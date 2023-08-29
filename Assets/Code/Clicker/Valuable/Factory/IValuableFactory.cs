using UnityEngine;

namespace Code.Clicker
{
    public interface IValuableFactory
    {
        Valuable Get(ValuableType type
            , Vector3 position 
            , Quaternion rotation);
    }
}