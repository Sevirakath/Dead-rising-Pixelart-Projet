using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Caster : MonoBehaviour
{
    
    [SerializeField] private Spell[] spellPrefabs;
    [SerializeField] private float castDelay = 0.5f;
    [SerializeField] private Transform castPosition;

    private Spell currentSpell;

    private Camera cam;
    private float currentCastTime;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        currentSpell = spellPrefabs[0];
    }

    // Update is called once per frame
    void Update()
    {
        currentCastTime += Time.deltaTime;
        
        if (Mouse.current.leftButton.isPressed && currentCastTime > castDelay)
        {
            currentCastTime = 0;
            CastSpell();
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame) currentSpell = spellPrefabs[0];
        if (Keyboard.current.digit2Key.wasPressedThisFrame) currentSpell = spellPrefabs[1];
        if (Keyboard.current.digit3Key.wasPressedThisFrame) currentSpell = spellPrefabs[2];
    }

    private void CastSpell()
    {
        Instantiate(currentSpell, castPosition.position, castPosition.rotation);
    }
}
