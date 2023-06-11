using Code.Clicker;
using Code.Services.InputService;
using Zenject;

namespace Code.Infrastucture
{
    public class ServiceInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindWallet();
            BindClickerEvents();
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
    }
}