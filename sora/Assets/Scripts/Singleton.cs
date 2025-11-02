using System;
using System.Reflection;

/// <summary>
/// 单例类，基于反射实现
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingleTon<T> where T: SingleTon<T>
{
    protected SingleTon() { }

    protected static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                {
                    throw new Exception("");
                }
                /// 基于反射获取单例类，
                instance = ctor.Invoke(null) as T;
            }
            return instance;
        }
    }
}