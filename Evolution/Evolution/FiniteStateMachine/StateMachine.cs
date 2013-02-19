using Evolution.Creatures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class StateMachine
    {
        private State globalState = null;
        private State currentState = null;
        private State previousState = null;
        private Entity owner = null;

        public State PreviousState
        {
            get { return previousState; }
            set { previousState = value; }
        }

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public Entity Owner
        {
            get { return owner; }
        }

        public StateMachine(Entity owner)
        {
            this.owner = owner;
        }

        public void Update(GameTime gameTime)
        {
            if (globalState != null) globalState.Execute(owner, gameTime);
            if (currentState != null) currentState.Execute(owner, gameTime);
        }

        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                previousState = currentState;
                currentState.Exit(owner);
            }
            currentState = newState;
            currentState.Enter(owner);
        }

        public void ChangeGlobalState(State newState)
        {
            if (globalState != null)
            {
                globalState.Exit(owner);
            }
            globalState = newState;
            globalState.Enter(owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(previousState);
        }

        public bool IsInState(State state)
        {
            if (currentState.GetType() == state.GetType()) return true;
            return false;
        }
    }
}
