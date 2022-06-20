using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class PurchaseEvent
    {
        private int eventId { get; }

        private string userId { set; get; }
        private string purchaseId { set; get; } // item id or dog id bought
        private string date { get; }


        public int EventId
        {
            get { return eventId; }
        }
        
        public string UserId
        {
            set { userId = value; }
            get { return userId; }
        }
        public string PurchaseId
        {
            set { purchaseId = value; }
            get { return purchaseId; }
        } 
        public string Date
        {
            get { return date; }
        }


        public PurchaseEvent(int eventId, string userId, string purchaseId)
        {
            this.eventId = eventId;
            this.userId = userId;
            this.purchaseId = purchaseId;
            this.date = DateTime.Now.ToString();

            Console.WriteLine($"Event ID   : { eventId }");
            Console.WriteLine($"User ID    : { userId }");
            Console.WriteLine($"Purchase ID: { purchaseId }");
            Console.WriteLine($"Date       : { date }");
        }

        public int getID()
        {
            return this.eventId;
        }

        public String displayPurchaseEvent()
        {
            String str = $"{this.eventId} - {this.userId} - {this.purchaseId} - {this.date}";
            return str;
        }





    }
}
