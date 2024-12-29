using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �V�[������InputButtonController����������ꍇ
    /// �����̂Ƃ͈ႤInputButtonController���I�t�ɂ���
    /// </summary>
    public class ActivateInputButtonController : MonoBehaviour
    {
        private InputButtonController    thisInputButtonController;

        private InputButtonController[]  inputButtonController;

        
        private void Awake()
        {
            thisInputButtonController = GetComponent<InputButtonController>();
            inputButtonController = FindObjectsOfType<InputButtonController>();
            for(int i = 0; i < inputButtonController.Length; i++)
            {
                if(inputButtonController[i] != thisInputButtonController)
                {
                    inputButtonController[i].enabled = false;
                }
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < inputButtonController.Length; i++)
            {
                if (inputButtonController[i] != thisInputButtonController)
                {
                    inputButtonController[i].enabled = true;
                }
            }
        }
    }
}
