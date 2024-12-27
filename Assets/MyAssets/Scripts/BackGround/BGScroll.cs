using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// バックグランドのスクロールを行うクラス
    /// backGroundsにセットした画像を右から左へスクロールする
    /// </summary>
    public class BGScroll : MonoBehaviour
    {
        /*SerializeField*/
        //背景をスクロールさせるスピード
        [SerializeField] 
        private float           scrollSpeed; 
        //背景のスクロールを開始する位置
        [SerializeField] 
        private float           startLine;
        //背景のスクロールが終了する位置
        [SerializeField] 
        private float           deadLine;

        [SerializeField]
        private float           backGroundImageInterval = 19f;

        [SerializeField]
        private GameObject[]    backGrounds = new GameObject[2];

        private void Start()
        {
            for(int i = 0; i < backGrounds.Length; i++)
            {
                backGrounds[i].transform.localPosition = new Vector3(i * backGroundImageInterval, 0, 0);
            }
        }

        private void Update()
        {
            for(int i = 0;i < backGrounds.Length; i++)
            {
                Scroll(i);
            }
        }

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
