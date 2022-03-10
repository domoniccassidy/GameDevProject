using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GetUnitInfo : MonoBehaviour,IPointerEnterHandler
{
     User user;
    public int monsterNum;
    public void OnPointerEnter(PointerEventData eventData)
    {
        user.MonsterInfo(monsterNum);
    }

    // Start is called before the first frame update
    void Start()
    {
        user = FindObjectOfType<User>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
