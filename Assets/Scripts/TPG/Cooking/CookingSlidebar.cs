using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For the Slider and Button components
using UnityEngine.EventSystems; // For Pointer events

public class CookingSlidebar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button button;
    [SerializeField] private CookingManager cookingManager;
    [SerializeField] private float targetTime = 10f;
    [SerializeField] private float cookingSpeed = 0.1f;
    [SerializeField] private float cookingSpeedIncrement = 0.1f;
    [SerializeField] private float cookingSpeedMax = 0.5f;
    [SerializeField] private float cookingSpeedMin = 0.1f;
    [SerializeField] private float cookingSpeedIntervalMin = 0.4f;
    [SerializeField] private float cookingSpeedIntervalMax = 0.6f;

    private bool isCooking = false;
    private bool firstClick = false;
    private float elapsedTime = 0f;
    private bool isMouseDown = false;
    private float middleMin;
    private float middleMax;

    public bool IsMouseDown
    {
        get { return isMouseDown; }
        set { isMouseDown = value; }
    }

    public bool IsCooking
    {
        get { return isCooking; }
        set { isCooking = value; }
    }

    void Start()
    {
        if (slider == null || button == null || cookingManager == null)
        {
            Debug.LogError("Slider, Button, or CookingManager is not assigned!");
            return;
        }

        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = 0.5f;

        // Define the middle range of the slider where progress counts
        middleMin = cookingSpeedIntervalMin;
        middleMax = cookingSpeedIntervalMax;

        // Ensure the button has an EventTrigger component
        EventTrigger eventTrigger = button.gameObject.AddComponent<EventTrigger>();

        // Add listener for button hold (OnPointerDown)
        EventTrigger.Entry pointerDown = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        pointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerDown);

        // Add listener for button release (OnPointerUp)
        EventTrigger.Entry pointerUp = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        pointerUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        eventTrigger.triggers.Add(pointerUp);
    }

    void Update()
    {
        if (slider == null)
            return;

        // Automatically increment the slider
        if (!isMouseDown)
        {
            if(firstClick)
                slider.value += cookingSpeed * Time.deltaTime;
        }
        else
        {
            // Decrease slider value when the player holds the button
            slider.value -= cookingSpeed * Time.deltaTime;
        }

        // Clamp slider value between 0 and 1
        slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);

        // Check if the slider is in the "middle" range
        if (slider.value >= middleMin && slider.value <= middleMax)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime -= Time.deltaTime;
        }

        elapsedTime = Mathf.Clamp(elapsedTime, 0, targetTime);

        // Optionally, increase cooking speed over time
        cookingSpeed = Mathf.Clamp(cookingSpeed + cookingSpeedIncrement * Time.deltaTime, cookingSpeedMin, cookingSpeedMax);

        // Debugging output
        Debug.Log("Elapsed Time: " + elapsedTime);

        // Check if cooking is complete
        if (elapsedTime >= targetTime)
        {
            isCooking = false;
            elapsedTime = 0f;
            cookingManager.FinishCooking();
            Debug.Log("Cooking complete!");
        }
    }

    public void StartCooking()
    {
        isCooking = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        firstClick = true;
        isMouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false;
    }
}
