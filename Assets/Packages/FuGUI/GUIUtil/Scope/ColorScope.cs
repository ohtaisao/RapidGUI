﻿using System.Collections.Generic;
using UnityEngine;


namespace FuGUI
{
    public static partial class GUIUtil
    {
        static Stack<Color> colorScopeStack = new Stack<Color>();

        public static void BeginColor(Color color)
        {
            colorScopeStack.Push(GUI.color);
            GUI.color = color;
        }

        public static void EndColor()
        {
            GUI.color = colorScopeStack.Pop();
        }


        public class ColorScope : GUI.Scope
        {
            public ColorScope(Color color) => BeginColor(color);

            protected override void CloseScope() => EndColor();
        }
    }
}