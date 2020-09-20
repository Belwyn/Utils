using Belwyn.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Belwyn.Utils.Logger;
using static Belwyn.Utils.Debugger;

public class DebugCalls : MonoBehaviour
{

    private float _time = 0f;


    void Update()
    {

        _time += Time.deltaTime;

        if (_time >= 1) {
            Log("TICK - this will only get printed if it is a test build!", this);
            DrawRay(transform.position, Vector3.right * 5, Color.magenta, 0.7f);
            _time = 0;
        }

    }
}
