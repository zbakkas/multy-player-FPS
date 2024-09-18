
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class GameController : NetworkBehaviour
{
    [Networked(OnChanged = nameof(UpdateHat))] public float health { get; set; } = 100;  // Synchronized health variable

    public Text healthText; // Reference to a UI text element displaying health

    private void Start()
    {
        // Disable health text on the local player's UI
        if (HasStateAuthority)
        {
            healthText.gameObject.SetActive(false);
        }
    }

    // Example method to decrease health (call this when the player takes damage)
    [Rpc]
    public void RPCdamagge()
    {
        health -= 10;
    }

    // Synchronized health change hook
    protected static void UpdateHat(Changed<GameController> ch)
    {
        // Update UI on all clients when health changes
        ch.Behaviour.healthText.text = ch.Behaviour.health.ToString();
    }

    private void Die()
    {
        // Implement the logic for when the player dies
        Debug.Log("Player has died!");
    }
}