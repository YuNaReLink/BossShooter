

using UnityEngine;

namespace CreateScript
{
    public interface IBaseLaunch
    {
        BulletData BulletData { get; }

        GameObject GameObject { get; }
    }

}
