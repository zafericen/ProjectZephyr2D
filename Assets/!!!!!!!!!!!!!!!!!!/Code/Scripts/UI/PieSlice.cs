using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectZephyr
{
    public class PieSlice : MonoBehaviour
    {
        public Image pieSliceImage;
        public void Select()
        {
            Color tempColor = pieSliceImage.color;
            tempColor.a = 1f;
            pieSliceImage.color = tempColor;
        }
        public void Deselect()
        {
            Color tempColor = pieSliceImage.color;
            tempColor.a = 0f;
            pieSliceImage.color = tempColor;
        }
    }
}
