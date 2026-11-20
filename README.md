# qodana-gate-trial-dotnet

A small .NET project for trying Qodana on pull requests.

The workflow `.github/workflows/quality.yml` runs the tests with coverage and then Qodana.
It keeps the Qodana results and the coverage report as artifacts of the run.

## Run the tests

```sh
dotnet test Parcel.sln
```
