using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-1,0,0);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }
    }
}
