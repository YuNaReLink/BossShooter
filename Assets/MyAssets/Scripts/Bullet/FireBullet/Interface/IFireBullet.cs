using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �e���˃N���X�̃C���^�t�F�[�X
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
