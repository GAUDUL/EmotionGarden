using System.Collections.Generic;
using UnityEngine;
using Mediapipe;
using Google.Protobuf;

public class SmileDetector : MonoBehaviour
{
    public bool isSmiling;
    public float smileScore;  // debug ��

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
        var C = face.Landmark[0];   // mid/lip center reference (�� �߽�)
        // ����
        var leftCheek = face.Landmark[234];
        var rightCheek = face.Landmark[454];

        // 3) ���� ���
        float leftCheekLift = C.Y - leftCheek.Y;
        float rightCheekLift = C.Y - rightCheek.Y;
        float cheekScore = (leftCheekLift + rightCheekLift) * 5f;  // 0.0~0.3

        // 1) �� �� (�¿�)
        float width = Mathf.Abs(R.X - L.X);
        float height = Mathf.Abs(T.Y - B.Y);
        float stretchScore = width / height;

        // 2) �Բ��� �ö� ����
        float leftLift = C.Y - L.Y;
        float rightLift = C.Y - R.Y;
        float liftScore = (leftLift + rightLift) * 5f;  // ����ġ

        // 3) ����
        float smileScore = stretchScore + liftScore + cheekScore;

        isSmiling = smileScore > 3.0f;
    }
}
