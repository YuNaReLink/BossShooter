using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 全弾オブジェクトを持つScriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> Bullets => bullets;
    }
}
