using UnityEngine;

namespace CreateScript
{
    public class PlayerInput : MonoBehaviour
    {
        private InputActionsControls inputActions;

        [SerializeField]
        private Vector2 move;
        public bool IsMove => Mathf.Abs(move.x) > 0.1f || Mathf.Abs(move.y) > 0.1f;

        public Vector2 Move => move;
        public float Horizontal => move.x;
        public void SetHorizontal(float horizontalRatio) { move.x *= horizontalRatio; }
        public float Vertical => move.y;
        public void SetVertical(float verticalRatio) { move.y *= verticalRatio; }

        [SerializeField]
        private float speedDown;

        public float SpeedDown => Mathf.Abs(speedDown * 0.5f);

        [SerializeField]
        private float attack;
        public float Attack => attack;


        private void Awake()
        {
            inputActions = new InputActionsControls();
        }

        private void Update()
        {
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
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Dispose();
        }
    }
}
