using UnityEngine;

namespace CreateScript
{
    /*
     * プレイヤーの移動処理を行うクラス
     */
    [System.Serializable]
    public class PlayerMovement
    {
        //プレイヤーのトランスフォーム
        private Transform   transform;
        //プレイヤーの入力
        private PlayerInput Input;
        //スピード
        [SerializeField]
        private float       speed = 5f;
        //PlayerControllerのAwake時に処理
        public void Setup(PlayerSetup actor)
        {
            transform = actor.GameObject.transform;
            Input = actor.Input;
        }
        //移動処理
        public void Move()
        {
            Vector3 pos = transform.position;
            float s = speed;
            if (Input.SpeedDown > 0)
            {
                s *= Input.SpeedDown;
            }
            pos.x += s * Input.Horizontal * Time.deltaTime;
            pos.y += s * Input.Vertical * Time.deltaTime;
            transform.position = pos;
        }
    }
}
