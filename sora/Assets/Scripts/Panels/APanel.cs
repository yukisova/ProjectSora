using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class APanel
{
    public GameObject gameObject { get; protected set; }
    protected APanel parent;
    protected List<APanel> children;
    public APanel(APanel parent)
    {
        this.parent = parent; 
    }
    protected virtual void OnFocus(){}
    protected virtual void OnClick(){}
}