using Locust.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Locust.Extensions;
using Locust.Base;
using Locust.Conversion;

namespace Locust.Mapping
{
    public class DefaultMapper : IMapper
    {
        public object Map(IDataReader reader, Type type)
        {
            var result = Activator.CreateInstance(type);

            ReflectionHelper.ForEachPublicInstanceReadableProperty(type, prop =>
            {
                if (reader.HasColumn(prop.Name))
                {
                    var value = reader[prop.Name];

                    if (value != null && !DBNull.Value.Equals(value))
                    {
                        var propType = prop.PropertyType;

                        if (propType == TypeHelper.TypeOfBool || propType == TypeHelper.TypeOfNullableBool)
                        {
                            prop.SetValue(result, SafeClrConvert.ToBoolean(value));
                        }
                        else if (propType == TypeHelper.TypeOfByte || propType == TypeHelper.TypeOfNullableByte)
                        {
                            prop.SetValue(result, SafeClrConvert.ToByte(value));
                        }
                        else if (propType == TypeHelper.TypeOfByteArray)
                        {
                            prop.SetValue(result, (byte[])value);
                        }
                        else if (propType == TypeHelper.TypeOfChar || propType == TypeHelper.TypeOfNullableChar)
                        {
                            prop.SetValue(result, SafeClrConvert.ToChar(value));
                        }
                        else if (propType == TypeHelper.TypeOfDateTime || propType == TypeHelper.TypeOfNullableDateTime)
                        {
                            prop.SetValue(result, SafeClrConvert.ToDateTime(value));
                        }
                        else if (propType == TypeHelper.TypeOfDateTimeOffset || propType == TypeHelper.TypeOfNullableDateTimeOffset)
                        {
                            prop.SetValue(result, SafeClrConvert.ToDateTime(value));
                        }
                        else if (propType == TypeHelper.TypeOfDecimal || propType == TypeHelper.TypeOfNullableDecimal)
                        {
                            prop.SetValue(result, SafeClrConvert.ToDecimal(value));
                        }
                        else if (propType == TypeHelper.TypeOfDouble || propType == TypeHelper.TypeOfNullableDouble)
                        {
                            prop.SetValue(result, SafeClrConvert.ToDouble(value));
                        }
                        else if (propType == TypeHelper.TypeOfFloat || propType == TypeHelper.TypeOfNullableFloat)
                        {
                            prop.SetValue(result, SafeClrConvert.ToSingle(value));
                        }
                        else if (propType == TypeHelper.TypeOfGuid)
                        {
                            prop.SetValue(result, new Guid(SafeClrConvert.ToString(value)));
                        }
                        else if (propType == TypeHelper.TypeOfInt16 || propType == TypeHelper.TypeOfNullableInt16)
                        {
                            prop.SetValue(result, SafeClrConvert.ToInt16(value));
                        }
                        else if (propType == TypeHelper.TypeOfInt32 || propType == TypeHelper.TypeOfNullableInt32)
                        {
                            prop.SetValue(result, SafeClrConvert.ToInt32(value));
                        }
                        else if (propType == TypeHelper.TypeOfInt64 || propType == TypeHelper.TypeOfNullableInt64)
                        {
                            prop.SetValue(result, SafeClrConvert.ToInt64(value));
                        }
                        else if (propType == TypeHelper.TypeOfSByte || propType == TypeHelper.TypeOfNullableSByte)
                        {
                            prop.SetValue(result, SafeClrConvert.ToSByte(value));
                        }
                        else if (propType == TypeHelper.TypeOfString)
                        {
                            prop.SetValue(result, SafeClrConvert.ToString(value));
                        }
                        else if (propType == TypeHelper.TypeOfTimeSpan || propType == TypeHelper.TypeOfNullableTimeSpan)
                        {
                            prop.SetValue(result, SafeClrConvert.ToDateTime(value));
                        }
                        else if (propType == TypeHelper.TypeOfUInt16 || propType == TypeHelper.TypeOfNullableUInt16)
                        {
                            prop.SetValue(result, SafeClrConvert.ToUInt16(value));
                        }
                        else if (propType == TypeHelper.TypeOfUInt32 || propType == TypeHelper.TypeOfNullableUInt32)
                        {
                            prop.SetValue(result, SafeClrConvert.ToUInt32(value));
                        }
                        else if (propType == TypeHelper.TypeOfUInt64 || propType == TypeHelper.TypeOfNullableUInt64)
                        {
                            prop.SetValue(result, SafeClrConvert.ToUInt64(value));
                        }
                    }
                }
            });

            return result;
        }
        public object Map(Type type, object source)
        {
            var result = null as object;
            var targetProps = ReflectionHelper.GetProperties(type, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (source != null)
            {
                result = Activator.CreateInstance(type);

                ReflectionHelper.ForEachPublicInstanceReadableProperty(source.GetType(), prop =>
                {
                    var targetProp = targetProps.FirstOrDefault(p => string.Compare(p.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
                    var srcValue = prop.GetValue(source);

                    if (targetProp != null && targetProp.CanWrite)
                    {
                        object value;

                        if (targetProp.PropertyType.IsNullableOrBasicType())
                        {
                            value = srcValue;

                            targetProp.SetValue(result, value);
                        }
                        else
                        {
                            if (!targetProp.PropertyType.IsEnumerable() && !targetProp.PropertyType.IsInterface)
                            {
                                value = Map(targetProp.PropertyType, srcValue);

                                targetProp.SetValue(result, value);
                            }
                            else
                            {
                                if (targetProp.PropertyType.IsEnumerable() && !targetProp.PropertyType.IsInterface)
                                {
                                    Type targetItemType;

                                    if (targetProp.PropertyType.TryGetItemType(out targetItemType))
                                    {
                                        if (targetProp.PropertyType.DescendsFrom(TypeHelper.TypeOfArray))
                                        {
                                            if (prop.PropertyType.DescendsFrom(TypeHelper.TypeOfArray))
                                            {
                                                var arrSource = srcValue as Array;

                                                if (arrSource != null)
                                                {
                                                    var arrDest = Activator.CreateInstance(targetProp.PropertyType, new object[] { arrSource.Length }) as Array;

                                                    Array.Copy(arrSource, arrDest, arrSource.Length);

                                                    targetProp.SetValue(result, arrDest);
                                                }
                                                else
                                                {
                                                    targetProp.SetValue(result, null);
                                                }
                                            }
                                            else
                                            {
                                                var sourceList = srcValue as ICollection;

                                                if (sourceList != null)
                                                {
                                                    var arrDest = Activator.CreateInstance(targetProp.PropertyType, new object[] { sourceList.Count }) as Array;
                                                    var i = 0;

                                                    foreach (var item in sourceList)
                                                    {
                                                        var targetItem = Map(targetItemType, item);
                                                        arrDest.SetValue(targetItem, i++);
                                                    }

                                                    targetProp.SetValue(result, arrDest);
                                                }
                                                else
                                                {
                                                    // last resort!

                                                    value = srcValue;

                                                    try
                                                    {
                                                        targetProp.SetValue(result, value);
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var list = Activator.CreateInstance(targetProp.PropertyType) as IList;
                                            var sourceList = srcValue as IEnumerable;

                                            if (list != null && sourceList != null)
                                            {
                                                foreach (var item in sourceList)
                                                {
                                                    var targetItem = Map(targetItemType, item);

                                                    list.Add(targetItem);
                                                }

                                                targetProp.SetValue(result, list);
                                            }
                                            else
                                            {
                                                value = srcValue;

                                                try
                                                {
                                                    targetProp.SetValue(result, value);
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        value = srcValue;

                                        try
                                        {
                                            targetProp.SetValue(result, value);
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                });
            }

            return result;
        }
        public void Copy(object source, object target)
        {
            if (source != null && target != null)
            {
                var type = target.GetType();
                var targetProps = ReflectionHelper.GetProperties(type, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                ReflectionHelper.ForEachPublicInstanceReadableProperty(source.GetType(), prop =>
                {
                    var targetProp = targetProps.FirstOrDefault(p => string.Compare(p.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
                    var srcValue = prop.GetValue(source);

                    if (targetProp != null && targetProp.CanWrite)
                    {
                        object value;

                        if (targetProp.PropertyType.IsNullableOrBasicType())
                        {
                            value = srcValue;

                            targetProp.SetValue((object)target, value);
                        }
                        else
                        {
                            if (!targetProp.PropertyType.IsEnumerable() && !targetProp.PropertyType.IsInterface)
                            {
                                value = Map(targetProp.PropertyType, srcValue);

                                targetProp.SetValue((object)target, value);
                            }
                            else
                            {
                                if (targetProp.PropertyType.IsEnumerable() && !targetProp.PropertyType.IsInterface)
                                {
                                    Type targetItemType;

                                    if (targetProp.PropertyType.TryGetItemType(out targetItemType))
                                    {
                                        if (targetProp.PropertyType.DescendsFrom(TypeHelper.TypeOfArray))
                                        {
                                            if (prop.PropertyType.DescendsFrom(TypeHelper.TypeOfArray) && srcValue != null)
                                            {
                                                var arrSource = srcValue as Array;

                                                if (arrSource != null)
                                                {
                                                    var arrDest = Activator.CreateInstance(targetProp.PropertyType, new object[] { arrSource.Length }) as Array;

                                                    Array.Copy(arrSource, arrDest, arrSource.Length);

                                                    targetProp.SetValue(target, arrDest);
                                                }
                                                else
                                                {
                                                    targetProp.SetValue(target, null);
                                                }
                                            }
                                            else
                                            {
                                                var sourceList = srcValue as ICollection;

                                                if (sourceList != null)
                                                {
                                                    var arrDest = Activator.CreateInstance(targetProp.PropertyType, new object[] { sourceList.Count }) as Array;
                                                    var i = 0;

                                                    foreach (var item in sourceList)
                                                    {
                                                        var targetItem = Map(targetItemType, item);
                                                        arrDest.SetValue(targetItem, i++);
                                                    }

                                                    targetProp.SetValue(target, arrDest);
                                                }
                                                else
                                                {
                                                    // last resort!

                                                    value = srcValue;

                                                    try
                                                    {
                                                        targetProp.SetValue(target, value);
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var list = Activator.CreateInstance(targetProp.PropertyType) as IList;
                                            var sourceList = srcValue as IEnumerable;

                                            if (list != null && sourceList != null)
                                            {
                                                foreach (var item in sourceList)
                                                {
                                                    var targetItem = Map(targetItemType, item);

                                                    list.Add(targetItem);
                                                }

                                                targetProp.SetValue((object)target, list);
                                            }
                                            else
                                            {
                                                value = srcValue;

                                                try
                                                {
                                                    targetProp.SetValue((object)target, value);
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        value = srcValue;

                                        try
                                        {
                                            targetProp.SetValue((object)target, value);
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                });
            }
        }
    }
}