using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActor : GenericActor
{

    GenericItem weapon;
    bool implementsMultipleStandardAttacks;

    public override void Flee()
    {
        
    }

    public override void MoveToPosition(byte loc)
    {

    }

    public override int StandardAttack()
    {
        return -1;
    }

    public override void UseItem(GenericItem item)
    {

    }

    public override void UseSkill(GenericSkill skill)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
