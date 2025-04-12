using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    public string[] contentInTaskExcuting;
    public string[] contentInTaskCompleted;
    public string[] contentInTaskEnd;
    private void Start()
    {
        gameTaskSO.state = GameTaskState.Waiting;
    }
    protected override void Interact()
    {
        
        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                DialogUI.instance.Show(npcName, gameTaskSO.dialog, OnDialogEnd);
                break;
            case GameTaskState.Executing:
                DialogUI.instance.Show(npcName, contentInTaskExcuting);
                break;
            case GameTaskState.Completed:
                DialogUI.instance.Show(npcName, contentInTaskCompleted, OnDialogEnd);
                break;
            case GameTaskState.End:
                DialogUI.instance.Show(npcName, contentInTaskEnd);
                break;
            default:
                break;
        }
    }

    public void OnDialogEnd()
    {
        switch (gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                
                gameTaskSO.Start();
                InventoryManager.instance.AddItem(gameTaskSO.startReward);
                MessageUI.instance.Show("你接受了一个任务!");
                break;
            case GameTaskState.Executing:

                break;
            case GameTaskState.Completed:
                gameTaskSO.End();
                InventoryManager.instance.AddItem(gameTaskSO.endReward);
                MessageUI.instance.Show("任务已提交!");
                break;
            case GameTaskState.End:
                break;
            default:
                break;
        }
    }
}
