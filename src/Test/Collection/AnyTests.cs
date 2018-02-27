﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void WhenAny()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };
            Assert.IsTrue(collection.Any());
        }

        [TestMethod]
        public void WhenNone()
        {
            ICollection<int> collection = new int[] { };
            Assert.IsFalse(collection.Any());
        }

        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;
            new Action(
                    () => collection.Any())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class CollectionCompareTestUtilTests
    {
        [TestMethod]
        public void List()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new List<int> { 1, 2, 3 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void OneItemList()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new List<int> { 1 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void EmptyList()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new int[] { },
                new List<int> { },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void Array()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArray()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new[] { 1},
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArray()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new int[] { },
                new int[] { },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
    }

    [TestClass]
    public class DefaultIfEmptyTests
    {
        [TestMethod]
        public void NotEmpty()
        {
            ICollection<int> notEmpty = new[] { 1 };
            
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(notEmpty),
                FastLinq.DefaultIfEmpty(notEmpty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyObject()
        {
            ICollection<object> empty = new object[] { };
            
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyValueType()
        {
            ICollection<int> empty = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void MutationsDoNotAffectReturnValue()
        {
            ICollection<int> empty = new int[] { };
            var defaultIfEmpty = empty.DefaultIfEmpty();

            if (defaultIfEmpty.IsReadOnly)
            {
                Assert.Inconclusive("Cannot test mutation because the return type is read only, preventing mutations - implicitly this test passes as in the absence of the ability to mutate, side effects of mutation are impossible");
            }
            
            // Mutate
            defaultIfEmpty.Clear();
            Assert.AreEqual(0, defaultIfEmpty.Count);

            // Get default again
            var second = empty.DefaultIfEmpty();
            Assert.AreEqual(1, second.Count, "The result should not be affected by previous operations");
        }
        
        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;
            new Action(
                () => collection.DefaultIfEmpty())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ToArrayTests
    {
        [TestMethod]
        public void NominalCase()
        {
            var input = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.ToArray(input),
                FastLinq.ToArray(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void NoItems()
        {
            ICollection<int> collection = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.ToArray(collection),
                FastLinq.ToArray(collection),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;
            new Action(
                    () => collection.ToArray())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class EnumerableWithCountTests
    {
        // Tested via other methods
        // TODO: Should likely test explicitly
    }

    [TestClass]
    public class SkipTests
    {
        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;

            new Action(
                    () => collection.Skip(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 1),
                FastLinq.Skip(collection, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAll()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 3),
                FastLinq.Skip(collection, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipMoreThanExist()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 50),
                FastLinq.Skip(collection, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNegative()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, -1),
                FastLinq.Skip(collection, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNone()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 0),
                FastLinq.Skip(collection, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
    }


    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;

            new Action(
                    () => collection.Take(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 1),
                FastLinq.Take(collection, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeAll()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 3),
                FastLinq.Take(collection, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeMoreThanExist()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 50),
                FastLinq.Take(collection, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNegative()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, -1),
                FastLinq.Take(collection, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNone()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 0),
                FastLinq.Take(collection, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
    }

    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void NominalCase()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstLarger()
        {
            var first = new int[] { 1, 2, 3, 4, 5, 6 };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondLarger()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { 4, 5, 6, 7, 8, 9 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstEmpty()
        {
            var first = new int[] { };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondEmpty()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void BothEmpty()
        {
            var first = new int[] { };
            var second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstNull()
        {
            ICollection<int> first = null;
            ICollection<int> second = new int[] { };
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void SecondNull()
        {
            ICollection<int> first = new int[] { };
            ICollection<int> second = null;
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void BothNull()
        {
            ICollection<int> first = null;
            ICollection<int> second = null;
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void ProjectionNull()
        {
            ICollection<int> first = new int[] { };
            ICollection<int> second = new int[] { };
            Func<int, int, object> projection = null;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => null;

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            ICollection<int> input = new int[] { };
            Func<int, string> projection =
                i => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            ICollection<int> input = null;
            Func<int, string> projection =
                i => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class SelectWithIndexTests
    {
        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (item, index) => item.ToString() + index.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (i, _) => null;

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            ICollection<int> input = new int[] { };
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            ICollection<int> input = null;
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> input = new[] { 1, 2, 3 };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Empty()
        {
            ICollection<int> input = new int[] { };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Duplicates()
        {
            ICollection<int> input = new[] { 1, 1, 2 };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Null()
        {
            ICollection<int> input = null;

            new Action(
                    () => FastLinq.Reverse(input))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void NominalCase()
        {
            ICollection<int> first = new[] { 1, 2, 3 };
            ICollection<int> second = new[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);

        }

        [TestMethod]
        public void Duplicates()
        {
            ICollection<int> first = new[] { 1, 2, 3 };
            ICollection<int> second = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstEmpty()
        {
            ICollection<int> first = new int[] { };
            ICollection<int> second = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondEmpty()
        {
            ICollection<int> first = new[] { 1, 2, 3 };
            ICollection<int> second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void BothEmpty()
        {
            ICollection<int> first = new int[] { };
            ICollection<int> second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void FirstNull()
        {
            ICollection<int> first = null;
            ICollection<int> second = new int[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void SecondNull()
        {
            ICollection<int> first = new int[] { 1, 2, 3 }; 
            ICollection<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void BothNull()
        {
            ICollection<int> first = null;
            ICollection<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}