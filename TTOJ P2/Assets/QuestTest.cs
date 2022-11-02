using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTest : MonoBehaviour
{

    string questName = "Save the bird";

    bool isQuestStarted = false;
    bool isQuestDone = false;
    bool isQuestFinished = false;
    bool isQuestFailed = false;

    GameObject player;
    GameObject capsule;

    public float startDis = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        capsule = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        QuestEvents();

        if (Input.GetKeyDown(KeyCode.E) && Mathf.Abs(transform.position.x - player.transform.position.x) < startDis && isQuestStarted && isQuestFinished == false)
            if(isQuestStarted){
            MiddleDialogue();
            
        }

         if (Input.GetKeyDown(KeyCode.E) && Mathf.Abs(transform.position.x - player.transform.position.x) < startDis && isQuestStarted == false){
            isQuestStarted = true;
            InitialDialogue();
            QuestsManager.UnlockedQuests.Add(questName);
        }
        
        if  (Input.GetKeyDown(KeyCode.E) && Mathf.Abs(transform.position.x - player.transform.position.x) < startDis && isQuestFinished){
            EndDialogue();
        }
        
    }

    void InitialDialogue(){
        Debug.Log("Hey, Could you touch the capsule, please?");
    }

    void MiddleDialogue(){
        Debug.Log("Just touch the capsule");
    }

    void EndDialogue(){
        Debug.Log("Quest Finished SUCKSEXFULLY, Now you will die!");
    }


    // Quest Events

    void QuestEvents(){
        if (Mathf.Abs(capsule.transform.position.x - player.transform.position.x) < 1f){
            isQuestFinished = true;
            QuestsManager.UnlockedQuests.Remove(questName);
            QuestsManager.FinishedQuests.Add(questName);
        }
    }

    void FailedQuest(){
        if(isQuestFailed){
            QuestsManager.FailedQuests.Add(questName);
            QuestsManager.UnlockedQuests.Remove(questName);
        }
    }

}
