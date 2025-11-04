using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public abstract class APanel
{
    public GameObject theGameObject { get; protected set; }
    public Transform theTransform => theGameObject.transform;
    public RectTransform rectTransform { get; protected set; }

    protected APanel parent;
    protected List<APanel> children;
    private GameObject Canvas; 

    private bool isInit;
    private bool isEnter;
    private bool isSuspend;
    protected bool isShowAfterExit;

    public APanel(APanel panel)
    {
        parent = panel;
        children = new List<APanel>();
    }
    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        foreach(APanel panel in children)
        {
            panel.GameUpdate();
        }
        if (!isSuspend)
        {
            OnUpdate();
        }
    }

    protected virtual void OnInit()
    {
        Suspend();
        Canvas = GameObject.Find("Canvas");
        if (theGameObject == null)
        {
            theGameObject = SoraUtil.getComponentFormChildren<Transform>(Canvas, GetType().Name).gameObject;
        }
        rectTransform = theGameObject.GetComponent<RectTransform>();
    }
    protected virtual void OnEnter()
    {
        theGameObject.SetActive(true);
        OnFadeIn();
    }
    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }
    public virtual void OnExit()
    {
        OnFadeOut();
        if (!isShowAfterExit)
        {
            theGameObject.SetActive(false);
        }
        parent.isEnter = false;
        parent.Resume();
        Suspend();
    }
    public void EnterPanel<T>() where T : APanel
    {
        if (isSuspend) return;
        APanel panel = GetPanel<T>();
        panel.Resume();
        panel.isEnter = false;
        Suspend();
    }
    public T GetPanel<T>() where T : APanel
    {
        return children.Where(x => x is T).ToArray()[0] as T;
    }
    public virtual void Suspend()
    {
        isSuspend = true;
    }
    public virtual void Resume()
    {
        isSuspend = false;
    }

    protected virtual void OnFadeIn(){}
    protected virtual void OnFadeOut(){}
}