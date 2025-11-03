using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 针对物品实现拖拽功能，并对当前期望放置区域进行标识（能放标绿，不能放标蓝）
/// </summary>
public class InventoryDragDrop: MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    public Action<InventoryDragDrop> FinishDragAction; 
    public Action<InventoryDragDrop> StartDragAction;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        rectTransform.position = eventData.position;
        StartDragAction.Invoke(this);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        FinishDragAction.Invoke(this);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        /// 进行拖拽
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}