I would not do this via unit-tests -- it's the wrong place. Do this in a build/test-script. You gain more flexibility and can do a lot of more things that may be necessary.

A rough outline would be:

build
run unit tests
run integration tests
run benchmarks
upload benchmark results to results-store (commercial product e.g. "PowerBI")
check current results with previous results
upload artefacts / deploy packages
On 6. if there is a regression you can let the build fail with non-zero exit-code.
BenchmarkDotNet can export results as JSON, etc., so you can take advantage of that.

The point is how to determine if a regression occures. Espcecially on CI builds (with containers, and that like) there may be different hardware on different benchmark-runs, so the results are not 1:1 comparable, and you have to take this into account.
Personally I don't let the script fail in case of a possible regression, but it sends an information about that, so I can manually check if it's a true regression or just a cause by different hardware.

Regression is simply detected if the current results are worse than the median of the last 5 results. Of course this is a rough method, but an effective one and you can tune that to your needs.