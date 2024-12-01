using System.Collections.Generic;
using DG.Tweening;

namespace AudioController
{
    public class AudioController
    {
        private readonly AudioModelConfig _audioModelConfig;
        private readonly AudioView.Pool _audioPool;
        
        private List<AudioView> _listAudioView = new List<AudioView>();
        
        public AudioController(
            AudioModelConfig audioModelConfig,
            AudioView.Pool audioPool)
        {
            _audioModelConfig = audioModelConfig;
            _audioPool = audioPool;
        }
        public void Play(AudioType nameSound, bool isLoop = false)
        {
            var audio = _audioPool.Spawn(new AudioProtocol(_audioModelConfig.GetAudioModelByType(nameSound)));
            audio.AudioSource.Play();
        
            _listAudioView.Add(audio);
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
        }
    }
}