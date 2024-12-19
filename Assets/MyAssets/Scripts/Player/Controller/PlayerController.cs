using UnityEngine;

namespace CreateScript
{
    public class PlayerController : MonoBehaviour,PlayerSetup
    {
        public GameObject GameObject => gameObject;

        private PlayerInput input;
        public PlayerInput Input => input;

        [SerializeField]
        private PlayerMovement movement;

        private FireBullet fireBullet;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
            fireBullet = GetComponentInChildren<FireBullet>();
        }

        private void Start()
        {
            movement.Setup(this);
        }
    
        // Update is called once per frame
        private void Update()
        {
            Bullet();
            movement.Move();
        }

        private void Bullet()
        {
            if(input.Attack > 0)
            {
                fireBullet.Fire();
            }
        }
    }
}
