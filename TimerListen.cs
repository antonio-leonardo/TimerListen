using System;
using System.Timers;
using System.Threading;

namespace Timer
{
    /// <summary>
    /// 
    /// </summary>
    public class TimerListen
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly bool _firstConstructorUsed;

        /// <summary>
        /// 
        /// </summary>
        private readonly bool _secondConstructorUsed;

        /// <summary>
        /// 
        /// </summary>
        private readonly int _step;

        /// <summary>
        /// 
        /// </summary>
        private readonly SynchronizationContext _threadContext;

        /// <summary>
        /// 
        /// </summary>
        public readonly Action _methodToInvokeOnSteps;

        /// <summary>
        /// 
        /// </summary>
        private readonly Action _methodToSendToInterface;
        /// <summary>
        /// 
        /// </summary>
        private Timer aTimer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimerListen(int step, Action methodToInvokeOnSteps)
        {
            this._step = step;
            this._firstConstructorUsed = true;
            this._methodToInvokeOnSteps = methodToInvokeOnSteps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiContext"></param>
        public TimerListen(int step, Tuple<Action, SynchronizationContext> methodToSendToInterfaceByUiContext)
        {
            this._step = step;
            this._secondConstructorUsed = true;
            this._methodToSendToInterface = methodToSendToInterfaceByUiContext.Item1;
            this._threadContext = methodToSendToInterfaceByUiContext.Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(this._step);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (this._firstConstructorUsed)
            {
                this._methodToInvokeOnSteps.Invoke();
            }
            else if (this._secondConstructorUsed)
            {
                this._threadContext.Post(new SendOrPostCallback((o) => { this._methodToSendToInterface.Invoke(); }), null);
            }
        }
    }
}