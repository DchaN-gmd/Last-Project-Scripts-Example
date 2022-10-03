using PlayerSystemDDX;
using UnityEngine;
using UnityEngine.Events;

namespace DanceBattle
{
    public class DanceBattlePlayer : Player
    {
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private UnityEvent<DanceBattlePlayer> _playerWinning;

        public event UnityAction<DanceBattlePlayer> PlayerWinning
        {
            add => _playerWinning.AddListener(value);
            remove => _playerWinning.RemoveListener(value);
        }

        private void OnEnable()
        {
            _spawner.StoppedSpawn += OnStopSpwan;
        }

        private void OnDisable()
        {
            _spawner.StoppedSpawn -= OnStopSpwan;
        }

        private void OnStopSpwan()
        {
            _playerWinning?.Invoke(this);
        }
    }
}