using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    /*
     * タイトルシーンでのUI処理の管理を行うクラス
     * 現状は何も処理はなし
     * GameUIControllerがあるのでこちらも作成
     */
    public class TitleUIController : MonoBehaviour
    {
        private static TitleUIController    instance;
        public static TitleUIController     Instance => instance;

        private Canvas                      canvas;

        [SerializeField]
        private FadePanel                   fadePanel;

        private void Awake()
        {
            instance = this;

            canvas = FindObjectOfType<Canvas>();
        }
    }
}
