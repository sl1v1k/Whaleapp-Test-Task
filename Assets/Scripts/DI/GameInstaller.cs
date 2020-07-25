using Zenject;
using UnityEngine;

namespace FSM.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameConfig config;

        public override void InstallBindings()
        {
            InstallGameManager();
            InstallFactory();
            InstallSignals();
        }

        private void InstallGameManager()
        {
            Container.BindInterfacesTo<GameManager>().AsSingle();  
        }

        private void InstallFactory()
        {
            Container.BindFactory<Unit, Unit.Factory>().FromComponentInNewPrefab(config.unitPrefab);
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<UnitDestroyedSignal>();
            Container.DeclareSignal<GameOverSignal>();
        }
    }
}