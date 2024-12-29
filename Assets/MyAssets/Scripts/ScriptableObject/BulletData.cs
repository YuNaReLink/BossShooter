using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 全弾オブジェクトを持つScriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
    public class BulletData : LedgerBase<OffScreenObject>
    {
    }
}
