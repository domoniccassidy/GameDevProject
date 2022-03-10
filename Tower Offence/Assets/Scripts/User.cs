using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class User : MonoBehaviour
{
    public List<GameObject> units;
    public EnemySpawner ES;
    public float Lives;
    public float Money;
    public float TimeLeft;
    


    public Text liveText;
    public Text moneyText;
    public Text timeText;
    public Text monsterText;
    public Text costText;
    public Text damageText;
    public Text stealageText;
    public Text infoText;
    public Text healthText;

    public Image win;
    public Image loss;

    public AudioClip winClip;
    public AudioClip lossClip;
    
    GameObject myEventSystem;
    
    public bool isGameOver = false;

    private void Start()
    {
        liveText.text = Lives.ToString();
        timeText.text = TimeLeft.ToString();
        moneyText.text = Money.ToString();
        myEventSystem  = GameObject.Find("EventSystem");

    }
    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            TimeLeft -= Time.deltaTime;

            if (Mathf.Floor(TimeLeft) < float.Parse(timeText.text))
            {
                timeText.text = ((int) TimeLeft).ToString();
            }
            if (TimeLeft < 0)
            {
                GameOver();
            }
            if(Lives == 0)
            {
                GoodOver();
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                SpawnSkelle();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SpawnGobbi();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SpawnHydros();
            }
        }
    }
    public void TakeHealth(float healthTaken)
    {
        
        if (!isGameOver)
        {
            
            if(Lives - healthTaken < 0)
            {
                Lives = 0;
            }
            else
            {
                Lives -= healthTaken;
            }
            liveText.text = Lives.ToString();
        }
        
    }
    public void MakeMoney(float money)
    {
        if (!isGameOver)
        {
            Money += money;
            moneyText.text = Money.ToString();
        }
    }
    public void SpawnSkelle()
    {
 
        if (units[0].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[0]);
            Money -= units[0].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnGobbi()
    {
        if (units[1].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[1]);
            Money -= units[1].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnHydros()
    {
        if (units[2].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[2]);
            Money -= units[2].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void MonsterInfo(int selectedMonster)
    {
        //Debug.Log(units[selectedMonster].GetComponent<Unit>().monsterName);
        Unit monsterDetails = units[selectedMonster].GetComponent<Unit>();
        monsterText.text = ("Monster: " + monsterDetails.monsterName);
        costText.text = ("Cost: " + monsterDetails.cost);
       healthText.text = ("Health: " + monsterDetails.health);
        damageText.text = ("Damage: " + monsterDetails.healthDamage);
        stealageText.text = ("Stealage: " + monsterDetails.moneyGainedPerTile);
        infoText.text = (monsterDetails.info);
    }
    void GameOver()
    {
        isGameOver = true;
        loss.enabled = true;
        GetComponent<AudioSource>().Pause();
        AudioSource.PlayClipAtPoint(lossClip, transform.position);
    }
    void GoodOver()
    {
        isGameOver = true;
        win.enabled = true;
        AudioSource.PlayClipAtPoint(winClip, transform.position);
    }
}
