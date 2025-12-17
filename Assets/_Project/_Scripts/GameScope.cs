using UnityEngine;

namespace MiniFarm
{
    public class GameScope : ServiceLocator
    {
        [Header("Scope")]
        [SerializeField] private WindowController _windowController;
        [SerializeField] private AudioSystem _audioSystem;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private GridMap _gridMap;

        [Header("Player")]
        [SerializeField] private UserInput _userInput;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerDirectionArrow _playerArrow;


        private void OnValidate()
        {
            _gridMap ??= FindAnyObjectByType<GridMap>();
        }

        public override void Configurate(IBuilder builder)
        {
            builder.Instantiate(_audioSystem);
            builder.Register(_gameSettings);
            builder.Register(_windowController);
            builder.Register<GameManager>();
            builder.Register<IGridMap>(_gridMap);
            builder.Register<FruitController>();
            builder.Instantiate<LevelTimer>();

            BuildInput(builder);
            builder.Instantiate(_player);
            builder.Instantiate(_playerArrow);
        }

        private void BuildInput(IBuilder builder)
        {
            switch (_userInput)
            {
                case _ or UserInput.Pc:
                    builder.Instantiate<KeybordInput, IInputService>();
                    break;
            }
        }
    }
}