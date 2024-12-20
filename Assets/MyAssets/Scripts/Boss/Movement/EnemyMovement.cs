using UnityEngine;

namespace CreateScript
{
    public enum VerticalDirection
    {
        Up = 1,
        Down = -1,
    }

    [System.Serializable]
    public class EnemyMovement
    {
        private Transform transform;

        [SerializeField]
        private float speed = 2f;

        [SerializeField]
        private bool reverse = false;

        [SerializeField]
        private float height = 1f;

        public void Setup(BossSetup actor)
        {
            transform = actor.GameObject.transform;
        }

        public void DoStart()
        {
            reverse = false;
        }

        public void VerticalMove()
        {
            Vector2 pos = transform.position;
            int dir = reverse ? -1 : 1;
            pos.y += speed * dir * Time.deltaTime;
            transform.position = pos;
            Camera camera = Camera.main;
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (screenBounds.y - height < transform.position.y)
            {
                reverse = true;
            }
            else if (-screenBounds.y + height > transform.position.y)
            {
                reverse = false;
            }
        }
    }
}
