using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ボスの移動処理クラス
    /// </summary>
    [System.Serializable]
    public class BossMovement
    {
        //ボスのトランスフォーム
        private Transform   transform;
        //スピード
        [SerializeField]
        private float       speed = 2f;
        //上下に移動するためのフラグ
        [SerializeField]
        private bool        reverse = false;
        //画面の上下でどこまでの高さまで行くかを制限する数値
        [SerializeField]
        private float       height = 1f;
        //状態が変わった時にスピードを変更する処理
        public void SetSpeed(float s)
        {
            speed = s;
        }
        //Awake時に処理
        public void Setup(BossSetup actor)
        {
            transform = actor.GameObject.transform;
        }

        public void DoStart()
        {
            reverse = false;
        }
        //上下に移動する処理
        public void VerticalMove()
        {
            Vector2 pos = transform.position;
            int dir = reverse ? -1 : 1;
            pos.y += speed * dir * Time.deltaTime;
            transform.position = pos;
            Camera camera = Camera.main;
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (screenBounds.y - height < transform.position.y)
            {
                reverse = true;
            }
            else if (-screenBounds.y + height > transform.position.y)
            {
                reverse = false;
            }
        }
    }
}
