using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class metalholder : MonoBehaviour
{
    public TextMeshProUGUI counter;
    private int metalcount;

    public GameObject button; 

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("count").GetComponent<TextMeshProUGUI>();
        metalcount -= 1;
        counter.text = "" + metalcount;

        button.active = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("metal"))
        {
            metalcount++;
            counter.text = "" + metalcount;
        }
    }
    private void Update()
    {
        if(metalcount == 30)
        {
            button.active = true;
        }
    }
}
