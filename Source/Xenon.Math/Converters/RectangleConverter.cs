using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Xenon.Math.Converters
{
    /// <summary>
    /// Defines a converter for <see cref="Rectangle"/>
    /// </summary>
    public class RectangleConverter : BaseConverter
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RectangleConverter"/>
        /// </summary>
        public RectangleConverter()
        {
            Type typeFromHandle = typeof(Rectangle);
            PropertyDescriptorCollection propertyDescriptions = new PropertyDescriptorCollection(new PropertyDescriptor[]
			{
				new FieldPropertyDescriptor(typeFromHandle.GetField("X")), 
				new FieldPropertyDescriptor(typeFromHandle.GetField("Y")), 
				new FieldPropertyDescriptor(typeFromHandle.GetField("Width")), 
				new FieldPropertyDescriptor(typeFromHandle.GetField("Height"))
			});
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="destinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (destinationType == typeof(InstanceDescriptor) && value is Rectangle)
            {
                Rectangle rectangle = (Rectangle)value;
                ConstructorInfo constructor = typeof(Rectangle).GetConstructor(new Type[]
				{ typeof(int), typeof(int), typeof(int), typeof(int) });

                if (constructor != null)
                    return new InstanceDescriptor(constructor, new object[]
					{ rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var values = ConvertToValues<int>(context, culture, value);
            return values != null ? new Rectangle(values[0], values[1], values[2], values[3]) : base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"/> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary"/> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> representing the given <see cref="T:System.Collections.IDictionary"/>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues", "null not allowed");
            
            return new Rectangle((int)propertyValues["X"], (int)propertyValues["Y"], (int)propertyValues["Width"], (int)propertyValues["Height"]);
        }
    }
}
