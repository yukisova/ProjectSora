using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridXYBuild: MonoBehaviour
{
    public GridXY<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 1f;
        grid = new GridXY<GridObject>(gridWidth, gridHeight, cellSize, Vector2.zero, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }
    public class GridObject
    {
        private GridXY<GridObject> grid;
        private int x;
        private int y;
        private Transform transform;

        public GridObject(GridXY<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, y);
        }

        public void ClearTransform()
        {
            this.transform = null;
            grid.TriggerGridObjectChanged(x, y);
        }

        public bool CanBuild()
        {
            return transform == null;
        }

        public override string ToString()
        {
            return x + ", " + y;
        }
    }
}
