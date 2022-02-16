using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class FPScounter : MonoBehaviour
{
    TextMeshProUGUI fpsCounterText;
    int fps;
    // Start is called before the first frame update
    void Start()
    {
       fpsCounterText=GameObject.Find("Canvas/FPScounter").gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateFPS());
    }

    IEnumerator UpdateFPS()
    {
        yield return new WaitForSeconds(0.4f);
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsCounterText.text = fps + "FPS";
        StartCoroutine(UpdateFPS());
    }
}
