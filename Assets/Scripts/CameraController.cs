using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.position.x > -2.31f)
        {
            transform.position = new Vector3(player.position.x,player.position.y + 2.46f,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(-2.31f, player.position.y + 2.46f, transform.position.z);
        }
    }
}
