using UnityEngine;

namespace MiniFarm
{
    public class Trap : MonoBehaviour
    {
        [field: SerializeField] public TrapType trapType { get; private set; }

        public virtual bool IsActive()
        {
            return true; 
        }
    }
}