using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAiTo4 : MonoBehaviour
{
    public bool Alert4 = false;
    public AlertAiTo3 alert3;

    float timeSinceLastCross = 0;
    // Update is called once per frame
    void Update()
    {
        if (Alert4)
        {
            timeSinceLastCross += Time.deltaTime;
        }
        if (timeSinceLastCross > 2)
        {
            Alert4 = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Alert4 = true;
        timeSinceLastCross = 0;
        alert3.Alert3 = false;
        alert3.timeSinceLastCross = 0;
    }
}
