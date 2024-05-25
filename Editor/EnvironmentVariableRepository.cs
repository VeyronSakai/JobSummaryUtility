using System;
using JetBrains.Annotations;

namespace JobSummaryUtility
{
    internal static class EnvironmentVariableRepository
    {
        private const string GitHubStepSummary = "GITHUB_STEP_SUMMARY";
        private const string GitHubActions = "GITHUB_ACTIONS";
        private const string True = "true";

        [CanBeNull]
        internal static string GetGitHubStepSummaryPath()
        {
            return Environment.GetEnvironmentVariable(GitHubStepSummary);
        }

        internal static bool IsGitHubActions()
        {
            return Environment.GetEnvironmentVariable(GitHubActions) == True;
        }
    }
}