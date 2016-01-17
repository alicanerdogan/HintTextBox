using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HintTextBox
{
    public class HintTextBox : TextBox
    {
        public HintTextBox()
        {
            TextChanged += (sender, e) =>
            {
                if (String.IsNullOrEmpty(Text))
                {
                    HintVisibility = Visibility.Visible;
                }
                else
                {
                    HintVisibility = Visibility.Hidden;
                }
            };

            FocusableChanged += (sender, e) =>
            {
                if (!(IsFocused || String.IsNullOrEmpty(Text)))
                {
                    HintVisibility = Visibility.Visible;
                }
                else
                {
                    HintVisibility = Visibility.Hidden;
                }
            };
        }

        public Visibility HintVisibility
        {
            get { return (Visibility)GetValue(HintVisibilityProperty); }
            set { SetValue(HintVisibilityProperty, value); }
        }

        public static readonly DependencyProperty HintVisibilityProperty =
            DependencyProperty.Register("HintVisibility", typeof(Visibility), typeof(HintTextBox), new PropertyMetadata(Visibility.Visible));

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(HintTextBox), new PropertyMetadata(String.Empty));

        public Brush HintForeground
        {
            get { return (Brush)GetValue(HintForegroundProperty); }
            set { SetValue(HintForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HintForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register("HintForeground", typeof(Brush), typeof(HintTextBox), new PropertyMetadata(Brushes.DarkGray));

        static HintTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintTextBox), new FrameworkPropertyMetadata(typeof(HintTextBox)));
        }

    }
}
