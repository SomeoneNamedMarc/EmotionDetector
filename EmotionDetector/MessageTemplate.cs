using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace EmotionDetector
{
    public class MessageTemplate : DataTemplateSelector
    {
        public DataTemplate? RightAlignedTemplate { get; set; }
        public DataTemplate? LeftAlignedTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
            if (itemsControl != null)
            {
                // Get the index of the current item
                int index = itemsControl.ItemContainerGenerator.IndexFromContainer(container);

                // Return the left-aligned template for even indices, right-aligned for odd indices
                return index % 2 == 0 ? RightAlignedTemplate : LeftAlignedTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
