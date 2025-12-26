using TMPro;
using UnityEngine;

namespace MiniFarm
{
    public class LocalicationText : MonoBehaviour
    {
        [SerializeField] private int _id;

        private void Start()
        {
            GetComponent<TMP_Text>().text = ServiceLocator.Resolver.Resolve<LocalizationContainer>().GetText(_id);
        }
    }
}