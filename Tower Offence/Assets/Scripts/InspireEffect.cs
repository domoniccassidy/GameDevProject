using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspireEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Random.insideUnitCircle/4;
        transform.localScale = new Vector3(Random.Range(0.15f,0.4f), Random.Range(0.15f, 0.4f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime *2;
        Color tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a -= Time.deltaTime;
        GetComponent<SpriteRenderer>().color = tempColor;
    }
}
