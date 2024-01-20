using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Events/deathEvents")]

public class deathEvent : ScriptAbleObjectBase
{
    public UnityAction<bool> onEventRaised;

    public void RaiseEvent(bool value)
    {
        onEventRaised?.Invoke(value);
    }

    public void Subscribe(UnityAction<bool> function)
    {
        onEventRaised += function;
    }

    public void UnSubscribe(UnityAction<bool> function)
    {
        onEventRaised -= function;
    }
}
