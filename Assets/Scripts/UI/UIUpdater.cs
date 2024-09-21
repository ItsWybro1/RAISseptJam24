using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            P1Death();
            P2Death();
            P3Death();
            P4Death();
        }
    }
    public void P1Death()
    {
        p1Picture.SetActive(false);
        p1Dead.SetActive(true);
    }
    public void P2Death()
    {
        p2Picture.SetActive(false);
        p2Dead.SetActive(true);
    }
    public void P3Death()
    {
        p3Picture.SetActive(false);
        p3Dead.SetActive(true);
    }
    public void P4Death()
    {
        p4Picture.SetActive(false);
        p4Dead.SetActive(true);
    }
}
