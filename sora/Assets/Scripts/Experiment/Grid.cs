using Unity.VisualScripting;
using UnityEngine;
using System;

/// <summary>
/// 三维网格下的Grid，一般用于地图内的移动与定位
/// </summary>
/// <typeparam name="T"></typeparam>
public class GridXZ<T>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition; // 网格原点位置，默认为原点
    private T[,] gridArray;
    private TextMesh[,] debugTextArray;

    public GridXZ(int width, int height, float cellSize, Vector3 originPosition = default(Vector3), Func<GridXZ<T>, int, int, T> createGridObject = null)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // 绘制坐标文本
                debugTextArray[x, z] = Utils.CreateWorldText(createGridObject(this, x, z).ToString(), null, GetWorldPosition(x, z) + GetCellHalfSize(), 10, Color.white, TextAnchor.MiddleCenter);
                debugTextArray[x, z].transform.rotation = Quaternion.Euler(90, 0, 0);
                // 绘制网格线（）
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }
    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }

    public Vector3 GetCellHalfSize()
    {
        return new Vector3(cellSize, 0, cellSize) * 0.5f;
    }

    /// <summary>
    /// 根据网格索引设置值
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="z">y</param>
    /// <param name="value">设置的值</param>
    public void SetValue(int x, int z, T value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
        }
    }

    /// <summary>
    /// 根据世界坐标设置值
    /// </summary>
    /// <param name="worldPosition">需要另外转换成索引的世界坐标</param>
    /// <param name="value">设置的值</param>
    public void SetValue(Vector3 worldPosition, T value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, value);
    }

    public T GetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            return default(T);
        }
    }

    public T GetValue(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetValue(x, z);
    }

    /// <summary>
    /// 修改网格中的信息（如果没有完成的话进行一定的修复）
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    public void TriggerGridObjectChanged(int x, int z)
    {
    }
}


/// <summary>
/// 二维下的网格，可以用于UI
/// </summary>
/// <typeparam name="T"></typeparam>
public class GridXY<T>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector2 originPosition; // 网格原点位置，默认为原点
    private T[,] gridArray;
    private TextMesh[,] debugTextArray;

    public GridXY(int width, int height, float cellSize, Vector2 originPosition = default(Vector2), Func<GridXY<T>, int, int, T> createGridObject = null)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                // 绘制坐标文本
                debugTextArray[x, y] = Utils.CreateWorldText(createGridObject(this, x, y).ToString(), null, GetScreenPosition(x, y) + GetCellHalfSize(), 10, Color.white, TextAnchor.MiddleCenter);
                // 绘制网格线（）
                Debug.DrawLine(GetScreenPosition(x, y), GetScreenPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetScreenPosition(x, y), GetScreenPosition(x + 1, y), Color.white, 100f);

            }
        }
        Debug.DrawLine(GetScreenPosition(0, height), GetScreenPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetScreenPosition(width, 0), GetScreenPosition(width, height), Color.white, 100f);
    }

    public Vector2 GetScreenPosition(int x, int y)
    {
        return new Vector2(x, y) * cellSize + originPosition;
    }
    public void GetXY(Vector2 screenPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((screenPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((screenPosition - originPosition).y / cellSize);
    }

    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }

    public Vector2 GetCellHalfSize()
    {
        return new Vector2(cellSize, cellSize) * 0.5f;
    }

    /// <summary>
    /// 根据网格索引设置值
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    /// <param name="value">设置的值</param>
    public void SetValue(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    /// <summary>
    /// 根据世界坐标设置值
    /// </summary>
    /// <param name="screenPosition">需要另外转换成索引的世界坐标</param>
    /// <param name="value">设置的值</param>
    public void SetValue(Vector2 screenPosition, T value)
    {
        int x, y;
        GetXY(screenPosition, out x, out y);
        SetValue(x, y, value);
    }

    public T GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(T);
        }
    }

    public T GetValue(Vector2 screenPosition)
    {
        int x, y;
        GetXY(screenPosition, out x, out y);
        return GetValue(x, y);
    }

    /// <summary>
    /// 修改网格中的信息（如果没有完成的话进行一定的修复）
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void TriggerGridObjectChanged(int x, int y)
    {
    }
}