using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class PanelBag: APanel
{
    Button closeButton;
    List<Button> gridButtons;
    public PanelBag(APanel parent) : base(parent)
    {

    }

    protected override void OnInit()
    {
        base.OnInit();

        closeButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "CloseButton");
        // gridButtons = theGameObject.GetComponentsInChildren<SymbolGridInventory>().Select(e => e.gameObject.GetComponent<Button>()).ToList();

        // foreach(Button gridButton in gridButtons)
        // {
        //     gridButton.onClick.AddListener(() =>
        //     {

        //     });
        // }

        closeButton.onClick.AddListener(() =>
        {
            OnExit();
        });
    }
}

public class SymbolGridInventory: MonoBehaviour
{

}