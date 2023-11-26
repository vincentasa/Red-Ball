
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothness;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        var pos = target.position;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos,smoothness * Time.deltaTime);
    }
}
