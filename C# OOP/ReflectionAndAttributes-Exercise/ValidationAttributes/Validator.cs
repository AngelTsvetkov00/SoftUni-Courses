using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var objProperties = obj.GetType().GetProperties();
            
            foreach(var property in objProperties)
            {
                var attributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                object value = property.GetValue(obj);
                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(value);

                    if(!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
