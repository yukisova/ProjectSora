/// 用于实现虚拟摇杆的部分，不然的话只有JoyStick
/// 拟采用DR2C的方案
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoyStick : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            Debug.Log(touchPosition);
        }
    }
}
