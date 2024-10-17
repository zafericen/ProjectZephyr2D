using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjectZephyr
{
    public class PieMenu : MonoBehaviour
    {
        public GameObject pieSlicePrefab;
        public float pieSize;

        public List<PieSlice> selectionList;
        public string selected;

        private Vector2 normalisedMousePosition;
        private float currentAngle;
        private int selection, previousSelection;
        private float sliceAngle;
        private int sliceNumber;

        public void Selection(int partNumber)
        {
            normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg + 90;
            currentAngle = (currentAngle + 360) % 360;

            int tempSelection = Mathf.FloorToInt(currentAngle / sliceAngle);
            if (partNumber == 1 && tempSelection >= sliceNumber) { selection = tempSelection % sliceNumber; }
            if (partNumber == 0 && tempSelection < sliceNumber) { selection = tempSelection; }

            if (selection != previousSelection)
            {
                selectionList[previousSelection].Deselect();
                previousSelection = selection;
                selectionList[selection].Select();
            }
        }
        public void Deselection()
        {
            selectionList[selection].Deselect();
        }

        public void MenuSetup(List<string> elementList, int partNumber, TextAlignmentOptions textAlignment)
        {
            sliceNumber = elementList.Count;
            sliceAngle = pieSize / sliceNumber;

            for (int i = 0; i < sliceNumber; i++)
            {
                GameObject sliceObject = Instantiate(pieSlicePrefab, transform);
                Transform sliceDividerElement = sliceObject.transform.GetChild(0);
                Transform sliceButtonElement = sliceObject.transform.GetChild(1);
                Transform sliceNameElement = sliceObject.transform.GetChild(2);
                Image sliceImage = sliceButtonElement.GetComponent<Image>();
                TMP_Text sliceText = sliceNameElement.GetComponent<TMP_Text>();

                if (partNumber == 1) { sliceNameElement.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90 - sliceAngle * 0.5f); }
                else { sliceNameElement.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 270 - sliceAngle * 0.5f); }
                sliceObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, (partNumber * pieSize) + (sliceAngle * (i + 1)));

                sliceImage.fillAmount = 0.5f / sliceNumber;
                Color tempColor = sliceImage.color;
                tempColor.a = 0f;
                sliceImage.color = tempColor;

                sliceText.alignment = textAlignment;
                sliceText.text = elementList[i];

                selectionList.Add(sliceObject.GetComponent<PieSlice>());
            }
        }
    }
}
