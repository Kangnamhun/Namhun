﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemTest : MonoBehaviour
{
    [SerializeField]
    private Quest quest;
    [SerializeField]
    private Category category;
    [SerializeField]
    private TaskTarget target;
    void Start()
    {
        var questSystem = Managers.Quest;
        questSystem.onQuestRegistered += (quest) =>{
            print($"New Quest : {quest.CodeName} Register");
            print($"Active Quests Count:{questSystem.ActiveQuests.Count}");
        };
        questSystem.onQuestCompleted += (quest) =>{
            print($"Quest:{quest.CodeName} Completed");
            print($"Completed Quests Count:{questSystem.CompletedQuests.Count}");
        };

        var newQuest = questSystem.Register(quest);
        newQuest.onTaskSuccessChanged += (quest, task, currentSuccess, prevSuccess) =>{
            print($"Quest:{quest.CodeName},Task:{task.CodeName}, CurrentSuccess:{currentSuccess}");
        };
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Managers.Quest.ReceiveReport(category, target, 1);
        }
    }
}