using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] Text text;

    public void SetQuest(string header, string description)
    {
        text.text = $"<b>{header}</b> \n <size=35>{description}</size>";
    }

    public void CompleteQuest()
    {
        text.text = "Задание выполнено!";
    }
}
