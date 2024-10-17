using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ProjectZephyr
{
    public class SelectionMenu : MonoBehaviour
    {
        public List<string> abilityList;
        public List<string> weaponList;
        public GameObject abilityPieMenuRoot;
        public GameObject weaponPieMenuRoot;

        private PieMenu abilityPieMenuScript;
        private PieMenu weaponPieMenuScript;

        public void CreatePieMenu()
        {
            abilityPieMenuScript = abilityPieMenuRoot.GetComponent<PieMenu>();
            abilityPieMenuScript.MenuSetup(abilityList, 1, TextAlignmentOptions.Left);
            weaponPieMenuScript = weaponPieMenuRoot.GetComponent<PieMenu>();
            weaponPieMenuScript.MenuSetup(weaponList, 0, TextAlignmentOptions.Right);
        }
        public void UpdatePieMenu()
        {
            Vector2 normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            float currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg + 90;
            currentAngle = (currentAngle + 360) % 360;
            if (currentAngle > 0 && currentAngle <= 180) 
            { 
                weaponPieMenuScript.Selection(0); 
                abilityPieMenuScript.Deselection(); 
            }
            if (currentAngle > 180 && currentAngle <= 360) 
            { 
                abilityPieMenuScript.Selection(1); 
                weaponPieMenuScript.Deselection();
            }
        }
    }
}
