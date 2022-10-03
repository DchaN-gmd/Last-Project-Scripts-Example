using LoadSystems;
using UnityEngine;

namespace UI
{
    public class ExitMainMenuPanel : ChoicePanel
    {
        [Space]
        [SerializeField] private LoadSystem _loadSystem;
        [SerializeField] [Min(0)] private int _mainMenuIndex;

        protected override void OnNoClick()
        {
            gameObject.SetActive(false);
        }

        protected override void OnYesClick()
        {
            _loadSystem.LoadSceneSingle(_mainMenuIndex);
        }
    }
}
