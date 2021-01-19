using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour
{
    Vector3 Respawn;
    public GameObject Checkpoint;
    private int tick = 0;
    private bool CheckpointActive = false;

    void Start()
    {
        Respawn = gameObject.transform.position;
    }

    private void Update()
    {
        if (CheckpointActive == true)
        {
            if (tick < 750)
            {
                Checkpoint.SetActive(true);
                tick = tick + 1;
            }
            else
            {
                CheckpointActive = false;
                tick = 0;
                Checkpoint.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            Respawn = gameObject.transform.position;
            CheckpointActive = true;
            other.gameObject.SetActive(false);
        } else if (other.tag == "Killbox")
        {
            this.transform.position = Respawn;

        }

    }
}
