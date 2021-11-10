using Mirror;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : NetworkBehaviour
{

    public static MatchManager instance = null;

    [SyncVar(hook = nameof(OnReceivedMatchStarted))] 
    public bool matchStarted = false;

    private void OnReceivedMatchStarted(bool _old, bool _new)
    {
        if(_new)
        {
            SceneManager.UnloadSceneAsync("Lobby");
        }
    }
    // Start is called before the first frame update
    protected void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Server]
    public void StartMatch() => matchStarted = true;
}
