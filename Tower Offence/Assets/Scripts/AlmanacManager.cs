using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlmanacManager : MonoBehaviour
{
    public GameObject monstersView;
    public GameObject towersView;
    public GameObject main;

    public List<GameObject> units;
    public Image monsterImage;
    public Text monsterText;
    public Text costText;
    public Text damageText;
    public Text stealageText;
    public Text infoText;
    public Text healthText;
    public Text speedText;
    public Text abilityText;

    public List<GameObject> towers;
    public Image towerImage;
    public Text towerText;
    public Text towerCostText;
    public Text towerDamageText;
    public Text rangeText;
    public Text pierceText;
    public Text shotDelayText;
    public Text towerInfoText;
    public Text shotsText;


    private void Start()
    {
        Unit monsterDetails = units[0].GetComponent<Unit>();
        monsterImage.sprite = units[0].GetComponent<SpriteRenderer>().sprite;
        monsterText.text = (monsterDetails.monsterName);
        speedText.text = ("Speed: " + monsterDetails.speed);
        abilityText.text = ("Ability: " + monsterDetails.ability);
        costText.text = ("Cost: " + monsterDetails.cost);
        healthText.text = ("Health: " + monsterDetails.health);
        damageText.text = ("Damage: " + monsterDetails.healthDamage);
        stealageText.text = ("Stealage: " + monsterDetails.moneyGainedPerTile);
        infoText.text = (monsterDetails.info);
        Tower towerDetails = towers[0].GetComponent<Tower>();
        towerText.text = (towerDetails.towerName);
        towerImage.sprite = towers[0].GetComponent<SpriteRenderer>().sprite;

        shotDelayText.text = ("Shot Delay: " + towerDetails.shotDelay);
        shotsText.text = ("Shots: " + towerDetails.shots);
        towerCostText.text = ("Cost: " + towerDetails.cost);
        pierceText.text = ("Pierce: " + towerDetails.pierce);
        towerDamageText.text = ("Damage: " + towerDetails.damage);
        rangeText.text = ("Range: " + towers[0].GetComponent<CircleCollider2D>().radius);
        towerInfoText.text = (towerDetails.info);
    }
    public void MonsterInfo(int selectedMonster)
    {
       
        Unit monsterDetails = units[selectedMonster].GetComponent<Unit>();
        monsterText.text = ( monsterDetails.monsterName);
        monsterImage.sprite = units[selectedMonster].GetComponent<SpriteRenderer>().sprite;
        speedText.text = ("Speed: " + monsterDetails.speed);
        abilityText.text = ("Ability: " + monsterDetails.ability);
        costText.text = ("Cost: " + monsterDetails.cost);
        healthText.text = ("Health: " + monsterDetails.health);
        damageText.text = ("Damage: " + monsterDetails.healthDamage);
        stealageText.text = ("Stealage: " + monsterDetails.moneyGainedPerTile);
        infoText.text = (monsterDetails.info);
    }
    public void TowerInfo(int selectedTower)
    {

        Tower towerDetails = towers[selectedTower].GetComponent<Tower>();
        towerText.text = (towerDetails.towerName);
        towerImage.sprite = towers[selectedTower].GetComponent<SpriteRenderer>().sprite;

        shotDelayText.text = ("Shot Delay: " + towerDetails.shotDelay);
        shotsText.text = ("Shots: " + towerDetails.shots);
        towerCostText.text = ("Cost: " + towerDetails.cost);
        pierceText.text = ("Pierce: " + towerDetails.pierce);
        towerDamageText.text = ("Damage: " + towerDetails.damage);
        rangeText.text = ("Range: " + towers[selectedTower].GetComponent<CircleCollider2D>().radius);
        towerInfoText.text = (towerDetails.info);
    }

    public void ViewMonsters()
    {
        main.SetActive(false);
        monstersView.SetActive(true);
    }
    public void ViewTowers()
    {
        main.SetActive(false);
        towersView.SetActive(true);
    }
    public void Back()
    {
        main.SetActive(true);
        monstersView.SetActive(false);
        towersView.SetActive(false);
    }
}
