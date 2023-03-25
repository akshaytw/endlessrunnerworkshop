using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftBoundary;
    [SerializeField] private float rightBoundary;
    [SerializeField] private AudioSource playerAS;

    // Used to prevent the player from moving again while a movement coroutine is already in progress.
    private bool isMoving;

    private void Update()
    {
#if UNITY_EDITOR
        if (isMoving) return;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
#endif
    }

    public void MoveLeft()
    {
        if (transform.position.x > leftBoundary)
            StartCoroutine(MovePlayer(Vector2.left));
    }

    public void MoveRight()
    {
        if (transform.position.x < rightBoundary)
            StartCoroutine(MovePlayer(Vector2.right));
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        playerAS.Play();
        var elapsedTime = 0f;
        var duration = 1f / moveSpeed;
        Vector3 startingPosition = transform.position;
        var targetPosition = startingPosition + direction;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            //   Time.deltaTime to ensure that the movement is smooth and consistent across different frame rates.
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}