using System;

namespace d01_ex01
{
    public enum TState
    {
        Done,
        Wontdo,
        New
    }
    class GetState
    {
        public void AddDone(ref Task Task)
        {
            Task.State = TState.Done;
        }
        public void AddWontdo(ref Task Task)
        {
            Task.State = TState.Wontdo;
        }
        public void AddState(ref Task Task)
        {
            Task.State = TState.New;
        }
    }
}