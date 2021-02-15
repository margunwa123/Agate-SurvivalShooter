using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement playerMovement, float h, float v)
    {
        this.playerMovement = playerMovement;
        this.h = h;
        this.v = v;
    }

    public override void Execute()
    {
        playerMovement.Move(h, v);
        playerMovement.Animating(h, v);
    }

    public override void UnExecute()
    {
        //invers arah dari movement player
        playerMovement.Move(-h, -v);
        //Menganimasikan player
        playerMovement.Animating(h, v);
    }
}
