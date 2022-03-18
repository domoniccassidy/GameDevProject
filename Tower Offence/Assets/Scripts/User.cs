using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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

    public GameObject blackOut;
    public GameObject levelText;
    public GameObject gameOverCanvas;
    public GameObject outcomeText;
    public GameObject stolenHolder;
    public GameObject livesHolder;
    public GameObject timeHolder;
    public GameObject retryButton;
    public GameObject menuButton;
    public Text menuLivesText;
    public Text menuTimeText;
    public Text menuStolenText;
    public AudioClip winClip;
    public AudioClip lossClip;
    public AudioClip scream;

    GameObject myEventSystem;

    public bool isGameOver = false;
    public bool isPaused = false;
    public float moneyStolen = 0;
    float musicVolume;
    AudioSource audioSource;
    private void Start()
    {
        Screen.fullScreen = !Screen.fullScreen;
        liveText.text = Lives.ToString();
        timeText.text = TimeLeft.ToString();
        moneyText.text = Money.ToString();
        myEventSystem = GameObject.Find("EventSystem");
        musicVolume = FindObjectOfType<SettingsManager>().musicVolume;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume / 100;

    }
    // Update is called once per frame
    void Update()
    {
        OnDebug();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
        if (!isGameOver && !isPaused)
        {
            TimeLeft -= Time.deltaTime;

            if (Mathf.Floor(TimeLeft) < float.Parse(timeText.text))
            {
                timeText.text = ((int)TimeLeft).ToString();
            }
            if (TimeLeft < 0)
            {
                GameOver();
            }
            if (Lives == 0)
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

            if (Lives - healthTaken < 0)
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
            moneyStolen += money;
            moneyText.text = Money.ToString();
        }
    }
    public void SpawnSkelle()
    {
        if (isPaused || isGameOver)
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
    public IEnumerator FadeBlackOut(bool win,int fadeSpeed =1)
    {
        gameOverCanvas.SetActive(true);
        Color objectColour = blackOut.GetComponent<Image>().color;
        Color levelTextColour = levelText.GetComponent<Text>().color;
        float fadeAmount;
        float waitTime = 1.4f;
        float timeElapsed = 200 - TimeLeft;
        float livesTaken = 50 - Lives;
        while(blackOut.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColour.a += (fadeSpeed * Time.deltaTime);
            objectColour = new Color(0,0, 0, fadeAmount);
            levelTextColour = new Color(levelTextColour.r, levelTextColour.g, levelTextColour.b, fadeAmount);
            levelText.GetComponent<Text>().color = levelTextColour;
            blackOut.GetComponent<Image>().color = objectColour;
            yield return null;
        }
        while(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        waitTime = 1.4f;
        if (win)
        {
            outcomeText.GetComponent<Text>().text = "Has Been Destroyed";
        }
        else
        {
            outcomeText.GetComponent<Text>().text = "Has Been Saved";

        }
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        stolenHolder.SetActive(true);
        float tempStolen = 0;
        while (tempStolen < moneyStolen)
        {
            tempStolen += 0.0005f * moneyStolen;
            menuStolenText.text = Mathf.Round(tempStolen).ToString();
            yield return null;
        }
        livesHolder.SetActive(true);
        float tempLives = 0;
        while (tempLives < livesTaken )
        {
            tempLives += 0.0005f * livesTaken;
            menuLivesText.text = Mathf.Round(tempLives).ToString();
            yield return null;
        }
        timeHolder.SetActive(true);
        float tempTime = 0;
        while (tempTime < timeElapsed)
        {
            tempTime += 0.0005f * timeElapsed;
            menuTimeText.text = Mathf.Round(tempTime).ToString();
            yield return null;
        }
        retryButton.SetActive(true);
        menuButton.SetActive(true);


    }
    void GameOver()
    {

        foreach (var item in MonsterButtons)
        {
            item.enabled = !item.enabled;
        }
        isGameOver = true;
        if (audioSource)
        {
            audioSource.Pause();
        }
        
        AudioSource.PlayClipAtPoint(lossClip, transform.position);
        StartCoroutine(FadeBlackOut(false));
    }
    void GoodOver()
    {
        foreach (var item in MonsterButtons)
        {
            item.enabled = !item.enabled;
        }
        isGameOver = true;
        if (audioSource)
        {
            audioSource.Pause();
        }
        AudioSource.PlayClipAtPoint(scream, transform.position);
        StartCoroutine(FadeBlackOut(true));
    }

    public void OnPause()
    {
        foreach (var item in MonsterButtons)
        {
            item.enabled = !item.enabled;
        }
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        isPaused = !isPaused;
    }
    public void OnPlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    
    void OnDebug()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.B))
        {
            Money += 9999999;
            moneyText.text = Money.ToString();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoodOver();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            GameOver();
        }

#endif
    }
}
