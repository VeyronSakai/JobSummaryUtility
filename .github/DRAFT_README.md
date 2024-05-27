# JobSummaryUtility

JobSummaryUtility is a utility for Unity to display information in the GitHub Actions job summaries.

## How to use

Using the `JobSummaryUtility` namespace, write the following code

```cs
JobSummary.AppendAllText("Hello, World");
```

and when you run this process on GitHub Actions, you will see the following in the Job Summary.

![hello-world-test](https://github.com/VeyronSakai/JobSummaryUtility/assets/43900255/3b1bae19-782d-41e5-9acd-4b8a8caf7b8f)

JobSummaryUtility also provides a property named `JobSummary.Enabled`, which returns `false` if writing to the Job Summary is not possible, for example, in environments other than GitHub Actions.

## Setup

Unity Package Manager allows you to install as follows;

1. Open the Package Manager in the UnityEditor.
2. Select the + button in the upper left corner.
3. Select Add package from git URL.
4. Enter https://github.com/VeyronSakai/JobSummaryUtility.git#0.1 and Select Add button.

It can also be installed by downloading .unitypackage from [Releases](https://github.com/VeyronSakai/JobSummaryUtility/releases/latest).

## License

This software is released under the CC0-1.0 License.
