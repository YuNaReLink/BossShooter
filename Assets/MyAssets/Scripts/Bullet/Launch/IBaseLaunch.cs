

using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 発射オブジェクトのインタフェース
    /// </summary>
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        SEManager   SEManager { get; }

        GameObject GameObject { get; }
    }

}
