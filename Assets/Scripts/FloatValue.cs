using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu] //Adds to the Create Object menu list

public class FloatValue : ScriptableObject, ISerializationCallbackReceiver //lives outside of scenes
{
    public float initialValue;

    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;  //reset value
    }

    //Serialization is when you load object from memory (start of the game)
    public void OnBeforeSerialize()
    {

    }

}
