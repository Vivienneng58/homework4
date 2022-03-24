using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1
{
    class Order
    {
        public long OrderID { get; private set; }
        public DateTime OrderTime { get; private set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; private set; }      //总价
        public List<OrderItem> OrderItemList;

        public Order()
        {
            OrderTime = DateTime.Now;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            OrderID = Convert.ToInt64(ts.TotalSeconds);     //使用时间戳作为订单号
            OrderItemList = new List<OrderItem>();
            TotalPrice = 0;
        }

        //添加明细
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach (OrderItem item in OrderItemList)
            {
                if (item.Equals(orderItem))
                {
                    throw new DataException("Error：无法添加重复的货物");
                }
            }

            OrderItemList.Add(orderItem);
            TotalPrice += orderItem.ProductPrice * orderItem.ProductAmount;
        }

        //删除明细
        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (!OrderItemList.Remove(orderItem))
            {
                throw new DataException("Error：无此订单货物");
            }

            TotalPrice -= orderItem.ProductPrice * orderItem.ProductAmount;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n");
            stringBuilder.Append($"订单号：\t{OrderID}\n");
            stringBuilder.Append($"订单时间：\t{OrderTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            stringBuilder.Append($"顾客名：\t{CustomerName}\n");
            stringBuilder.Append($"地址：\t{Address}\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("订单内容\n");
            foreach (OrderItem item in OrderItemList)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append($"{item}\n");
            }
            stringBuilder.Append("\n");
            stringBuilder.Append($"总额：\tCNY￥{TotalPrice}\n");
            stringBuilder.Append("\n");
            return stringBuilder.ToString();
        }
    }
}
