namespace TestGame
{
    public class PanelRoot: APanel
    {
        /// PanelAttribute
        APanel panelAttribute;
        /// PanelBag
        APanel panelBag;
        /// PanelShop 
        APanel panelShop;

        public PanelRoot(): base(null)
        {
            children.Add(new PanelAttribute(this));
        }
        protected override void OnInit()
        {
            base.OnInit();
            Resume();
            EventCenter.Instance.RegisterObserver(EventType.OnSceneChangeComplete, () =>
            {
                theGameObject.SetActive(false);
            });
        }
        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelAttribute>();
        }
    }
}