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

    


    public Player player;

    [SerializeField] private Image _fillImage;

    void Start()
    {
        // Инициализация таймера
        player = FindAnyObjectByType<Player>();
        _fillImage = FindAnyObjectByType<FillingQTE>().GetComponent<Image>();
    }

    void Update()
    {   

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
        }
        if(incorrectPressCount >= 5) //поражение
        {
            isHoldingPlayer = false;
            incorrectPressCount = 0;
            Debug.Log("вас заразили");
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

