using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject HoldPos;

    private GameObject holding;
    private GameObject[] Holdable;

    void Start()
    {
        Holdable = GameObject.FindGameObjectsWithTag("Holdable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (holding != null)
            {
                holding.GetComponent<LampController>().Holding(false);
                holding = null;
                return;
            } 
            Debug.Log("SUBMIIIIT");
            foreach (GameObject hold in Holdable)
            {
                Debug.Log(Vector2.Distance(hold.transform.position, transform.position));
                if (Vector2.Distance(hold.transform.position, transform.position) < 1.5f)
                {
                    holding = hold;
                    holding.GetComponent<LampController>().Holding(true);
                    break;
                }
            }
        }
        if (holding != null)
        {
            holding.transform.position = transform.position + new Vector3(transform.localScale.x * 0.8f, 0, 0);
        }
    }
}
