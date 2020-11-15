using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talezar : MonoBehaviour
{
    [SerializeField] Knight characterClass;
    Sprite characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        this.characterSprite = gameObject.GetComponent<Sprite>();
        //characterClass = GameObject.Find("BookOfTheKnight").GetComponent<Knight>();
        print(characterClass.HPMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
