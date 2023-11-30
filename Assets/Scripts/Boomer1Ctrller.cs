using UnityEngine;
using UnityEngine.AI;

public class Boomer1Ctrller : MonoBehaviour
{
    private bool isMoving = false;
    public GameObject ball;
    public NavMeshAgent Boomer;
    public Transform Player2, self;
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("P2"))
        {
            if (ball.activeSelf)
            {
                isMoving = true;
                Boomer.SetDestination(Player2.position);
            }
            else if (isMoving)
            {
                isMoving = false;
                Boomer.SetDestination(self.position);
            }
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("P2"))
        {
            isMoving = false;
            Boomer.SetDestination(self.position);
        }
    }
}
