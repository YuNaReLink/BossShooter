using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �Q�[���̎��s���I�������鏈�����s���N���X
    /// </summary>
    public class GameEnd : MonoBehaviour
    {

        [SerializeField]
        private float endCount = 2f;


        private void ReadyEnd()
        {
            StartCoroutine(End());
        }
        private System.Collections.IEnumerator End()
        {
            yield return new WaitForSecondsRealtime(endCount); // 1�t���[���҂�
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
            //�Q�[���v���C�I��
            Application.Quit();
#endif
        }
    }
}
