using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    //private Level lvl;
    private bool is_on;

    public void Initialize() 
    {
        //debug and temporary
        Activate();


    }

    public void EnterLobby() 
    {

    }

    public void EnterLevel() 
    {
    
    }

    public void StartGame() 
    {
        
    }

    public void Activate() 
    {
        is_on = true;
    }

    public void Deactivate() {
        is_on = false;
    }

}
