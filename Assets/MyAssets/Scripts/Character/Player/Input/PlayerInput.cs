using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /*
     * プレイヤーの入力をまとめて処理してるクラス
     */
    public class PlayerInput : MonoBehaviour
    {
        private InputActionsControls    inputActions;
        //*移動入力関係*//
        [SerializeField]
        private Vector2     move;

        public Vector2      Move => move;
        public float        Horizontal => move.x;
        public float        Vertical => move.y;
        //*減速入力関係*//
        [SerializeField]
        private float       speedDown;

        public float        SpeedDown => Mathf.Abs(speedDown * 0.5f);
        //*攻撃入力関係*//
        [SerializeField]
        private float       attack;
        public float        Attack => attack;
        //*ボム入力関係*//
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
        //ボムの発射を行うために押した瞬間を判定するためのコルーチン
        private void OnBomb(InputAction.CallbackContext context)
        {
            bomb = true;
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(BombButtonPress());
        }
        private System.Collections.IEnumerator BombButtonPress()
        {
            yield return null; // 1フレーム待つ
            bomb = false;
        }
    }
}
