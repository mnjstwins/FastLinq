``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|            Method | SizeOfInput | ElementToRequest |        Mean |       Error |    StdDev |  Gen 0 | Allocated |
|------------------ |------------ |----------------- |------------:|------------:|----------:|-------:|----------:|
|    **Array_FastLinq** |           **0** |                **0** |   **3.5381 ns** |   **2.3991 ns** | **0.1356 ns** |      **-** |       **0 B** |
|     Array_Optimal |           0 |                0 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |           0 |                0 |  29.7827 ns |   5.5258 ns | 0.3122 ns |      - |       0 B |
| Collection_System |           0 |                0 |  29.9250 ns |  13.3518 ns | 0.7544 ns | 0.0095 |      40 B |
| Enumerable_System |           0 |                0 |  30.1710 ns |  18.6502 ns | 1.0538 ns | 0.0114 |      48 B |
|    IList_FastLinq |           0 |                0 |   5.5206 ns |   1.4546 ns | 0.0822 ns |      - |       0 B |
|     IList_Optimal |           0 |                0 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |           0 |                0 |   8.2250 ns |   5.1932 ns | 0.2934 ns |      - |       0 B |
|     List_FastLinq |           0 |                0 |   3.5541 ns |   2.3512 ns | 0.1328 ns |      - |       0 B |
|      List_Optimal |           0 |                0 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |           0 |                0 |   6.3406 ns |   1.9321 ns | 0.1092 ns |      - |       0 B |
|    **Array_FastLinq** |           **0** |               **10** |   **3.6905 ns** |   **3.1583 ns** | **0.1784 ns** |      **-** |       **0 B** |
|     Array_Optimal |           0 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |           0 |               10 |  29.4817 ns |   9.4697 ns | 0.5351 ns |      - |       0 B |
| Collection_System |           0 |               10 |  29.8835 ns |   6.5634 ns | 0.3708 ns | 0.0095 |      40 B |
| Enumerable_System |           0 |               10 |  31.6501 ns |   8.6506 ns | 0.4888 ns | 0.0114 |      48 B |
|    IList_FastLinq |           0 |               10 |   5.7360 ns |   4.9181 ns | 0.2779 ns |      - |       0 B |
|     IList_Optimal |           0 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |           0 |               10 |   8.0300 ns |   2.1155 ns | 0.1195 ns |      - |       0 B |
|     List_FastLinq |           0 |               10 |   3.4354 ns |   1.9412 ns | 0.1097 ns |      - |       0 B |
|      List_Optimal |           0 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |           0 |               10 |   6.3200 ns |   3.8818 ns | 0.2193 ns |      - |       0 B |
|    **Array_FastLinq** |           **0** |              **100** |   **3.7722 ns** |   **8.3783 ns** | **0.4734 ns** |      **-** |       **0 B** |
|     Array_Optimal |           0 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |           0 |              100 |  29.9987 ns |   6.9621 ns | 0.3934 ns |      - |       0 B |
| Collection_System |           0 |              100 |  30.3469 ns |   9.8310 ns | 0.5555 ns | 0.0095 |      40 B |
| Enumerable_System |           0 |              100 |  29.0646 ns |  19.7291 ns | 1.1147 ns | 0.0114 |      48 B |
|    IList_FastLinq |           0 |              100 |   5.6381 ns |   4.5115 ns | 0.2549 ns |      - |       0 B |
|     IList_Optimal |           0 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |           0 |              100 |   8.1155 ns |   3.6477 ns | 0.2061 ns |      - |       0 B |
|     List_FastLinq |           0 |              100 |   3.4758 ns |   1.9637 ns | 0.1110 ns |      - |       0 B |
|      List_Optimal |           0 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |           0 |              100 |   6.4362 ns |   5.7904 ns | 0.3272 ns |      - |       0 B |
|    **Array_FastLinq** |          **10** |                **0** |   **7.2235 ns** |   **4.0196 ns** | **0.2271 ns** |      **-** |       **0 B** |
|     Array_Optimal |          10 |                0 |   0.0789 ns |   0.6622 ns | 0.0374 ns |      - |       0 B |
|      Array_System |          10 |                0 |  37.7934 ns | 120.5757 ns | 6.8128 ns |      - |       0 B |
| Collection_System |          10 |                0 |  34.9694 ns |  15.7885 ns | 0.8921 ns | 0.0095 |      40 B |
| Enumerable_System |          10 |                0 |  32.3398 ns |  18.4443 ns | 1.0421 ns | 0.0114 |      48 B |
|    IList_FastLinq |          10 |                0 |  10.4957 ns |   4.9899 ns | 0.2819 ns |      - |       0 B |
|     IList_Optimal |          10 |                0 |   3.0393 ns |   0.9154 ns | 0.0517 ns |      - |       0 B |
|      IList_System |          10 |                0 |  14.7700 ns |   5.9291 ns | 0.3350 ns |      - |       0 B |
|     List_FastLinq |          10 |                0 |   6.9856 ns |   2.1040 ns | 0.1189 ns |      - |       0 B |
|      List_Optimal |          10 |                0 |   1.0485 ns |   0.2750 ns | 0.0155 ns |      - |       0 B |
|       List_System |          10 |                0 |  10.6978 ns |   7.4344 ns | 0.4201 ns |      - |       0 B |
|    **Array_FastLinq** |          **10** |               **10** |   **3.4442 ns** |   **1.9372 ns** | **0.1095 ns** |      **-** |       **0 B** |
|     Array_Optimal |          10 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |          10 |               10 |  31.1007 ns |  13.0029 ns | 0.7347 ns |      - |       0 B |
| Collection_System |          10 |               10 | 100.4591 ns |  14.9414 ns | 0.8442 ns | 0.0094 |      40 B |
| Enumerable_System |          10 |               10 |  74.2545 ns |  65.3266 ns | 3.6911 ns | 0.0113 |      48 B |
|    IList_FastLinq |          10 |               10 |   5.3085 ns |   2.9843 ns | 0.1686 ns |      - |       0 B |
|     IList_Optimal |          10 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |          10 |               10 |   8.2414 ns |   6.6714 ns | 0.3769 ns |      - |       0 B |
|     List_FastLinq |          10 |               10 |   3.6086 ns |   2.1346 ns | 0.1206 ns |      - |       0 B |
|      List_Optimal |          10 |               10 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |          10 |               10 |   6.2772 ns |   4.0554 ns | 0.2291 ns |      - |       0 B |
|    **Array_FastLinq** |          **10** |              **100** |   **3.4527 ns** |   **2.1277 ns** | **0.1202 ns** |      **-** |       **0 B** |
|     Array_Optimal |          10 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |          10 |              100 |  31.1038 ns |  19.8008 ns | 1.1188 ns |      - |       0 B |
| Collection_System |          10 |              100 | 100.8300 ns |  45.6183 ns | 2.5775 ns | 0.0094 |      40 B |
| Enumerable_System |          10 |              100 |  72.2265 ns |  38.4710 ns | 2.1737 ns | 0.0113 |      48 B |
|    IList_FastLinq |          10 |              100 |   5.4137 ns |   1.4366 ns | 0.0812 ns |      - |       0 B |
|     IList_Optimal |          10 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |          10 |              100 |   7.9665 ns |   3.3650 ns | 0.1901 ns |      - |       0 B |
|     List_FastLinq |          10 |              100 |   3.4101 ns |   2.7653 ns | 0.1562 ns |      - |       0 B |
|      List_Optimal |          10 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |          10 |              100 |   6.3891 ns |   3.4201 ns | 0.1932 ns |      - |       0 B |
|    **Array_FastLinq** |         **100** |                **0** |   **7.0287 ns** |   **4.4491 ns** | **0.2514 ns** |      **-** |       **0 B** |
|     Array_Optimal |         100 |                0 |   0.0014 ns |   0.0429 ns | 0.0024 ns |      - |       0 B |
|      Array_System |         100 |                0 |  33.5539 ns |   4.8301 ns | 0.2729 ns |      - |       0 B |
| Collection_System |         100 |                0 |  34.2894 ns |  15.8484 ns | 0.8955 ns | 0.0095 |      40 B |
| Enumerable_System |         100 |                0 |  32.1151 ns |   6.9554 ns | 0.3930 ns | 0.0114 |      48 B |
|    IList_FastLinq |         100 |                0 |  10.3137 ns |   1.2096 ns | 0.0683 ns |      - |       0 B |
|     IList_Optimal |         100 |                0 |   2.9170 ns |   1.0567 ns | 0.0597 ns |      - |       0 B |
|      IList_System |         100 |                0 |  14.3930 ns |   5.8578 ns | 0.3310 ns |      - |       0 B |
|     List_FastLinq |         100 |                0 |   6.7456 ns |   2.6532 ns | 0.1499 ns |      - |       0 B |
|      List_Optimal |         100 |                0 |   0.8593 ns |   1.8510 ns | 0.1046 ns |      - |       0 B |
|       List_System |         100 |                0 |  10.4844 ns |   0.8205 ns | 0.0464 ns |      - |       0 B |
|    **Array_FastLinq** |         **100** |               **10** |   **7.1586 ns** |   **2.2186 ns** | **0.1254 ns** |      **-** |       **0 B** |
|     Array_Optimal |         100 |               10 |   0.0857 ns |   1.0780 ns | 0.0609 ns |      - |       0 B |
|      Array_System |         100 |               10 |  33.8674 ns |  16.9712 ns | 0.9589 ns |      - |       0 B |
| Collection_System |         100 |               10 | 106.6877 ns |  46.3110 ns | 2.6167 ns | 0.0094 |      40 B |
| Enumerable_System |         100 |               10 |  76.0155 ns |  57.0007 ns | 3.2206 ns | 0.0113 |      48 B |
|    IList_FastLinq |         100 |               10 |  10.5686 ns |   6.4015 ns | 0.3617 ns |      - |       0 B |
|     IList_Optimal |         100 |               10 |   2.9786 ns |   2.6728 ns | 0.1510 ns |      - |       0 B |
|      IList_System |         100 |               10 |  15.2886 ns |  17.1876 ns | 0.9711 ns |      - |       0 B |
|     List_FastLinq |         100 |               10 |   7.0001 ns |   2.2093 ns | 0.1248 ns |      - |       0 B |
|      List_Optimal |         100 |               10 |   1.0356 ns |   1.3893 ns | 0.0785 ns |      - |       0 B |
|       List_System |         100 |               10 |  10.4484 ns |   3.3190 ns | 0.1875 ns |      - |       0 B |
|    **Array_FastLinq** |         **100** |              **100** |   **3.3326 ns** |   **0.7724 ns** | **0.0436 ns** |      **-** |       **0 B** |
|     Array_Optimal |         100 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      Array_System |         100 |              100 |  29.7524 ns |  11.0680 ns | 0.6254 ns |      - |       0 B |
| Collection_System |         100 |              100 | 738.7249 ns | 153.6130 ns | 8.6794 ns | 0.0086 |      40 B |
| Enumerable_System |         100 |              100 | 458.2945 ns | 105.9659 ns | 5.9873 ns | 0.0110 |      48 B |
|    IList_FastLinq |         100 |              100 |   5.2588 ns |   1.4935 ns | 0.0844 ns |      - |       0 B |
|     IList_Optimal |         100 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|      IList_System |         100 |              100 |   8.5873 ns |   2.7408 ns | 0.1549 ns |      - |       0 B |
|     List_FastLinq |         100 |              100 |   3.4861 ns |   3.2840 ns | 0.1856 ns |      - |       0 B |
|      List_Optimal |         100 |              100 |          NA |          NA |        NA |    N/A |       N/A |
|       List_System |         100 |              100 |   6.5831 ns |   6.2739 ns | 0.3545 ns |      - |       0 B |

Benchmarks with issues:
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=0]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=0]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=0]
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=0, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=10]
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=10, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=100, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=100, ElementToRequest=100]
  ElementAtOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [SizeOfInput=100, ElementToRequest=100]
