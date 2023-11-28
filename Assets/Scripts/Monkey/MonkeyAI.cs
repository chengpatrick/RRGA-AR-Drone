using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum MonkeyState
{
    Idle, Jump, Fly, Disappear
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

    [SerializeField]
    Animator AC_Monki;

    private void Start()
    {

    }

    private void OnEnable()
    {
        if (!getPlayerPosition)
        {
            monkeyState = MonkeyState.Idle;

            // get player position
            if (MonkeySpawnManager.Instance.testInDroneSimulator)
                playerPosition = MonkeySpawnManager.Instance.PlayerTransform.position;
            else
                playerPosition = Camera.main.transform.position;

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

            case MonkeyState.Jump:
                JumpAction();
                JumpTransition();
                break;

            case MonkeyState.Fly:
                FlyAction();
                FlyTransition();
                break;

            case MonkeyState.Disappear:
                DisappearAction();
                break;
        }
    }

    void IdleAction() { }

    void IdleTransition()
    {
        monkeyState = MonkeyState.Jump;
    }

    private void JumpAction()
    {
        AC_Monki.enabled = true;
        transform.LookAt(playerPosition);
    }

    private void JumpTransition()
    {
        StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(0.7f); 
        monkeyState = MonkeyState.Fly;
    }

    private void FlyAction()
    {
        // Monkey looks at the player
        //transform.LookAt(playerPosition);
        StartCoroutine(JumpToTarget(playerPosition));

/*        // Monkey moves to the player
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);*/
    }

    private void FlyTransition()
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
