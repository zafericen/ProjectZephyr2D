using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public SimpleFlash flashEffect;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            flashEffect.Flash();
        }
    }
}
