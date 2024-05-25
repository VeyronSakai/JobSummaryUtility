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

        public static void AppendText(string text)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            File.AppendAllText(stepSummaryPath, text);
        }

        public static async Task AppendTextAsync(string text, CancellationToken cancellationToken = default)
        {
            var stepSummaryPath = GetGitHubStepSummaryPath();
            if (string.IsNullOrEmpty(stepSummaryPath))
            {
                return;
            }

            await File.AppendAllTextAsync(stepSummaryPath, text, cancellationToken);
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