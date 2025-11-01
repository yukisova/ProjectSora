/// 享元模式：避免产生的多对象，减少内存以及占用性能，会尝试重用现有的同类对象
/// MVC中的M层
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 存储所有的数据模型，如场景的信息
/// </summary>
public class ModelContainer
{
    private static ModelContainer instance;
    public static ModelContainer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ModelContainer();
            }
            return instance;
        }
    }
    private Dictionary<Type, AModel> modelDic;
    private ModelContainer()
    {
        modelDic = new Dictionary<Type, AModel>();
        AddModel(new SceneModel());
        // AddModel(new PlayerModel());
    }

    public T GetModel<T>() where T : AModel
    {
        if (modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }
        return default(T);
    }
    private void AddModel<T>(T obj) where T: AModel
    {
        modelDic.Add(typeof(T), obj as T);
    }
}