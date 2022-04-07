using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

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
    

    public GameObject PauseMenu;
    public List<Button> MonsterButtons;

    public GameObject Almanac;
    public GameObject uiHolder;

    public GameObject blackOut;
    public GameObject levelText;
    public GameObject gameOverCanvas;
    public GameObject outcomeText;
    public GameObject outcomeInitText;
    public GameObject stolenHolder;
    public GameObject livesHolder;
    public GameObject timeHolder;
    public GameObject retryButton;
    public GameObject menuButton;
    public GameObject inputObject;
    public GameObject submitButton;
    public Text menuLivesText;
    public Text menuTimeText;
    public Text menuStolenText;
    
    public AudioClip lossClip;
    public AudioClip victoryMusic;

    GameObject myEventSystem;

    public bool isGameOver = false;
    public bool isPaused = false;
    public float moneyStolen = 0;
    float musicVolume;
    AudioSource audioSource;
    float timeElapsed =0;
    float livesTaken;

    List<string> leaderboard;
    public InputField input;
    public Text submitText;
    private void Start()
    {
        musicVolume = FindObjectOfType<SettingsManager>().musicVolume;
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = musicVolume / 100;
        liveText.text = Lives.ToString();
        timeText.text = TimeLeft.ToString();
        moneyText.text = Money.ToString();
        myEventSystem = GameObject.Find("EventSystem");
       
        leaderboard = GameObject.Find("LeaderboardManager").GetComponent<LeaderBoard>().leaderboard;
  


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
            timeElapsed += Time.deltaTime;

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
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnSkelle();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SpawnGobbi();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                SpawnHydros();
            }
            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                SpawnShronk();
            }
            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            {
                SpawnSummoner();
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            {
                SpawnCrisp();
            }
            if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            {
                SpawnBongo();
            }
            if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            {
                SpawnFather();
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                StartCoroutine(ToggleUI());
            }
        }
    }
    public void TakeHealth(float healthTaken)
    {

        if (!isGameOver)
        {

            if (Lives - healthTaken < 0)
            {
                livesTaken += Lives;
                Lives = 0;
                
            }
            else
            {
                Lives -= healthTaken;
                livesTaken += healthTaken;
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
    public void SpawnCrisp()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[5].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[5]);
            Money -= units[5].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnBongo()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[6].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[6]);
            Money -= units[6].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public void SpawnFather()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (units[7].GetComponent<Unit>().cost <= Money)
        {
            ES.Spawn(units[7]);
            Money -= units[7    ].GetComponent<Unit>().cost;
            moneyText.text = Money.ToString();
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
    }
    public IEnumerator FadeBlackOut(bool win,int fadeSpeed =1)
    {
        gameOverCanvas.SetActive(true);
        Color objectColour = blackOut.GetComponent<Image>().color;
        Color levelTextColour = levelText.GetComponent<Text>().color;
        Color outcomeInitTextColour = outcomeInitText.GetComponent<Text>().color;
        float fadeAmount;
        float waitTime = 1.4f;
        timeElapsed = Mathf.Floor(timeElapsed);
        if (win)
        {
            outcomeInitText.GetComponent<Text>().text = "Congratulations";
        }
        else
        {
            outcomeInitText.GetComponent<Text>().text = "For Shame";

        }
        while (blackOut.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColour.a += (fadeSpeed * Time.deltaTime);
            objectColour = new Color(0,0, 0, fadeAmount);
            levelTextColour = new Color(levelTextColour.r, levelTextColour.g, levelTextColour.b, fadeAmount);
            outcomeInitTextColour = new Color(outcomeInitTextColour.r, outcomeInitTextColour.g, outcomeInitTextColour.b, fadeAmount);
            outcomeInitText.GetComponent<Text>().color = outcomeInitTextColour;
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
            tempStolen += 0.005f * moneyStolen;
            menuStolenText.text = Mathf.Round(tempStolen).ToString();
            yield return null;
        }
        livesHolder.SetActive(true);
        float tempLives = 0;
        while (tempLives < livesTaken )
        {
            tempLives += 0.005f * livesTaken;
            menuLivesText.text = Mathf.Round(tempLives).ToString();
            yield return null;
        }
        timeHolder.SetActive(true);
        float tempTime = 0;
        while (tempTime < timeElapsed)
        {
            tempTime += 0.005f * timeElapsed;
            menuTimeText.text = Mathf.Round(tempTime).ToString();
            yield return null;
        }
        retryButton.SetActive(true);
        submitButton.SetActive(win);
        inputObject.SetActive(win);
        menuButton.SetActive(true);


    }
    public IEnumerator ToggleUI(int toggleSpeed = 400)
    {
        Vector3 originalPosition = uiHolder.transform.position;

        if (originalPosition.x == 960)
        {
            while (uiHolder.transform.position.x < 1250)
            {
                
                uiHolder.transform.position += new Vector3(toggleSpeed * Time.deltaTime, 0);
                if (uiHolder.transform.position.x > 1250)
                {
                    uiHolder.transform.position = new Vector3(1250, uiHolder.transform.position.y, 0);
                }
                yield return null;
            }
    
        }
       else if (originalPosition.x == 1250)
        {
            while (uiHolder.transform.position.x > 960)
            {
              
                uiHolder.transform.position -= new Vector3(toggleSpeed * Time.deltaTime, 0);
                if(uiHolder.transform.position.x < 960)
                {
                    uiHolder.transform.position = new Vector3(960, uiHolder.transform.position.y, 0);
                }
                yield return null;
            }
        }
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

        audioSource.clip = lossClip;
        audioSource.Play();
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
        
        audioSource.clip = victoryMusic;
        audioSource.Play();
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
    public void OnAlmanac()
    {
        Almanac.SetActive(!Almanac.activeSelf);
        isPaused = !isPaused;
    }
    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnSetHighScores() 
    {
        List<string> tempScores = leaderboard[SceneManager.GetActiveScene().buildIndex - 1].Split('-').ToList();
        List<string> timeScores;
        List<string> moneyScores;
        
       for(int i = 0; i< (timeScores = tempScores[0].Split(',').ToList()).Count; i++)
        {
            List<string> seperateEntry = timeScores[i].Split(':').ToList();

            if (timeElapsed < int.Parse(seperateEntry[1]))
            {
                timeScores.Insert(i, input.text + ":" + Mathf.RoundToInt(timeElapsed));
                timeScores.RemoveAt(5);
                break;
            }
        }
        for (int i = 0; i < (moneyScores = tempScores[1].Split(',').ToList()).Count; i++)
        {
            List<string> seperateEntry = moneyScores[i].Split(':').ToList();
     
            if (moneyStolen > int.Parse(seperateEntry[1]))
            {
                moneyScores.Insert(i, input.text + ":" + moneyStolen);
                moneyScores.RemoveAt(5);
                break;
            }
        }

        string tempTime = "";
        string tempMoney = "";
        for (int i = 0; i < 5; i++)
        {
            if (i != 4)
            {
                tempTime += timeScores[i] + ",";
                tempMoney += moneyScores[i] + ",";
            }
            else
            {
                tempTime += timeScores[i];
                    tempMoney += moneyScores[i];
            }
        }
  
        leaderboard[SceneManager.GetActiveScene().buildIndex - 1] = tempTime + "-" + tempMoney;
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, leaderboard[SceneManager.GetActiveScene().buildIndex - 1]);
        submitText.text = "Score Submitted";
        
        submitButton.GetComponent<Button>().interactable = false;
      

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
