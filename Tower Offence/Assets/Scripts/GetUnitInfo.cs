using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GetUnitInfo : MonoBehaviour,IPointerEnterHandler
{
     AlmanacManager almanacManager;
    public int monsterNum;
    public void OnPointerEnter(PointerEventData eventData)
    {
        almanacManager.MonsterInfo(monsterNum);
    }

    // Start is called before the first frame update
    void Start()
    {
        almanacManager = FindObjectOfType<AlmanacManager>();
    }

    
}
