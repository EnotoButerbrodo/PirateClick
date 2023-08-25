using Code.Clicker.HUD;
using EnotoButebrodo;
using UnityEngine;

namespace Code.Clicker
{ 
    public class ReloadState : ValuableState
    {
        private readonly ITimersService _timersService;
        private readonly IValuableHUD _hud;
        private Timer _timer;

        public ReloadState(ValuableStateMachine context
            , ITimersService timersService
            , IValuableHUD hud) : base(context)
        {
            _timersService = timersService;
            _hud = hud;
            _timer = _timersService.GetTimer();
            
        }

        public override void Enter()
        {
            Animator.SetReloading(true);
            _hud.CoinsReloadBar.Show();
            _timer.Start(Valuable.Stats.CoinsRefreshTime);
            _timer.Ticked += OnTimerTick;
            _timer.Finished += OnTimerFinish;
        }

        private void OnTimerFinish(TimerEventArgs args)
        {
            Context.Enter(Context.HasCoinsState);
        }

        private void OnTimerTick(TimerEventArgs args)
        {
            Debug.Log(args.Percent);
            _hud.CoinsReloadBar.SetPercent(args.Percent);
        }

        public override void Exit()
        {
            Animator.SetReloading(false);
            _hud.CoinsReloadBar.Hide();
            _timer.Ticked -= OnTimerTick;
            _timer.Finished -= OnTimerFinish;
            _timer.Stop();
        }

        public override void React()
        {
            Animator.SetReloadClick();
            _hud.CoinsReloadBar.DoAttention();
        }
    }
}