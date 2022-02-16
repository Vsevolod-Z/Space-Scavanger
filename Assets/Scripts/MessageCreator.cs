using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessageCreator : MonoBehaviour
{
    TextMeshProUGUI messageText;

    void Start()
    {
        messageText = GameObject.Find("Canvas/MessageTextMEshPRO").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator CreateDangerWarning(string _message)
    {
        messageText.color = Color.red;
        messageText.text = _message;
        yield return new WaitForSeconds(2f);
        messageText.text = "";
    }
    public IEnumerator CreateWarning(string _message)
    {
        messageText.color = Color.yellow;
        messageText.text = _message;
        yield return new WaitForSeconds(2f);
        messageText.text = "";
    }
    public IEnumerator CreateNotification(string _message)
    {
        messageText.color = Color.green;
        messageText.text = _message;
        yield return new WaitForSeconds(2f);
        messageText.text = "";
    }
}
