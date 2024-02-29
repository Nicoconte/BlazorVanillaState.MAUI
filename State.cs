namespace BlazorVanillaState.MAUI
{
    public class State<T>
    {
        private T Value { get; set; }

        protected event Action<T> OnStateChange;

        /// <summary>
        /// Use this method to notify the state if there any change
        /// </summary>
        protected void NotifyStateChanged() => OnStateChange?.Invoke(Value);


        /// <summary>
        /// Get value from State
        /// </summary>
        /// <returns></returns>
        public T GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Set the value to state
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(T value)
        {
            Value = value;
            NotifyStateChanged();
        }

        /// <summary>
        /// Set the to state by accessing to the value itself
        /// </summary>
        /// <param name="action"></param>
        public void SetValue(Action<T> action)
        {
            action.Invoke(Value);
            NotifyStateChanged();
        }

        /// <summary>
        /// Set a initial value of the state
        /// </summary>
        /// <param name="initialState"></param>
        public void SetInitialState(T initialState)
        {
            SetValue(initialState);
        }

        /// <summary>
        /// Reset the state by setting a default value of T
        /// </summary>
        public void ClearState()
        {
            SetValue(default(T));
        }

        /// <summary>
        /// Subscribe to state changes
        /// </summary>
        /// <param name="handler"></param>
        public State<T> Subscribe(Action<T> handler)
        {
            OnStateChange += handler;

            return this;
        }

        /// <summary>
        /// Handle subscription error. It will be automatically unsubscribing
        /// </summary>
        /// <param name="handler"></param>
        public void Catch(Action<Exception> handler)
        {
            try
            {

            }
            catch (Exception e)
            {
                handler(e);
            }
        }

        /// <summary>
        /// Unsuscribe to state changes
        /// </summary>
        /// <param name="handler"></param>
        public void Unsubscribe(Action<T> handler)
        {
            OnStateChange -= handler;
        }

    }
}
