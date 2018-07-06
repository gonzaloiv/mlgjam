using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour {

    #region Fields

    public virtual State CurrentState { get { return currentState; } }
    protected State currentState;
    private string previousState;

    #endregion

    #region Mono Behaviour

    protected void Update () {
        if (currentState)
            currentState.Play();
    }

    protected void LateUpdate () {
        if (currentState)
            currentState.LatePlay();
    }

    #endregion

    #region Public Behaviour

    public virtual State GetState<T> () where T : State {
        T state = GetComponent<T>();
        if (state == null)
            state = gameObject.AddComponent<T>();
        return state;
    }

    public virtual State GetState (string stateName) {
        State state = GetComponent(stateName) as State;
        Debug.Log(stateName);
        if (state == null)
            state = gameObject.AddComponent(Type.GetType(stateName)) as State;
        return state;
    }

    public virtual void ChangeState<T> () where T : State {
        if (currentState != null) {
            currentState.Exit();
            previousState = currentState.GetType().ToString();
        }
        currentState = GetState<T>();
        if (currentState != null)
            currentState.Enter();
    }

    public virtual void PreviousState () {
        if (string.IsNullOrEmpty(previousState))
            return;
        if (currentState != null)
            currentState.Exit();
        string state = previousState;
        previousState = currentState.GetType().ToString();
        currentState = GetState(state);
        if (currentState != null)
            currentState.Enter();
    }

    #endregion

}