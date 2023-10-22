using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField]
    LineFactory lineFactory;

    [SerializeField]
    bool Q2a, Q2b, Q2d, Q2e;

    [SerializeField]
    bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {        
        CalculateGameDimensions();
        
        if (Q2a) Question2a();
        if (Q2b) Question2b(200);
        if (Q2d) Question2d();
        if (Q2e) Question2e(200);
        if (Q3a) Question3a();
        if (Q3b) Question3b();
        if (Q3c) Question3c();
        if (projection) Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2;
        GameWidth = Camera.main.aspect * GameHeight;
        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(3,-1); // Position of starting point. Vector2.zero is equivalent to new Vector2(0,0)
        endPt = new Vector2(1, 2); // Position of the ending point of the line yes
        // Use line factory to get line to draw
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true); // Enable drawing yayy
        Vector2 vec2 = endPt - startPt; // Get direction vector from start to end point
        Debug.Log($"Magnitude = {vec2.magnitude}");
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector2 startPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );
            Vector2 endPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            Vector3.zero,
            new Vector3(5, 5, 0),
            Color.red,
            604);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var direction = new Vector3(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(-maxY, maxY)
                );

            DebugExtension.DebugArrow(
                Vector3.zero,
                direction,
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        // Create dah vectors
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;

        // Draw dah vectors
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2")); // Your code here.ToString("F2"));
    }

    public void Question3b()
    {
        // More vectors yay
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;
        
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        
    }

    public void Question3c() { }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}