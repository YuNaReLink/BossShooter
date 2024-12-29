using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField]
        private bool            active;

        [SerializeField]
        private float           changeCount;
        [SerializeField]
        private float           loopCount;

        [SerializeField]
        private Color           changeColor;

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


        public void ColorChangeStart()
        {
            changeTimer.Start(changeCount);
            loopTimer.Start(loopCount);
        }

        public void LoopColorChangeStart()
        {
            changeTimer.Start(changeCount);
        }


        public void Toggle()
        {
            SetState(!active);
        }
        public void Finsh()
        {
            SetState(false);
        }

        private void SetState(bool b)
        {
            active = b;
            spriteRenderer.color = b ? changeColor : baseColor;
        }
    }
}
