using Helpers;
using UnityEngine;

namespace Behaviours
{
    struct BackgroundMusicEvent
    {
        private AudioClip _audioClip;
        private static BackgroundMusicEvent _soundEvent;

        public AudioClip AudioClip => _audioClip;

        public static void Trigger(AudioClip audioClip)
        {
            _soundEvent._audioClip = audioClip;
            EventManager.TriggerEvent(_soundEvent);
        }
    }
}