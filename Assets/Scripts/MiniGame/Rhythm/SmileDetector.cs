using System.Collections.Generic;
using UnityEngine;
using Mediapipe;
using Google.Protobuf;

public class SmileDetector : MonoBehaviour
{
    public bool isSmiling;
    public float smileScore;  // debug ¿ë

    public void Check(List<NormalizedLandmarkList> faces)
    {
        if (faces == null || faces.Count == 0)
        {
            isSmiling = false;
            return;
        }

        var face = faces[0];

        var L = face.Landmark[61];
        var R = face.Landmark[291];
        var T = face.Landmark[13];  // top lip
        var B = face.Landmark[14];  // bottom lip
        var C = face.Landmark[0];   // mid/lip center reference (¾ó±¼ Áß½É)
        // ±¤´ë
        var leftCheek = face.Landmark[234];
        var rightCheek = face.Landmark[454];

        // 3) ±¤´ë »ó½Â
        float leftCheekLift = C.Y - leftCheek.Y;
        float rightCheekLift = C.Y - rightCheek.Y;
        float cheekScore = (leftCheekLift + rightCheekLift) * 5f;  // 0.0~0.3

        // 1) ÀÔ Æø (ÁÂ¿ì)
        float width = Mathf.Abs(R.X - L.X);
        float height = Mathf.Abs(T.Y - B.Y);
        float stretchScore = width / height;

        // 2) ÀÔ²¿¸® ¿Ã¶ó°£ Á¤µµ
        float leftLift = C.Y - L.Y;
        float rightLift = C.Y - R.Y;
        float liftScore = (leftLift + rightLift) * 5f;  // °¡ÁßÄ¡

        // 3) ÃÖÁ¾
        float smileScore = stretchScore + liftScore + cheekScore;

        isSmiling = smileScore > 2.5f;
    }
}
