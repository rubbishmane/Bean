using UnityEngine;

public class BoostTester : MonoBehaviour
{
    public TestHerion testHerion;

    void Update()
    {
        // Press "S" to activate the speed boost
        if (Input.GetKeyDown(KeyCode.F))
        {
            testHerion.ApplySpeedBoost();
        }

        // Press "H" to activate the health boost
        if (Input.GetKeyDown(KeyCode.H))
        {
            testHerion.ApplyHealthBoost();
        }

        // Press "B" to activate both boosts
        if (Input.GetKeyDown(KeyCode.B))
        {
            testHerion.ApplyBothBoosts();
        }
    }
}
