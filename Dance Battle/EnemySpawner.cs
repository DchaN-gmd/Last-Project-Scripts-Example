using LevelSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WebCamSystem.Processing;

namespace DanceBattle
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Inspector Fields
        [Header("Controllers")]
        [SerializeField] private Level _level;
        [SerializeField] private FillProgressBarMoutionProcessor _moutionProcessor;

        [Header("Enemy data")]
        [SerializeField] private EnemyData[] _enemyData;

        [Header("Parameters")]
        [SerializeField] private float _delayBeforeSpawnNextEnemy;
        [SerializeField] private Transform _sideContainer;
        [SerializeField] private Image _slider;
        [SerializeField] private int _roundIndex;
        [SerializeField] private Transform _enemyPoint;
        [SerializeField] private Transform _effectPoint;

        [Header("Events")]
        [SerializeField] private UnityEvent _stoppedSpawn;
        #endregion

        #region Fields
        private Enemy _currentEnemy;
        private ParticleSystem _spawnEnemyEffect;
        private bool _isStopSpawn = false;
        private bool _isReload = false;
        #endregion

        public event UnityAction StoppedSpawn
        {
            add => _stoppedSpawn?.AddListener(value);
            remove => _stoppedSpawn.RemoveListener(value);
        }

        #region Unity Functions
        private void OnEnable()
        {
            _moutionProcessor.Filled += OnFilled;
            _level.RoundStarted += Spawn;
        }

        private void OnDisable()
        {
            _moutionProcessor.Filled -= OnFilled;
            _level.RoundStarted -= Spawn;
        }
        #endregion


        private void Spawn()
        {
            for (int i = 0; i < _enemyData.Length; i++)
            {
                if (_enemyData[i].RoundIndex == _roundIndex)
                {
                    _spawnEnemyEffect = Instantiate(_enemyData[i].SpawnEffect, _sideContainer);
                    _spawnEnemyEffect.transform.position = _effectPoint.position;
                    _spawnEnemyEffect.Play();

                    _currentEnemy = Instantiate(_enemyData[i].Enemy, _sideContainer);
                    _currentEnemy.transform.position = _enemyPoint.position;
                    _currentEnemy.SetSlider(_slider);

                    _moutionProcessor.SetSliderColor(_enemyData[i].SliderColor);
                    _moutionProcessor.Speed = _enemyData[i].Speed;
                }
            }
        }

        private void OnFilled()
        {
            _moutionProcessor.enabled = false;

            if (_roundIndex == _enemyData.Length)
            {
                if(!_isStopSpawn)
                {
                    _isStopSpawn = true;
                    _currentEnemy.ShowDefeatAnimation();

                    _stoppedSpawn?.Invoke();
                }
                return;
            }

            if (!_isReload)
            {
                StartCoroutine(DelaySystem.DelayFunction(_delayBeforeSpawnNextEnemy, NextEnemy));
                _isReload = true;
            }
        }

        private void NextEnemy()
        {
            _roundIndex++;
            _isReload = false;

            _moutionProcessor.enabled = true;
            _moutionProcessor.ResetProgressBar();

            Destroy(_spawnEnemyEffect.gameObject);
            Destroy(_currentEnemy.gameObject);
            Spawn();
        }
    }
}