using UnityEngine;

namespace CreateScript
{
    /*
     * 弾発射クラスのインタフェース
     */
    public interface IFireBullet
    {
        void Setup(IBaseLaunch launch);
        void DoUpdate(float time);
        void Fire(Transform target);
        public void DecreaseFireCountCoolDown(float count);
        public float MinFireCount {  get; }
    }
}
