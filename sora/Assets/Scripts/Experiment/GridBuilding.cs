/// 用于创建网格的特殊系统，与Grid配合使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem: MonoBehaviour
{
    [SerializeField] private ProjectObjectTypeSO testTransform; 
    public GridXZ<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 1f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.left * 3 + Vector3.back * 3, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }

    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, z);
        }

        public void ClearTransform()
        {
            this.transform = null;
            grid.TriggerGridObjectChanged(x, z);
        }

        public bool CanBuild()
        {
            return transform == null;
        }

        public override string ToString()
        {
            return x + ", " + z;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);
            GridObject gridObject = grid.GetValue(x, z);
            // if (gridObject.CanBuild())
            // {

            // }
        }
    }
}

public class Mouse3D
{
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 worldPosition = hitInfo.point;
            return worldPosition;
        }
        return Vector3.negativeInfinity;
    }
}
