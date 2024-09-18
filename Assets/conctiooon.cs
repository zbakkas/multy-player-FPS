using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
public class conctiooon : MonoBehaviour, INetworkRunnerCallbacks
{
    public bool concOnAwik = false;
    public NetworkRunner ruuner;
    // public NetworkObject playerprrfab;
    private void Awake()
    {
        if (concOnAwik)
        {
            cooncToRunner();
        }
    }
    

    public async void cooncToRunner()
    {
        if (ruuner == null)
        {
            ruuner = gameObject.AddComponent<NetworkRunner>();
        }

        await ruuner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName="test",
            //Scene=3,
            PlayerCount=2,
            SceneManager=gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

    }
   

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer") ;
    // NetworkObject playeronjct = ruuner.Spawn(playerprrfab,Vector3.zero);
      //  ruuner.SetPlayerObject(ruuner.LocalPlayer, playeronjct);
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
     }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerJoined");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {

    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
 
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
       
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
       
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
     
    }
}
