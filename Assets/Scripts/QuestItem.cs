using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuestItem : Actionable
{
    [Inject] QuestUI questUI;
    private void Start() {
        questUI.SetQuest("Потерянная игрушка", "Найдите игрушку, возможно, она на первом этаже");
        StartCoroutine(UpAndDown());
    }
    public override void Action()
    {
        questUI.CompleteQuest();
        Destroy(gameObject);
    }

    IEnumerator UpAndDown()
    {
        int y=0;
        while(true)
        {
            for(y=0; y < 180; y++)
            {
                yield return new WaitForSeconds(1/180);
                transform.position += new Vector3(0, 0.001f, 0);
            }

            for(y=0; y < 360; y++)
            {
                yield return new WaitForSeconds(1/180);
                transform.position -= new Vector3(0, 0.001f, 0);
            }

            for(y=0; y < 180; y++)
            {
                yield return new WaitForSeconds(1/180);
                transform.position += new Vector3(0, 0.001f, 0);
            }
        }
    }

}
