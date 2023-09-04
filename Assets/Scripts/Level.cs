using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public TextMeshProUGUI playerPowerText;
    public TextMeshProUGUI enemyPowerText;
    Buttons buttons;
    public GameObject gameUI;
    public int playerMaxPower;
    public int enemyMaxPower;
    [HideInInspector] public int playerPower;

    [SerializeField] public GameObject swordman, musketeer, smg, machinegun, cannon;
    [SerializeField] public GameObject swordsmanInfo, musketeerInfo, smgInfo, machinegunInfo, cannonInfo;
    [SerializeField] public int playerSwordmanPower, playerMusketeerPower, playerSmgPower, playerMachinegunPower, playerCannonPower;

    bool once;
    GridSystem gSystem;
    void Start()
    {
        once = true;
        playerPower = 0;
        gSystem = GameObject.Find("Grid System").GetComponent<GridSystem>();
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();
        playerPowerText.text = $"Güç: 0 / {playerMaxPower}";
        enemyPowerText.text = $"Güç: {enemyMaxPower}";

    }

    void Update()
    {
        if (buttons.isFight == true && once == true)
        {
            gameUI.SetActive(false);
            once = false;
        }
    }
    // Update is called once per frame
    public void AddPower()
    {
        if (gSystem.playerUnitPrefab.name == "PlayerSwordsman")
            playerPower += playerSwordmanPower;
        if (gSystem.playerUnitPrefab.name == "PlayerMusketeer")
            playerPower += playerMusketeerPower;
        if (gSystem.playerUnitPrefab.name == "PlayerSmg")
            playerPower += playerSmgPower;
        if (gSystem.playerUnitPrefab.name == "PlayerMachinegun")
            playerPower += playerMachinegunPower;
        if (gSystem.playerUnitPrefab.name == "PlayerCannon")
            playerPower += playerCannonPower;

        playerPowerText.text = $"Güç: {playerPower} / {playerMaxPower}";
        if (playerPower >= playerMaxPower)
        {
            playerPowerText.color = Color.black;
        }       
    }

    public void DeletePower()
    {
        if (gSystem.deletePlayerUnitPrefab.name == "PlayerSwordsman(Clone)")
            playerPower -= playerSwordmanPower;
        if (gSystem.deletePlayerUnitPrefab.name == "PlayerMusketeer(Clone)")
            playerPower -= playerMusketeerPower;
        if (gSystem.deletePlayerUnitPrefab.name == "PlayerSmg(Clone)")
            playerPower -= playerSmgPower;
        if (gSystem.deletePlayerUnitPrefab.name == "PlayerMachinegun(Clone)")
            playerPower -= playerMachinegunPower;
        if (gSystem.deletePlayerUnitPrefab.name == "PlayerCannon(Clone)")
            playerPower -= playerCannonPower;

        playerPowerText.text = $"Güç: {playerPower} / {playerMaxPower}";
        if (playerPower <= playerMaxPower)
        {
            playerPowerText.color = Color.red;
        }
    }



}
