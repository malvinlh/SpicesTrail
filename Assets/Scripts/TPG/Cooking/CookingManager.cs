using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// to control how the whole cooking scene works
// the scene will have 4 slides of images 
// the first slide will be the ingredients
// the second slide will be how to cook the ingredients
// the third slide will be the cooking process
// the fourth will be the final result of the cooking 
public class CookingManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private CookingSlidebar cookingSlidebar;
    [SerializeField] private List<Image> slides = new List<Image>();
    [SerializeField] private int currentSlide = 0;
    [SerializeField] private Button buttonNext;


    // Start is called before the first frame update
    void Start()
    {
        cookingSlidebar = slider.GetComponent<CookingSlidebar>();
        if (slides.Count == 0 || buttonNext == null || cookingSlidebar == null)
        {
            Debug.LogError("Slides, Button, or CookingSlidebar is not properly assigned.");
            return;
        }

        // Ensure only the first slide is visible at the start
        UpdateSlidesVisibility();

        // Add listener for the button
        buttonNext.onClick.AddListener(OnNextButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnNextButtonClicked()
    {
        if (currentSlide < slides.Count - 1)
        {
            currentSlide++;
            UpdateSlidesVisibility();

            // Start cooking when reaching the cooking slide
            if (currentSlide == 2)
            {
                buttonNext.gameObject.SetActive(false);
                StartCooking();
            }
        }
    }

    private void UpdateSlidesVisibility()
    {
        for (int i = 0; i < slides.Count; i++)
        {
            slides[i].gameObject.SetActive(i == currentSlide);
        }
    }

    private void StartCooking()
    {
        if (cookingSlidebar != null)
        {
            cookingSlidebar.gameObject.SetActive(true);
            Debug.Log("Cooking started!");
        }
    }

    public void FinishCooking()
    {
        cookingSlidebar.gameObject.SetActive(false);
        cookingSlidebar.IsCooking = false;
        Debug.Log("Cooking finished! Proceeding to the next slide.");
        OnNextButtonClicked(); // Automatically go to the next slide after cooking
    }

}
