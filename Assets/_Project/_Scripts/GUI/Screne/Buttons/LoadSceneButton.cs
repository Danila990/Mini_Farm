using UnityEngine;

namespace MiniFarm
{
    public class LoadSceneButton : UIButton
    {
        [field: SerializeField] public int sceneLoad { get; private set; }

        public void SetIndex(int sceneLoad) => this.sceneLoad = sceneLoad;

        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            SceneLoader.LoadLevel(sceneLoad);
        }
    }
}