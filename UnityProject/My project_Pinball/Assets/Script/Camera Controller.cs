using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float lenght;
    public Transform target;
    private Vector3 defaultPosition;

    public bool hasTarget { get { return target != null; } }

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    public void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * lenght);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    // Ini adalah metode FollowTarget yang benar, tidak perlu mendeklarasikan lagi
    public void FollowTarget(Transform targetTransform, float lenght)
    {
        target = targetTransform;
        Debug.Log("Camera now following: " + target.name);
    }

    public void GobackToDefault()
    {
        target = null;

        //gerakan ke posisi default
        StartCoroutine(MovePosition(defaultPosition, 5));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            // pindahkan posisi camera secara tertutup
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}