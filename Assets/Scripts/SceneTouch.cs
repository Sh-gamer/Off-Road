using Cinemachine;
using UnityEngine;

public class SceneTouvh : MonoBehaviour
{
    [SerializeField ] CinemachineFreeLook cineCam;
    [SerializeField] TouchField touchField;
    [SerializeField] float SensivityX;
    [SerializeField] float SensivityY;
    private void Update()
    {
        cineCam.m_XAxis.Value += touchField.TouchDist.x * 200 * SensivityX * Time.deltaTime;
        cineCam.m_YAxis.Value += touchField.TouchDist.y * SensivityY * Time.deltaTime;
    }
}
