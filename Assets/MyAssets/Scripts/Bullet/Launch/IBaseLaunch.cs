

using UnityEngine;

namespace CreateScript
{
    /*
     * 発射オブジェクトのインタフェース
     */
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        SEManager   SEManager { get; }

        GameObject GameObject { get; }
    }

}
