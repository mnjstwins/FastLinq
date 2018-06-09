﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using System.Collections.ObjectModel;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;

    /*
        Pays performance in enumeration and a few bytes in the write case to save memory by lazy-loading the list
        
             Method | EnumerateAfterwards | InputSize |        Mean |      Error |     StdDev |  Gen 0 | Allocated |
------------------- |-------------------- |---------- |------------:|-----------:|-----------:|-------:|----------:|
     Array_FastLinq |               False |         0 |    21.79 ns |   8.983 ns |  0.5076 ns | 0.0152 |      64 B |
      Array_Optimal |               False |         0 |    54.93 ns |   6.379 ns |  0.3604 ns | 0.0094 |      40 B |
       Array_System |               False |         0 |    57.60 ns |  19.277 ns |  1.0892 ns | 0.0095 |      40 B |

 Collection_Optimal |               False |         0 |    28.88 ns |   3.603 ns |  0.2036 ns | 0.0095 |      40 B |
  Collection_System |               False |         0 |    30.91 ns |   4.708 ns |  0.2660 ns | 0.0095 |      40 B |

 Enumerable_Optimal |               False |         0 |    54.39 ns |  12.117 ns |  0.6846 ns | 0.0209 |      88 B |
  Enumerable_System |               False |         0 |    54.30 ns |  15.051 ns |  0.8504 ns | 0.0209 |      88 B |

     IList_FastLinq |               False |         0 |    20.32 ns |   4.854 ns |  0.2742 ns | 0.0152 |      64 B |
      IList_Optimal |               False |         0 |    30.61 ns |   6.288 ns |  0.3553 ns | 0.0095 |      40 B |
       IList_System |               False |         0 |    32.84 ns |   7.666 ns |  0.4332 ns | 0.0095 |      40 B |

      List_FastLinq |               False |         0 |    20.60 ns |   1.838 ns |  0.1038 ns | 0.0152 |      64 B |
       List_Optimal |               False |         0 |    29.15 ns |  19.316 ns |  1.0914 ns | 0.0095 |      40 B |
        List_System |               False |         0 |    35.09 ns | 109.988 ns |  6.2145 ns | 0.0095 |      40 B |


     Array_FastLinq |               False |         2 |    29.44 ns |  47.210 ns |  2.6675 ns | 0.0152 |      64 B |
      Array_Optimal |               False |         2 |   130.78 ns |  75.306 ns |  4.2549 ns | 0.0169 |      72 B |
       Array_System |               False |         2 |   130.54 ns | 130.152 ns |  7.3538 ns | 0.0169 |      72 B |

 Collection_Optimal |               False |         2 |    51.22 ns |  75.280 ns |  4.2535 ns | 0.0170 |      72 B |
  Collection_System |               False |         2 |    61.30 ns |  70.472 ns |  3.9818 ns | 0.0170 |      72 B |

 Enumerable_Optimal |               False |         2 |   147.43 ns | 165.930 ns |  9.3754 ns | 0.0303 |     128 B |
  Enumerable_System |               False |         2 |   108.96 ns |  75.320 ns |  4.2557 ns | 0.0303 |     128 B |

     IList_FastLinq |               False |         2 |    23.95 ns |  34.047 ns |  1.9237 ns | 0.0152 |      64 B |
      IList_Optimal |               False |         2 |    55.25 ns | 105.905 ns |  5.9838 ns | 0.0170 |      72 B |
       IList_System |               False |         2 |    57.65 ns |  92.915 ns |  5.2499 ns | 0.0170 |      72 B |

      List_FastLinq |               False |         2 |    23.37 ns |   5.350 ns |  0.3023 ns | 0.0152 |      64 B |
       List_Optimal |               False |         2 |    50.54 ns |  46.879 ns |  2.6488 ns | 0.0171 |      72 B |
        List_System |               False |         2 |    50.37 ns |  15.156 ns |  0.8563 ns | 0.0171 |      72 B |


     Array_FastLinq |               False |        10 |    24.54 ns |  14.395 ns |  0.8133 ns | 0.0152 |      64 B |
      Array_Optimal |               False |        10 |    99.73 ns |  39.058 ns |  2.2068 ns | 0.0247 |     104 B |
       Array_System |               False |        10 |   102.33 ns |  24.777 ns |  1.4000 ns | 0.0247 |     104 B |

 Collection_Optimal |               False |        10 |    55.22 ns |  41.083 ns |  2.3213 ns | 0.0247 |     104 B |
  Collection_System |               False |        10 |    59.34 ns |  27.955 ns |  1.5795 ns | 0.0247 |     104 B |

 Enumerable_Optimal |               False |        10 |   279.72 ns | 243.052 ns | 13.7329 ns | 0.0644 |     272 B |
  Enumerable_System |               False |        10 |   262.50 ns | 191.728 ns | 10.8330 ns | 0.0644 |     272 B |

     IList_FastLinq |               False |        10 |    22.86 ns |   9.366 ns |  0.5292 ns | 0.0152 |      64 B |
      IList_Optimal |               False |        10 |    69.69 ns |  32.159 ns |  1.8171 ns | 0.0247 |     104 B |
       IList_System |               False |        10 |    66.18 ns |  34.273 ns |  1.9365 ns | 0.0247 |     104 B |

      List_FastLinq |               False |        10 |    24.54 ns |  28.037 ns |  1.5842 ns | 0.0152 |      64 B |
       List_Optimal |               False |        10 |    66.60 ns |  19.439 ns |  1.0983 ns | 0.0247 |     104 B |
        List_System |               False |        10 |    62.57 ns |   7.125 ns |  0.4026 ns | 0.0247 |     104 B |


     Array_FastLinq |               False |       100 |    23.78 ns |   3.517 ns |  0.1987 ns | 0.0152 |      64 B |
      Array_Optimal |               False |       100 |   134.38 ns | 107.434 ns |  6.0702 ns | 0.1104 |     464 B |
       Array_System |               False |       100 |   136.60 ns |  29.124 ns |  1.6455 ns | 0.1104 |     464 B |

 Collection_Optimal |               False |       100 |   255.38 ns |  24.998 ns |  1.4124 ns | 0.1101 |     464 B |
  Collection_System |               False |       100 |   256.32 ns |  71.287 ns |  4.0278 ns | 0.1101 |     464 B |

 Enumerable_Optimal |               False |       100 | 1,402.97 ns | 626.055 ns | 35.3733 ns | 0.2937 |    1240 B |
  Enumerable_System |               False |       100 | 1,541.22 ns | 968.601 ns | 54.7278 ns | 0.2937 |    1240 B |

     IList_FastLinq |               False |       100 |    23.98 ns |   2.925 ns |  0.1653 ns | 0.0152 |      64 B |
      IList_Optimal |               False |       100 |    98.99 ns |  40.194 ns |  2.2710 ns | 0.1105 |     464 B |
       IList_System |               False |       100 |   104.07 ns |  39.475 ns |  2.2304 ns | 0.1105 |     464 B |

      List_FastLinq |               False |       100 |    25.94 ns |  15.985 ns |  0.9032 ns | 0.0152 |      64 B |
       List_Optimal |               False |       100 |    96.53 ns |  99.968 ns |  5.6484 ns | 0.1105 |     464 B |
        List_System |               False |       100 |   102.61 ns |  66.290 ns |  3.7455 ns | 0.1105 |     464 B |


     Array_FastLinq |                True |         0 |    78.73 ns |  41.204 ns |  2.3281 ns | 0.0151 |      64 B |
      Array_Optimal |                True |         0 |    68.74 ns |  21.789 ns |  1.2311 ns | 0.0094 |      40 B |
       Array_System |                True |         0 |    77.02 ns |  80.143 ns |  4.5282 ns | 0.0094 |      40 B |

 Collection_Optimal |                True |         0 |    37.21 ns |  36.442 ns |  2.0590 ns | 0.0095 |      40 B |
  Collection_System |                True |         0 |    38.37 ns |  32.983 ns |  1.8636 ns | 0.0095 |      40 B |

 Enumerable_Optimal |                True |         0 |    62.59 ns |  46.974 ns |  2.6541 ns | 0.0209 |      88 B |
  Enumerable_System |                True |         0 |    68.39 ns |  28.139 ns |  1.5899 ns | 0.0209 |      88 B |

     IList_FastLinq |                True |         0 |    88.29 ns |  34.238 ns |  1.9345 ns | 0.0247 |     104 B | Base cost of the memory + slower enumeration in Lazy
      IList_Optimal |                True |         0 |    38.96 ns |   8.389 ns |  0.4740 ns | 0.0095 |      40 B |
       IList_System |                True |         0 |    42.04 ns |  33.745 ns |  1.9067 ns | 0.0095 |      40 B |

      List_FastLinq |                True |         0 |    81.26 ns |  46.411 ns |  2.6223 ns | 0.0247 |     104 B |
       List_Optimal |                True |         0 |    36.25 ns |   5.694 ns |  0.3217 ns | 0.0095 |      40 B |
        List_System |                True |         0 |    38.19 ns |  18.471 ns |  1.0436 ns | 0.0095 |      40 B |


     Array_FastLinq |                True |         2 |    89.53 ns |  27.389 ns |  1.5475 ns | 0.0228 |      96 B |
      Array_Optimal |                True |         2 |    94.09 ns |  54.614 ns |  3.0858 ns | 0.0170 |      72 B |
       Array_System |                True |         2 |    94.65 ns |  60.070 ns |  3.3941 ns | 0.0170 |      72 B |

 Collection_Optimal |                True |         2 |    49.01 ns |  21.014 ns |  1.1874 ns | 0.0171 |      72 B |
  Collection_System |                True |         2 |    52.25 ns |   2.458 ns |  0.1389 ns | 0.0171 |      72 B |

 Enumerable_Optimal |                True |         2 |   114.98 ns |  75.673 ns |  4.2757 ns | 0.0303 |     128 B |
  Enumerable_System |                True |         2 |   108.53 ns |  18.391 ns |  1.0391 ns | 0.0304 |     128 B |

     IList_FastLinq |                True |         2 |   103.86 ns |  44.670 ns |  2.5240 ns | 0.0247 |     104 B |
      IList_Optimal |                True |         2 |    65.34 ns |  44.344 ns |  2.5055 ns | 0.0170 |      72 B |
       IList_System |                True |         2 |    65.32 ns |  53.516 ns |  3.0238 ns | 0.0170 |      72 B |

      List_FastLinq |                True |         2 |   107.94 ns |  77.605 ns |  4.3848 ns | 0.0247 |     104 B |
       List_Optimal |                True |         2 |    64.08 ns |  24.313 ns |  1.3737 ns | 0.0170 |      72 B |
        List_System |                True |         2 |    60.03 ns |  38.790 ns |  2.1917 ns | 0.0170 |      72 B |


     Array_FastLinq |                True |        10 |   161.94 ns |  64.998 ns |  3.6725 ns | 0.0226 |      96 B | Memory broke even - curious that enumeration is faster for system IList than Array
      Array_Optimal |                True |        10 |   134.24 ns | 105.122 ns |  5.9396 ns | 0.0246 |     104 B |
       Array_System |                True |        10 |   168.12 ns | 295.322 ns | 16.6862 ns | 0.0246 |     104 B |

 Collection_Optimal |                True |        10 |    98.83 ns | 134.471 ns |  7.5979 ns | 0.0247 |     104 B |
  Collection_System |                True |        10 |   115.42 ns |  55.946 ns |  3.1611 ns | 0.0247 |     104 B |

 Enumerable_Optimal |                True |        10 |   382.65 ns | 340.621 ns | 19.2457 ns | 0.0644 |     272 B |
  Enumerable_System |                True |        10 |   386.46 ns | 257.124 ns | 14.5280 ns | 0.0644 |     272 B |

     IList_FastLinq |                True |        10 |   211.52 ns | 124.283 ns |  7.0222 ns | 0.0246 |     104 B |
      IList_Optimal |                True |        10 |    99.31 ns |  26.652 ns |  1.5059 ns | 0.0247 |     104 B |
       IList_System |                True |        10 |    99.26 ns |  77.677 ns |  4.3889 ns | 0.0247 |     104 B |

      List_FastLinq |                True |        10 |   200.41 ns |  50.793 ns |  2.8699 ns | 0.0246 |     104 B |
       List_Optimal |                True |        10 |   115.86 ns |  39.915 ns |  2.2553 ns | 0.0247 |     104 B |
        List_System |                True |        10 |   106.04 ns | 159.378 ns |  9.0051 ns | 0.0247 |     104 B |


     Array_FastLinq |                True |       100 |   988.59 ns | 641.590 ns | 36.2510 ns | 0.0210 |      96 B |
      Array_Optimal |                True |       100 |   452.69 ns | 470.760 ns | 26.5988 ns | 0.1097 |     464 B |
       Array_System |                True |       100 |   460.43 ns | 316.618 ns | 17.8895 ns | 0.1101 |     464 B |

 Collection_Optimal |                True |       100 |   568.04 ns | 530.618 ns | 29.9809 ns | 0.1097 |     464 B |
  Collection_System |                True |       100 |   631.54 ns | 904.161 ns | 51.0868 ns | 0.1097 |     464 B |

 Enumerable_Optimal |                True |       100 | 1,648.27 ns | 228.526 ns | 12.9122 ns | 0.2937 |    1240 B |
  Enumerable_System |                True |       100 | 1,620.19 ns | 590.413 ns | 33.3594 ns | 0.2937 |    1240 B |

     IList_FastLinq |                True |       100 | 1,003.81 ns | 375.754 ns | 21.2308 ns | 0.0229 |     104 B |
      IList_Optimal |                True |       100 |   348.34 ns | 246.965 ns | 13.9540 ns | 0.1101 |     464 B |
       IList_System |                True |       100 |   379.79 ns | 223.462 ns | 12.6260 ns | 0.1101 |     464 B |

      List_FastLinq |                True |       100 | 1,047.84 ns | 837.727 ns | 47.3331 ns | 0.0229 |     104 B |
       List_Optimal |                True |       100 |   376.72 ns | 170.576 ns |  9.6379 ns | 0.1101 |     464 B |
        List_System |                True |       100 |   344.93 ns | 111.085 ns |  6.2765 ns | 0.1101 |     464 B |
     */


    /// <summary>
    /// Enumerable.ToList optimizes ICollection and EMPTY, and falls back to Enumerable
    /// </summary>
    public class ToLazyListBenchmark
    {
        [Params(true, false)] public bool EnumerateAfterwards;

        [Params(0, 2, 10, 100)] public int InputSize;

        private int[] array;
        private List<int> list;
        // HashSet is ICollection, not IList, and has a struct enumerator
        private HashSet<int> collection;
        // ReadOnlyCollection is IList, but has an object enumerator
        private ReadOnlyCollection<int> ilist;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, this.InputSize);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.ToList(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.ToList(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.ToList(this.ilist);
            
            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.ToList(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.ToList(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.ToLazyList(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.ilist);
            
            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        // Not implemented by FastLinq for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.ToLazyList(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            // TODO: Optimal should be lazy also
            // System is pretty close to optimal for IEnumerable, good enough for now
            Enumerable_System();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }
        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }
    }
}
