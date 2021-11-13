using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLocation : QuestEvent
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player" || !isAvailable) return;
        CompleteObjective();
    }
// Change this to QuestObjectives???
}