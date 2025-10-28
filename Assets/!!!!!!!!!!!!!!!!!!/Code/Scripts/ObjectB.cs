using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectB : MonoBehaviour
{
    private bool pressed;
    private ObjectBVM _objectBVM;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        _objectBVM = new ObjectBVM();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            _objectBVM.SendAnswer();
            _objectBVM.SendRequest();
        }
    }
}
