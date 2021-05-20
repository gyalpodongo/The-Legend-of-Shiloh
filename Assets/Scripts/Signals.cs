using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Signals : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>(); 
    
    public void Raise()
    {
        for(int i=listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised(); 
        }

    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener); //add SignalListener object to list
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener); //remove SignalListener object from list
    }
}
