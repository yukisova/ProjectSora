using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryDragDropSystem : MonoBehaviour
{

    public Vector2Int currentPointGrid;
    public Vector2Int originPointGrid; /// 物品原本的位置
    InventoryGridMap[][] gridMaps;
    private GridLayoutGroup gridLayoutGroup;
    List<InventoryDragDrop> dragDrops;
    private void Start()
    {
        currentPointGrid = Vector2Int.left;
        gridLayoutGroup = GetComponentInChildren<GridLayoutGroup>();
        int columns = gridLayoutGroup.constraintCount;

        gridMaps = gridLayoutGroup.gameObject.GetComponentsInChildren<InventoryGridMap>()
            .Select((value, index) => new { Value = value, Index = index })
            .GroupBy(x => x.Index / columns)
            .Select(g => g.Select(x => x.Value).ToArray())
            .ToArray();

        dragDrops = GetComponentsInChildren<InventoryDragDrop>().ToList();
        foreach(InventoryDragDrop dragDrop in dragDrops)
        {
            dragDrop.FinishDragAction = (item) =>
            {
                Vector2Int index = CheckPointInGrid(TryGetInputPoint());
                if (index.x == -1 || index.y == -1)
                {
                    item.transform.position = gridMaps[originPointGrid.x][originPointGrid.y].transform.position;
                }
                else
                {
                    item.transform.position = gridMaps[index.x][index.y].transform.position; 
                }
            };
            dragDrop.StartDragAction = (item) =>
            {
                originPointGrid = CheckPointInGrid(item.transform.position);
            };
        }
    }
    private void Update()
    {
        Vector2 mousePosition = TryGetInputPoint();
        if (mousePosition != Vector2.left)
        {
            Vector2Int pointInGrid = CheckPointInGrid(mousePosition);
            if (pointInGrid != currentPointGrid)
            {
                currentPointGrid = pointInGrid;
            }
            gridMaps.ToList().ForEach(row => row.ToList().ForEach(cell => cell.isHighlighted = false));
            if (currentPointGrid.x != -1 && currentPointGrid.y != -1)
            {
                gridMaps[currentPointGrid.x][currentPointGrid.y].isHighlighted = true;
            }
        }
        else
        {
            gridMaps.ToList().ForEach(row => row.ToList().ForEach(cell => cell.isHighlighted = false));
        }
    }

    private Vector2 TryGetInputPoint()
    {
        Vector2 mousePosition = Input.mousePosition;
        #if PLATFORM_ANDROID
        if (Input.touchCount > 0)
        {
            mousePosition = Input.GetTouch(0).position;
        }
        else
        {
            mousePosition = Vector2.left;
        }
#endif
        return mousePosition;
    }

    private Vector2Int CheckPointInGrid(Vector2 position)
    {
        for (int x = 0; x < gridMaps.Length; x++)
        {
            for (int y = 0; y < gridMaps[x].Length; y++)
            {
                RectTransform rectTransform = gridMaps[x][y].GetComponent<RectTransform>();
                Vector3[] worldCorners = new Vector3[4];
                rectTransform.GetWorldCorners(worldCorners);
                Rect rect = new Rect(worldCorners[0], worldCorners[2] - worldCorners[0]);

                if (rect.Contains(position))
                {
                    return new Vector2Int(x, y);
                }
                else
                {
                    continue;
                }
            }
        }
        return new Vector2Int(-1, -1);
    }
}