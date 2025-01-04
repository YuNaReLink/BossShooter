using UnityEngine;

namespace CreateScript
{
    /*
     * �Q�[���̎��s���I�������鏈�����s���N���X
     */
    public class GameEnd : MonoBehaviour
    {

        [SerializeField]
        private float endCount = 2f;

        //�{�^����UnityEvent�ɐݒ�
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
