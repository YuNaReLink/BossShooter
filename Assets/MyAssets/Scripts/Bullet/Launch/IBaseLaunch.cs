

using UnityEngine;


namespace CreateScript
{
    /*
     * ���˃I�u�W�F�N�g�̃C���^�t�F�[�X
     */
    public interface IBaseLaunch
    {
        //�e�̃f�[�^���܂Ƃ߂�����
        BulletLedger BulletData { get; }
        //SE�̃f�[�^���܂Ƃ߂�����
        SEHandler   SEHandler { get; }
        //�����̃I�u�W�F�N�g��public�Ŏ擾��������
        GameObject GameObject { get; }
    }

}
