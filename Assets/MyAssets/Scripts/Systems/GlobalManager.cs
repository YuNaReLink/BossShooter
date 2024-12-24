using Unity.Collections;
using UnityEngine;

namespace CreateScript
{
    public enum GameMode
    {
        Null = -1,
        Title,
        Game,
        Result
    }

    public enum ResultType
    {
        GameOver,
        GameClear
    }
    /// <summary>
    /// 全てのシーンのオブジェクト管理を行うクラス
    /// シングルトンパターンでDontDestroyOnLoadにしてシーンをまたいで処理を行う
    /// </summary>
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager    instance;
        public static GlobalManager     Instance => instance;

        [SerializeField]
        [ReadOnly]
        private GameMode                gameMode;

        public void SetGameMode(GameMode mode)
        {
            gameMode = mode;
        }

        [SerializeField]
        [ReadOnly]
        private ResultType resultType;

        public void SetResultType(ResultType type)
        {
            resultType = type;
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

