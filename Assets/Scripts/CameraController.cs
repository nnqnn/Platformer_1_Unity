using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public static CameraController Instance { get; set; }

    
    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<HeroScript>().transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        pos.z = -30f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 1.7f);

    }
}
