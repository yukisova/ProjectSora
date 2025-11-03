using System;
using System.Linq;
using UnityEngine;
public class SoraUtil
{
    /// <summary>
    /// 查找某个游戏物体下的指定物体的指定组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">游戏物品</param>
    /// <param name="name"></param>
    /// <param name="isActive">是否仅查找激活的</param>
    /// <returns></returns>
    public static T getComponentFormChildren<T>(GameObject obj, string name, bool isActive = false)
    {
        foreach (Transform t in obj.GetComponentsInChildren<Transform>(!isActive))
        {
            if (t.name == name)
            {
                if (t.GetComponent<T>() != null)
                {
                    return t.GetComponent<T>();
                }
            }
        }
        return default;
    }

    public static bool isGenericType(Type type, Type generic)
    {
        if (type == null || generic == null) return false;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == generic)
            return true;

        Type baseType = type.BaseType;
        while (baseType != null && baseType != typeof(object))
        {
            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == generic)
                return true;
            baseType = baseType.BaseType;
        }

        return type.GetInterfaces().Any(interfaceType =>
            interfaceType.IsGenericType &&
            interfaceType.GetGenericTypeDefinition() == generic
        );
    }
}