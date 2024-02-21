using UnityEngine;
using Pcx;

public class PointSizeController : MonoBehaviour
{
    public PointCloudRenderer pointCloudRenderer; // 引用 PointCloudRenderer 组件

    public float decreaseRate = 0.00001f; // 控制点大小逐渐减小的速度
    public float minPointSize = 0.2f; // 
    public float decreaseRateWhenSmall = 0.5f; // 当点的大小小于 minPointSize 时，减小速度减半

    void Update()
    {
        // 如果 pointCloudRenderer 为空，则不执行后续操作
        if (pointCloudRenderer == null)
        {
            Debug.LogWarning("PointCloudRenderer reference is null. Ensure it is assigned in the inspector.");
            return;
        }

        // 逐渐减小点的大小
        pointCloudRenderer.pointSize -= decreaseRate * Time.deltaTime;

       
        // 当点的大小小于 minPointSize 时，减小速度减半
        if (pointCloudRenderer.pointSize < minPointSize)
        {
            decreaseRate *= decreaseRateWhenSmall;
        }

        // 确保点的大小不会小于最小值
        pointCloudRenderer.pointSize = Mathf.Max(0.00001f, pointCloudRenderer.pointSize);
    }
}
