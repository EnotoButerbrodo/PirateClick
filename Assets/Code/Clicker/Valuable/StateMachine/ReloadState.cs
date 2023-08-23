using EnotoButebrodo;
using UnityEngine;

namespace Code.Clicker
{ 
    public class ReloadState : ValuableState
    {
        private readonly ITimersService _timersService;
        private Timer _timer;

        public ReloadState(ValuableStateMachine context
            , ITimersService timersService) : base(context)
        {
            _timersService = timersService;
            _timer = _timersService.GetTimer();
            
        }

        public override void Enter()
        {
            Animator.SetReloading(true);
            _timer.Start(Valuable.CoinsRefreshTime);
            _timer.Finished += OnTimerFinish;
        }

        private void OnTimerFinish(TimerEventArgs args)
        {
            Context.Enter(Context.HasCoinsState);
        }

        public override void Exit()
        {
            Animator.SetReloading(false);
            _timer.Finished -= OnTimerFinish;
            _timer.Stop();
        }

        public override void React()
        {
            Animator.SetReloadClick();
        }
    }
}