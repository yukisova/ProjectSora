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
            
        }
        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelAttribute>();
        }
    }
}