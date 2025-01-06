using UnityEngine;

namespace CreateScript
{
    /*
     * �L�����N�^�[�S�̂ŋ��ʂ���C���^�t�F�[�X
     */
    public interface CharacterSetup
    {
        GameObject GameObject { get; }
    }
    //���͊e�L�����N�^�[�ʂ̃C���^�t�F�[�X


    public interface PlayerSetup : CharacterSetup
    {

        PlayerInput Input { get; }
    }

    /*
     * �{�X��Damager������̂Ŋg�������l��
     * Player�o�[�W�������쐬(���g�p)
     */
    public interface PlayerDamager
    {

    }

    public interface BossSetup : CharacterSetup
    {
        BossMovement Movement {  get; }
    }
    /*
     * �����蔻��Ŏg�p���Ă�C���^�t�F�[�X
     * ����ɂ����g���Ă��Ȃ��̂Œ��g�͋�
     */
    public interface BossDamager
    {

    }
}

