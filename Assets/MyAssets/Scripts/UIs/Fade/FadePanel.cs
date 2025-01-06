using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * シーン遷移時にフェード処理を行うクラス
     * フェードパネルにアタッチして使う
     */
    public class FadePanel : MonoBehaviour
    {
        private Image panel;

        [SerializeField]
        private float speed = 1.0f;
        [SerializeField]
        private float targetAlpha = 0.0f;
        //フェード時のalphaの最終ゴール値を決める
        public void SetTargetAlpha(float alpha) { targetAlpha = alpha; }

        private void Awake()
        {
            panel = GetComponent<Image>();
        }

        private void Start()
        {
            if(targetAlpha > 0)
            {
                panel.color = new Color(0, 0, 0, 0);
            }
            else
            {
                panel.color = new Color(0, 0, 0, 1);
            }
            GlobalManager.Instance.SetGameStop(true);
            StartCoroutine(FadeStart());
        }
        //Time.timeScaleが0でも動くようにするために
        //非同期で処理を行う
        private IEnumerator FadeStart()
        {
            // フェードイン
            yield return StartCoroutine(Fade(targetAlpha));

            if (SceneChanger.Instance.IsTransitioning)
            {
                SceneChanger.Instance.OnChangeScene();
            }
            else
            {
                Destroy(gameObject);
            }
            GlobalManager.Instance.SetGameStop(false);
        }


        // フェード処理
        private IEnumerator Fade(float targetAlpha)
        {
            float startAlpha = panel.color.a;
            float time = 0;

            while (time < speed)
            {
                time += Time.unscaledDeltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / speed);
                panel.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            panel.color = new Color(0, 0, 0, targetAlpha);
        }
    }
}
