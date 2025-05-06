using System.Collections;
using UnityEngine;

public class TankBuffManager : MonoBehaviour
{
    public void ApplyBuff(IEnumerator buffRoutine)
    {
        StartCoroutine(buffRoutine);
    }
}
