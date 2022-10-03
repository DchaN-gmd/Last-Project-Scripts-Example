using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class ChoicePanel : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] protected Button _yesButton;
        [SerializeField] protected Button _noButton;

        protected void OnEnable()
        {
            _yesButton.onClick.AddListener(OnYesClick);
            _noButton.onClick.AddListener(OnNoClick);
        }

        protected void OnDisable()
        {
            _yesButton.onClick.RemoveListener(OnYesClick);
            _noButton.onClick.RemoveListener(OnNoClick);
        }

        protected abstract void OnYesClick();
        protected abstract void OnNoClick();
    }
}
