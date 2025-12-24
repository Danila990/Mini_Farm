using UnityEngine;
using UnityEngine.UI;

namespace MiniFarm
{
    public class AudionChanger : MonoBehaviour
    {
        [SerializeField] private Sprite _offState;
        [SerializeField] private Button _sound;
        [SerializeField] private Button _music;

        private Image _imageSound;
        private Image _imageMusic;
        private AudioSystem _audioSystem;
        private Sprite _onState;

        private void Start()
        {
            _audioSystem = ServiceLocator.Resolver.Resolve<AudioSystem>();
            _onState = _sound.GetComponent<Image>().sprite;
            _imageSound = _sound.GetComponent<Image>();
            _imageMusic = _music.GetComponent<Image>();

            ChangeSoundImage();
            ChangeMusicImage();
            _sound.onClick.AddListener(OnClickSound);
            _music.onClick.AddListener(OnClickMusic);
        }

        private void OnDestroy()
        {
            _sound.onClick.RemoveListener(OnClickSound);
            _music.onClick.RemoveListener(OnClickMusic);
        }

        private void OnClickSound()
        {
            _audioSystem.SetSoundMute(!_audioSystem.IsSoundMute);
            ChangeSoundImage();
        }

        private void OnClickMusic()
        {
            _audioSystem.SetMusicMute(!_audioSystem.IsMusicMute);
            ChangeMusicImage();
        }

        private void ChangeSoundImage()
        {
            if (!_audioSystem.IsSoundMute)
                _imageSound.sprite = _onState;
            else
                _imageSound.sprite = _offState;
        }

        private void ChangeMusicImage()
        {
            if (!_audioSystem.IsMusicMute)
                _imageMusic.sprite = _onState;
            else
                _imageMusic.sprite = _offState;
        }
    }
}