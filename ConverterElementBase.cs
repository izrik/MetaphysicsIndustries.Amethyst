using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class ConverterElementBase : AmethystElement
    {
        public static ConverterElementBase CreateConverter(Type inputType, Type outputType)
        {
            Type constructedType = typeof(ConverterElement<,>).MakeGenericType(inputType, outputType);
            Assembly assembly = Assembly.GetExecutingAssembly();
            ConverterElementBase converter = (ConverterElementBase)assembly.CreateInstance(constructedType.FullName);
            if (converter == null)
            {
                throw new Exception("Assembly.CreateInstance returned \"null\"");
            }

            return converter;
        }

        public ConverterElementBase(Node node)
            :base(node)
        {
        }
    }
}
