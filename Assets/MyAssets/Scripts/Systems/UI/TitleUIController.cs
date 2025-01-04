using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    public class TitleUIController : MonoBehaviour
    {
        private static TitleUIController instance;
        public static TitleUIController Instance => instance;

        private Canvas canvas;

        [SerializeField]
        private FadePanel fadePanel;

        private void Awake()
        {
            instance = this;

            canvas = FindObjectOfType<Canvas>();
        }
    }
}
