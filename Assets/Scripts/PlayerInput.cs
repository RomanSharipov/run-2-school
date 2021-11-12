using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction TriedClimbStairs;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TriedClimbStairs?.Invoke();
        }
    }
}
