using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameTaskState
{
    Waiting,
    Executing,
    Completed,
    End
}
[CreateAssetMenu()]
public class GameTaskSO : ScriptableObject
{
    public GameTaskState state;

    public string[] dialog;

    public ItemSO startReward;
    public ItemSO endReward;

    public int enemyCountNeed = 10;
    public int currentEnemyCount = 0;
    public void Start()
    {
        currentEnemyCount = 0;
        state = GameTaskState.Executing;
        EventCenter.OnEnemyDied += OnEnemyDied;

    }

    public void End()
    {
        state = GameTaskState.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;
    }
    public void OnEnemyDied(Enemy enemy) 
    {
        if (state == GameTaskState.Completed) return;
        currentEnemyCount++;
        if(currentEnemyCount >= enemyCountNeed)
        {
            state = GameTaskState.Completed;
            MessageUI.instance.Show("任务已完成, 请前去获取奖励!");
        }
    }
}
