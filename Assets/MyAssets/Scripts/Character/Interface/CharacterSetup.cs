using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �L�����N�^�[�S�̂ŋ��ʂ���C���^�t�F�[�X
    /// </summary>
    public interface CharacterSetup
    {
        GameObject GameObject { get; }
    }
    //���͊e�L�����N�^�[�ʂ̃C���^�t�F�[�X


    public interface PlayerSetup : CharacterSetup
    {

        PlayerInput Input { get; }
    }

    public interface BossSetup : CharacterSetup
    {
        BossMovement Movement {  get; }
    }
}

