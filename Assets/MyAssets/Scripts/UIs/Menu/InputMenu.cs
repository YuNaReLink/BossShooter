using UnityEngine;

namespace CreateScript
{
    /*
     * メニューの開閉入力を行うクラス
     */
    public class InputMenu : MonoBehaviour
    {
        private bool open;


        private MenuCaller caller;

        private void Awake()
        {
            caller = GetComponent<MenuCaller>();
        }

        private void Start()
        {
            open = false;
            caller.Close();
        }

        //メニューの更新
        private void Update()
        {
            if (!InputUIAction.Instance.Pause) { return; }
            open = !open;

            //フラグよって開閉を決める
            if (open)
            {
                caller.Call();
            }
            else
            {
                caller.Close();
            }
        }
    }
}
