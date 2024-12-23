using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �Q�[���̎��s���I�������鏈�����s���N���X
    /// </summary>
    public class GameEnd : MonoBehaviour
    {
        private Timer gameEndTimer = new Timer();

        [SerializeField]
        private float endCount = 2f;

        private void Awake()
        {
            gameEndTimer.OnceEnd += End;
        }

        public void Update()
        {
            gameEndTimer.Update(Time.deltaTime);
        }

        public void ReadyEnd()
        {
            if (!gameEndTimer.IsEnd()) { return; }
            gameEndTimer.Start(endCount);
        }

        private void End()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
            //�Q�[���v���C�I��
            Application.Quit();
#endif
        }
    }
}
