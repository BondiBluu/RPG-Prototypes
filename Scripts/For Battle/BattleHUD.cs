using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    [Header("Player Names and Levels")]
    public TMP_Text[] nameTextPlayers;
    [SerializeField] TMP_Text[] levelTextPlayers;

    [Header("Player HP")]
    public TMP_Text[] currentHPPlayers;
    public TMP_Text[] maxHPPlayers;
    public Slider[] sliderHPPlayers;

    [Header("Player MP")]
    public TMP_Text[] currentMPPlayers;
    public TMP_Text[] maxMPPlayers;
    public Slider[] sliderMPPlayers;

    [Header("Allies")]
    public TMP_Text[] nameTextAllies;
    public Slider[] sliderHPAllies;
    public Slider[] sliderMPAllies;

    [Header("Enemy Names")]
    public TMP_Text[] nameTextEnemies;

    [Header("Enemy HP Sliders")]
    public Slider[] sliderEnemies;

    //Setting the HUD
    public void SetPlayerHUD(Unit[] units)
    {
        for (int i = 0; i < units.Length; i++)
        {
            //displaying name, lvl, max and current hp and mp of players
            nameTextPlayers[i].text = units[i].characterStats.CharacterName;
            levelTextPlayers[i].text = units[i].characterStats.Level.ToString();
            maxHPPlayers[i].text = units[i].characterStats.MaxHP.ToString();
            currentHPPlayers[i].text = units[i].characterStats.CurrentHP.ToString();
            maxMPPlayers[i].text = units[i].characterStats.MaxMP.ToString();
            currentMPPlayers[i].text = units[i].characterStats.CurrentMP.ToString();

            //displaying things for allies
            nameTextAllies[i].text = units[i].characterStats.CharacterName;
            sliderHPAllies[i].maxValue = units[i].characterStats.MaxHP;
            sliderHPAllies[i].value = units[i].characterStats.CurrentHP;
            sliderMPAllies[i].maxValue = units[i].characterStats.MaxMP;
            sliderMPAllies[i].value = units[i].characterStats.CurrentMP;

            //sliders have built in max values and vaues in general
            sliderHPPlayers[i].maxValue = units[i].characterStats.MaxHP; 
            sliderMPPlayers[i].maxValue = units[i].characterStats.MaxMP; 
            sliderHPPlayers[i].value = units[i].characterStats.CurrentHP;
            sliderMPPlayers[i].value = units[i].characterStats.CurrentMP;
        }
    }

    public void SetEnemyHUD(Unit[] units)
    {
        for (int i = 0; i < units.Length; i++)
        {
            //displaying name and current hp of enemies
            nameTextEnemies[i].text = units[i].characterStats.CharacterName;
            sliderEnemies[i].maxValue = units[i].characterStats.MaxHP;
            sliderEnemies[i].value = units[i].characterStats.CurrentHP;
        }
    }

    //updating player hp
    public void UpdatePlayerHPAndMP(Unit unit, int hP, int mP)
    {
        int characterIndex = System.Array.IndexOf(battleSystem.playerUnits, unit);

        if (characterIndex != -1)
        {
            //updating the current hp and mp of all players, and numberical value of hp
            sliderHPPlayers[characterIndex].value = hP;
            sliderHPAllies[characterIndex].value = hP;
            currentHPPlayers[characterIndex].text = hP.ToString();

            sliderMPPlayers[characterIndex].value = mP;
            sliderMPAllies[characterIndex].value = mP;
            currentMPPlayers[characterIndex].text = mP.ToString();
        }
                    
    }
    
    public void UpdateEnemyHPAndMP(Unit unit, int hP)
    {
        int characterIndex = System.Array.IndexOf(battleSystem.enemyUnits, unit);

        if (characterIndex != -1)
        {
            //updating the current hp and mp of all enemies
            sliderEnemies[characterIndex].value = hP;
        }
                    
    }
    
}


