using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPowerUp : MonoBehaviour
{
    public GameObject powerUpExplosion;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gameController.playerInvincible)
            {
                gameController.SetPlayerInvincible(true);
            }
            Instantiate(powerUpExplosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }
}
