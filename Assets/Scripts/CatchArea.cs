using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArea : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> astronauts = new List<GameObject>();

    public int astronautsNumber;

    private void Update()
    {

        astronautsNumber = astronauts.Count;

        if (astronauts.Count == 0)
        {
            Debug.Log("gagné");
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        GameObject collidedObject = other.gameObject;

        foreach (GameObject astronaut in astronauts)
        {
            if (collidedObject == astronaut)
            {
                astronauts.Remove(astronaut);
                Destroy(collidedObject);
               
                break;
            }
        }
    }
}
