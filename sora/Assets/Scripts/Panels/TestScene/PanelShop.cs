
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelShop: APanel
{
    Button closeButton;
    public PanelShop(APanel parent) : base(parent)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();

        closeButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "CloseButton");

        closeButton.onClick.AddListener(() =>
        {
            OnExit();
        });
    }
}