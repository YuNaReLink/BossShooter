using UnityEngine;

namespace CreateScript
{
    public class SEManager : MonoBehaviour
    {
        /*Serialized*/

        //�䒠
        [SerializeField]
        private AudioLedger ledger;

        /*Method*/

        //�Đ����邽�߂����̃I�u�W�F�N�g�𐶐�����B
        //�ԍ��w��Ȃ̂ŊԈႢ�ɒ��ӁB
        //�ԍ����w�肵�Ȃ������ꍇ��0�Ԃ��Đ������B
        public void Play(int i = 0)
        {
            //�ԍ����͈͊O�Ȃ疳������B
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            //��̃I�u�W�F�N�g�𐶐�����B
            GameObject o = new("SE Player");

            //�R���|�[�l���g������t����B
            SEPlayer se = o.AddComponent<SEPlayer>();

            //�炷�B
            se.Play(ledger[i]);
        }
    }
}
