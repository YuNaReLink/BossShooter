using UnityEngine;

namespace CreateScript
{
    /*
     * 敵の状態を変更するクラス
     * 主に敵の弾の状態を変更している
     */
    public class FormChange : MonoBehaviour
    {
        //状態数値
        [SerializeField]
        private int             stateCount = 3;
        //ボス本体
        private BossSetup       boss;
        //ボスの移動処理
        private BossMovement   movement;
        //ボスの発射口
        private Launch[]        launches;
        //弾のタイプ
        private EnemyBulletType bulletType;
        //状態が変化した時の移動スピードの値
        [SerializeField]
        private float[]         formMoveSpeeds; 
        private void Awake()
        {
            boss = GetComponent<BossSetup>();
            launches = GetComponentsInChildren<Launch>();

            movement = boss.Movement;
        }

        private void Start()
        {
            stateCount = 0;
            SetForm(0);
        }
        //破壊された回数によってボスの状態を変える
        public void SetForm(int count)
        {
            stateCount += count;
            switch (stateCount)
            {
                case 0:
                    bulletType = EnemyBulletType.LockOn;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
                    break;
                case 1:
                    bulletType = EnemyBulletType.Random;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
                    break;
                case 2:
                    bulletType = EnemyBulletType.Homing;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
                    break;
                default:
                    break;
            }
            for(int i = 0; i < launches.Length; i++)
            {
                launches[i].SetBulleyType(bulletType);
            }
        }
    }
}
