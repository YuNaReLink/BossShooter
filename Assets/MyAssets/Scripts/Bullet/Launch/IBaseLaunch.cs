

using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���˃I�u�W�F�N�g�̃C���^�t�F�[�X
    /// </summary>
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        SEManager   SEManager { get; }

        GameObject GameObject { get; }
    }

}
