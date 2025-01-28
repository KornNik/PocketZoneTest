using Helpers;
using System.Threading.Tasks;
using System;

namespace Behaviours
{
    sealed class LoadLevelState : BaseState
    {
        private ILevelLoader _levelLoader;
        private UnitsFabric _playerFabric;
        private UnitsFabric _enemyFabric;

        public LoadLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _playerFabric = new PlayerFabric();
            _enemyFabric = new EnemyFabric();
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }
        private async void LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(CreateUnits);
            await LoadTask(StartGameState);
        }

        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelByIndex(0);
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
        private void CreateUnits()
        {
            _playerFabric.CreateUnit();
            _enemyFabric.CreateUnit();
        }
    }
}
