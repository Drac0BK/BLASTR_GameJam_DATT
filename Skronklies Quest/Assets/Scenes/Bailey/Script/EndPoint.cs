using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public GameObject SceneChange;
    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.0f, 3.0f), 0.0f);
        foreach(var colliders in hitColliders)
        {
            if(colliders.tag == "Player")
            {
                foreach(var collider2 in hitColliders)
                {
                    if (collider2.tag == "Skronkly")
                    {
                        SceneChange.GetComponent<SceneChanger>().Win();
                        return;
                    }
                }
                return;
            }
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawCube(transform.position, new Vector2(1.0f, 3.0f));
    //}
}
