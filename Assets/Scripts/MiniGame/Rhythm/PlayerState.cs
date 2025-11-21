using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private Image image;
    private Sprite idleSprite;

    [SerializeField] Sprite bloomingSprite;
    [SerializeField] Sprite bloomSprite;
    [SerializeField] private float bloomDuration = 0.15f;

    private bool playBloomOnce = false;
    private float bloomTimer = 0f;


    private bool useCameraDetection = false; //나중에 카메라 연결 시
    public bool isSmiling;

    void Start()
    {
        image = GetComponent<Image>();
        idleSprite = image.sprite;
    }

    void Update()
    {
        isSmiling = CheckSmile();

        if (playBloomOnce)
        {
            bloomTimer += Time.deltaTime;
            image.sprite = bloomSprite;

            if (bloomTimer >= bloomDuration)
            {
                playBloomOnce = false;
            }
            return;
        }

        if (isSmiling)
            image.sprite = bloomingSprite;
        else
            image.sprite = idleSprite;
    }

    public void PlayBloom()
    {
        playBloomOnce = true;
        bloomTimer = 0f;
    }    

    bool CheckSmile()
    {
        if (useCameraDetection)
            return false;
            //return FaceDetector.IsSmiling(); // 추후 표정 인식 이용
        else
        {
            // PC
            if (Input.GetMouseButton(0))
                return true;

            // 모바일
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began || 
                    touch.phase == TouchPhase.Moved || 
                    touch.phase == TouchPhase.Stationary)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
