using Fusion;
using UnityEngine;
using System.Linq;
public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public Transform[] p; 
   

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
           // if(Runner.LocalPlayer.ToString() == "[Player:0]")
            ///{
                Runner.Spawn(PlayerPrefab, p[Random.Range(0, p.Length)].position, Quaternion.identity, player);
           // }
          //  else if (Runner.LocalPlayer.ToString() == "[Player:1]")
          //  {
           //     Runner.Spawn(PlayerPrefab, p[Random.Range(0,p.Length)].position, Quaternion.identity, player);
          //  }
        }
    }

  
}