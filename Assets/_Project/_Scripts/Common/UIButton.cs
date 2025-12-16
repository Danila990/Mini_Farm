using MiniFarm;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFarm
{
    public class UIButton : MonoBehaviour
    {
        protected virtual void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick() { }
    }
}