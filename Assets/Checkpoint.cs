<<<<<<< HEAD
using System.Transactions;
=======

>>>>>>> 9dee39f509047844cccd9a1533fcbfc5fd598a1b
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
<<<<<<< HEAD
    //Code that runs when something enters the trigger checkpoint collider
=======
    //Code that runs when something enters the Trigger checkpoint collider
>>>>>>> 9dee39f509047844cccd9a1533fcbfc5fd598a1b
    void OnTriggerEnter(Collider other)
    {
        //if it is not the player that triggers it, skip the code
        if (!other.CompareTag("Player"))
        {
            return;
        }

        //if the position of this checkpoint is the currentCheckpoint for player, then run increment code
<<<<<<< HEAD

=======
>>>>>>> 9dee39f509047844cccd9a1533fcbfc5fd598a1b
        if (transform == GameLogic.checkpointA[GameLogic.currentCheckpoint].transform)
        {
            //check if it is the last checkpoint in the list or not
            if (GameLogic.currentCheckpoint + 1 < GameLogic.checkpointA.Length)
            {
                //if the current checkpoint is 0 in the array, then increase lap
                if (GameLogic.currentCheckpoint == 0)
                {
                    GameLogic.currentLap++;
                }
                //increase checkpoint if it is not last checkpoint
                GameLogic.currentCheckpoint++;
            }
            else
            {
                //reset checkpoint to 0 if last checkpoint is reached
                GameLogic.currentCheckpoint = 0;
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 9dee39f509047844cccd9a1533fcbfc5fd598a1b
    }
}
