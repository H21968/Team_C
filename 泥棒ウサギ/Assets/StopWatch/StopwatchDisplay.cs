using UnityEngine;

using TMPro;

public class StopwatchDisplay : MonoBehaviour

{

    public TextMeshProUGUI timeText;  // �\������e�L�X�g

    private float elapsedTime = 0f;   // �o�ߎ��ԁi�b�j

    private bool isRunning = true;    // ���쒆���ǂ���

    void Update()

    {

        if (isRunning)

        {

            // �o�ߎ��Ԃ𑝂₷

            elapsedTime += Time.deltaTime;

            // ���E�b�E�~���b�ɕ�����

            int minutes = (int)(elapsedTime / 60);

            int seconds = (int)(elapsedTime % 60);

            int milliseconds = (int)((elapsedTime * 100) % 100);

            // �\���X�V�i��F02:34.56�j

            timeText.text = $"{minutes:00}:{seconds:00}.{milliseconds:00}";

        }

    }

    // �ꎞ��~�E�ĊJ�p

    public void ToggleStopwatch()

    {

        isRunning = false;

    }



}