using CreateScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem instance;
    public static ScoreSystem Instance => instance;

    [SerializeField]
    private int currentCount;
    public int CurrentCount => currentCount;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void AddScore(BulletType type)
    {
        int count = 0;
        switch (type)
        {
            case BulletType.Random:
            case BulletType.Straight:
                count = 10;
                break;
            case BulletType.LockOn:
                count = 15;
                break;
            case BulletType.Homing:
                count = 20;
                break;
        }
        currentCount += count;
    }
}
