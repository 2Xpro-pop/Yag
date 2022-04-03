using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolower : MonoBehaviour
{
    [SerializeField] Transform position;

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector3(
             position.position.x,
             position.position.y,
             -10
         );
    }
}
