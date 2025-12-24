using UnityEngine;
using UnityEngine.UI;
using YG;

namespace MiniFarm
{
    public class LoadLevelSetuper : MonoBehaviour
    {
        private void Start()
        {
            var buttons = GetComponentsInChildren<LoadSceneButton>();
            for (int i = 0; i < YG2.saves.CurrentLevel; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;
                buttons[i].SetIndex(i + 1);
            }
        }
    }
}