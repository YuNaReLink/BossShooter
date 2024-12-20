using UnityEngine;

namespace CreateScript
{

    [System.Serializable]
    public class PlayerMovement
    {
        private Transform transform;

        private PlayerInput Input;

        [SerializeField]
        private float speed = 5f;

        public void Setup(PlayerSetup actor)
        {
            transform = actor.GameObject.transform;
            Input = actor.Input;
        }

        public void Move()
        {
            Vector3 pos = transform.position;
            float s = speed;
            if (Input.SpeedDown > 0)
            {
                s *= Input.SpeedDown;
            }
            pos.x += s * Input.Horizontal * Time.deltaTime;
            pos.y += s * Input.Vertical * Time.deltaTime;
            transform.position = pos;
        }
    }
}
