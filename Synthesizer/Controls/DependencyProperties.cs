using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
namespace Synthesizer.Controls
{
    


    partial class Knob
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(Knob),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                Changed_Value,
                Coerce_Value
            ));

        static void Changed_Value(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as Knob;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_Value(oldValue, newValue);
            }
        }


        static object Coerce_Value(DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as Knob;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_Value(ref value);


            return value;
        }

        public static readonly DependencyProperty FromProperty = DependencyProperty.Register(
            "From",
            typeof(double),
            typeof(Knob),
            new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsRender,
                Changed_From,
                Coerce_From
            ));

        static void Changed_From(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as Knob;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_From(oldValue, newValue);
            }
        }


        static object Coerce_From(DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as Knob;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_From(ref value);


            return value;
        }

        public static readonly DependencyProperty ToProperty = DependencyProperty.Register(
            "To",
            typeof(double),
            typeof(Knob),
            new FrameworkPropertyMetadata(
                100.0,
                FrameworkPropertyMetadataOptions.AffectsRender,
                Changed_To,
                Coerce_To
            ));

        static void Changed_To(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as Knob;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_To(oldValue, newValue);
            }
        }


        static object Coerce_To(DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as Knob;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_To(ref value);


            return value;
        }

      

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public Knob()
        {
            CoerceAllProperties();
            Constructed__AudioKnob();
        }
        // --------------------------------------------------------------------
        partial void Constructed__AudioKnob();
        // --------------------------------------------------------------------
        void CoerceAllProperties()
        {
            CoerceValue(ValueProperty);
            CoerceValue(FromProperty);
            CoerceValue(ToProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------


        // --------------------------------------------------------------------
        public double Value
        {
            get
            {
                return (double)GetValue(ValueProperty);
            }
            set
            {
                if (Value != value)
                {
                    SetValue(ValueProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Value(double oldValue, double newValue);
        partial void Coerce_Value(ref double coercedValue);
        // --------------------------------------------------------------------



        // --------------------------------------------------------------------
        public double From
        {
            get
            {
                return (double)GetValue(FromProperty);
            }
            set
            {
                if (From != value)
                {
                    SetValue(FromProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_From(double oldValue, double newValue);
        partial void Coerce_From(ref double coercedValue);
        // --------------------------------------------------------------------



        // --------------------------------------------------------------------
        public double To
        {
            get
            {
                return (double)GetValue(ToProperty);
            }
            set
            {
                if (To != value)
                {
                    SetValue(ToProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_To(double oldValue, double newValue);
        partial void Coerce_To(ref double coercedValue);
        // --------------------------------------------------------------------


    }

}
