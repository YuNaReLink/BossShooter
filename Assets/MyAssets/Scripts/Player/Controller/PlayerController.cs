using UnityEngine;

namespace CreateScript
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput input;

        [SerializeField]
        private float speed = 0.05f;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            
        }
    
        // Update is called once per frame
        private void Update()
        {
            Vector3 pos = transform.position;
            pos.x += speed * input.Horizontal * Time.deltaTime;
            pos.y += speed * input.Vertical * Time.deltaTime;
            transform.position = pos;
        }
    }
}
