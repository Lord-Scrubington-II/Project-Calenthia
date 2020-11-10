using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dietrich : MonoBehaviour
{
    [SerializeField] Mage characterClass;
    Sprite characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        //this.characterClass = GameObject.Find("ArcanumOfTheMage").GetComponent<Mage>();
        this.characterSprite = gameObject.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
