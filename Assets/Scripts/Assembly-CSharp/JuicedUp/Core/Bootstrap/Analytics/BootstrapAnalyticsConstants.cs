namespace JuicedUp.Core.Bootstrap.Analytics
{
	public static class BootstrapAnalyticsConstants
	{
		public static class Event
		{
			public const string StageStarted = "entry_point_stage_started";

			public const string StageCompleted = "entry_point_stage_completed";

			public const string StepStarted = "entry_point_step_started";

			public const string StepCompleted = "entry_point_step_completed";

			public const string StepFailed = "entry_point_step_failed";

			public const string LoadingScreenShown = "loading_screen_shown";

			public const string LoadingScreenPhase = "loading_screen_phase";
		}

		public static class Key
		{
			public const string Stage = "stage";

			public const string Step = "step";

			public const string IsParallel = "is_parallel";

			public const string DurationMs = "duration_ms";

			public const string SequentialCount = "sequential_count";

			public const string ParallelCount = "parallel_count";

			public const string ExceptionType = "exception_type";

			public const string Phase = "phase";

			public const string ElapsedMs = "elapsed_ms";

			public const string Status = "status";

			public const string WasVsReady = "was_vs_ready";

			public const string ElapsedMsSinceHidden = "elapsed_ms_since_hidden";
		}

		public static class Phase
		{
			public const string MetaReady = "meta_ready";

			public const string VsReady = "vs_ready";

			public const string VsReadyLate = "vs_ready_late";

			public const string VsTimeout = "vs_timeout";

			public const string Hidden = "hidden";

			public const string Error = "error";
		}

		public static class PhaseStatus
		{
			public const string BeforeHidden = "before_hidden";

			public const string AfterHidden = "after_hidden";
		}
	}
}
