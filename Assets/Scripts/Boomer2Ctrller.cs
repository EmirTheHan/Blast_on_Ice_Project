using UnityEngine;
using UnityEngine.AI;

public class Boomer2Ctrller : MonoBehaviour
{
    private bool isMoving = false;
    public GameObject ball;
    public NavMeshAgent Boomer;
    public Transform Player1, self;
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("P1"))
        {
            if (ball.activeSelf)
            {
                isMoving=true;
                Boomer.SetDestination(Player1.position);
            }
            else if(isMoving)
            {
                isMoving=false;
                Boomer.SetDestination(self.position);
            }
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("P1"))
        {
            isMoving = false;
            Boomer.SetDestination(self.position);
        }
    }
}
