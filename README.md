## Dynamic Proxy Benchmarks

To execute the benchmark

```
dotnet run -c release
```


Sample results
```
BenchmarkDotNet=v0.11.1, OS=macOS High Sierra 10.13.6 (17G65) [Darwin 17.7.0]
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


           Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
----------------- |----------:|----------:|----------:|-------:|---------:|
 UsingLightInject |  27.65 ns | 0.4298 ns | 0.4021 ns |   1.00 |     0.00 |
      UsingCastle |  41.57 ns | 0.8464 ns | 0.7503 ns |   1.50 |     0.03 |
       UsingLinFu | 542.42 ns | 8.5399 ns | 7.9883 ns |  19.62 |     0.39 |
```
