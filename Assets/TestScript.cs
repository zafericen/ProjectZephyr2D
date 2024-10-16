using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class TestScript : MonoBehaviour
    {
        public List<string> selectionList;
        public UISetup uiSetupScript;
        public PieMenu pieMenuScript;

        // TODO: Singleton GameHandler

        void Awake()
        {
            uiSetupScript.PieMenuSetup(selectionList);
        }

        void Update()
        {
            pieMenuScript.Selection(uiSetupScript.pieAngle);
        }
    }
}


