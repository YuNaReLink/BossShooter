using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    //�e�̃��X�g�̗v�f���Ɏg���^�O
    public enum BulletType
    {
        Straight,
        LockOn,
        Random,
        Homing
    }
    /// <summary>
    /// �S�e�I�u�W�F�N�g������ScriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> Bullets => bullets;
    }
}
