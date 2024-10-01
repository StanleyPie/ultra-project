using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int basedPoint = 150;
    public int point;
    public int softing = 300;

    public float amplitude = 1;
    public int frequency = 1;

    public Vector2 xLimits = new Vector2(0, 1);
    public int moveSpeed = 1;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }

    void DrawLine()
    {
        float xStart = this.xLimits.x;
        float endPoint = 2 * Mathf.PI;
        float xFinish = this.xLimits.y;

        this.lineRenderer.positionCount = point;
        for (int currentPoint = 0; currentPoint < point; currentPoint++)
        {
            float progress = (float)currentPoint / (point - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = (this.amplitude * Mathf.Sin((x * frequency * endPoint) + (Time.timeSinceLevelLoad * moveSpeed)));

            Vector3 originalPosition = new Vector3(x, y, 0);
            Vector3 rotatedPosition = transform.rotation * originalPosition;
            this.lineRenderer.SetPosition(currentPoint, rotatedPosition + this.transform.position);
        }
    }

    private void Update()
    {
        this.AdjustValue();
        this.DrawLine();
    }

    void AdjustValue()
    {
        float waveLength = 2 * Mathf.PI / frequency;
        this.point = Mathf.Max(this.basedPoint, Mathf.CeilToInt(Mathf.Abs(this.xLimits.y - xLimits.x) / waveLength * softing));
    }

}
