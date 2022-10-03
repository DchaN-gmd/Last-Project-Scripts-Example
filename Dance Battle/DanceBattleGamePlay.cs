using TMPro;
using UnityEngine;
using LoadSystems;
using PlayerSystemDDX;
using System.Collections;
using WebCamSystem.Processing;

namespace DanceBattle
{
    public class DanceBattleGamePlay : GamePlay<DanceBattlePlayer, AnimatedPanel>
    {
        [Header("Controllers")]
        [SerializeField] private LoadSystem _loadSystem;
        [SerializeField] private FillProgressBarMoutionProcessor[] _moutionProcessors;

        [Header("Parameters")]
        [SerializeField] private float _delayBeforeLoadNextScene;

        [Header("UI")]
        [SerializeField] private TMP_Text _leftTeamName;
        [SerializeField] private TMP_Text _rightTeamName;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _leftPlayer.PlayerWinning += OnPlayerWinning;
            _rightPlayer.PlayerWinning += OnPlayerWinning;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _leftPlayer.PlayerWinning -= OnPlayerWinning;
            _rightPlayer.PlayerWinning -= OnPlayerWinning;
        }

        protected override void OnLevelFinished()
        {
            base.OnLevelFinished();
            ShowFinish();
        }

        private void Start()
        {
            if (PlayerNames.IsInitialized)
            {
                _leftTeamName.text = PlayerNames.Names[0].GetLocalizedString();
                _rightTeamName.text = PlayerNames.Names[1].GetLocalizedString();
            }
            ShowPrepare();
        }

        private void OnPlayerWinning(DanceBattlePlayer player)
        {
            foreach (var moutionProcessor in _moutionProcessors)
            {
                moutionProcessor.enabled = false;
            }

            RaisePlayerScore(player);
            SaveScore();
            FinishRound();
            NextRound();
        }

    }
}
