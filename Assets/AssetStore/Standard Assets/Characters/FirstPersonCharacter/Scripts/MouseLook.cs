using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    /// <summary>
    /// last edit: 4/2/2021 
    /// right click mouse disables the cursor.
    /// left click mouse does not have any role anymore.
    /// clicking inventory buttons were causing cursor error (reappearing) That is solved by disabling left click.
    /// 
    /// InternalLockUpdate() overloaded for panels. If any panel is activa then cursor is active.
    /// </summary>

    [Serializable]
    public class MouseLook
    {
        
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;
        public bool lockCursor = true;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
        private bool m_cursorIsLocked = true;

        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }


        public void LookRotation(Transform character, Transform camera)
        {
            float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }

            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if(!lockCursor)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
        }

        public void UpdateCursorLock(GameObject uiPanel,GameObject inventoryPanel, GameObject bagPanel) //added line at 1/16/2021 4PM Overloaded
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate(uiPanel,inventoryPanel,bagPanel);
        }

        private void InternalLockUpdate()
        {            

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            /*else if (Input.GetKeyUp(KeyCode.I))
            {
                m_cursorIsLocked = false;
            }*/
            //else if (Input.GetMouseButtonUp(0))
            //{
            //    m_cursorIsLocked = true;
            //}

            if (Input.GetMouseButtonUp(1))
            {
                m_cursorIsLocked = true;
            }


                if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        private void InternalLockUpdate(GameObject uiPanel, GameObject inventoryPanel, GameObject bagPanel) //added line at 1/16/2021 4PM Overloaded
        {
            if (inventoryPanel.activeSelf || bagPanel.activeSelf || uiPanel.activeSelf)//added line at 1/2/21 8PM
            {
                m_cursorIsLocked = false;
            }

            /*if (!inventoryPanel.activeSelf)
            {                
                m_cursorIsLocked = true;
            }*/

            /*if (uiPanel.activeSelf)//added line at 
            {
                m_cursorIsLocked = false;
            }*/

            /*if(!uiPanel.activeSelf)
            {
                m_cursorIsLocked = true;
            }*/

            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            //else if(Input.GetMouseButtonUp(0))
            //{
            //    m_cursorIsLocked = true;
            //}
            if (Input.GetMouseButtonDown(1))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
