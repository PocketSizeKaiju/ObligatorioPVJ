using UnityEngine;
using TMPro;

public class StepsForTrailer : MonoBehaviour
{
    [Header("Panels de cada Paso")]
    public GameObject[] steps;

    [Header("Referencias del Jugador")]
    public MonoBehaviour movementScript;
    public MonoBehaviour shootScript;
    // Agregamos esta referencia para saber si el objeto entero desapareció
    public GameObject playerObject; 

    [Header("Objetos de Escena")]
    public GameObject enemy;

    private int _currentStep = 0;
    private bool _playerWasDead = false;

    void Start()
    {
        UpdateStepVisibility();
    }

    void Update()
    {
        // MONITOREO DEL JUGADOR:
        // Si el objeto del jugador se desactiva (porque murió) y estábamos en el paso de acción
        if (playerObject != null && !playerObject.activeInHierarchy && !_playerWasDead)
        {
            if (_currentStep == 2) // Solo si estamos en la parte de combate
            {
                HandlePlayerDeath();
            }
        }
    }

    public void NextStep()
    {
        Debug.Log("EL BOTON FUNCIONA");
        _currentStep++;
        _playerWasDead = false; // Reseteamos el estado por si revivió
        UpdateStepVisibility();
    }

    private void HandlePlayerDeath()
    {
        _playerWasDead = true;
        Debug.Log("Trailer detectó muerte: Desactivando todo.");
        
        
        if(movementScript) movementScript.enabled = false;
        if(shootScript) shootScript.enabled = false;
        if(enemy) enemy.SetActive(false);
        
        // RECUPERAR CURSOR: Por si los scripts del jugador lo habían ocultado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartTrailer()
    {
        _currentStep = 0;
        _playerWasDead = false;
        if(playerObject) playerObject.SetActive(true); // Intentamos reactivarlo
        UpdateStepVisibility();
    }

    private void UpdateStepVisibility()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            if(steps[i] != null)
                steps[i].SetActive(i == _currentStep);
        }

        switch (_currentStep)
        {
            case 0:
                if(movementScript) movementScript.enabled = false;
                if(shootScript) shootScript.enabled = false;
                if(enemy) enemy.SetActive(false);
                break;

            case 1: 
                if(movementScript) movementScript.enabled = true;
                if(shootScript) shootScript.enabled = true;
                break;

            case 2: 
                if(movementScript) movementScript.enabled = true;
                if(shootScript) shootScript.enabled = true;
                if(enemy) enemy.SetActive(true);
                break;

            case 3: 
                // Final del trailer: desactivamos acción
                if(movementScript) movementScript.enabled = false;
                if(shootScript) shootScript.enabled = false;
                if(enemy) enemy.SetActive(false);
                break;
        }
    }
}