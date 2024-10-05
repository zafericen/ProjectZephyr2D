using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuıDebugger : MonoBehaviour
{
    void OnGUI()
    {
        for (int i = 0; i < InputHandler.instance.buffer.Length; i++)
        {

            GUI.Label(new Rect(100 * i, 50, 100, 100), InputHandler.instance.buffer[i].type.ToString() + " : " + InputHandler.instance.buffer[i].holdType.ToString() + " : " + InputHandler.instance.buffer[i].attackType.ToString());
        }


        for (int i = 0; i < InputHandler.instance.inputStack.Count; i++)
        {

            GUI.Label(new Rect(120 * i, 100, 100, 100), InputHandler.instance.inputStack.Get(i).type.ToString() + " : " + InputHandler.instance.inputStack.Get(i).holdType.ToString() + " : " + InputHandler.instance.inputStack.Get(i).attackType.ToString());
        }
    }

}
