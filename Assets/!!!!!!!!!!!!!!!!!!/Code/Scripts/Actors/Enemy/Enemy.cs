using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        public GameObject Player => player;
    }
}
