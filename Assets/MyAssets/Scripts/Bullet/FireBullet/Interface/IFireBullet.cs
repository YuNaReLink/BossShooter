using UnityEngine;

namespace CreateScript
{
    /*
     * �e���˃N���X�̃C���^�t�F�[�X
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
