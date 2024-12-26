using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {
        /*static*/

        //�V���O���g��
        public static PauseMenu Instance { get; private set; }

        /*Serialized*/
        [SerializeField]
        private SceneList next;


        /*Component*/

        //���ʉ��Đ��p�̃R���|�[�l���g
        //private SEManager se;

        //�����~�߂邽�߂̃R���|�[�l���g
        private Pause pause;

        /*Event*/

        private void Awake()
        {
            //�V���O���g���p�̕ϐ��ɑ������B
            Instance = this;

            /*�e�R���|�[�l���g�̎擾*/

            //se = GetComponent<SEManager>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //�J�n���ɉ���炷�B
            //se.Play();

            //�|�[�Y��L��������B
            pause.Enable();
        }

        private void OnDestroy()
        {
            //�I�u�W�F�N�g�̔j�����V���O���g���p�ϐ��ɓ`����B
            //������A���g�ȊO�������Ă����ꍇ�͉������Ȃ��B
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //���j���[�I������
        public void Close()
        {
            //�|�[�Y�̉�����Pause.OnDestroy�Ɋ܂܂�Ă��邽�߁A�����ŏ����K�v�͖����B
            //pause.Disable();

            //���ʉ��̍Đ�
            //se.Play();

            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
        }
    }
}
