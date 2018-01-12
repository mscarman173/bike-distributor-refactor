using System;
using System.Text;

namespace BikeDistributor
{
    public class PlainTextReceiptFormatter
    {
        public string Format(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var builder = new StringBuilder();
            builder.AppendFormat("Order Receipt for {0}", order.Company);
            builder.AppendLine();

            foreach (var item in order.LineItems)
            {
                builder.AppendFormat("\t{0} x {1} = {2:C}", item.Quantity, item.Description, item.ItemTotal);
                builder.AppendLine();
            }

            builder.AppendFormat("Sub-Total: {0:C}", order.SubTotal);
            builder.AppendLine();
            builder.AppendFormat("Tax: {0:C}", order.Tax);
            builder.AppendLine();
            builder.AppendFormat("Total: {0:C}", order.Total);

            return builder.ToString();
        }
    }
}