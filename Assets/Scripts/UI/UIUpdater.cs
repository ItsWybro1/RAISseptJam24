using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject p1Picture;
    public GameObject p2Picture;
    public GameObject p3Picture;
    public GameObject p4Picture;
    public GameObject p1Dead;
    public GameObject p2Dead;
    public GameObject p3Dead;
    public GameObject p4Dead;
    public GameManager gameManager;
    public GameObject p1, p2, p3, p4;
    public static List<GameObject> ActivePlayers = new List<GameObject>();
    public TextMeshProUGUI winText;
    public GameObject p1wins,p2wins,p3wins,p4wins;
    public PlayerHealth healthTest, healthTest1, healthTest2, healthTest3;

    public void Awake()
    {
        Debug.Log("" + ActivePlayers.Count);
    }
    public void Start()
    {
        p1Picture.SetActive(true);
        p2Picture.SetActive(true);
        p3Picture.SetActive(true);
        p4Picture.SetActive(true);
        p1Dead.SetActive(false);
        p2Dead.SetActive(false);
        p3Dead.SetActive(false);
        p4Dead.SetActive(false);
        p1wins.SetActive(false);
        p2wins.SetActive(false);
        p3wins.SetActive(false);
        p4wins.SetActive(false);
        healthTest = p1.GetComponentInChildren<PlayerHealth>();
        healthTest1 = p2.GetComponentInChildren<PlayerHealth>();
        healthTest2 = p3.GetComponentInChildren<PlayerHealth>();
        healthTest3 = p4.GetComponentInChildren<PlayerHealth>();
        if (p1 != null)
        {
            ActivePlayers.Add(p1);
            Debug.Log("did the thing");
        }
        if (p2 != null)
        {
            ActivePlayers.Add(p2);
        }
        if (p3 != null)
        {
            ActivePlayers.Add(p3);
        }
        if (p4 != null)
        {
            ActivePlayers.Add(p4);
        }
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            P1Death();
            P2Death();
            //P3Death();
            P4Death();
            Debug.Log(""+ ActivePlayers.Count);
        }
        if(ActivePlayers.Count <= 1)
        {
            Debug.Log("its triggering");
            StartCoroutine(WinThing());
            //CheckForWinner();
        }
    }
    public void P1Death()
    {
        p1Picture.SetActive(false);
        p1Dead.SetActive(true);
        ActivePlayers.Remove(p1);
        Debug.Log("dead1");
    }
    public void P2Death()
    {
        p2Picture.SetActive(false);
        p2Dead.SetActive(true);
        ActivePlayers.Remove(p2);
        Debug.Log("dead2");
    }
    public void P3Death()
    {
        p3Picture.SetActive(false);
        p3Dead.SetActive(true);
        ActivePlayers.Remove(p3);
        Debug.Log("dead3");
    }
    public void P4Death()
    {
        p4Picture.SetActive(false);
        p4Dead.SetActive(true);
        ActivePlayers.Remove(p4);
        Debug.Log("dead4");
    }
    public void allDeath()
    {
        foreach (var me in ActivePlayers)
        {
            Debug.Log(me);
            Debug.Log(me.name);
            //winText.text = go.name + " WINS";
            if ( healthTest.cur_health == 0)
            {
                Debug.Log("p1winshuzzah");
                //p1wins.SetActive(true);
                P1Death();
            }
            if ( healthTest1.cur_health == 0)
            {
                Debug.Log("p2winshuzzah");
                //p2wins.SetActive(true);
                P2Death();
            }
            if (healthTest2.cur_health == 0)
            {
                Debug.Log("p3winshuzzah");
                //p3wins.SetActive(true);
                P3Death();
            }
            if (healthTest3.cur_health == 0)
            {
                Debug.Log("p4winshuzzah");
                //p4wins.SetActive(true);
                P4Death();
            }
        }
    }
    public void CheckForWinner()
    {
        foreach (var go in ActivePlayers)
        {
            Debug.Log(go);
            Debug.Log(go.name);
            //winText.text = go.name + " WINS";
            if (go.name == "Player")
            {
                Debug.Log("p1winshuzzah");
                p1wins.SetActive(true);
            }
            else if (go.name == "Player2")
            {
                Debug.Log("p2winshuzzah");
                p2wins.SetActive(true);
            }
            else if (go.name == "Player3")
            {
                Debug.Log("p3winshuzzah");
                p3wins.SetActive(true);
            }
            else if (go.name == "Player4")
            {
                Debug.Log("p4winshuzzah");
                p4wins.SetActive(true);
            }
        }
    }
    public IEnumerator WinThing()
    {
        Debug.Log("Question");
        CheckForWinner();
        yield return new WaitForSeconds(5);
    }
}
