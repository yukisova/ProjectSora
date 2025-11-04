using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class PanelBag: APanel
{
    Button closeButton;
    public PanelBag(APanel parent) : base(parent) { }

    protected override void OnInit()
    {
        base.OnInit();

        isShowAfterExit = true;
        closeButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "CloseButton");

        closeButton.onClick.AddListener(() =>
        {
            OnExit();
        });
    }

    protected override void OnFadeIn()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    protected override void OnFadeOut()
    {
        rectTransform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack);
    }
}