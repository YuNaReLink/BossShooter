

using UnityEngine;

namespace CreateScript
{
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        SEManager   SEManager { get; }

        GameObject GameObject { get; }
    }

}
