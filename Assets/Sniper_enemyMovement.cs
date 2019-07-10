using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_enemyMovement : MonoBehaviour
{
    public Transform Player;

    public void Update()
    {
        transform.LookAt(Player);
    }
}