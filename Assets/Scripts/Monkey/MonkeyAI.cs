using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum MonkeyState
{
    Idle, Move, Disappear
}

public class MonkeyAI : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    Vector3 playerPosition;

    MonkeyState monkeyState;

    private void Start()
    {
        monkeyState = MonkeyState.Idle;

        // get player position
        playerPosition = MonkeySpawnManager.Instance.PlayerTransform.position;
    }

    private void Update()
    {
        switch (monkeyState)
        {
            case MonkeyState.Idle:
                IdleAction();
                IdleTransition();
                break;

            case MonkeyState.Move:
                MoveAction();
                MoveTransition();
                break;
            case MonkeyState.Disappear:
                DisappearAction();
                break;
        }
    }

    void IdleAction() { }

    void IdleTransition()
    {
        
        monkeyState = MonkeyState.Move;
    }

    void MoveAction()
    {
        // Monkey looks at the player
        transform.LookAt(playerPosition);

        // Monkey moves to the player
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);
    }

    void MoveTransition()
    {
        if (Vector3.Distance(transform.position, playerPosition) < 0.001f)
        {
            monkeyState = MonkeyState.Disappear;
        }
    }

    void DisappearAction()
    {
        gameObject.SetActive(false);
    }
}
