using System;

namespace KioskCheckoutSystem
{
    class KioskCheckoutService
    {
        private Basket _basket; 

        public KioskCheckoutService(Basket basket)
        {
            _basket = basket;
        }

        public string GetReceipt()
        {
            if (_basket == null)
            {
                return ErrorMessages.OutOfOrder;
            }
            
            var digitalReceiptFactory = new DigitalReceiptFactory(_basket);
            var digitalReceipt = digitalReceiptFactory.GenerateDigitalReceipt();

            if (digitalReceipt == null)
            {
                return ErrorMessages.OutOfOrder;
                
            }
            return digitalReceipt.ToPrintableString();
        }
        
    }
}
