using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuıDebugger : MonoBehaviour
{
    void OnGUI()
    {
        for (int i = 0; i < InputHandler.instance.buffer.Length; i++)
        {
            
            GUI.Label(new Rect(100*i , 60, 50, 50), InputHandler.instance.buffer[i].type.ToString() + " : " + InputHandler.instance.buffer[i].holdType.ToString());
        }
    }

}
