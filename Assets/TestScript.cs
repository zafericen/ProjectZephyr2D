using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class TestScript : MonoBehaviour
    {
        public SelectionMenu selectionMenuScript;

        public string selectedAbility;
        public string selectedWeapon;

        // TODO: Singleton GameHandler

        void Awake()
        {
            selectionMenuScript.CreatePieMenu();
        }

        void Update()
        {
            selectionMenuScript.UpdatePieMenu();
        }
    }
}


