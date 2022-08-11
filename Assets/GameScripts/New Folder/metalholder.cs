using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class metalholder : MonoBehaviour
{
    public TextMeshProUGUI counter;
    private int metalcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("count").GetComponent<TextMeshProUGUI>();
        counter.text = "" + metalcount;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("metal"))
        {
            metalcount++;
            counter.text = "" + metalcount;
        }
    }
}
