# AzureFunctionsCSharpBenchmarkDotNet

```
> dotnet build -c Release
> dotnet .\tests\FunctionAppBenchmark\bin\Release\netcoreapp3.1\FunctionAppBenchmark.dll
```

## Results

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.403
  [Host] : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|       Method |         Mean |      Error |     StdDev |
|------------- |-------------:|-----------:|-----------:|
| FastEndpoint |     2.988 ms |  0.1073 ms |  0.3044 ms |
| SlowEndpoint | 2,030.517 ms | 10.8453 ms | 10.1447 ms |

