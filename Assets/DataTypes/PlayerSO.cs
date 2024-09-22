using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO's", order = 0)]
public class PlayerSO : ScriptableObject
{
    public Sprite ui;
    public GameObject Prefab;
    public AnimatorController animator;
}
