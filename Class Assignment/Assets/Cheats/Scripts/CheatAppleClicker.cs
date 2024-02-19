using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CheatAppleClicker : MonoBehaviour
{
    public int allVitaminsGained;
    public int _vitamins;
    public int vitaminsPerClick = 1;

    public int apples;
    public int strawberries;
    public int lemons;

    public int applePrice;
    public int strawberryPrice;
    public int lemonPrice;

    public int vitaminsPerStrawberry;
    public int vitaminsPerLemon;
    public TextMeshProUGUI vitaminCountText;

    public TextMeshProUGUI gameProgressText;
    public Slider gameProgressSlider;

    [Header("Apples")]
    public Button buyAppleButton;
    public Button buyStrawberryButton;
    public Button buyLemonButton;
    [Header("Strawberries")]
    public TextMeshProUGUI numberOfApplesText;
    public TextMeshProUGUI numberOfStrawberriesText;
    public TextMeshProUGUI numberOfLemonsText;
    [Header("Lemons")]
    public TextMeshProUGUI costOfApplesText;
    public TextMeshProUGUI costOfStrawberriesText;
    public TextMeshProUGUI costOfLemonsText;




    private void Start()
    {
        buyAppleButton.onClick.AddListener(() => BuyApple());
        buyStrawberryButton.onClick.AddListener(() => BuyStrawberries());
        buyLemonButton.onClick.AddListener(() => BuyLemons());
        StartCoroutine(GetVitaminsEverySecond());

        Vitamins = 0;
    }

    public int Vitamins
    {
        get
        {
            return _vitamins;
        }
        set
        {
            //Calculate how much vitamins have been added and add it to total vitamins gained
            int difference = value - _vitamins;
            if (difference > 0)
                allVitaminsGained += difference;

            _vitamins = value;
            vitaminCountText.text = "" + _vitamins;
            UpdateUI();
        }
    }

    IEnumerator GetVitaminsEverySecond()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(1);
            Vitamins += strawberries * vitaminsPerStrawberry;
            Vitamins += lemons * vitaminsPerLemon;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    void UpdateUI()
    {
        gameProgressSlider.value = allVitaminsGained;
        gameProgressText.text = gameProgressSlider.value + "/" + gameProgressSlider.maxValue;

        numberOfApplesText.text = "" + apples;
        numberOfStrawberriesText.text = "" + strawberries;
        numberOfLemonsText.text = "" + lemons;

        costOfApplesText.text = "" + applePrice;
        costOfStrawberriesText.text = "" + strawberryPrice;
        costOfLemonsText.text = "" + lemonPrice;

        buyAppleButton.interactable = Vitamins >= applePrice;
        buyStrawberryButton.interactable = Vitamins >= strawberryPrice;
        buyLemonButton.interactable = Vitamins >= lemonPrice;
    }

    public void ClickApple()
    {
        //Apple pressed, do stuff
        Vitamins += vitaminsPerClick;
    }
    public void BuyApple()
    {
        Vitamins -= applePrice;
        apples++;
        vitaminsPerClick++;
        applePrice *= 2;
        UpdateUI();
    }
    public void BuyStrawberries()
    {
        Vitamins -= strawberryPrice;
        strawberries++;
        strawberryPrice *= 2;
        UpdateUI();
    }
    public void BuyLemons()
    {
        Vitamins -= lemonPrice;
        lemons++;
        lemonPrice *= 2;
        UpdateUI();
    }
}