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

    public GameObject PauseMenu;
    public List<Button> MonsterButtons;
    public Image win;
    public Image loss;

    public AudioClip winClip;
    public AudioClip lossClip;
    
    GameObject myEventSystem;
    
    public bool isGameOver = false;
    public bool isPaused = false;
    float musicVolume;
    AudioSource audioSource;
    private void Start()
    {
        liveText.text = Lives.ToString();
        timeText.text = TimeLeft.ToString();
        moneyText.text = Money.ToString();
        myEventSystem  = GameObject.Find("EventSystem");
        musicVolume = FindObjectOfType<SettingsManager>().musicVolume;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume / 100;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var item in MonsterButtons)
            {
                item.enabled = !item.enabled;
            }
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            isPaused = !isPaused;
        }
        if (!isGameOver && !isPaused)
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
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                SpawnHydros();
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                SpawnShronk();
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                SpawnSummoner();
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
        if(isPaused || isGameOver)
        {
            return;
        }
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
        if (isPaused || isGameOver)
        {
            return;
        }
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
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[2].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[2]);
            Money -= units[2].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnShronk()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[3].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[3]);
            Money -= units[3].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnSummoner()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[4].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[4]);
            Money -= units[4].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void MonsterInfo(int selectedMonster)
    {
        if (isPaused || isGameOver)
        {
            return;
        }
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
        foreach (var item in MonsterButtons)
        {
            item.enabled = !item.enabled;
        }
        isGameOver = true;
        loss.enabled = true;
        audioSource.Pause();
        AudioSource.PlayClipAtPoint(lossClip, transform.position);
    }
    void GoodOver()
    {
        foreach (var item in MonsterButtons)
        {
            item.enabled = !item.enabled;
        }
        isGameOver = true;
        win.enabled = true;
        AudioSource.PlayClipAtPoint(winClip, transform.position);
    }
}
