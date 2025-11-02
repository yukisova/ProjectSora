using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    OnSceneChangeComplete,
}
public class EventCenter: SingleTon<EventCenter>
{
    private EventCenter()
    {
        EventDic = new Dictionary<EventType, List<IEventInfo>>();
    }

    public class IEventInfo{}
    public class EventInfo: IEventInfo
    {
        public UnityAction action;
        public EventInfo(UnityAction action)
        {
            this.action = action;
        }
    }
    public class EventInfo<T> : IEventInfo
    {
        public UnityAction<T> action;
        public EventInfo(UnityAction<T> action)
        {
            this.action = action;
        }
    }
    /// <summary>
    /// 在单例中切换场景的时候不应该被移除的事件
    /// </summary>
    public class PermanentEventInfo: IEventInfo
    {
        public UnityAction action;
        public PermanentEventInfo(UnityAction action)
        {
            this.action = action;
        }
    }
    public class PermanentEventInfo<T>: IEventInfo
    {
        public UnityAction<T> action;
        public PermanentEventInfo(UnityAction<T> action)
        {
            this.action = action;
        }
    }
    private Dictionary<EventType, List<IEventInfo>> EventDic;
    public void RegisterObserver(EventType type, UnityAction action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> { new EventInfo(action) });
        }
        else
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is EventInfo)
                {
                    (info as EventInfo).action += action;
                }
            }
        }
    } 
    public void RegisterObserver<T>(EventType type, UnityAction<T> action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> { new EventInfo<T>(action) });
        }
        else
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is EventInfo<T>)
                {
                    (info as EventInfo<T>).action += action;
                }
            }
        }
    }
    public void RegisterPermanentObserver(EventType type, UnityAction action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> { new PermanentEventInfo(action) });
        }
        else
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is PermanentEventInfo)
                {
                    (info as PermanentEventInfo).action += action;
                }
            }
        }
    } 
    public void RegisterPermanentObserver<T>(EventType type, UnityAction<T> action)
    {
        if (!EventDic.ContainsKey(type))
        {
            EventDic.Add(type, new List<IEventInfo> { new PermanentEventInfo<T>(action) });
        }
        else
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is PermanentEventInfo<T>)
                {
                    (info as PermanentEventInfo<T>).action += action;
                }
            }
        }
    }
    public void NotisfyObserver(EventType type)
    {
        if (EventDic.ContainsKey(type))
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is EventInfo)
                {
                    (info as EventInfo).action.Invoke();
                }
                else if (info is PermanentEventInfo)
                {
                    (info as PermanentEventInfo).action.Invoke();
                }
            }
        }
    }
    public void NotisfyObserver<T>(EventType type, T param)
    {
        if (EventDic.ContainsKey(type))
        {
            foreach(IEventInfo info in EventDic[type])
            {
                if (info is EventInfo<T>)
                {
                    (info as EventInfo<T>).action.Invoke(param);
                }
                else if (info is PermanentEventInfo<T>)
                {
                    (info as PermanentEventInfo<T>).action.Invoke(param);
                }
            }
        }
    }
 
    public void ClearObserver()
    {
        foreach(EventType type in Enum.GetValues(typeof(EventType)))
        {
            for (int i = 0; i < EventDic[type].Count; i++)
            {
                if (EventDic[type][i] is not PermanentEventInfo && !SoraUtil.isGenericType(EventDic[type][i].GetType(), typeof(PermanentEventInfo<>)))
                {
                    EventDic[type].RemoveAt(i);
                }
            }
        }
    }
    
}