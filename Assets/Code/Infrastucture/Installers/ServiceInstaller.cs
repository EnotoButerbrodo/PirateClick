using Code.Clicker;
using Code.Services.InputService;
using Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastucture
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private AudioService _audio;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindWallet();
            BindClickerEvents();
            BindAudioService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromNew()
                .AsSingle();
        }

        private void BindWallet()
        {
            Container
                .Bind<IWallet>()
                .To<Wallet>()
                .FromNew()
                .AsSingle();
        }

        private void BindClickerEvents()
        {
            Container
                .Bind<ClickerEvents>()
                .FromNew()
                .AsSingle();
        }

        private void BindAudioService()
        {
            var audioSource = Container
                .InstantiatePrefabForComponent<AudioService>(_audio);

            Container
                .Bind<IAudioService>()
                .To<AudioService>()
                .FromInstance(audioSource)
                .AsSingle();
        }
    }
}