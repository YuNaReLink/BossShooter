using UnityEngine;

namespace CreateScript
{
    /*
     * �J�ڂ���V�[����ݒ肷��N���X
     * �{�^���ɐݒ肵�ĉ����ꂽ�Ƃ��ɃV�[����ݒ�
     */
    public class ChangeScene : MonoBehaviour
    {
        //�����ɐݒ肵���V�[����SceneChanger�ɐݒ�
        [SerializeField]
        private SceneList nextScene;

        public void SetNextScene()
        {
            SceneChanger.Instance.SetNextScene(nextScene);
        }
    }
}
