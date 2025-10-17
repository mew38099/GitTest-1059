using System;
using UnityEngine;

public class KillObjective : IQuest
{
    private readonly int _targetCount;
    private int _currentCount;
    private readonly string _enemyName;
    

    public event Action OnObjectiveCompleted;

    public KillObjective(string name, int target)
    {
        _enemyName = name;
        _targetCount = target;
        _currentCount = 0;
    }
    public bool IsTarget(string targetId)
    {
        return targetId == _enemyName; // ����Ҫ��ͷ����§ҹ�ç�Ѻ���ͷ���ͧ��æ���������
    }
    public bool IsComplete => _currentCount >= _targetCount;

    public string GetProgressText()
    {
        return $"Defeat {_enemyName}: {_currentCount}/{_targetCount}";
    }

    public void UpdateProgress(int amount)
    {
        if (IsComplete) return;

        _currentCount += amount;

        if (IsComplete)
        {
            // �ԧ Event �������������
            OnObjectiveCompleted?.Invoke();
        }
    }
}
