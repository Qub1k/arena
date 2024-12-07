using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Infected : MonoBehaviour
{

    
    
    
    
    public float speed = 3f; // Скорость движения врага
    public float stoppingDistance = 1f; // Расстояние, на котором враг перестает двигаться


    //QTE
    public Image icon; // Иконка, которая будет отображаться
    public Sprite[] buttonIcons; // Массив с иконками кнопок WASD

    public int correctPressCount = 0;
    
    public int incorrectPressCount = 0;
    private string currentButton = "";


    public bool isHoldingPlayer; // Переменная, которая указывает, держит ли враг игрока


    private float currentTime = 0;

    public float holdTime = 1;

    
    private float deltaTime;
    private int numberOfClicks = 0;
    [SerializeField] private float expectedCPS = 6;
    private float timePassed = 0;
    float portionOfElement = 0;


    


    public Player player;

    [SerializeField] private Image _fillImage;
    [SerializeField] private Image _armanImage;


    void Start()
    {
        // Инициализация таймера

    }

    void Update()
    {   
        ClickQTE();

        // Проверяем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > stoppingDistance) //продолжает идти
        {
            isHoldingPlayer = false;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

        }
        else //станит игрока
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            isHoldingPlayer = true;
            
        }

        if (correctPressCount >= 3) //победа
        {
            
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //Destroy(gameObject);
            isHoldingPlayer = false;
            incorrectPressCount = 0;
            Debug.Log("win");
            _fillImage.fillAmount = 0;
            Destroy(gameObject);
        }
        if(incorrectPressCount >= 5) //поражение
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            isHoldingPlayer = false;
            incorrectPressCount = 0;
            Debug.Log("вас заразили");
            Destroy(gameObject);    
        }

        
        



        if(isHoldingPlayer) 
        {
            // Проверяем нажатие клавиши
            if (Input.GetKeyDown(KeyCode.W) && currentButton == "W" ||
                Input.GetKeyDown(KeyCode.A) && currentButton == "A" ||
                Input.GetKeyDown(KeyCode.S) && currentButton == "S" ||
                Input.GetKeyDown(KeyCode.D) && currentButton == "D")
            { 
            currentTime = 0;
            _fillImage.fillAmount = currentTime/holdTime;
            correctPressCount++;
            QTEButtonInit();
            }

            currentTime += Time.deltaTime;

            _fillImage.fillAmount = currentTime/holdTime;
            if(currentTime >= holdTime)
            {
                
                currentTime = 0;
                _fillImage.fillAmount = currentTime/holdTime;
                incorrectPressCount++;
                QTEButtonInit();
            }
        
        }
        
    }

    private void ClickQTE(){
        timePassed += Time.deltaTime;
        float currentCPS = numberOfClicks / timePassed;
        portionOfElement = currentCPS / expectedCPS;

        Debug.Log(currentCPS);
        if (Input.GetKeyDown(KeyCode.Y)){
            numberOfClicks += 1;
        }

        if (timePassed >= 3){
            timePassed = 1;
            numberOfClicks = System.Convert.ToInt32(timePassed * currentCPS);
        }

        _armanImage.fillAmount = portionOfElement;

    }


    void QTEButtonInit() //инициализируется и отображается рандомная кнопка
    {
        // Выбираем случайную кнопку для отображения
        int randomIndex = Random.Range(0, buttonIcons.Length);
        icon.sprite = buttonIcons[randomIndex]; 

        // Определяем, какая кнопка отображается
        switch (randomIndex)
        {
            case 0:
                currentButton = "W";
                break;
            case 1:
                currentButton = "A";
                break;
            case 2:
                currentButton = "S";
                break;
            case 3:
                currentButton = "D";
                break;
        }

        // Активируем иконку на UI
        icon.gameObject.SetActive(true);
    }


}

