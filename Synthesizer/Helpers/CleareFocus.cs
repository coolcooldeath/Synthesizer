using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Synthesizer.Helpers
{
    class ClearFocusBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
            => AssociatedObject.MouseDown += AssociatedObject_MouseDown;

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
            => Keyboard.ClearFocus();

        protected override void OnDetaching()
            => AssociatedObject.MouseDown -= AssociatedObject_MouseDown;
    }
}
