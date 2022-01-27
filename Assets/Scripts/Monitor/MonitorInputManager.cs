using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.SceneController;
using UnityEngine.SceneManagement;
namespace CoffeeCoffee.Monitor
{
    public class MonitorInputManager : MonoBehaviour
    {
        const string BUTTON = "Button";
        const float LEVEL_CHANGE_DELAY = 1f;

        List<MonitorButton> monitorButtons = new List<MonitorButton>();
        OrderDictionary orderDictionary = new OrderDictionary();
        Order playerOrder;
        GameManager gameManager;
        levelChanger levelChanger;
        WaitForSeconds changeLevelWaitTimer;

        string playerInputSize;
        string playerInputFlavor;
        string playerInputMilk;
        string playerInputEsspresso;
        string playerInputBeverage;
        string playerInputTemperature;
        string playerInputShot;

        private void Awake()
        {
            GameObject[] objByTags = FindInActiveObjectsByTag(BUTTON);
            foreach (GameObject button in objByTags)
            {
                MonitorButton tempButton;
                tempButton = button.GetComponent<MonitorButton>();
                monitorButtons.Add(tempButton);
            }

            changeLevelWaitTimer = new WaitForSeconds(LEVEL_CHANGE_DELAY);
        }
        GameObject[] FindInActiveObjectsByTag(string tag)
        {
            List<GameObject> validTransforms = new List<GameObject>();
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].gameObject.CompareTag(tag))
                    {
                        validTransforms.Add(objs[i].gameObject);
                    }
                }
            }
            return validTransforms.ToArray();
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
        }
        public void CustomerPayment()
        {
            //gameobjects string name references
            const string SMALL = "SmallSizeButton";
            const string MEDIUM = "MediumSizeButton";
            const string LARGE = "LargeSizeButton";
            const string SINGLE = "SingleButton";
            const string DOUBLE = "DoubleButton";
            const string TRIPLE = "TripleButton";
            const string REGUALR = "RegularButton";
            const string DECAF = "DecafButton";
            const string BLONDE = "BlondeButton";
            const string LATTE = "LatteButton";
            const string CAPPUCHINO = "CappuchinoButton";
            const string AMERICANO = "AmericanoButton";
            const string WARM = "WarmButton";
            const string EXTRA_HOT = "ExtraHotButton";
            const string REGULAR_TEMP = "RegularTemp";
            const string TWO_PERCENT = "TwoPercentButton";
            const string WHOLE = "WholeMilkButton";
            const string NONFAT = "NonfatButton";
            const string VANILLA = "VanillaButton";
            const string CARAMEL = "CaramelButton";
            const string HAZELNUT = "HazelnutButton";
            const string MOCHA = "MochaButton";
            const string CLASSIC = "ClassicButton";

            GetButtonPressedInfo(SMALL, MEDIUM, LARGE, SINGLE, DOUBLE, TRIPLE, REGUALR, DECAF, BLONDE, LATTE, CAPPUCHINO, AMERICANO, WARM, EXTRA_HOT, REGULAR_TEMP, TWO_PERCENT, WHOLE, NONFAT, VANILLA, CARAMEL, HAZELNUT, MOCHA, CLASSIC);
            CreateDefaultDataIfNecessary();
            CreateOrder();
            gameManager.peoples = null;
            ChangeSceneToSyrupStation();
        }

        private void GetButtonPressedInfo(string SMALL, string MEDIUM, string LARGE, string SINGLE, string DOUBLE, string TRIPLE, string REGUALR, string DECAF, string BLONDE, string LATTE, string CAPPUCHINO, string AMERICANO, string WARM, string EXTRA_HOT, string REGULAR_TEMP, string TWO_PERCENT, string WHOLE, string NONFAT, string VANILLA, string CARAMEL, string HAZELNUT, string MOCHA, string CLASSIC)
        {
            foreach (MonitorButton mB in monitorButtons)
            {

                if (mB.buttonType == MonitorButton.ButtonType.beverageButton && mB.isPressed)
                {
                    if (mB.gameObject.name == LATTE)
                    {
                        playerInputBeverage = orderDictionary.beverages[0];
                    }
                    if (mB.gameObject.name == CAPPUCHINO)
                    {
                        playerInputBeverage = orderDictionary.beverages[1];
                    }
                    if (mB.gameObject.name == AMERICANO)
                    {
                        playerInputBeverage = orderDictionary.beverages[2];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.espressoButton && mB.isPressed)
                {
                    if (mB.gameObject.name == REGUALR)
                    {
                        playerInputEsspresso = orderDictionary.esspressos[0];
                    }
                    if (mB.gameObject.name == BLONDE)
                    {
                        playerInputEsspresso = orderDictionary.esspressos[1];
                    }
                    if (mB.gameObject.name == DECAF)
                    {
                        playerInputEsspresso = orderDictionary.esspressos[2];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.milkButton && mB.isPressed)
                {
                    if (mB.gameObject.name == TWO_PERCENT)
                    {
                        playerInputMilk = orderDictionary.milks[0];
                    }
                    if (mB.gameObject.name == NONFAT)
                    {
                        playerInputMilk = orderDictionary.milks[1];
                    }
                    if (mB.gameObject.name == WHOLE)
                    {
                        playerInputMilk = orderDictionary.milks[2];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.shotButton && mB.isPressed)
                {
                    if (mB.gameObject.name == SINGLE)
                    {
                        playerInputShot = orderDictionary.shots[0];
                    }
                    if (mB.gameObject.name == DOUBLE)
                    {
                        playerInputShot = orderDictionary.shots[1];
                    }
                    if (mB.gameObject.name == TRIPLE)
                    {
                        playerInputShot = orderDictionary.shots[2];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.sizeButton && mB.isPressed)
                {
                    if (mB.gameObject.name == SMALL)
                    {
                        playerInputSize = orderDictionary.sizes[0];
                    }
                    else if (mB.gameObject.name == MEDIUM)
                    {
                        playerInputSize = orderDictionary.sizes[1];
                    }
                    else if (mB.gameObject.name == LARGE)
                    {
                        playerInputSize = orderDictionary.sizes[2];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.syrupButton && mB.isPressed)
                {
                    if (mB.gameObject.name == VANILLA)
                    {
                        playerInputFlavor = orderDictionary.flavors[0];
                    }
                    if (mB.gameObject.name == CARAMEL)
                    {
                        playerInputFlavor = orderDictionary.flavors[1];
                    }
                    if (mB.gameObject.name == HAZELNUT)
                    {
                        playerInputFlavor = orderDictionary.flavors[2];
                    }
                    if (mB.gameObject.name == CLASSIC)
                    {
                        playerInputFlavor = orderDictionary.flavors[3];
                    }
                    if (mB.gameObject.name == MOCHA)
                    {
                        playerInputFlavor = orderDictionary.flavors[4];
                    }
                }
                else if (mB.buttonType == MonitorButton.ButtonType.temperatureButton && mB.isPressed)
                {
                    if (mB.gameObject.name == WARM)
                    {
                        playerInputTemperature = orderDictionary.temperatures[1];
                    }
                    if (mB.gameObject.name == REGULAR_TEMP)
                    {
                        playerInputTemperature = orderDictionary.temperatures[0];
                    }
                    if (mB.gameObject.name == EXTRA_HOT)
                    {
                        playerInputTemperature = orderDictionary.temperatures[2];
                    }
                }
            }
        }

        private void CreateDefaultDataIfNecessary()
        {
            if (playerInputSize == null)
            {
                playerInputSize = orderDictionary.sizes[0];
            }
            if (playerInputFlavor == null)
            {
                playerInputFlavor = orderDictionary.flavors[0];
            }
            if (playerInputMilk == null)
            {
                playerInputMilk = orderDictionary.milks[0];
            }
            if (playerInputEsspresso == null)
            {
                playerInputEsspresso = orderDictionary.esspressos[0];
            }
            if (playerInputBeverage == null)
            {
                playerInputBeverage = orderDictionary.beverages[0];
            }
            if (playerInputTemperature == null)
            {
                playerInputTemperature = orderDictionary.temperatures[0];
            }
            if (playerInputShot == null)
            {
                playerInputShot = orderDictionary.shots[0];
            }
        }

        private void CreateOrder()
        {
            playerOrder = new Order(playerInputSize, playerInputShot, playerInputEsspresso,
            playerInputFlavor, playerInputBeverage, playerInputMilk, playerInputTemperature);
            gameManager.playerInputedOrder = GetPlayerCreatedOrder();
        }
        private void ChangeSceneToSyrupStation()
        {
            int syrups = 4;
            StartCoroutine(SceneChangeDelay(syrups));
        }

        IEnumerator SceneChangeDelay(int buildIndex)
        {
            yield return changeLevelWaitTimer;
            SceneManager.LoadScene(buildIndex);
        }
        
        public Order GetPlayerCreatedOrder()
        {
            return playerOrder.GetOrder();
        }

    }
}
