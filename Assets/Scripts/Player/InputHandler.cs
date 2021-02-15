using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    // Queue untuk menyimpan list command
    Queue<Command> commands = new Queue<Command>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // handle input movement
        Command moveCommand = InputMovementHandling();

        if(moveCommand != null )
        {
            commands.Enqueue(moveCommand);
            moveCommand.Execute();
        }
    }

    void Update()
    {
        // handle shoot
        Command shootCommand = InputShootHandling();
        if(shootCommand != null)
        {
            shootCommand.Execute();
        }
    }

    Command InputMovementHandling()
    {
        if(Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }
        else if(Input.GetKey(KeyCode.Z))
        {
            return Undo();
        }
        else
        {
            return null;
        }

    }

    Command Undo()
    {
        // kalo queue command tidak kosong, undo
        if(commands.Count > 0 )
        {
            Debug.Log("Undoing");
            Command undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    Command InputShootHandling()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        return null;
    }
}
