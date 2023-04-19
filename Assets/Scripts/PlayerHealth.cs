using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] HealthBar healthbar;

    public UnitHealth playerHealth = new UnitHealth(100, 100);

    private void OnCollisionEnter(Collision collision)
    {
        PlayerTakeDmg(20);
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg);
        healthbar.SetHealth(GameManager.gameManager.playerHealth.Health);
        if (GameManager.gameManager.playerHealth.Health <= 0)
            GameManager.gameManager.GameOver();
    }
}
