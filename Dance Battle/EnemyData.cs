using UnityEngine;

namespace DanceBattle
{
    [CreateAssetMenu(fileName = "New enemy data", menuName = "DanceBattleData/Create enemy data", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] [Min(0)] private int _roundIndex;
        [SerializeField] private float _speed;
        [SerializeField] private Color _sliderColor;
        [SerializeField] private ParticleSystem _spawnEffect;

        public Enemy Enemy => _enemy;
        public int RoundIndex => _roundIndex;
        public float Speed => _speed;
        public Color SliderColor => _sliderColor;
        public ParticleSystem SpawnEffect => _spawnEffect;
    }
}
