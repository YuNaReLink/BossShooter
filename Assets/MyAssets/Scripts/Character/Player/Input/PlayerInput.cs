using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /*
     * �v���C���[�̓��͂��܂Ƃ߂ď������Ă�N���X
     */
    public class PlayerInput : MonoBehaviour
    {
        private InputActionsControls    inputActions;
        //*�ړ����͊֌W*//
        [SerializeField]
        private Vector2     move;

        public Vector2      Move => move;
        public float        Horizontal => move.x;
        public float        Vertical => move.y;
        //*�������͊֌W*//
        [SerializeField]
        private float       speedDown;

        public float        SpeedDown => Mathf.Abs(speedDown * 0.5f);
        //*�U�����͊֌W*//
        [SerializeField]
        private float       attack;
        public float        Attack => attack;
        //*�{�����͊֌W*//
        [SerializeField]
        private bool        bomb;
        public bool         Bomb => bomb;

        private InputAction bombAction;
        private void Awake()
        {
            inputActions = new InputActionsControls();
        }

        private void Update()
        {
            if (GlobalManager.Instance.IsGameStop) { return; }

            var value = inputActions.Player.Move.ReadValue<Vector2>();
            move.x = value.x;
            move.y = value.y;

            var s = inputActions.Player.SpeedDown.ReadValue<float>();
            speedDown = s;

            var a = inputActions.Player.Attack.ReadValue<float>();
            attack = a;
        }

        private void OnEnable()
        {
            inputActions.Enable();

            bombAction = inputActions.Player.Bomb;

            bombAction.performed += OnBomb;

            bombAction.Enable();
        }

        private void OnDisable()
        {
            bombAction.performed -= OnBomb;

            bombAction.Disable();

            inputActions.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Dispose();
        }
        //�{���̔��˂��s�����߂ɉ������u�Ԃ𔻒肷�邽�߂̃R���[�`��
        private void OnBomb(InputAction.CallbackContext context)
        {
            bomb = true;
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(BombButtonPress());
        }
        private System.Collections.IEnumerator BombButtonPress()
        {
            yield return null; // 1�t���[���҂�
            bomb = false;
        }
    }
}
