using UnityEngine;
using UnityEngine.UI;

public class PanelAttribute: APanel
{
    Slider hpSlider;
    Slider mpSlider;
    Button bagButton;
    Button shopButton;

    public PanelAttribute(APanel parent): base(parent)
    {
        children.Add(new PanelBag(this));
        children.Add(new PanelShop(this));
    }
    protected override void OnInit()
    {
        base.OnInit();
        hpSlider = SoraUtil.getComponentFormChildren<Slider>(theGameObject, "Hp");
        mpSlider = SoraUtil.getComponentFormChildren<Slider>(theGameObject, "Mp");
        bagButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "BagButton");
        shopButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "ShopButton");
        bagButton.onClick.AddListener(() =>
        {
            EnterPanel<PanelBag>();
        });
        shopButton.onClick.AddListener(() =>
        {
            EnterPanel<PanelShop>();
        });
    }
}