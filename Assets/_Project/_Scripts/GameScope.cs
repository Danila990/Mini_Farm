using UnityEngine;

namespace MiniFarm
{
    public class GameScope : ServiceLocator
    {
        [Space(5)]
        [Header("Scope")]
        [SerializeField] private LocalizationContainer _localizationContainer;
        [SerializeField] private AudioSystem _audioSystem;

        [Header("Ui")]
        [SerializeField] private WindowController _windowController;
        
        [Header("Grid")]
        [SerializeField] private LevelSettings _levelSetting;

        [Header("Player")]
        [SerializeField] private UserInput _userInput;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerDirectionArrow _playerArrow;

        public override void Configurate(IBuilder builder)
        {
            builder.RegisterInstantiate(_audioSystem);
            builder.RegisterInstantiate(_localizationContainer);
            builder.RegisterNewClass<GameManager>();
            BuildUI(builder);
            BuildLevel(builder);
            BuildPlayer(builder);
        }

        private void BuildLevel(IBuilder builder)
        {
            LevelData levelData = _levelSetting.GetLevelData(SceneLoader.ÑurrentLevel);

            builder.RegisterInstantiate(_levelSetting);
            builder.RegisterInstantiate(levelData);
            builder.RegisterInstantiate<GridMap, IGridMap>(levelData.gridMap);
            builder.RegisterNewClass<FruitController>();
            builder.RegisteNewGameobject<LevelTimer>();
        }

        private void BuildUI(IBuilder builder)
        {
            builder.Register(_windowController);
        }

        private void BuildPlayer(IBuilder builder)
        {
            switch (_userInput)
            {
                case _ or UserInput.Pc:
                    builder.RegisteNewGameobject<KeybordInput, IInputService>();
                    break;
            }

            builder.RegisterInstantiate(_player);
            builder.RegisterInstantiate(_playerArrow);
        }
    }
}