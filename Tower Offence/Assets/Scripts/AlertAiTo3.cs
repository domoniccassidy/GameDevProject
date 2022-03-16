using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAiTo3 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Alert3 = false;
    public float timeSinceLastCross = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Alert3)
        {
            timeSinceLastCross += Time.deltaTime;
        }
        if(timeSinceLastCross > 2)
        {
            Alert3 = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Alert3 = true;
        timeSinceLastCross = 0;
    }
}
