using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class InspireUnit : MonoBehaviour
{
    // Start is called before the first frame update
    public float inspireDelay;


    private List<Collider2D> colliders;
    private User user;
    private float sinceLastInspire = 0  ;
    void Start()
    {
        user = FindObjectOfType<User>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!user.isGameOver && !user.isPaused)
        {
            if (sinceLastInspire >= inspireDelay)
            {
                colliders = Physics2D.OverlapCircleAll(transform.position, 1.53f).ToList();
               
                foreach (var item in colliders.ToList())
                {
                    if (item.GetComponent<Unit>() == null)
                    {

                        colliders.Remove(item);
                        continue;
                    }
                    if(item.gameObject == gameObject)
                    {
                        colliders.Remove(item);
                    }
                  
                    
                }
                sinceLastInspire -= inspireDelay;
                colliders[Random.Range(0, colliders.Count)].GetComponent<Unit>().Inspire();
            }
            sinceLastInspire += Time.deltaTime;
        }
    }
}
