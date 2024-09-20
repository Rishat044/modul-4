from order import Order, Item
from payment import CreditCardPayment
from delivery import CourierDelivery
from notification import EmailNotification
from discount import DiscountCalculator, PercentageDiscount

def main():

    order = Order()
    order.add_item(Item("Товар 1", 500, 2))
    order.add_item(Item("Товар 2", 200, 1))

    order.payment_method = CreditCardPayment()
    order.delivery_method = CourierDelivery()

    discount_calculator = DiscountCalculator()
    discount_calculator.add_discount_rule(PercentageDiscount(10))  # 10% скидка
    total = order.calculate_total(discount_calculator)


    order.payment_method.process_payment(total)

    order.delivery_method.deliver_order(order)

    notification = EmailNotification()
    notification.send_notification("Ваш заказ был успешно оформлен.")

if __name__ == "__main__":
    main()
