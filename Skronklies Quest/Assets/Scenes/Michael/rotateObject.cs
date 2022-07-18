using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{

    void Update()
    {       

        transform.rotation = Quaternion.EulerAngles (0,0, this.transform.rotation.z+1);
    }
}
