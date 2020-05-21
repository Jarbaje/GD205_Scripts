using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullets : MonoBehaviour
{
    public static int bulletsLeft = 10;
    TextMeshProUGUI bullets;
    
    // Start is called before the first frame update
    void Start()
    {
        bullets = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bullets.text = "Bullets: " + bulletsLeft;
    }
}
