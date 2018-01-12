using System;
using System.Text;

namespace BikeDistributor
{
    public class HtmlReceiptFormatter
    {
        public string Format(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var builder = new StringBuilder();
            builder.Append("<html><body>");
            builder.AppendFormat("<h1>Order Receipt for {0}</h1>", order.Company);

            builder.Append("<ul>");
            foreach (var item in order.OrderItems)
            {
                builder.AppendFormat("<li>{0} x {1} = {2:C}</li>", item.Quantity, item.Description, item.ItemTotal);
            }
            builder.Append("</ul>");

            builder.AppendFormat("<h3>Sub-Total: {0:C}</h3>", order.SubTotal);
            builder.AppendFormat("<h3>Tax: {0:C}</h3>", order.Tax);
            builder.AppendFormat("<h2>Total: {0:C}</h2>", order.Total);
            builder.Append("</body></html>");

            return builder.ToString();
        }
    }
}