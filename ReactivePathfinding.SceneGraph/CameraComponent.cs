﻿using System;
using System.Collections.Generic;
using OpenTK;


namespace ReactivePathfinding.SceneGraph
{
    /// <summary>    
    /// Represents the position and rotation of the position from which the observer is viewing the scene
    /// </summary>
    public class CameraComponent : SceneGraphComponent
    {
        private Vector3 rotation;

        public Vector3 Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
    }
}
