using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Belwyn.Utils;
using Belwyn.Utils.Test;

public class AwakeInvoke : MonoBehaviour
{

    public string text = "It is a test build! The debug event got fired";

    public StringEventDebug stringDebugEvent;


    private void Start() {
        stringDebugEvent.Invoke(text);
    }

}
