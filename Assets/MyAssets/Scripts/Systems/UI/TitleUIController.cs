using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    /*
     * �^�C�g���V�[���ł�UI�����̊Ǘ����s���N���X
     * ����͉��������͂Ȃ�
     * GameUIController������̂ł�������쐬
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
