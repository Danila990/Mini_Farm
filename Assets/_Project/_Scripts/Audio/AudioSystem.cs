using System;
using System.Linq;
using UnityEngine;
using YG;

namespace MiniFarm
{
    [Serializable]
    public class SoundData
    {
        [field: SerializeField] public AudioClip audioClip { get; private set; }
        [field: SerializeField, Range(0, 1)] public float volume { get; private set; } = 1.0f;

        public string id => audioClip.name;
    }

    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private SoundData[] _sounds;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioSource _music;

        public bool IsMusicMute => _music.mute;
        public bool IsSoundMute => _sound.mute;

        private void Start()
        {
            SetMusicMute(YG2.saves.IsMusicMute);
            SetSoundMute(YG2.saves.IsSoundMute);
        }

        public void SetSoundMute(bool mute)
        {
            _sound.mute = mute;
        }
        public void SetMusicMute(bool state)
        {
            _music.mute = state;
        }

        public void Play(string id)
        {
            if (!_sound.mute)
            {
                SoundData soundData = GetSoundData(id);
                _sound.PlayOneShot(soundData.audioClip, soundData.volume);
            }
        }

        private SoundData GetSoundData(string id)
        {
            return _sounds.FirstOrDefault(sound => sound.id == id);
        }
    }
}