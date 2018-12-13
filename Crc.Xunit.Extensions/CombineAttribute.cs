using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Crc.Xunit.Extensions
{
    public class CombineAttribute : DataAttribute
    {
        private List<object[]> _data;

        public CombineAttribute(params object[] objectsToCombine)
        {
            List<List<object>> possibleValuesByType = objectsToCombine.Select(GetAllPossibleValues).ToList();
            List<int> dataCountsByType = possibleValuesByType.Select(l => l.Count).ToList();
            int totalDataCount = dataCountsByType.Aggregate(1, (current, accumulated) => current * accumulated);
            
            List<int> repetitions = new List<int>();

            for (int i = 0; i < objectsToCombine.Length; i++)
            {
                repetitions.Add(dataCountsByType.Skip(i + 1).Aggregate(1, (current, accumulated) => current * accumulated));
            }

            List<int> restos = possibleValuesByType.Select(l => l.Count).ToList();

            _data = new List<object[]>(totalDataCount);

            for (int lineIndex = 0; lineIndex < totalDataCount; lineIndex++)
            {
                var line =  new object[objectsToCombine.Length];
                _data.Add(line);
                for (int typeIndex = 0; typeIndex < objectsToCombine.Length; typeIndex++)
                {
                    line[typeIndex] = possibleValuesByType[typeIndex][(lineIndex / repetitions[typeIndex] )% restos[typeIndex]];
                }
            }
        }

        private List<object> GetAllPossibleValues(object objectToBeCombined)
        {
            if (objectToBeCombined is Type type)
            {
                if (type.IsEnum)
                {
                    var result = new List<object>();

                    foreach (object item in Enum.GetValues(type))
                    {
                        result.Add(item);
                    }

                    return result;
                }

                if (type == typeof(bool))
                {
                    return new List<object> { false, true };
                }
            }
            else if(objectToBeCombined is IEnumerable ienumerable)
            {
                var result = new List<object>();

                foreach (object item in ienumerable)
                {
                    result.Add(item);
                }

                return result;
            }

            throw new ArgumentException($"Object to be combined {objectToBeCombined} not expected. Only type of enum, typeof(bool) and IEnumerables accepted",nameof(type));
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return _data;
        }
    }
}
