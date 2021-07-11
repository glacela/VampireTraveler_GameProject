using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject vampire, bat;

    int playerActive = 1;

    void Start()
    {
        vampire.gameObject.SetActive (true);
        bat.gameObject.SetActive (false);
    }

    public void SwitchPlayer()
    {
        switch (playerActive) {

        case 1:

            playerActive = 2;

            vampire.gameObject.SetActive (false);
            bat.gameObject.SetActive (true);
            break;

        case 2:

            playerActive = 1;

            vampire.gameObject.SetActive (true);
            bat.gameObject.SetActive (false);
            break;

        }

    }

    void Update()
    {
        
    }
}
