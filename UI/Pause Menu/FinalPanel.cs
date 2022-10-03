namespace UI
{
    public class FinalPanel : ChoicePanel
    {
        protected override void OnNoClick()
        {
            gameObject.SetActive(false);
        }

        protected override void OnYesClick()
        {
            
        }
    }
}
