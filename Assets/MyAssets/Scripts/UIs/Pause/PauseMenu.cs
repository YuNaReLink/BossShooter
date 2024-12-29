using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ポーズを有効、無効にする処理を行うクラス
    /// SEや時間を止める処理もここで行う
    /// </summary>
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {


        public static PauseMenu Instance { get; private set; }


        //時を止めるためのコンポーネント
        private Pause pause;

        //効果音再生用のコンポーネント
        [SerializeField]
        private SEManager seManager;

        private void Awake()
        {
            //シングルトン用の変数に代入する。
            Instance = this;



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



        //メニュー終了処理
        public void Close()
        {

            //効果音の再生
            seManager.Play(1);

            //オブジェクトの破棄
            Destroy(gameObject);
        }
    }
}
