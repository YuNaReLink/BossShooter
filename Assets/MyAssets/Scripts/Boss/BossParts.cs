using UnityEngine;

namespace CreateScript
{
    public class BossParts : MonoBehaviour
    {

        private HP hp;

        private void Awake()
        {
            hp = GetComponent<HP>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShooterTransform == transform) { return; }
            hp.DecreaseHP(1);
            if (hp.Death())
            {
                Death();
            }
        }

        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            Destroy(gameObject);
        }
    }
}
