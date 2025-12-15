using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MiniFarm
{
    public class GameScope : ServiceScore
    {
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

        protected override void BuildServices(IServiceContainer container)
        {
            ServiceLocator.Set(_gameSettings);
            BuildGameManager(container);
            BuildGrid(container);
            BuildLogick(container);
            BuildPlayerArrow(container);
        }

        private void BuildLogick(IServiceContainer container)
        {
            FruitCounter fruitCounter = _parrentScope.AddComponent<FruitCounter>();
            LevelTimer timeCounter = _parrentScope.AddComponent<LevelTimer>();

            container.Set(fruitCounter).Set(timeCounter);
        }

        private void BuildPlayerArrow(IServiceContainer container)
        {
            IInputService inputService = _userInput switch
            {
                _ or UserInput.Mobile => _parrentScope.AddComponent<KeybordInput>(),
            };

            _player = Instantiate(_player);
            _playerArrow = Instantiate(_playerArrow);

            container.Set<IInputService>(inputService).Set(_player).Set(_playerArrow);
        }

        private void BuildGrid(IServiceContainer container)
        {
            container.Set<IGridMap>(_gridMap);
        }

        private void BuildGameManager(IServiceContainer container)
        {
            GameManager gameManager = _parrentScope.AddComponent<GameManager>();
            container.Set(gameManager);
        }
    }
}