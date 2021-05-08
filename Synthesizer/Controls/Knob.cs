using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Synthesizer.Controls
{
    public partial class Knob : FrameworkElement
    {
  
        
        readonly static Brush s_foregroundBrush = new SolidColorBrush(Color.FromRgb(0xEE, 0xEE, 0xEE));

        readonly TranslateTransform _translate = new TranslateTransform();
        readonly ScaleTransform _scale = new ScaleTransform();
        readonly RotateTransform _rotate = new RotateTransform();

        readonly SolidColorBrush _knobBrush = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22));
        readonly SolidColorBrush _knobBrushRing = new SolidColorBrush(Color.FromRgb(0x15, 0x15, 0x15));

        MouseEventHandler MouseMovedHandler;
        FrameworkElement currentRoot;

        partial void Constructed__AudioKnob()
        {
            MouseMovedHandler = MouseMoved;
        }

        double ComputeRatio()
        {
            var value = Value;
            var a = From;
            var b = To;
            var from = a.Min(b);
            var to = a.Max(b);
            var range = to - from;
            var ratio = ((value - from) / range).Clamp(0, 1);

            return ratio.IsNaN() ? 0 : ratio;
        }

        double ComputeValueFromPoint(Point pos)
        {
            var rs = RenderSize;

            var x = pos.X - rs.Width / 2.0;
            var y = pos.Y - rs.Height / 2.0;

            var angle = Math.Atan2(x, -y) * 180 / Math.PI + 180;

            var ratio = ((angle - 45) / 270).Clamp(0, 1);

            var a = From;
            var b = To;
            var from = a.Min(b);
            var to = a.Max(b);

            var range = to - from;

            var value = from + range * ratio;

            return value.IsNaN() ? a : value;
        }

        partial void Coerce_Value(ref double coercedValue)
        {
            coercedValue = coercedValue.Clamp(From, To);
        }

        partial void Changed_From(double oldValue, double newValue)
        {
            CoerceValue(ValueProperty);
        }

        partial void Changed_To(double oldValue, double newValue)
        {
            CoerceValue(ValueProperty);
        }

        static FrameworkElement FindRoot(FrameworkElement e)
        {
            if (e != null)
            {
                var p = e.Parent as FrameworkElement;
                if (p != null)
                {
                    return FindRoot(p);
                }
                else
                {
                    return e;
                }
            }
            else
            {
                return null;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            var pos = e.GetPosition(this);

            Value = ComputeValueFromPoint(pos);

            currentRoot = FindRoot(this);

            if (currentRoot != null)
            {
                currentRoot.AddHandler(MouseMoveEvent, MouseMovedHandler, true);
                
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (currentRoot != null)
            {
                currentRoot.RemoveHandler(MouseMoveEvent, MouseMovedHandler);
                currentRoot = null;
            }
        }

        void MouseMoved(object s, MouseEventArgs e)
        {
            var pos = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Value = ComputeValueFromPoint(pos);
            }
            else if (currentRoot != null)
            {
                currentRoot.RemoveHandler(MouseMoveEvent, MouseMovedHandler);
                currentRoot = null;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var rs = RenderSize;
            var width = rs.Width;
            var height = rs.Height;

            var zoom = width.Min(height) / 100.0;

            if (!zoom.IsNaN())
            {
                var ratio = ComputeRatio();
                var angle = ratio * 270 + 45;

                var origo = new Point();

                _translate.X = width / 2;
                _translate.Y = height / 2;

                _scale.ScaleX = zoom;
                _scale.ScaleY = zoom;

                _rotate.Angle = angle;
                Pen pen = new Pen(s_foregroundBrush, 10);
                Pen penThin = new Pen(s_foregroundBrush, 5);


                drawingContext.PushTransform(_translate);
                drawingContext.PushTransform(_scale);
                drawingContext.DrawEllipse(null, null, origo, 55, 55);
                drawingContext.DrawLine(pen, new Point(0, 0), new Point(0, 50));
                
              /*  drawingContext.DrawLine(penThin, origo, new Point(50, 50));*/
             
                drawingContext.DrawEllipse(_knobBrushRing, null, origo, 55, 55);
                drawingContext.DrawEllipse(_knobBrush, null, origo, 50, 50);
               /* drawingContext.DrawGeometry(_knobBrush, null, origo, 50, 50);*/

                drawingContext.PushTransform(_rotate);
                drawingContext.DrawLine(pen, new Point(0,0), new Point(0, 50));

                drawingContext.Pop();
                drawingContext.Pop();
            }

        }

    }
}
