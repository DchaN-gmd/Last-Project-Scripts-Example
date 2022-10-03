using UnityEngine;

namespace UI
{
    public class ExitPanel : ChoicePanel
    {
        protected override void OnNoClick()
        {
            gameObject.SetActive(false);
        }

        protected override void OnYesClick()
        {
            Application.Quit();
        }
    }
}
