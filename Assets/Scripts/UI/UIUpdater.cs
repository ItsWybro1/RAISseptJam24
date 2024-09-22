using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
        GameObject p1 = GameObject.Find("Player1");
        if (p1 != null)
        {
            ActivePlayers.Add(p1);
        }
        GameObject p2 = GameObject.Find("Player2");
        if (p2 != null)
        {
            ActivePlayers.Add(p2);
        }
        GameObject p3 = GameObject.Find("Player3");
        if (p3 != null)
        {
            ActivePlayers.Add(p3);
        }
        GameObject p4 = GameObject.Find("Player4");
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
            P3Death();
            //P4Death();
        }
        if(ActivePlayers.Count <= 1)
        {
            foreach (var go in ActivePlayers)
            {
                Debug.Log(go.name);
                winText.text = go.name + " WINS";
            }
        }
    }
    public void P1Death()
    {
        p1Picture.SetActive(false);
        p1Dead.SetActive(true);
        ActivePlayers.Remove(p1);
    }
    public void P2Death()
    {
        p2Picture.SetActive(false);
        p2Dead.SetActive(true);
        ActivePlayers.Remove(p2);
    }
    public void P3Death()
    {
        p3Picture.SetActive(false);
        p3Dead.SetActive(true);
        ActivePlayers.Remove(p3);
    }
    public void P4Death()
    {
        p4Picture.SetActive(false);
        p4Dead.SetActive(true);
        ActivePlayers.Remove(p4);
    }
}
