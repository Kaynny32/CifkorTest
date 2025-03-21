using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[SerializeField]
public class InfoContainer 
{
    public string Name;
}
public class QueueManager : MonoBehaviour
{
    InfoContainer messageContainer;

    Queue <InfoContainer> NetworkMessageQueue = new Queue<InfoContainer>();

    [SerializeField]
    bool QueueIsRunning = false;

    [SerializeField]
    int _RequestsCount = 0;


    private void FixedUpdate()
    {
        //DEBUG IN EDITOR
        _RequestsCount = NetworkMessageQueue.Count;
    }

    public void AddMessageToQueue(string name)
    {
        InfoContainer MessegeInfo = new InfoContainer();
        MessegeInfo.Name = name;
        NetworkMessageQueue.Enqueue(MessegeInfo);

        if (!QueueIsRunning)
        {
            messageContainer = NetworkMessageQueue.Dequeue();
            StartCoroutine(SendMessageInQueue());
            QueueIsRunning = true;
        }
    }

    public void StopResendMessageCorutine()
    {
        StopCoroutine(SendMessageInQueue());
        if (NetworkMessageQueue.Count > 0)
        {
            messageContainer = NetworkMessageQueue.Dequeue();
        }
        messageContainer = null;
        QueueIsRunning = false;
    }

    public bool CheckQueueIsEmpty()
    {
        return NetworkMessageQueue.Count < 1;
    }


    public void ClearQueue()
    {
        NetworkMessageQueue.Clear();
        StopCoroutine(SendMessageInQueue());
        QueueIsRunning = false;
        messageContainer = null;
    }

    IEnumerator SendMessageInQueue()
    { 
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Start: " + messageContainer.Name);
        NetworkManager.instance.SendMessageInQueue(messageContainer.Name);
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
                messageContainer = NetworkMessageQueue.Dequeue();
                StartCoroutine(SendMessageInQueue());
            }
            else
            {
                QueueIsRunning = false;
                messageContainer = null;
            }
        }
    }
}