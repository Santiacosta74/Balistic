using UnityEngine;

public class BallImpact : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        FixedJoint joint = collision.gameObject.GetComponent<FixedJoint>();
        if (joint != null)
        {
            Destroy(joint);
        }
    }
}
