using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<IQuest> _activeObjectives = new List<IQuest>();

    void Start()
    {
        // ������ҧ���������� (��鴨�ԧ�Ҩ�Ҩҡ������)
        AddQuestObjective(new KillObjective("Wolf", 5));
    }

    // ���ʹ����Ѻ�����������
    public void AddQuestObjective(IQuest objective)
    {
        _activeObjectives.Add(objective);
        objective.OnObjectiveCompleted += HandleObjectiveCompleted;
    }

    // ���ʹ��� QuestManager �� "�ѧ" ��õ�¢ͧ�ѵ��
    public void SubscribeToEnemyDeath(Idestoryable enemy)
    {
        enemy.OnDestory += HandleEnemyDied;
    }

    // Handler ����Ѻ Event ��õ�¢ͧ�ѵ��
    private void HandleEnemyDied(Idestoryable enemy)
    {
        // 1. ��Ǩ�ͺ�������ѵ�ٷ����
        string enemyType = enemy.GetType().Name; // 㹵�����ҧ��� "Wolf"

        // 2. ǹ�ٻ�� Active Objectives �������Ǣ�ͧ
        foreach (var obj in _activeObjectives)
        {
            // *** ����������Ӥѭ: ��� Casting/Checking ***
            // �������� objective ����繻����� KillObjective ����ͧ��� 'Wolf' �������
            if (obj is KillObjective killObj && killObj.IsComplete == false)
            {
                // �������� KillObjective �纪��ͷ���ͧ������ (�鴨�ԧ�ЫѺ��͹���ҹ��)
                // ��Ҩ����¡ UpdateProgress ������ͧ������ KillObjective �ӧҹ���ҧ��
                killObj.UpdateProgress(1);
                Debug.Log($"Quest Progress: {obj.GetProgressText()}");
            }
        }
    }

    private void HandleObjectiveCompleted()
    {
        // ... �Ѵ����������������������� (�� ź�͡�ҡ Active Objectives, �駼�����)
        Debug.Log("An objective has been successfully completed!");
    }
}
