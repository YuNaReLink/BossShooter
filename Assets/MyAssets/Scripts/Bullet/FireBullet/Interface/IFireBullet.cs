using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 弾発射クラスのインタフェース
    /// </summary>
    public interface IFireBullet
    {
        void Setup(IBaseLaunch launch);
        void DoUpdate(float time);
        void Fire(Transform target);
        public void DecreaseFireCountCoolDown(float count);
        public float MinFireCount {  get; }
    }
}
