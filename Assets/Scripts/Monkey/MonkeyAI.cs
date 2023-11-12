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
    float jumpSpeed = 1f;

    [SerializeField]
    float dropSpeed = 2f;

    [SerializeField]
    Vector3 playerPosition;

    MonkeyState monkeyState;

    bool getPlayerPosition;

    private void Start()
    {

    }

    private void OnEnable()
    {
        if (!getPlayerPosition)
        {
            monkeyState = MonkeyState.Idle;

            // get player position
            playerPosition = MonkeySpawnManager.Instance.PlayerTransform.position;

            getPlayerPosition = true;
        }
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
        StartCoroutine(JumpToTarget(playerPosition));

/*        // Monkey moves to the player
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);*/
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
        getPlayerPosition = false;
        gameObject.SetActive(false);
    }

    private IEnumerator JumpToTarget(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        Vector3 handlePosition = Vector3.Lerp(startPosition, targetPosition, 0.5f);
        handlePosition.y += 5;

        float distance = (startPosition - targetPosition).magnitude;
        float duration = distance / jumpSpeed;

        for (float f = 0; f < 1; f += Time.deltaTime / duration)
        {
            transform.position = Vector3.Lerp(
                Vector3.Lerp(
                    startPosition,
                    handlePosition,
                    f),
                Vector3.Lerp(
                    handlePosition,
                    targetPosition,
                    f),
                f);

            yield return null;
        }

        /*        float interpolateValue = 0;

                while (interpolateValue < 1)
                {
                    float duration;

                    if (interpolateValue < 0.5f)
                        duration = distance / jumpSpeed;
                    else
                        duration = distance / dropSpeed;

                    interpolateValue += Time.deltaTime / duration;
                    transform.position = Vector3.Lerp(
                    Vector3.Lerp(startPosition, handlePosition, interpolateValue),
                    Vector3.Lerp(handlePosition, targetPosition, interpolateValue),
                    interpolateValue);

                    yield return null;
                }*/

    }
}
