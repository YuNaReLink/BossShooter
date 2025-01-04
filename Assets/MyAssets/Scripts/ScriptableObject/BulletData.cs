using UnityEngine;

namespace CreateScript
{
    /*
     * 全弾オブジェクトを持つScriptableObject
     */
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
    public class BulletData : LedgerBase<OffScreenObject>
    {
    }
}
