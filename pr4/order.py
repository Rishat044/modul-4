class Item:
    def __init__(self, name, price, quantity):
        self.name = name
        self.price = price
        self.quantity = quantity

class Order:
    def __init__(self):
        self.items = []
        self.payment_method = None
        self.delivery_method = None

    def add_item(self, item):
        self.items.append(item)

    def calculate_total(self, discount_calculator):
        total = sum(item.price * item.quantity for item in self.items)
        return discount_calculator.apply_discount(total)
