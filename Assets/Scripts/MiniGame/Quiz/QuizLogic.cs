using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLogic : MonoBehaviour
{
    [SerializeField] private List<Question> allQuestions = new List<Question>();
    private List<Question> quizQuestions = new List<Question>();
    private int currentIndex = 0;
    private Question currentQuestion;

    private const int QUIZ_COUNT = 5;
    private int score = 0;
    public bool HasMoreQuestions => currentIndex < quizQuestions.Count;
        
    void Awake()
    {
        PrepareQuiz();
    }

    public void PrepareQuiz()
    {
        ShuffleQuestions();

        int count = Mathf.Min(QUIZ_COUNT, allQuestions.Count);
        quizQuestions = allQuestions.GetRange(0, count);
        currentIndex = 0;
    }
    public Question GetNextQuestion()
    {
        if (!HasMoreQuestions)
        {
            return null;
        }
        currentQuestion = quizQuestions[currentIndex];
        currentIndex++;
        return currentQuestion;
    }

    public bool CheckAnswer(int index)
    {
        bool isCorrect = (index == currentQuestion.GetCorrectAnswerIndex());
        if (isCorrect)
        {
            score += 10;
        }
        return isCorrect;
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < allQuestions.Count - 1; i++)
        {
            int rand = Random.Range(i, allQuestions.Count);
            (allQuestions[i], allQuestions[rand]) = (allQuestions[rand], allQuestions[i]);
        }
    }    

    public int GetScore() => score;
}
