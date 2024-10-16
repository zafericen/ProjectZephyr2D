using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectZephyr
{
    public class UISetup : MonoBehaviour
    {
        public GameObject pieSlicePrefab;
        public Transform pieMenuRoot;
        public PieMenu pieMenuScript;

        [HideInInspector]
        public float pieAngle = 0;
        public void PieMenuSetup(List<string> selectionList)
        {
            int sliceNumber = selectionList.Count;
            pieAngle = 360f / sliceNumber;
            float sliceSize = 1f / sliceNumber;

            for (int i = 0; i < sliceNumber; i++)
            {
                GameObject pieSliceObject = Instantiate(pieSlicePrefab, pieMenuRoot);
                Transform pieSliceDividerElement = pieSliceObject.transform.GetChild(0);
                Transform pieSliceButtonElement = pieSliceObject.transform.GetChild(1);
                Transform pieSliceNameElement = pieSliceObject.transform.GetChild(2);
                Image pieSliceImage = pieSliceButtonElement.GetComponent<Image>();
                TMP_Text pieSliceText = pieSliceNameElement.GetComponent<TMP_Text>();

                pieSliceNameElement.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90 - pieAngle * 0.5f);
                pieSliceObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, pieAngle * (i + 1));

                pieSliceImage.fillAmount = sliceSize;
                Color tempColor = pieSliceImage.color;
                tempColor.a = 0f;
                pieSliceImage.color = tempColor;

                pieSliceText.alignment = TextAlignmentOptions.Left;
                pieSliceText.text = selectionList[i];

                pieMenuScript.selectionList.Add(pieSliceObject.GetComponent<PieSlice>());
            }
        }
    }

}
