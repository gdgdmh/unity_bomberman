﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mhl;

namespace Bomberman
{
    public class TouchGameController
    {
        UiTask uiTask = null;

        public TouchGameController(UiTask uiTask)
        {
            this.uiTask = uiTask;
        }

        public void Update()
        {
            uiTask.Update();
        }

        /// <summary>
        /// 方向キーが押されたか
        /// </summary>
        /// <param name="key">対象の方向キー</param>
        /// <returns>対象の方向キーが押されている間trueが返される</returns>
        public bool IsPress(GameControllerConstant.DirectionKey key)
        {
            UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            return uiTask.IsPress(key);
        }

        /// <summary>
        /// ボタンが押されたか
        /// </summary>
        /// <param name="button">対象のボタン</param>
        /// <returns>対象のボタンがtrueなら押されている</returns>
        public bool IsButtonDown(GameControllerConstant.Button button)
        {
            UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            return uiTask.IsButtonDown(button);
        }

        /// <summary>
        /// ボタンが持ち上げられたか
        /// </summary>
        /// <param name="button">対象のボタン</param>
        /// <returns>trueなら持ち上げられた</returns>
        public bool IsButtonUp(GameControllerConstant.Button button)
        {
            UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            return !uiTask.IsButtonDown(button);
        }

        /*
        /// <summary>
        /// 方向キーからUnityのKeyCodeに変換
        /// </summary>
        /// <param name="key">対象の方向キー</param>
        /// <param name="key1">UnityEngineのKeyCode</param>
        /// <param name="key2">UnityEngineのKeyCode(複数のケースあり)</param>
        private void ConvertDirectionKeyToUnityKeyCode(GameControllerConstant.DirectionKey key, out KeyCode key1, out KeyCode key2)
        {
            key1 = KeyCode.None;
            key2 = KeyCode.None;
            switch (key)
            {
                case GameControllerConstant.DirectionKey.Up:
                    key1 = KeyCode.UpArrow;
                    break;
                case GameControllerConstant.DirectionKey.Down:
                    key1 = KeyCode.DownArrow;
                    break;
                case GameControllerConstant.DirectionKey.Right:
                    key1 = KeyCode.RightArrow;
                    break;
                case GameControllerConstant.DirectionKey.Left:
                    key1 = KeyCode.LeftArrow;
                    break;
                case GameControllerConstant.DirectionKey.RightUp:
                    key1 = KeyCode.RightArrow;
                    key2 = KeyCode.UpArrow;
                    break;
                case GameControllerConstant.DirectionKey.RightDown:
                    key1 = KeyCode.RightArrow;
                    key2 = KeyCode.DownArrow;
                    break;
                case GameControllerConstant.DirectionKey.LeftUp:
                    key1 = KeyCode.LeftArrow;
                    key2 = KeyCode.UpArrow;
                    break;
                case GameControllerConstant.DirectionKey.LeftDown:
                    key1 = KeyCode.LeftArrow;
                    key2 = KeyCode.DownArrow;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ボタンからUnityのKeyCodeに変換
        /// </summary>
        /// <param name="button">対象のボタン</param>
        /// <returns>UnityEngineのキーコード</returns>
        private KeyCode ConvertButtonToUnityKeyCode(GameControllerConstant.Button button)
        {
            switch (button)
            {
                case GameControllerConstant.Button.A:
                    return KeyCode.Space;
                // A以外は今の所使用しないので割り当てなしとしています
                // 必要があれば割り当てをしてください
                case GameControllerConstant.Button.B:
                    return KeyCode.None;
                case GameControllerConstant.Button.X:
                    return KeyCode.None;
                case GameControllerConstant.Button.Y:
                    return KeyCode.None;
                default:
                    return KeyCode.None;
            }
        }
        */
    }
}
