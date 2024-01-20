using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class deathEventListener : MonoBehaviour
{
    [SerializeField] private deathEvent _event = default;

    public UnityEvent listener;

    private void OnEnable()
    {
        _event?.Subscribe(Respond);
    }


    private void OnDisable()
    {
        _event?.UnSubscribe(Respond);
    }

    private void Respond(bool idk)
    {
        listener?.Invoke();
    }
}

