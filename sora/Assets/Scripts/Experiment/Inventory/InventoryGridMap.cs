using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 实现背包网格映射
/// </summary>

public class InventoryGridMap: MonoBehaviour
{
    /// 1. 针对网格当前的位置，进行初始化
    /// 2. 提供网格坐标与屏幕坐标的转换方法
    /// 3. 鼠标位置转换为网格坐标
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    private bool _isHightlighted = false;
    public bool isHighlighted
    {
        get { return _isHightlighted; }
        set
        {
            _isHightlighted = value;
            if (_isHightlighted)
            {
                image.color = Color.yellow;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }

}