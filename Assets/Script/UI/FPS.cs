using UnityEngine;

public class FPS : MonoBehaviour
{
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    Vector3 acceleration;
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        GUI.Label(new Rect(100, 100, 300, 20), fps.ToString("f2") + "fps", myStyle);
        GUI.Label(new Rect(70, 70, 200,50), "x:"+acceleration.x.ToString("f2")+ " y:" + acceleration.y.ToString("f2"), myStyle);

    }


    void Update()
    {
         acceleration = Input.acceleration;
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
}
