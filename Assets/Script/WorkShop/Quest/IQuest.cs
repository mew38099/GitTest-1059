using UnityEngine;

public interface IQuest 
{
    // �����͵�Ǩ�ͺ���������¹����������������ѧ
    bool IsComplete { get; }

    // ��ͤ�������ʴ������׺˹�� (�� "Kill 5/10 Wolves")
    string GetProgressText();

    // ���ʹ����Ѻ�ѻവ�����׺˹�� (�١���¡�ҡ��¹͡)
    void UpdateProgress(int amount);

    // ���ǹ������Ѻ����͹�к� QuestManager �����ʶҹ�����¹
    event System.Action OnObjectiveCompleted;
}
