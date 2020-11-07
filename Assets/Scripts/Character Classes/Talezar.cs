using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookOfTheKnight", menuName = "Character Classes", order = 1)]
public class Talezar : MonoBehaviour
{
    Knight characterClass = (Knight)PlayerActor.CreateInstance("Knight");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
