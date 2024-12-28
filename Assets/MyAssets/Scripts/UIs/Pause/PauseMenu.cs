using UnityEngine;

namespace CreateScript
{
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {

        //シングルトン
        public static PauseMenu Instance { get; private set; }

        /*Serialized*/
        [SerializeField]
        private SceneList next;

        //効果音再生用のコンポーネント
        //private SEManager se;

        //時を止めるためのコンポーネント
        private Pause pause;

        [SerializeField]
        private SEManager seManager;

        private void Awake()
        {
            //シングルトン用の変数に代入する。
            Instance = this;

            /*各コンポーネントの取得*/

            seManager = GetComponent<SEManager>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //開始時に音を鳴らす。
            seManager.Play(1);

            //ポーズを有効化する。
            pause.Enable();
        }

        private void OnDestroy()
        {
            //オブジェクトの破棄をシングルトン用変数に伝える。
            //万が一、自身以外が入っていた場合は何もしない。
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //メニュー終了処理
        public void Close()
        {
            //ポーズの解除はPause.OnDestroyに含まれているため、ここで書く必要は無い。
            //pause.Disable();

            //効果音の再生
            seManager.Play(1);

            //オブジェクトの破棄
            Destroy(gameObject);
        }
    }
}
