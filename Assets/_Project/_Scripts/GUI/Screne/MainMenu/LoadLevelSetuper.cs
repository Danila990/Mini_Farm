using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MiniFarm
{
    public class LoadLevelSetuper : MonoBehaviour
    {
        private void Start()
        {
            var buttons = GetComponentsInChildren<LoadSceneButton>();
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 1; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;
                buttons[i].SetIndex(i + 1);
            }
        }
    }
}