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

    /*
     * ボスのDamagerがあるので拡張性を考え
     * Playerバージョンも作成(未使用)
     */
    public interface PlayerDamager
    {

    }

    public interface BossSetup : CharacterSetup
    {
        BossMovement Movement {  get; }
    }
    /*
     * 当たり判定で使用してるインタフェース
     * 判定にしか使っていないので中身は空
     */
    public interface BossDamager
    {

    }
}

