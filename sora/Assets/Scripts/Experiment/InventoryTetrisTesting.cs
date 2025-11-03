using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




// public class InventoryTetrisTesting : MonoBehaviour
// {
//     public struct AddItemTetris
//     {
//         public ItemTetrisSO itemTetrisSO;
//         public Vector2Int gridPosition;
//         public PlaceObjectTypeSO.Dir dir;
//     }

//     [SerializeField] private List<AddItemTetris> addItemTetrisList;

//     [SerializeField] private InventoryTetris inventoryTetris;

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             foreach (AddItemTetris addItemTetris in addItemTetrisList)
//             {
//                 inventoryTetris.TryPlaceItem(addItemTetris.itemTetrisSO, addItemTetris.gridPosition, addItemTetris.dir);
//             }
//         }
//     }
// }

// public class ItemTetrisSO : ScriptableObject
// {
//     public string itemName;
//     public Vector2Int size;
// }
// public class PlaceObjectTypeSO : ScriptableObject
// {
//     public enum Dir
//     {
//         Up,
//         Right,
//         Down,
//         Left
//     }
// }
// public class InventoryTetris
// {
//     public bool TryPlaceItem(ItemTetrisSO itemTetrisSO, Vector2Int gridPosition, PlaceObjectTypeSO.Dir dir)
//     {
//         Debug.Log($"尝试放置物品 {itemTetrisSO.itemName} 在位置 {gridPosition} 方向 {dir}");
//         return true;
//     }
// }