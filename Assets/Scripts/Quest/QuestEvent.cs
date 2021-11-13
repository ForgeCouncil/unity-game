using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{

    public string qTitle;
    public string qText;
    public QuestLocation[] childLocations;
    public QuestLocation[] siblingsLocations;
    public bool isAvailable = false;

    public void CompleteObjective()
    {
        if (!isAvailable) return;

        QuestManager.Instance?.UpdateDisplay(qTitle, qText);
        foreach (QuestLocation item in siblingsLocations)
        {
            item.isAvailable = false;
        }
        foreach (QuestLocation item in childLocations)
        {
            item.isAvailable = true;
            item.siblingsLocations = childLocations;

        }
    }

 }