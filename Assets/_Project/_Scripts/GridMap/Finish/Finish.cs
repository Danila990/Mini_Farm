using DG.Tweening;
using UnityEngine;

namespace MiniFarm
{
    public class Finish : MonoBehaviour
    {
        public void ActivateFlag()
        {
            gameObject.SetActive(true);
        }

        public void DeactivateFlag()
        {
            gameObject.SetActive(false);
        }
    }
}