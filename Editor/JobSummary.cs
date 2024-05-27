using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace JobSummaryUtility
{
    public static class JobSummary
    {
        public static bool Enabled
        {
            get
            {
                if (!EnvironmentVariableRepository.IsGitHubActions())
                {
                    return false;
                }

                var stepSummaryPath = EnvironmentVariableRepository.GetGitHubStepSummaryPath();
                if (string.IsNullOrEmpty(stepSummaryPath))
                {
                    return false;
                }

                var dir = Path.GetDirectoryName(stepSummaryPath);
                return !string.IsNullOrEmpty(dir) && Directory.Exists(dir);
            }
        }

        public static void AppendAllText(string contents)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            File.AppendAllText(stepSummaryPath, contents);
        }

        public static async Task AppendAllTextAsync(string contents, CancellationToken cancellationToken = default)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            await File.AppendAllTextAsync(stepSummaryPath, contents, cancellationToken);
        }

        public static void AppendAllLines(IEnumerable<string> contents)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            File.AppendAllLines(stepSummaryPath, contents);
        }

        public static async Task AppendAllLinesAsync(IEnumerable<string> contents,
            CancellationToken cancellationToken = default)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            await File.AppendAllLinesAsync(stepSummaryPath, contents, cancellationToken);
        }

        [CanBeNull]
        private static string GetGitHubStepSummaryPath()
        {
            if (!EnvironmentVariableRepository.IsGitHubActions())
            {
                return null;
            }

            var stepSummaryPath = EnvironmentVariableRepository.GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return null;
            }

            var dir = Path.GetDirectoryName(stepSummaryPath);
            if (string.IsNullOrEmpty(dir))
            {
                return null;
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return stepSummaryPath;
        }
    }
}
