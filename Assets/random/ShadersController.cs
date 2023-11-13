using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadersController : MonoBehaviour
{
    public int size = 256;
    public ComputeShader SimulationShader;
    public RenderTexture Result;
    // Start is called before the first frame update
    void Start()
    {
        Result = new RenderTexture(size, size, 24);
        Result.enableRandomWrite = true;
        Result.Create();

        SimulationShader.SetTexture(0, "Result", Result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        SimulationShader.Dispatch(0, Result.width / 8, Result.height / 8, 1);
        Graphics.Blit(Result, destination);
    }
}
