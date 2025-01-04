using UnityEngine;

namespace CreateScript
{
    /*
     * 動かしたいX方向を決めるタグ
     */
    public enum AppearanceTypeX
    {
        Null = -1,
        Left,
        Right
    }
    /*
     * 動かしたいY方向を決めるタグ
     */
    public enum AppearanceTypeY
    {
        Null = -1,
        Up,
        Down
    }
    /*
     *オブジェクトをカメラの大きさを元にした上下左右に動かして登場させる
     *処理を行うクラス
     */
    public class Appearance : MonoBehaviour
    {
        //どの方向から動かしたいかを決めるタグX
        [SerializeField]
        private AppearanceTypeX     appearanceTypeX;
        //どの方向から動かしたいかを決めるタグY
        [SerializeField]
        private AppearanceTypeY     appearanceTypeY;
        //カメラ
        private new Camera          camera;
        //スクリーン内の数値
        private Vector2             screenBounds => camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
        //登場時に動くゴール地点
        private Vector2             goalPostion = Vector2.zero;
        //動いてる間コライダーを非表示にするためのコライダー
        private new Collider2D      collider;
        //登場中は無敵なのでカラー変更処理
        private ColorChanger        colorChanger;

        //登場中に不要な処理をオフにするためのPlayerController宣言
        private PlayerController    player;
        //こちらも同じ宣言
        private OnScreenMove        onScreenMove;

        private PlayerLaunch        playerLaunch;
        private void Awake()
        {
            camera = Camera.main;
            collider = GetComponent<Collider2D>();
            collider.enabled = false;
            colorChanger = GetComponent<ColorChanger>();
            SetCharacterInformation();
        }
        //プレイヤー独自の情報取得はこの中で行う
        //プレイヤー独自の物なので継承なり実装した時の管理を考えたメソッド
        private void SetCharacterInformation()
        {
            player = GetComponent<PlayerController>();
            onScreenMove = GetComponent<OnScreenMove>();
            playerLaunch = GetComponentInChildren<PlayerLaunch>();
            player.enabled = false;
            onScreenMove.enabled = false;
            playerLaunch.enabled = false;
        }

        private void Start()
        {
            switch (appearanceTypeX)
            {
                case AppearanceTypeX.Null:
                    goalPostion.x = 0;
                    break;
                case AppearanceTypeX.Left:
                    goalPostion.x = -screenBounds.x / 2f;
                    break;
                case AppearanceTypeX.Right:
                    goalPostion.x = screenBounds.x / 2f;
                    break;
            }
            switch (appearanceTypeY)
            {
                case AppearanceTypeY.Null:
                    goalPostion.y = 0;
                    break;
                case AppearanceTypeY.Up:
                    goalPostion.y = screenBounds.y / 2f;
                    break;
                case AppearanceTypeY.Down:
                    goalPostion.y = -screenBounds.y / 2f;
                    break;
            }
            colorChanger.ColorChangeStart();
        }


        private void Update()
        {
            if (GlobalManager.Instance.IsGameStop) { return; }
            transform.position = Vector2.Lerp(transform.position, goalPostion, Time.deltaTime * 5f);
            Vector2 sub = (Vector2)transform.position - goalPostion;
            colorChanger.LoopColorChangeStart();
            if(sub.magnitude < 0.01f)
            {
                colorChanger.Finsh();
                collider.enabled = true;
                ActivateCharacterInformation();
                Destroy(colorChanger);
                Destroy(this);
            }
        }   

        //取得した情報を有効にする
        //プレイヤー独自の物なので継承なり実装した時の管理を考えたメソッド
        private void ActivateCharacterInformation()
        {
            player.enabled = true;
            onScreenMove.enabled = true;
            playerLaunch.enabled = true;
        }
    }
}
