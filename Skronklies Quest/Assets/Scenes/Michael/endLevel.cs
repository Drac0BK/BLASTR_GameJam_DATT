using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endLevel : MonoBehaviour
{

    [SerializeField]
    private Text winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            Debug.Log("it working yet?");
            winText.text = "YOU WIN, YOU SAVED SKRONKLE";
        }
    }

}