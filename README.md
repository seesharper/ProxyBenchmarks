## Dynamic Proxy Benchmarks

To execute the benchmark

```
dotnet run -c release
```


Interface method without arguments
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

Interface method with value type argument

```
BenchmarkDotNet=v0.11.1, OS=macOS High Sierra 10.13.6 (17G65) [Darwin 17.7.0]
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


           Method |      Mean |     Error |   StdDev | Scaled | ScaledSD |
----------------- |----------:|----------:|---------:|-------:|---------:|
 UsingLightInject |  45.18 ns | 0.9711 ns | 2.771 ns |   1.00 |     0.00 |
      UsingCastle |  48.64 ns | 1.0095 ns | 1.572 ns |   1.08 |     0.07 |
       UsingLinFu | 680.05 ns | 7.1048 ns | 6.298 ns |  15.11 |     0.94 |
```

Interface method with reference type argument

```
BenchmarkDotNet=v0.11.1, OS=macOS High Sierra 10.13.6 (17G65) [Darwin 17.7.0]
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


           Method |      Mean |      Error |     StdDev | Scaled | ScaledSD |
----------------- |----------:|-----------:|-----------:|-------:|---------:|
 UsingLightInject |  32.44 ns |  0.1918 ns |  0.1700 ns |   1.00 |     0.00 |
      UsingCastle |  42.39 ns |  0.4456 ns |  0.3950 ns |   1.31 |     0.01 |
       UsingLinFu | 654.16 ns | 11.2917 ns | 10.5623 ns |  20.16 |     0.33 |
```
