using UnityEngine;
using UnityEngine.UI;

namespace DanceBattle
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    {
        private readonly int Defeat = Animator.StringToHash("Defeat");

        private Animator _animator;
        private Image _slider;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void ShowDefeatAnimation()
        {
            _animator.SetTrigger(Defeat);
        }

        public void SetSlider(Image slider)
        {
            _slider = slider;
        }
    }
}
