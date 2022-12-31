using System.Windows;
using System.Windows.Controls;

namespace PrismPractice.Views
{
    /// <summary>
    /// FontBorderTextBlock.xaml の相互作用ロジック
    /// </summary>
    public partial class FontBorderTextBlock : UserControl
    {
       
        public string Text { get; set; }

        public new string Foreground { get; set; }

        public string BorderColor { get; set; }

        public new double FontSize { get; set; }

        public new string Content { get; set; }

        public new string FontFamily { get; set; }

        
        public string EditableText
        {
            get { return (string)this.GetValue(EditableTextProperty); }
            set { this.SetValue(EditableTextProperty, value); }
        }

        public static readonly DependencyProperty EditableTextProperty =
            DependencyProperty.Register("EditableText",
                                        typeof(string),
                                        typeof(FontBorderTextBlock),
                                      new PropertyMetadata(string.Empty));

        public FontBorderTextBlock()
        {
            this.InitializeComponent();

            this.DataContext = this;
        }
    }
}
