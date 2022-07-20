using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogTest : MonoBehaviour
{
    private float start, shrink;

    [SerializeField]
    private SpriteRenderer fog, fogBackground;

    // Start is called before the first frame update
    void Start()
    {
        fog.color = new Color(1, 1, 1, start);
        fogBackground.color = new Color(1, 1, 1, start);

        start = 0;
        shrink = start;
    }

    // Update is called once per frame
    void Update()
    {
        shrink += Time.deltaTime/5;
        fog.color = new Color(1, 1, 1, shrink);
        fogBackground.color = new Color(1, 1, 1, shrink);
    }
}
