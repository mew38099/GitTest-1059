using UnityEngine;

public interface Idestoryable
{
    // �س���ѵ�����Ѻ��Ҿ�ѧ���Ե�Ѩ�غѹ
    int health { get; set; }

    // �س���ѵ�����Ѻ��Ҿ�ѧ���Ե�٧�ش (�Ҩ������������)
    int maxHealth { get; set; }

    // ���ʹ����Ѻ�Ѻ�����������
    void TakeDamage(int damageAmount) { 
        health -= damageAmount;
    }
    event System.Action<Idestoryable> OnDestory;

}
