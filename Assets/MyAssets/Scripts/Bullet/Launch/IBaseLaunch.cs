

using UnityEngine;

namespace CreateScript
{
    /*
     * ���˃I�u�W�F�N�g�̃C���^�t�F�[�X
     */
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        SEManager   SEManager { get; }

        GameObject GameObject { get; }
    }

}
