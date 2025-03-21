using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[SerializeField]
public class InfoConteiner
{
    public string Name;
}
public class QueueManager : MonoBehaviour
{
    InfoConteiner messageConteiner;

    Queue <InfoConteiner> NetworkMessageQueue = new Queue<InfoConteiner>();

    bool QueueIsRuning = false;

    public void AddMassgeToQueue(string name)
    {
        InfoConteiner MessegeInfo = new InfoConteiner();
        MessegeInfo.Name = name;
        NetworkMessageQueue.Enqueue(MessegeInfo);

        if (!QueueIsRuning)
        {
            messageConteiner = NetworkMessageQueue.Dequeue();
            StartCoroutine(SendMessageInQueue());
            QueueIsRuning = true;
        }
    }

    public void StopResendMessageCorutine()
    {
        StopCoroutine(SendMessageInQueue());
        if (NetworkMessageQueue.Count > 0)
        {
            messageConteiner = NetworkMessageQueue.Dequeue();
        }
        messageConteiner = null;
        QueueIsRuning = false;
    }

    public bool CheckQueueIsEmpty()
    {
        if (NetworkMessageQueue.Count == 0)
            return true;
        else 
            return false;
    }

    IEnumerator SendMessageInQueue()
    { 
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Start: " + messageConteiner.Name);
        NetworkManager.instance.SenMessageInQueue(messageConteiner.Name);
    }

    public void ControlMessageSending(bool messageSendSuccessfully)
    {
        if (!messageSendSuccessfully)
        {
            StartCoroutine(SendMessageInQueue());
        }
        else
        {
            if (!CheckQueueIsEmpty())
            {
                messageConteiner = NetworkMessageQueue.Dequeue();
                StartCoroutine(SendMessageInQueue());
            }
            else
            {
                QueueIsRuning = false;
                messageConteiner = null;
            }
        }
    }
}