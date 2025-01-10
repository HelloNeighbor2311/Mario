using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public CharacterBase character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            character.groundCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null) {
            character.groundCheck = false;
        }
    }
}
