using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class PieMenu : MonoBehaviour
    {
        public List<PieSlice> selectionList;
        [HideInInspector]
        public Vector2 normalisedMousePosition;
        [HideInInspector]
        public float currentAngle;
        [HideInInspector]
        public int selection, previousSelection;

        public void Selection(float pieAngle)
        {
            normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg + 90;
            currentAngle = (currentAngle + 360) % 360;

            selection = Mathf.FloorToInt(currentAngle / pieAngle);

            if (selection != previousSelection)
            {
                selectionList[previousSelection].Deselect();
                previousSelection = selection;
                selectionList[selection].Select();
            }
        }


    }
}
