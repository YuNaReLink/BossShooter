

using UnityEngine;


namespace CreateScript
{
    /*
     * 発射オブジェクトのインタフェース
     */
    public interface IBaseLaunch
    {
        //弾のデータをまとめたもの
        BulletLedger BulletData { get; }
        //SEのデータをまとめたもの
        SEHandler   SEHandler { get; }
        //自分のオブジェクトをpublicで取得したもの
        GameObject GameObject { get; }
    }

}
