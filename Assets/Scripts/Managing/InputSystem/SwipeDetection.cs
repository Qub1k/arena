using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private SpecialAttacks attacks;
    [SerializeField] private float minSwipeLength;
    [SerializeField] private float requiredCurvature;

    private List<Vector2> positions = new List<Vector2>();
    private Vector3 initialPosition;
    public bool isSwipeActive;

    private void Start(){
        PlayerInputManager.Instance.InputActions.Player.MousePosition.performed += OnTouchPositionChanged;
    }
    private void OnDisable(){
        PlayerInputManager.Instance.InputActions.Player.MousePosition.performed -= OnTouchPositionChanged;
    }
    private void OnTouchPositionChanged(InputAction.CallbackContext context){
        Vector2 touchPos = Mouse.current.position.ReadValue();

        if (Mouse.current.leftButton.isPressed)
        {
            if (!isSwipeActive)
            {
                StartSwipe(touchPos);
            }

            positions.Add(touchPos);
        }
        else if (isSwipeActive)
        {
            EndSwipe();
        }
    }
    private void StartSwipe(Vector2 touchPosition){
        isSwipeActive = true;
        initialPosition = touchPosition;
        positions.Clear();
        positions.Add(initialPosition);
    }
    private void EndSwipe(){
        if(positions.Count > 2 && Vector2.Distance(positions[^1], initialPosition) >= minSwipeLength){
            if(isCurved(positions)){
                StartCoroutine(attacks.HandleUppercut());
            }
            else{
                Debug.Log("Straight line is drawn");
            }
        }
        isSwipeActive=false;
    }

    private bool isCurved(List<Vector2> positions){
        float totalDeviation = 0f;

        Vector2 start = positions[0];
        Vector2 end = positions[^1];
        Vector2 direction = (end - start).normalized;

        for(int i = 0; i < positions.Count; i++){
            Vector2 toPoint = positions[i] - start;
            float dotProduct = Vector2.Dot(toPoint.normalized, direction);

            float deviation = Mathf.Sqrt(1 - dotProduct*dotProduct) * toPoint.magnitude;

            totalDeviation += deviation;
        }
        float averageDeviation = totalDeviation / positions.Count;
        return averageDeviation > requiredCurvature;
    }
}
