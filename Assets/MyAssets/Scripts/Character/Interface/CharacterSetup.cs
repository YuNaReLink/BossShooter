using UnityEngine;

namespace CreateScript
{
    /*
     * キャラクター全体で共通するインタフェース
     */
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

