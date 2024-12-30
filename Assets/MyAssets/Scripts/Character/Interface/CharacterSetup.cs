using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// キャラクター全体で共通するインタフェース
    /// </summary>
    public interface CharacterSetup
    {
        GameObject GameObject { get; }
    }
    //下は各キャラクター別のインタフェース


    public interface PlayerSetup : CharacterSetup
    {

        PlayerInput Input { get; }
    }

    public interface BossSetup : CharacterSetup
    {
        BossMovement Movement {  get; }
    }
}

