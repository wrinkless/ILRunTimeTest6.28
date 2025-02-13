﻿using UnityEngine;

    /// <summary>
    /// 通用单例类
    /// </summary>
    /// <typeparam name="T">要来继承的类名字</typeparam>
    public class MonoSingleton<T> : MonoBehaviour where T: MonoBehaviour 
    {
        static T m_instance;    
        public static T Instance
        {
            get 
            {
                if (m_instance == null) 
                {
                    m_instance = GameObject.FindObjectOfType<T> ();             
                    if (m_instance == null) 
                    {
                        GameObject singleton = new GameObject (typeof(T).Name);
                        m_instance = singleton.AddComponent<T> ();
                    }
                }
                return m_instance;
            }
        }  
        public virtual void Awake()
        {
            if (m_instance == null) 
            {
                m_instance = this as T;
                //DontDestroyOnLoad (this.gameObject);
            } 
            else 
            {
                Destroy (gameObject);
            }
        }
    }

