using System.Collections;
using System.Collections.Generic;
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
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager instance;
        public static GlobalManager Instance => instance;

        [SerializeField]
        [ReadOnly]
        private GameMode gameMode;
        public GameMode GameMode => gameMode;

        public void SetGameMode(GameMode mode)
        {
            gameMode = mode;
        }

        [SerializeField]
        [ReadOnly]
        private ResultType resultType;
        public ResultType ResultType => resultType;

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

