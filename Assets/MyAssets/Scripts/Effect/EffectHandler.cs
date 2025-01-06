using UnityEngine;

namespace CreateScript
{
    public enum EffectTag
    {
        Explosion,
        Hit
    }

    /*
     * Sprite�^�̃G�t�F�N�g���I�u�W�F�N�g�Ƃ��Đ�������N���X
     */
    public class EffectHandler : MonoBehaviour
    {
        [SerializeField]
        private EffectLedger ledger;


        //�Đ����邽�߂����̃I�u�W�F�N�g�𐶐�����B
        //�ԍ��w��Ȃ̂ŊԈႢ�ɒ��ӁB
        //�ԍ����w�肵�Ȃ������ꍇ��0�Ԃ��Đ������B
        public void Create(Vector2 pos,Vector3 scale,int i = 0)
        {
            //�ԍ����͈͊O�Ȃ疳������B
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            ImageEffect effect = Instantiate(ledger[i],pos,Quaternion.identity);
            effect.gameObject.transform.localScale = scale;
        }
    }
}
