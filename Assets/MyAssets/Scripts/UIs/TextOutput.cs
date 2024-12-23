using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    public class TextOutput : MonoBehaviour
    {
        [SerializeField]
        private Text text;


        public void SetText(string t)
        {
            text.text = t;
        }
    }
}
