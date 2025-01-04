using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
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

        private void Update()
        {
            if (!InputUIAction.Instance.Pause) { return; }
            open = !open;

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
