using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
public Transform target;
  [SerializeField] Vector3 offset;
  Vector3 p;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

transform.position = new Vector3(target.position.x-offset.x,transform.position.y,transform.position.z);
    }
}
