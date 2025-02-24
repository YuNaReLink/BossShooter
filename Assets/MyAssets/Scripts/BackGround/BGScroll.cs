using UnityEngine;

namespace CreateScript
{
    /*
     * バックグランドのスクロールを行うクラス
     * backGroundsにセットした画像を右から左へスクロールする
     */
    public class BGScroll : MonoBehaviour
    {
        //背景をスクロールさせるスピード
        [SerializeField] 
        private float           scrollSpeed; 
        //背景のスクロールを開始する位置
        [SerializeField] 
        private float           startLine;
        //背景のスクロールが終了する位置
        [SerializeField] 
        private float           deadLine;
        //複数の背景画像を配置する位置の間隔
        [SerializeField]
        private float           imageInterval = 19f;

        [SerializeField]
        private GameObject[]    backGrounds = new GameObject[2];

        private void Start()
        {
            for(int i = 0; i < backGrounds.Length; i++)
            {
                backGrounds[i].transform.localPosition = new Vector3(i * imageInterval, 0, 0);
            }
        }

        private void Update()
        {
            for(int i = 0;i < backGrounds.Length; i++)
            {
                Scroll(i);
            }
        }
        //Updateでスクロール処理
        public void Scroll(int i)
        {
            float speed = scrollSpeed * Time.deltaTime;
            backGrounds[i].transform.Translate(speed, 0, 0); //x座標をscrollSpeed分動かす

            if (backGrounds[i].transform.position.x < deadLine) //もし背景のx座標よりdeadLineが大きくなったら
            {
                backGrounds[i].transform.localPosition = new Vector3(startLine, 0, 0);//背景をstartLineまで戻す
            }
        }
    }
}
