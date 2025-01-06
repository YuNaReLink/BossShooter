using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// SE���I�u�W�F�N�g�Ƃ��Đ�������N���X
    /// �I�u�W�F�N�g�ɃA�^�b�`���Ďg��
    /// </summary>
    public class SEHandler : MonoBehaviour
    {
        //SE�̃X�N���v�^�u���I�u�W�F�N�g���A�^�b�`
        [SerializeField]
        private AudioLedger     ledger;
        //SE�̃{�����[���ύX
        [SerializeField]
        [Range(0,1)]
        private float           volum = 1.0f;


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
            se.Play(ledger[i],volum);
        }
    }
}
