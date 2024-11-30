﻿using System.Collections.Generic;
using DG.Tweening;

namespace AudioController
{
    public class AudioController
    {
        private readonly AudioModelConfig _audioModelConfig;
        private readonly AudioView.Pool _audioPool;
        
        private List<AudioView> _listAudioView = new List<AudioView>();
        private Dictionary<AudioType, AudioView> _dictionary = new Dictionary<AudioType, AudioView>();
        
        public AudioController(
            AudioModelConfig audioModelConfig,
            AudioView.Pool audioPool)
        {
            _audioModelConfig = audioModelConfig;
            _audioPool = audioPool;
        }
        public void Play(AudioType nameSound,float pitchValue, bool isLoop = false)
        {
            var audio = _audioPool.Spawn(new AudioProtocol(_audioModelConfig.GetAudioModelByType(nameSound)));
            audio.AudioSource.pitch = pitchValue;
            audio.AudioSource.Play();
        
            _listAudioView.Add(audio);
            _dictionary.Add(nameSound, audio);
            if (!isLoop)
            {
                DOVirtual.DelayedCall(audio.AudioSource.clip.length, () =>
                {
                    DespawnAudio(nameSound, audio);
                });
            }
        }

        public void DespawnAudio(AudioType nameSound, AudioView audio)
        {
            audio.AudioSource.clip = null;
                    
            _audioPool.Despawn(audio);
            _listAudioView.Remove(audio);
            _dictionary.Remove(nameSound);
        }
    }
}