using System;
using System.Reflection;

/// <summary>
/// 单例类，是一个可以随时进行访问的静态类
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
                /// 在T对应的类当中
                /// 获取所有非public 的构造方法
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                /// 从ctors中获取无参的构造方法
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                {
                    throw new Exception("");
                }
                instance = ctor.Invoke(null) as T;
            }
            return instance;
        }
    }
}