using UnityEngine;

namespace CreateScript
{
    public class ColorChanger : MonoBehaviour
    {
        //カラー変更が有効かのフラグ
        [SerializeField]
        private bool            active;
        //変更する時間
        [SerializeField]
        private float           changeCount;
        //変更中どれくらいの間隔で色を切り替えるかの時間
        [SerializeField]
        private float           loopCount;
        //変更後のカラー
        [SerializeField]
        private Color           changeColor;
        //変更前のカラー
        private Color           baseColor;

        //カラーを変更するタイマー
        private Timer           changeTimer = new();
        //カラーを点滅させる間隔を管理するタイマー
        private Timer           loopTimer = new();

        private SpriteRenderer  spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            baseColor = spriteRenderer.color;

            changeTimer.OnEnd += Finsh;

            loopTimer.SetLoop(true);
            loopTimer.OnEnd += Toggle;

            active = false;
        }
        public void Update()
        {
            if (changeTimer.IsEnd())
            {
                return;
            }
            float t = Time.deltaTime;
            loopTimer.Update(t);
            changeTimer.Update(t);
        }

        //色を変更したい時
        public void ColorChangeStart()
        {
            changeTimer.Start(changeCount);
            loopTimer.Start(loopCount);
        }
        //常時色を変更し続けたい時
        public void LoopColorChangeStart()
        {
            changeTimer.Start(changeCount);
        }

        //ループ中の時
        public void Toggle()
        {
            SetState(!active);
        }
        //終わった時
        public void Finsh()
        {
            SetState(false);
        }
        //フラグで元の色か変更後の色に変える
        private void SetState(bool b)
        {
            active = b;
            spriteRenderer.color = b ? changeColor : baseColor;
        }
    }
}
